using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindSwap.Application.Features.PostFeature.Commands.CreatePost;
using MindSwap.Application.Features.PostFeature.Queries.GetPostDetails;
using MindSwap.Application.Features.UserFeature.Commands.CreateUser;

namespace MindSwap.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginPageController : Controller
    {
        private readonly IMediator _mediator;

        public LoginPageController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // // GET
        // public IActionResult Index()
        // {
        //     return View();
        // }
        //
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailsDto>> Get(int id)
        {
            var post = await _mediator.Send(new GetUserDetailsQuery {
                Id = id});
            return Ok(post);
        }
        
        // POST api/<PostController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post(CreateUserCommand user)
        {
            var response = await _mediator.Send(user);
            return CreatedAtAction(nameof(Get),new { id = response });
        }
    }
}