using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo13092024.Db.Models
{
    public class PlayerInstrument
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Player")]
        [Required]
        public int PlayerId { get; set; }

        [ForeignKey("InstrumentType")]
        [Required]
        public int InstrumentTypeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ModelName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Level { get; set; }

        public InstrumentType InstrumentType { get; set; }
        public Player Player { get; set; }
    }
}
