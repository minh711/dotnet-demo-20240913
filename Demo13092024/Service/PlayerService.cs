using AutoMapper;
using Demo13092024.Db;
using Demo13092024.Db.Models;
using Demo13092024.DTOs;
using Demo13092024.DTOs.PlayerInstrument;
using Demo13092024.DTOs.Players;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Demo13092024.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly CodeFirstDemoContext _dbContext;
        private readonly IMapper _mapper;

        public PlayerService(CodeFirstDemoContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreatePlayerAsync(CreatePlayerRequest playerRequest)
        {
            //var player = new Player
            //{
            //    Name = playerRequest.Nickname,
            //    JoinedDate = DateTime.Now,
            //    Instruments = playerRequest.PlayerInstruments.Select(i => new PlayerInstrument
            //    {
            //        InstrumentTypeId = i.InstrumentTypeId,
            //        ModelName = i.ModelName,
            //        Level = i.Level
            //    }).ToList()
            //};

            var player = _mapper.Map<Player>(playerRequest);

            _dbContext.Players.Add(player);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeletePlayerAsync(int id)
        {
            var player = await _dbContext.Players.FindAsync(id);
            if (player == null) return false;

            _dbContext.Players.Remove(player);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<GetPlayerResponse> GetPlayerAsync(UrlQueryParameters urlQueryParameters)
        {
            var player = await _dbContext.Players
                .Select(p => new GetPlayerResponse
                {
                    PlayerId = p.Id,
                    NickName = p.Name,
                    JoinedDate = p.JoinedDate,
                    InstrumentSubmittedCount = p.Instruments.Count
                })
                .FirstOrDefaultAsync(p => p.PlayerId == urlQueryParameters.Id);

            return player;
        }

        public async Task<GetPlayerDetailResponse> GetPlayerDetailAsync(int id)
        {
            var player = await _dbContext.Players
                .Include(p => p.Instruments)
                .ThenInclude(pi => pi.InstrumentType)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (player == null) return null;

            return new GetPlayerDetailResponse
            {
                NickName = player.Name,
                JoinedDate = player.JoinedDate,
                PlayerInstruments = player.Instruments.Select(i => new GetPlayerInstrumentResponse
                {
                    InstrumentTypeId = i.InstrumentTypeId,
                    ModelName = i.ModelName,
                    Level = i.Level
                }).ToList()
            };
        }

        public async Task<bool> UpdatePlayerAsync(int id, UpdatePlayerRequest playerRequest)
        {
            var player = await _dbContext.Players.FindAsync(id);
            if (player == null) return false;

            player.Name = playerRequest.NickName;
            _dbContext.Players.Update(player);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
