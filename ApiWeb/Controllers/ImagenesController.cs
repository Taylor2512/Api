using Aplication.AppServices.Azure;
using Aplication.Tools.Enums;
using Domain.Entities.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenesController : ControllerBase
    {
        private IAzureStorageService azure;

        public ImagenesController(IAzureStorageService azure)
        {
            this.azure = azure;
        }

        [HttpPost]
        public async Task<ActionResult<object>> PostImagen([FromForm][FromBody] Imagenes imagenes)
        {
            if (imagenes.formFile != null)
            {
                imagenes.urlAzure = await this.azure.UploadAsync(imagenes.formFile, ContainerEnum.IMAGENES);
            }


            return Ok(imagenes);
        }
    }
}
