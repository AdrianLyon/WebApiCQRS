using CQRSPractice.Infrastructure.Commands;
using CQRSPractice.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSPractice.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ResponseCache(Duration = 20)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            return await _mediator.Send(new GetAllCategoryQuery());
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration = 20)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var query = new GetCategoryByIdQuery(id);
            var category = await _mediator.Send(query);
            if (category == null) return NotFound();
            return category;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryDto>> Post(CreateCategoryCommand command)
        {
            var category = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDto>> Put(int id, UpdateCategoryCommand command)
        {
            if (id != command.Id) return BadRequest();
            var category = await _mediator.Send(command);
            if (category == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryDto>> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id));
            if (!result) return NotFound();
            return NoContent();
        }
    }
}