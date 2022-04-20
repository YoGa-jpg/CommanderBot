using System.Collections.Generic;

namespace CommanderBot.Model
{
    public class Server
    {
        public int Id { get; private set; }
        public int Might { get; private set; }
        public string Name { get; private set; }

        public IEnumerable<Feudalist> Feudalists { get; set; }
    }
}