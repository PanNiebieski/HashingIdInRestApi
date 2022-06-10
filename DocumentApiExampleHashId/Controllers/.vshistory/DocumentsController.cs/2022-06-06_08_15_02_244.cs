using HashidsNet;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DocumentApiExample.Controllers
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentsController : ControllerBase
    {
        private readonly IHashids _hashids;

        public DocumentsController(IHashids hashids)
        {
            _hashids = hashids;
        }


        [HttpGet("{documentId}")]
        public IActionResult GetDocumentById(
            [FromRoute] string documentId)
        {
            var rawId = _hashids.Decode(documentId);
            if (rawId.Length == 0)
                return NotFound();

            var doc = Data.Documents.FirstOrDefault
                (x => x.Id == rawId[0]);

            if (doc is null)
                return NotFound(doc);

            return Ok(doc);
        }

        [HttpGet("{uniqueId}")]
        public IActionResult GetDocumentByUniqueId(
            [FromRoute] string uniqueId)
        {
            var hexstringId = _hashids.DecodeHex(uniqueId);
            if (hexstringId.Length == 0)
                return NotFound();

            var stringId = UnConvertToHexString(hexstringId);
            Guid guid;
            if (Guid.TryParse(stringId, out guid))
                return NotFound();

            var doc = Data.Documents.FirstOrDefault
                (x => x.UniqueId == guid);

            if (doc is null)
                return NotFound(doc);

            return Ok(doc);
        }

        [HttpGet("{hex}")]
        public IActionResult GetDocumentByIdAndTag(
            [FromRoute] string hex)
        {
            var hexstring = _hashids.DecodeHex(hex);
            if (hexstring.Length == 0)
                return NotFound();

            var stringId = UnConvertToHexString(hexstring);
            Guid guid;
            if (Guid.TryParse(stringId, out guid))
                return NotFound();


            var docs = Data.Documents.Where
                (x => x.Tag == tag);

            if (docs.Count() == 0)
                return NotFound(docs);

            return Ok(docs.Take(numbers));
        }

        string ConvertToHexString(string value)
        {
            Byte[] stringBytes = Encoding.UTF8.GetBytes(value);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }

        string UnConvertToHexString(string value)
        {
            int numberChars = value.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(value.Substring(i, 2), 16);
            }
            return Encoding.UTF8.GetString(bytes);
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