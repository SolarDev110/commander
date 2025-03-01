using AutoMapper;
using commander.Data;
using commander.Dtos;
using commander.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace commander.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneRepo _repository;
        private readonly IMapper _mapper;

        public PhoneController(IPhoneRepo phonerepo , IMapper mapper)
        {
            _repository = phonerepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Phone>> GetAllPhones()
        {
            var phones = _repository.GetAppPhones();

              return phones != null ? Ok(_mapper.Map<IEnumerable< PhoneReadDto>>(phones)) : NotFound();
           
          
        }

        [HttpGet("{id}")]
        public ActionResult<PhoneReadDto> GetPhoneByID(int id)
        {
            var phoneItem = _repository.GetPhoneById(id);
            return phoneItem != null ? Ok(_mapper.Map<PhoneReadDto>(phoneItem)) : NotFound();
        }

      



    }

}
