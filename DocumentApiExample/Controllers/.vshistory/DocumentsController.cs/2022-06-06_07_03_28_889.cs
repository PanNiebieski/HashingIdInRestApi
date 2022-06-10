using Microsoft.AspNetCore.Mvc;

namespace DocumentApiExample.Controllers
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentsController : ControllerBase
    {
        [HttpGet("{documentId}")]
        public IActionResult GetDocumentById(
            [FromRoute] int documentId)
        {
            var doc = Data.Documents.FirstOrDefault
                (x => x.Id == documentId);

            if (doc is null)
                return NotFound(doc);

            return Ok(doc);
        }

        [HttpGet("{documentId}")]
        public IActionResult GetDocumentByIdAndTag(
            [FromRoute] int documentId)
        {
            var doc = Data.Documents.FirstOrDefault
                (x => x.Id == documentId);

            if (doc is null)
                return NotFound(doc);

            return Ok(doc);
        }
    }

    public class DocumentResponse
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Tag { get; set; }
    }

    public class Data
    {
        public static readonly DocumentResponse[] Documents = new[]
        {
            new DocumentResponse() { Id = 1,
                Text = "Dokumentacja ASP.NET Core"},
            new DocumentResponse() { Id = 2,
                Text = "Cały StackOverflow"},

        };
    }
}