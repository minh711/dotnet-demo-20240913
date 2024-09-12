
using Demo13092024.Db;
using Demo13092024.Db.Models;
using Demo13092024.DTOs;
using Demo13092024.DTOs.Players;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Numerics;

namespace Demo13092024.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly CodeFirstDemoContext _dbContext;

        public PlayerService(CodeFirstDemoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatePlayerAsync(CreatePlayerRequest playerRequest)
        {
            await _dbContext.Players.AddAsync(playerRequest);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeletePlayerAsync(int id)
        {
            var player = await _dbContext.Players.FindAsync(id);
            if (player == null)
                return false;
            _dbContext.Players.Remove(player);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<GetPlayerResponse> GetPlayerAsync()
        {
            var players = _dbContext.Players.AsQueryable();
            var total = await players.CountAsync();
            var pagedPlayers = await players
                .ToListAsync();

            return new GetPlayerResponse
            {
                Total = total,
                Data = pagedPlayers.Select(p => new GetPlayerResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Age = p.Age,
                    Instrument = p.Instrument,
                }).ToList(),
            };
        }

        public async Task<GetPlayerDetailResponse> GetPlayerDetailAsync(int id)
        {
            var player = await _dbContext.Players.FindAsync(id);
            if (player == null)
                return null;
            return new GetPlayerDetailResponse
            {
                Id = player.Id,
                Name = player.Name,
                Age = player.,
                Instrument = player.Instrument,
            };
        }

        public async Task<bool> UpdatePlayerAsync(int id, UpdatePlayerRequest playerRequest)
        {
            var player = await _dbContext.Players.FindAsync(id);
            if (player == null)
                return false;
            player.Name = playerRequest.Name;
            player.JoinedDate = playerRequest.JoinDate;
            player.Instruments = playerRequest.Instruments;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
