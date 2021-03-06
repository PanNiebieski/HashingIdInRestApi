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
                UniqueId = new Guid("8611a2bb-2fdf-4102-8a33-09c2ddd9718d"),
                Text = "Dokumentacja ASP.NET Core", Tag = "A"},
            new DocumentResponse() { Id = 2,
                UniqueId = new Guid("cf7ad0ca-b7cf-4f3f-9942-ceaa69194c76"),
                Text = "Cały StackOverflow", Tag = "B"},
            new DocumentResponse() { Id = 3,
                UniqueId = new Guid("b3ee95a4-bfd8-4ac9-bffb-261775f7d448"),
                Text = "Licznik Wyświetleń", Tag = "A"},
            new DocumentResponse() { Id = 4,
                UniqueId = new Guid("3a715c4e-c31e-436d-ad69-5ddad0bc4dc9"),
                Text = "Dokumentacja Jiry", Tag = "B"},
        };
    }
}