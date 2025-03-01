using AutoMapper;
using commander.Data;
using commander.Dtos;
using commander.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace commander.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IRateRepo _repository;
        private readonly IMapper _mapper;

        public RateController(IRateRepo rateRepo , IMapper mapper)
        {
            _repository = rateRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Rate>> GetAllRates()
        {
            var rates = _repository.GetAllRates();

            return rates != null ? Ok(_mapper.Map<IEnumerable< RateReadDto>>(rates)) : NotFound();
         
        }

        [HttpGet("{id}")]
        public ActionResult<RateReadDto> GetRateById(int id)
        {
            var rateItem = _repository.GetRateById(id);
            return rateItem != null ? Ok(_mapper.Map<RateReadDto>(rateItem)) : NotFound();
        }





    }

}
