using System.ComponentModel.DataAnnotations;

namespace Demo13092024.Db.Models
{
    public class InstrumentType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
