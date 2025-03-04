using AutoMapper;
using commander.Data;
using commander.Dtos;
using commander.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text.Json;

namespace commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IRateRepo _repository;
        private readonly IMapper _mapper;

        public RateController(IRateRepo rateRepo, IMapper mapper)
        {
            _repository = rateRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Rate>> GetAllRates()
        {
            var rates = _repository.GetAllRates();

            return rates != null ? Ok(_mapper.Map<IEnumerable<RateReadDto>>(rates)) : NotFound();

        }

        [HttpGet("{id}")]
        public ActionResult<RateReadDto> GetRateById(int id)
        {
            var rateItem = _repository.GetRateById(id);
            return rateItem != null ? Ok(_mapper.Map<RateReadDto>(rateItem)) : NotFound();
        }



        [HttpGet("Sum{id}/{fromDate}/{toDate}")]
        public ActionResult<int> GetSumByPhoneId(int id, string fromDate, string toDate)
        {
            var sum = _repository
                .GetAllRates()
                .Where(x => x.PhoneId == id && x.Date >= DateTime.Parse(fromDate) && x.Date <= DateTime.Parse(toDate))
                .Sum(x => x.Amount);
            return Ok(sum);
        }
        [HttpGet("Transfer {fromPhoneId} / {toPhoneId} / {amount}")]
        public ActionResult<(int , int)> TransferFromSum(int fromPhoneId, int toPhoneId, Decimal amount)
        {
            int amountkeeper = (int)amount;
            amount = -amount;
            var sumFromPhone = _repository.GetAllRates().Where(x => x.PhoneId == fromPhoneId);
            foreach (var item in sumFromPhone)
            {
                int itemkeeper = (int)item.Amount;
                item.Amount += amount;
                if (item.Amount >= 0)
                {
                    break;
                }
                else
                {
                    item.Amount = 0;
                    amount += itemkeeper;
                }
            }

            decimal sumFrom = sumFromPhone.Sum(x => x.Amount);





            var sumToPhone = _repository.GetAllRates().Where(x => x.PhoneId == toPhoneId);
            foreach (var item in sumToPhone)
            {
                int itemkeeper = (int)item.Amount;
                item.Amount += amountkeeper;
                if (item.Amount<=100)
                {
                    break;
                }
                else
                {
                    amountkeeper = amountkeeper - 100 + itemkeeper;
                    item.Amount = 100;
                    
                }
            }
            decimal sumTo = sumToPhone.Sum(x => x.Amount);

            return Ok($"{(int)sumFrom} , {(int)sumTo}");
        }
        /// amount keeper -100 +item

    }

}
