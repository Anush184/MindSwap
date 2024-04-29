using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindSwap.Application.Features.PostFeature.Commands.CancelPost;
using MindSwap.Application.Features.PostFeature.Commands.ChangePostApproval;
using MindSwap.Application.Features.PostFeature.Commands.CreatePost;
using MindSwap.Application.Features.PostFeature.Commands.DeletePost;
using MindSwap.Application.Features.PostFeature.Commands.UpdatePost;
using MindSwap.Application.Features.PostFeature.Queries.GetAllPosts;
using MindSwap.Application.Features.PostFeature.Queries.GetPostDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MindSwap.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<PostController>
        [HttpGet]
        public async Task<ActionResult<List<PostDto>>> Get(bool isLoggedInUser = false)
        {
            var posts = await _mediator.Send(new GetPostsQuery());
            return Ok(posts);
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDetailsDto>> Get(int id)
        {
            var post = await _mediator.Send(new GetPostDetailsQuery {
                Id = id});
            return Ok(post);
        }

        // POST api/<PostController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post(CreatePostCommand post)
        {
            var response = await _mediator.Send(post);
            return CreatedAtAction(nameof(Get),new { id = response });
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdatePostCommand post)
        {
            await _mediator.Send(post);
            return NoContent();
        }

        //PUT api/<PostController>/CancelPost/
        [HttpPut]
        [Route("CancelPost")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult> CancelPost(CancelPostCommand cancelPost)
        {
            await _mediator.Send(cancelPost);
            return NoContent();
        }

        //PUT api/<PostController>/UpdateApproval/
        [HttpPut]
        [Route("UpdateApproval")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult> UpdateApproval(ChangePostApprovalCommand updateApprovalPost)
        {
            await _mediator.Send(updateApprovalPost);
            return NoContent();
        }


        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeletePostCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
