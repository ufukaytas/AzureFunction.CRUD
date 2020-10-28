using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CRUD.Function.Services;
using CRUD.Function.Model;

namespace CRUD.Function
{
    public class DeleteHttpTrigger
    {
        private ICRUDService _service;
        public DeleteHttpTrigger(ICRUDService service)
        {
            _service = service;
        }

        [FunctionName("delete")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "delete/{id}")] HttpRequest req, 
            string id,
            ILogger log)
        {
            var isSuccess = await _service.DeleteAsync(new Guid(id));
            return new OkObjectResult($"the user is deleted: {isSuccess}");
        }
    }
}
