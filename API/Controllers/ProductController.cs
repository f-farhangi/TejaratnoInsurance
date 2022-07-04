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
    public class ProductController : ControllerBase
    {
        #region Fields

        private readonly IProductService _service;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var entity = await _service.GetProducts();
            var dto = _mapper.Map<IEnumerable<ProductDto>>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(long id)
        {
            var entity = await _service.GetProduct(id);
            var dto = _mapper.Map<ProductDto>(entity);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Post([FromBody] ProductForInsertDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(modelState: ModelState);

            var product = _mapper.Map<Product>(dto);
            await _service.InsertProduct(product);

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Put([FromBody] ProductForUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(modelState: ModelState);

            var product = await _service.GetProduct(dto.Id);
            _mapper.Map(dto, product);

            await _service.UpdateProduct(product);

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            if (id <= 0)
                return BadRequest("Input Id Is Not Valid");

            await _service.DeleteProduct(id);
            return Ok();
        }

        #endregion
    }
}
