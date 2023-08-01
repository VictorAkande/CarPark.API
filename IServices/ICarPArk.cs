using CarPark.API.DTO;
using CarPark.API.Helper;

namespace CarPark.API.IServices
{
    public interface ICarPArk
    {
        Task<ApiResponse> CalculateTicketCost(CalculateTicketRequest calculateTicketRequest);
        Task<ApiResponse> GetTicketsByDate(DateTime date);
    }
}
