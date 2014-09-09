using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Actor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }

        public string Biography { get; set; }

        public string PhotoURI { get; set; }
        public string[] OtherPhotosURIs { get; set; }

        public Movie[] Movies { get; set; }
    }
}
