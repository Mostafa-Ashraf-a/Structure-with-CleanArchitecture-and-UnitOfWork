using MostafaProject.Domain.Entities;
using Shared.Enums;

namespace MostafaProject.Application.Interfaces
{
    public interface IBookService
    {
        Task<KeyValuePair<ResponseEnum, object>> CreateNewDemo(Book add);
        Task<KeyValuePair<ResponseEnum, object>> GetAll();
        //Task<KeyValuePair<ResponseEnum, PaginationResponse<GetJobOrderIndexDto>>> GetAllJobOrders(JopFilterDto filter);
        //Task<KeyValuePair<ResponseEnum, EditJobOrderDto>> GetJobOrderById(string id);
        //Task<KeyValuePair<ResponseEnum, object>> EditJobOrderById(Guid jobOrderId, EditJobOrderDto editJobOrder, int? endDateByDays);
        Task<KeyValuePair<ResponseEnum, object>> Remove(Guid id);
    }
}
