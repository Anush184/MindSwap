using MediatR;
using Microsoft.AspNetCore.Mvc;
using MindSwap.Application.Features.CommentFeature.Commands.CancelComment;
using MindSwap.Application.Features.CommentFeature.Commands.ChangeCommentApproval;
using MindSwap.Application.Features.CommentFeature.Commands.CreateComment;
using MindSwap.Application.Features.CommentFeature.Commands.DeleteComment;
using MindSwap.Application.Features.CommentFeature.Commands.UpdateComment;
using MindSwap.Application.Features.CommentFeature.Queries.GetAllComments;
using MindSwap.Application.Features.CommentFeature.Queries.GetCommentDetails;
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
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<CommentController>
        [HttpGet]
        public async Task<ActionResult<List<CommentDto>>> Get()
        {
            var comments = await _mediator.Send(new GetCommentsQuery());
            return Ok(comments);
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDetailsDto>> Get(int id)
        {
            var comment = await _mediator.Send(new GetCommentDetailsQuery
            {
                Id = id
            });
            return Ok(comment);
        }

        // POST api/<CommentController>
        [HttpPost]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post(CreateCommentCommand comment)
        {
            var response = await _mediator.Send(comment);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateCommentCommand comment)
        {
            await _mediator.Send(comment);
            return NoContent();
        }

        //PUT api/<CommentController>/CancelComment/
        [HttpPut]
        [Route("CancelComment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult> CancelComment(CancelCommentCommand cancelComment)
        {
            await _mediator.Send(cancelComment);
            return NoContent();

        }

        //PUT api/<CommentController>/UpdateApproval/
        [HttpPut]
        [Route("UpdateApproval")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult> UpdateApproval(ChangeCommentApprovalCommand updateApprovalComment)
        {
            await _mediator.Send(updateApprovalComment);
            return NoContent();
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCommentCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
