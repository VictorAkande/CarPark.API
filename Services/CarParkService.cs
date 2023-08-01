using CarPark.API.ApplicationContext;
using CarPark.API.DTO;
using CarPark.API.Helper;
using CarPark.API.IServices;
using CarPark.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CarPark.API.Services
{
    public class CarParkService : ICarPArk
    {
        private readonly AppDbContext _dbContext;

        public CarParkService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApiResponse> CalculateTicketCost(CalculateTicketRequest calculateTicketRequest)
        {
            try
			{

                if (!DateTime.TryParse(calculateTicketRequest.entryTime, out DateTime entry) ||
                    !DateTime.TryParse(calculateTicketRequest.exitTime, out DateTime exit))
                {
                   
                    var response = new ApiResponse
                    {
                        StatusCode = 400,
                        Data = "Invalid date/time format for entryTime or exitTime."
                    };
                    return response;
                }

                if (entry >= exit)
                {
                    var response = new ApiResponse
                    {
                        StatusCode = 400,
                        Data = "Entry time must be before exit time"
                    };
                    return response;
                }

                TimeSpan parkingDuration = exit - entry;
                int totalCost = _dbContext.ParkingRules.Select(r => r.EntranceFee).FirstOrDefault();

                if (parkingDuration.TotalHours >= 1)
                {
                    totalCost += _dbContext.ParkingRules.Select(r => r.FirstHourCost).FirstOrDefault();

                    double additionalHours = Math.Ceiling(parkingDuration.TotalHours - 1);
                    totalCost += (int)additionalHours * _dbContext.ParkingRules.Select(r => r.SuccessiveHourCost).FirstOrDefault();
                }

                ParkingTicket ticket = new ParkingTicket
                {
                    EntryTime = entry,
                    ExitTime = exit,
                    TotalCost = totalCost
                };

                _dbContext.ParkingTickets.Add(ticket);
                var savedata = _dbContext.SaveChanges();


                if (savedata > 0)
                {
                    var response = new ApiResponse
                    {
                        StatusCode = 200,
                        Data = totalCost
                    };
                    return response;
                }
                else
                {
                    var response = new ApiResponse
                    {
                        StatusCode = 500,
                        Data = "Internal Server Error"
                    };
                    return response;
                }
            }
			catch (Exception ex)
			{
                var response = new ApiResponse
                {
                    StatusCode = 500,
                    Data = ex.StackTrace
                };
                return response;
            }
        }

        public async Task<ApiResponse> GetTicketsByDate(DateTime date)
        {
            try
            {

                List<ParkingTicket> parkingTickets = _dbContext.ParkingTickets
                    .Where(ticket => ticket.EntryTime.Date == date.Date)
                    .ToList();

                var response = new ApiResponse
                {
                    StatusCode = 200,
                    Data = parkingTickets
                };
                return response;
            }
            catch (Exception ex)
            {
                var response = new ApiResponse
                {
                    StatusCode = 500,
                    Data = ex.StackTrace
                };
                return response;
            }
        }
    }
}
