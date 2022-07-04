using API.ApplicationServices;
using API.Entities;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        #region Fields

        private readonly IBasketService _service;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public BasketController(IBasketService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        [HttpGet("{clientBasketId}")]
        public async Task<ActionResult<BasketDto>> Get(string clientBasketId)
        {
            Basket basket = await _service.GetBasket(clientBasketId);
            BasketDto result = _mapper.Map<BasketDto>(basket);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BasketItemToAddDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(modelState: ModelState);

            await _service.AddItemToBasket(dto);
            return Ok();
        }

        [HttpPost("Increase")]
        public async Task<ActionResult> Increase([FromBody] OperationalBasketItemDto dto)
        {
            if (dto.ProductId <= 0)
                return BadRequest("Input Id Is Not Valid");

            await _service.Increase(dto.ClientBasketId, dto.ProductId);
            return Ok();
        }

        [HttpPost("Decrease")]
        public async Task<ActionResult> Decrease([FromBody] OperationalBasketItemDto dto)
        {
            if (dto.ProductId <= 0)
                return BadRequest("Input Id Is Not Valid");

            await _service.Decrease(dto.ClientBasketId, dto.ProductId);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] BasketItemToRemoveDto dto)
        {
            if (dto.BasketItemId <= 0)
                return BadRequest("Input Id Is Not Valid");

            await _service.RemoveItemFromBasket(dto.ClientBasketId, dto.BasketItemId);
            return Ok();
        }

        #endregion
    }
}
