using Microsoft.AspNetCore.Mvc;

namespace DocumentApiExample.Controllers
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentsController : ControllerBase
    {
        [HttpGet("{documentId:int}")]
        public IActionResult GetDocumentById(
            [FromRoute] int documentId)
        {
            var doc = Data.Documents.FirstOrDefault
                (x => x.Id == documentId);

            if (doc is null)
                return NotFound(doc);

            return Ok(doc);
        }

        //[HttpGet("{uniqueId}")]
        //public IActionResult GetDocumentByUniqueId(
        //    [FromRoute] Guid uniqueId)
        //{
        //    var doc = Data.Documents.FirstOrDefault
        //        (x => x.UniqueId == uniqueId);

        //    if (doc is null)
        //        return NotFound(doc);

        //    return Ok(doc);
        //}

        [HttpGet("u/{uniqueId}")]
        public IActionResult GetDocumentByUniqueId(
            [FromRoute] string uniqueId)
        {
            var doc = Data.Documents.FirstOrDefault
                (x => x.UniqueId == Guid.Parse(uniqueId));

            if (doc is null)
                return NotFound(doc);

            return Ok(doc);
        }

        [HttpGet("{tag:string}/{numbers:int}")]
        public IActionResult GetDocumentByIdAndTag(
            [FromRoute] string tag, [FromRoute] int numbers)
        {
            var docs = Data.Documents.Where
                (x => x.Tag == tag);

            if (docs.Count() == 0 )
                return NotFound(docs);

            return Ok(docs.Take(numbers));
        }
    }

    public class DocumentResponse
    {
        public int Id { get; set; }

        public Guid UniqueId { get; set; }

        public string Text { get; set; }

        public string Tag { get; set; }
    }

    public class Data
    {
        public static readonly DocumentResponse[] Documents = new[]
        {
            new DocumentResponse() { Id = 1,
                UniqueId = Guid.NewGuid(),
                Text = "Dokumentacja ASP.NET Core", Tag = "A"},
            new DocumentResponse() { Id = 2,
                UniqueId = Guid.NewGuid(),
                Text = "Cały StackOverflow", Tag = "B"},
            new DocumentResponse() { Id = 3,
                UniqueId = Guid.NewGuid(),
                Text = "Licznik Wyświetleń", Tag = "A"},
            new DocumentResponse() { Id = 4,
                UniqueId = Guid.NewGuid(),
                Text = "Dokumentacja Jiry", Tag = "B"},
        };
    }
}