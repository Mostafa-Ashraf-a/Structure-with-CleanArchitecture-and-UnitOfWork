using MostafaProject.Infrastructure.Interface;
namespace MostafaProject.Application.Implementation
{
    public class BaseService
    {
        public IUnitOfWork _unitOfWork { get; }

        //protected readonly ICurrentUser _currentUser;
        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        protected string HandleException(Exception ex)
        {
            return $"Exception:{ex.Message}\n{ex?.InnerException}";
        }

    }
}
