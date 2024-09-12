using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo13092024.Db.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        public DateTime JoinedDate { get; set; }

        public List<PlayerInstrument> Instruments { get; set; }
    }
}
