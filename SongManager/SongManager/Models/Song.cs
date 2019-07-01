using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongManager.Models
{
    public class Song
    {
        public Guid Id { get; set; }

        public string Songname { get; set; }

        public string Artist { get; set; }

        public string Youtubelink { get; set; }
    }
}
