using AutoMapper;
using MostafaProject.Domain;
using MostafaProject.Domain.Entities;
using MostafaProject.infrastructure.Interface;
using MostafaProject.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostafaProject.Application.Implementation
{
    public class BaseService<TEntity> where TEntity : BaseEntity
    {
        public IMapper _mapper { get; }
        public IUnitOfWork _unitOfWork { get; }
        public IGenericRepository<TEntity> _repo { get; }

        //protected readonly ICurrentUser _currentUser;
        public BaseService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repo, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
            _mapper = mapper;
        }
        protected string HandleException(Exception ex)
        {
            return $"Exception:{ex.Message}\n{ex?.InnerException}";
        }

    }
}
