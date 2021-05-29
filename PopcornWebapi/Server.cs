using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopcornWebapi
{
    public class Server
    {
        public Guid Id { get; set; }
        public VideoFile video { get; set; }
        public List<Streamer> streamers { get; set; }
        public float CurrentPosition { get; set; }

        public Server(Guid id, VideoFile video, List<Streamer> streamer, float CurrentPosition)
        {
            Id = id;
            this.video = video;
            this.streamers = streamer;
            this.CurrentPosition = CurrentPosition;
        }
    }
}
