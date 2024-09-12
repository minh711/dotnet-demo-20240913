namespace Demo13092024.Db.Models
{
    public class PlayerInstrument
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int InstrumentTypeId { get; set; }
        public string ModelName { get; set; }
        public string Level { get; set; }

        public InstrumentType InstrumentType { get; set; }
    }
}
