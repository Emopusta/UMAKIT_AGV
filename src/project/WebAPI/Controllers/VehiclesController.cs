using Application.Features.Images.Commands.AddImage;
using Application.Features.Images.Dtos;
using Application.Features.Vehicles.Commands.AddVehicle;
using Application.Features.Vehicles.Commands.UpdateVehicle;
using Application.Features.Vehicles.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] AddVehicleCommand addVehicleCommand)
        {
            AddedVehicleDto result = await Mediator.Send(addVehicleCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateVehicleCommand updateVehicleCommand)
        {
            UpdatedVehicleDto result = await Mediator.Send(updateVehicleCommand);
            return Ok(result);
        }
    }
}
