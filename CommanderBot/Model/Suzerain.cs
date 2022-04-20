using System.Collections.Generic;

namespace CommanderBot.Model
{
    class Suzerain : Feudalist
    {
        public IEnumerable<Vassal> Vassals { get; set; }
    }
}
