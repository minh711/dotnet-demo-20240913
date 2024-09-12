namespace Demo13092024.Db.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime JoinedDate { get; set; }
        public List<PlayerInstrument> Instruments { get; set; }
    }
}
