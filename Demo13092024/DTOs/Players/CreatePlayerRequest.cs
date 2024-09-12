using Demo13092024.DTOs.PlayerInstrument;
using System.ComponentModel.DataAnnotations;

namespace Demo13092024.DTOs.Players
{
    public class CreatePlayerRequest
    {
        [Required]  
        public string Nickname { get; set; }

        [Required]
        public List<CreatePlayerInstrumentRequest> PlayerInstruments { get; set; }
    }
}
