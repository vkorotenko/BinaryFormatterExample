using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace BinaryFormatterExample.Controllers
{
    /// <summary>
    /// add to project &lt;EnableUnsafeBinaryFormatterSerialization&gt;true&lt;/EnableUnsafeBinaryFormatterSerialization&gt;
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BinaryDataController : ControllerBase
    {


        private readonly ILogger<BinaryDataController> _logger;

        public BinaryDataController(ILogger<BinaryDataController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<FileContentResult> Get()
        {
            var data = GetSampleData();
            IFormatter formatter = new BinaryFormatter();
            await using var ms = new MemoryStream();
            formatter.Serialize(ms, data);
            ms.Seek(0, SeekOrigin.Begin);
            return new FileContentResult(ms.GetBuffer(), "application/request");

        }

        private IEnumerable<SampleData> GetSampleData()
        {
            var list = new List<SampleData>();
            var createdAt = new Guid("4E8CD131-A55A-49F1-964C-FAB057919EBE");
            var modifiedAt = new Guid("A7695D5A-E07E-4AA3-8040-5F30411EACD9");
            for (var i = 0; i < 2000; i++)
            {
                list.Add(new SampleData
                {
                    Created = DateTime.Now,
                    CreatedAt = createdAt,
                    Description = "desc",
                    Id = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    ModifiedAt = modifiedAt,
                    Title = "title"
                });
            }

            return list.ToArray();
        }
    }
}
