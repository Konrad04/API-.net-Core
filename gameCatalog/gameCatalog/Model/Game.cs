using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameCatalog.Model
{
    public class Game
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Rok { get; set; }
        public string Gatunek { get; set; }
        public string Nota { get; set; }
        public string Zdjecie { get; set; }
    }
}
