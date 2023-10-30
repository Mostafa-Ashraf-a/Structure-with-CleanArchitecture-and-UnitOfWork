using MostafaProject.Domain.Dtos.Demo;
using Shared.Enums;

namespace MostafaProject.Application.Interfaces
{
    public interface IDemoService
    {
        Task<KeyValuePair<ResponseEnum, object>> CreateNewDemo(AddDemoDto add);
        //Task<KeyValuePair<ResponseEnum, PaginationResponse<GetJobOrderIndexDto>>> GetAllJobOrders(JopFilterDto filter);
        //Task<KeyValuePair<ResponseEnum, EditJobOrderDto>> GetJobOrderById(string id);
        //Task<KeyValuePair<ResponseEnum, object>> EditJobOrderById(Guid jobOrderId, EditJobOrderDto editJobOrder, int? endDateByDays);
        Task<KeyValuePair<ResponseEnum, object>> Delete(Guid id);
    }
}
