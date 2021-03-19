using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Electronic.API.Persistence
{
    public abstract class BaseController : Controller
    {
        protected readonly IElectronicRepository _electronicRepository;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        protected BaseController(IElectronicRepository electronicRepository
            , IMapper mapper, IUnitOfWork unitOfWork)
        {
            _electronicRepository = electronicRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}
