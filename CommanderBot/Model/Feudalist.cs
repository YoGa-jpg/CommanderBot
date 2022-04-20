namespace CommanderBot.Model
{
    public abstract class Feudalist
    {
        public int Id { get; set; }
        public int Power { get; set; }
        public int ProductionRate { get; set; } = 1;
        public int Cost { get; set; }
        public string Name { get; set; }

        //public IEnumerable<Feudalist> Vassals { get; set; }
        //public Feudalist Suzerain { get; set; }
        //public int SuzerainId { get; set; }

        //public int ServerId { get; set; }
        //public Server Server { get; set; }
    }
}