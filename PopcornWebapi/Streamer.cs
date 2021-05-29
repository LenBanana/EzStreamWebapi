using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopcornWebapi
{
    public class Streamer
    {
        public string Username { get; set; }
        public bool Playing { get; set; }
        public Streamer(string Username)
        {
            Playing = false;
            this.Username = Username;
        }
    }
}
