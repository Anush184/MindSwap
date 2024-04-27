using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MindSwap.Api.Models
{
    public class CustomProblemDetails: ProblemDetails
    {
       public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
