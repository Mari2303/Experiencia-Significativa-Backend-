using AutoMapper;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Service.Interfaces;

namespace API.Controllers
{
    public class UserController : BaseModelController<User, UserDTO, UserRequest>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IBaseModelService<User, UserDTO, UserRequest> baseService, IUserService service, IMapper mapper) : base(baseService, mapper)
        {
            _userService = service;
            _mapper = mapper;
        }
    }
}
