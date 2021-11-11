using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoClassesMetier
{
    public class Jeux
    {
        private int idJeux;
        private string nomJeux;
        private string imageJeux;

        public Jeux(int unId, string unNom, string uneImage)
        {
            IdJeux = unId;
            NomJeux = unNom;
            ImageJeux = uneImage;
        }

        public int IdJeux { get => idJeux; set => idJeux = value; }
        public string NomJeux { get => nomJeux; set => nomJeux = value; }
        public string ImageJeux { get => imageJeux; set => imageJeux = value; }
    }
}
