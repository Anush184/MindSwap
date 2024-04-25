using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Commands.ChangePostApproval
{
    public class ChangePostApprovalCommandValidator: AbstractValidator<ChangePostApprovalCommand>
    {
        public ChangePostApprovalCommandValidator()
        {
            RuleFor(p => p.Approved)
                .NotNull()
                .WithMessage("Approval status can not be null");
        }
    }
}
