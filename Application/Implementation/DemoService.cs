using AutoMapper;
using MostafaProject.Application.Interfaces;
using MostafaProject.Domain.Dtos.Demo;
using MostafaProject.Domain.Entities;
using MostafaProject.infrastructure.Interface;
using MostafaProject.Infrastructure.Interface;
using Shared.Enums;

namespace MostafaProject.Application.Implementation
{
    public class DemoService : BaseService<Demo>, IDemoService
    {
        public DemoService(IUnitOfWork unitOfWork, IGenericRepository<Demo> repo, IMapper mapper) : base(unitOfWork, repo, mapper)
        {
        }

        public async Task<KeyValuePair<ResponseEnum, object>> CreateNewDemo(AddDemoDto add)
        {
            try
            {
                if (add == null)
                    return new(ResponseEnum.Error, "Empty Data");
                var data = _mapper.Map<Demo>(add);
                await _repo.AddAsync(data);
                var result = await _unitOfWork.SaveChangesAsync();
                return result > 0 ? new KeyValuePair<ResponseEnum, object>(ResponseEnum.OK, data) :
                    new(ResponseEnum.Error, "Data Not Saved");
            }
            catch (Exception ex)
            {
               return new(ResponseEnum.Error, HandleException(ex));
            }
            
        }

        public async Task<KeyValuePair<ResponseEnum, object>> Delete(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return new(ResponseEnum.Error, "ID IS EMPTY");

                await _repo.DeleteAsync(id);
                var result = await _unitOfWork.SaveChangesAsync();

                return result > 0 ? new(ResponseEnum.OK, "Deleted successfully") :
                    new(ResponseEnum.Error, "Not Saved");
            }
            catch (Exception ex)
            {
                return new(ResponseEnum.Error, HandleException(ex));
            }
        }
    }
}
