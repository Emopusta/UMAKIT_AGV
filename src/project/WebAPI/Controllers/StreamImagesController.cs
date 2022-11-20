using Application.Features.Images.Commands.AddImage;
using Application.Features.Images.Dtos;
using Application.Features.StreamImages.Commands.AddStreamImage;
using Application.Features.StreamImages.Commands.UpdateStreamImage;
using Application.Features.StreamImages.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamImagesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] AddStreamImageCommand addStreamImageCommand)
        {
            AddedStreamImageDto result = await Mediator.Send(addStreamImageCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStreamImageCommand updateStreamImageCommand)
        {
            UpdatedStreamImageDto result = await Mediator.Send(updateStreamImageCommand);
            return Ok(result);
        }

    }
}
