using Demo13092024.DTOs.PlayerInstrument;

namespace Demo13092024.DTOs.Players
{
    public class GetPlayerDetailResponse
    {
        public string NickName { get; set; }
        public DateTime JoindDate {  get; set; }
        public List<GetPlayerInstrumentResponse> PlayerInstruments { get; set; }
    }
}
