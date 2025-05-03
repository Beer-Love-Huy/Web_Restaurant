using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace MenuAPI.Infrastructure.Middleware
{
    public class ExtendedProblemDetails : ProblemDetails
    {
        public string Timestamp { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IDictionary<string, string[]> Errors { get; set; }
    }
}
