using System.ComponentModel.DataAnnotations;

namespace Demo13092024.DTOs.Players
{
    public class UpdatePlayerRequest
    {
        [Required]
        public string NickName { get; set; }
    }
}
