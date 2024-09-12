using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo13092024.Db;
using Demo13092024.Db.Models;
using Demo13092024.Service;
using Demo13092024.DTOs.Players;
using Demo13092024.DTOs;

namespace Demo13092024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayersAsync([FromQuery] UrlQueryParameters urlQueryParameters)
        {
            var result = await _playerService.GetPlayerAsync(urlQueryParameters);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("{id:int}/detail")]
        public async Task<IActionResult> GetPlayerDetailAsync(int id)
        {
            var result = await _playerService.GetPlayerDetailAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostPlayerAsync([FromBody] CreatePlayerRequest playerRequest)
        {
            await _playerService.CreatePlayerAsync(playerRequest);
            return Ok(new { message = "Player created successfully" });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutPlayerAsync(int id, [FromBody] UpdatePlayerRequest playerRequest)
        {
            var result = await _playerService.UpdatePlayerAsync(id, playerRequest);
            if (!result) return NotFound();
            return Ok(new { message = "Renamed successfully" });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePlayerAsync(int id)
        {
            var result = await _playerService.DeletePlayerAsync(id);
            if (!result) return NotFound();
            return Ok(new { message = "Deleted successfully" });
        }
    }
}
