using API.Controllers.Base;
using API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/teamdraw")]
    public class TeamDrawController : BaseController
    {
        private readonly IDrawTeamService _drawTeamService;

        public TeamDrawController(IDrawTeamService drawTeamService)
        {
            _drawTeamService = drawTeamService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teams = await _drawTeamService.Draw();

            return Ok(teams);
        }
    }
}