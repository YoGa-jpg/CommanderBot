namespace CommanderBot.Model
{
    class Vassal : Feudalist
    {
        public int SuzerainId { get; set; }
        public Suzerain Suzerain { get; set; }
    }
}
