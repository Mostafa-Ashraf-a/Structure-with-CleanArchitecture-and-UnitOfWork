using MostafaProject.Application.Interfaces;
using MostafaProject.Domain.Entities;
using MostafaProject.infrastructure.Interface;
using MostafaProject.Infrastructure.Interface;
using Shared.Enums;
namespace MostafaProject.Application.Implementation
{
    public class BookService : BaseService, IBookService
    {
        IGenericRepository<Book> _repo;
        public BookService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repo = _unitOfWork.GetRepository<Book>();
        }

        public async Task<KeyValuePair<ResponseEnum, object>> CreateNewDemo(Book add)
        {
            try
            {
                if (add == null)
                    return new(ResponseEnum.Error, "Empty Data");
                await _repo.AddAsync(add);
                var result = await _unitOfWork.SaveChangesAsync();
                return result > 0 ? new KeyValuePair<ResponseEnum, object>(ResponseEnum.OK, add) :
                    new(ResponseEnum.Error, "Data Not Saved");
            }
            catch (Exception ex)
            {
               return new(ResponseEnum.Error, HandleException(ex));
            }
            
        }

        public async Task<KeyValuePair<ResponseEnum, object>> Remove(Guid id)
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

        public async Task<KeyValuePair<ResponseEnum, object>> GetAll()
        {
            try
            {
                return new KeyValuePair<ResponseEnum, object>(ResponseEnum.OK, await _repo.GetAllAsync());
            }
            catch (Exception ex)
            {
                return new KeyValuePair<ResponseEnum, object>(ResponseEnum.Error, $"Error = {ex.Message}\n{ex.InnerException}");
                
            }
            
        }
    }
}
