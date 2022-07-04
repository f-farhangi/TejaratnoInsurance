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
    public class CategoryController : ControllerBase
    {
        #region Fields

        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public CategoryController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            var entity = await _service.GetCategories();
            var dto = _mapper.Map<IEnumerable<CategoryDto>>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(long id)
        {
            var entity = await _service.GetCategory(id);
            var dto = _mapper.Map<CategoryDto>(entity);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Post([FromBody] CategoryForInsertDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(modelState: ModelState);

            var category = _mapper.Map<Category>(dto);
            await _service.InsertCategory(category);

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> Put([FromBody] CategoryForUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(modelState: ModelState);

            var category = await _service.GetCategory(dto.Id);
            _mapper.Map(dto, category);

            await _service.UpdateCategory(category);

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            if (id <= 0)
                return BadRequest("Input Id Is Not Valid");

            await _service.DeleteCategory(id);
            return Ok();

        }

        #endregion
    }
}
