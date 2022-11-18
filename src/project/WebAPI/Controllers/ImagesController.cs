using Application.Features.Images.Commands.AddImage;
using Application.Features.Images.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add(IFormFile file)
        {
            AddImageCommand addGIFCommand = new() { File = file };
            AddedImageDto result = await Mediator.Send(addGIFCommand);
            return Ok(result);
        }
    }
}
