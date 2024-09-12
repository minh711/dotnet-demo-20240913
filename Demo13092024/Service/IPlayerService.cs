using Demo13092024.DTOs.Players;
using Demo13092024.DTOs.PlayerInstrument;
using Demo13092024.DTOs;

namespace Demo13092024.Service
{
    public interface IPlayerService
    {
        Task CreatePlayerAsync(CreatePlayerRequest playerRequest);
        Task<bool> UpdatePlayerAsync(int id, UpdatePlayerRequest playerRequest);
        Task<bool> DeletePlayerAsync(int id);
        Task<GetPlayerDetailResponse> GetPlayerDetailAsync(int id);
        Task<GetPlayerResponse> GetPlayerAsync(UrlQueryParameters urlQueryParameters);
    }
}
