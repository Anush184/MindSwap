using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindSwap.Application.Features.CategoryFeature.Commands.CreateCategory;
using MindSwap.Application.Features.CategoryFeature.Commands.DeleteCategory;
using MindSwap.Application.Features.CategoryFeature.Commands.UpdateCategory;
using MindSwap.Application.Features.CategoryFeature.Queries.GetAllCategories;
using MindSwap.Application.Features.CategoryFeature.Queries.GetCategoryDetails;
using MindSwap.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MindSwap.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<List<CategoryDto>> Get()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());
            return categories;
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDetailsDto>> Get(int id)
        {
            var category = await _mediator.Send(new GetCategoryDetailsQuery(id));
            return Ok(category);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateCategoryCommand category)
        {
            var response = await _mediator.Send(category);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateCategoryCommand category)
        {
            await _mediator.Send(category);
            return NoContent();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
