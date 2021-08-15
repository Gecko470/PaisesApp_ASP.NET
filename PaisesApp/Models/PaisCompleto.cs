using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaisesApp.Models
{
    public class PaisCompleto
    {
        public string name { get; set; }

        public string capital { get; set; }

        public string region { get; set; }

        public string flag { get; set; }

        public int population { get; set; }

        public string area { get; set; }

        public List<string> borders { get; set; }

        public List<Languages> languages { get; set; }

        public Translations translations { get; set; }
    }
}
