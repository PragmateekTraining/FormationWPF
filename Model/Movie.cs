using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Movie
    {
        public string Title { get; set; }
        public string PosterURI { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Uri MoreInfoURI { get; set; }

        public IList<Actor> Actors { get; set; }

        public Movie()
        {
            Actors = new List<Actor>();
        }
    }
}
