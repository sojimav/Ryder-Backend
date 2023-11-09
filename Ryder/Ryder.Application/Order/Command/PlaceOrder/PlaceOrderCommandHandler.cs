using AspNetCoreHero.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ryder.Application.Common.Hubs;
using Ryder.Domain.Context;
using Ryder.Domain.Entities;
using Ryder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Serilog;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Crypto.Agreement;
using System.Text.RegularExpressions;

namespace Ryder.Application.Order.Command.PlaceOrder
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, IResult<Guid>>
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly ILogger<PlaceOrderCommandHandler> _logger;
      

        public PlaceOrderCommandHandler(ApplicationContext context, UserManager<AppUser> userManager,
            IHubContext<NotificationHub> notificationHub, ILogger<PlaceOrderCommandHandler> logger)
        {
            _context = context;
            _userManager = userManager;
            _notificationHub = notificationHub;
            _logger = logger;
        }



		public async Task<IResult<Guid>> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var currentUser = await _userManager.FindByIdAsync(request.AppUserId.ToString());

                if (currentUser == null)
                {
                    return Result<Guid>.Fail("User not found");
                }

                var order = new Domain.Entities.Order
                {
                    Id = Guid.NewGuid(),
                    PickUpLocation = new Address
                    {
                        City = request.PickUpLocation.City,
                        State = request.PickUpLocation.State,
                        PostCode = request.PickUpLocation.PostCode,
                        Longitude = request.PickUpLocation.Longitude,
                        Latitude = request.PickUpLocation.Latitude,
                        Country = request.PickUpLocation.Country,
                    },
                    DropOffLocation = new Address
                    {
                        City = request.PickUpLocation.City,
                        State = request.PickUpLocation.State,
                        PostCode = request.PickUpLocation.PostCode,
                        Longitude = request.PickUpLocation.Longitude,
                        Latitude = request.PickUpLocation.Latitude,
                        Country = request.PickUpLocation.Country,
                    },
                    PickUpPhoneNumber = request.PickUpPhoneNumber,
                    PackageDescription = request.PackageDescription,
                    ReferenceNumber = request.ReferenceNumber,
                    Amount = request.Amount,
                    RiderId = Guid.Empty,
                    AppUserId = currentUser.Id,
                    Status = OrderStatus.OrderPlaced
                };



                var availableRiders = _context.Riders.Where(row => row.AvailabilityStatus == RiderAvailabilityStatus.Available).ToList();

                foreach (var rider in availableRiders)
                {
					await _notificationHub.Clients.All.SendAsync("IncomingRequest", rider.Id.ToString(), "You have an incoming request.", cancellationToken: cancellationToken);
				}


                await _notificationHub.Clients.All.SendAsync("IncomingRequest", "You have an incoming request.", cancellationToken: cancellationToken);


                await _context.Orders.AddAsync(order, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                    return Result<Guid>.Success(order.Id, "Order placed successfully");
            }
            catch (Exception)
            {
                return Result<Guid>.Fail("Order not placed");
            }
        }
    }
}
