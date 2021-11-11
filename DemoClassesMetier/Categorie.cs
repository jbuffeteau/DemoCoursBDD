using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoClassesMetier
{
    public class Categorie
    {
        // Membres privés
        private int numeroCategorie;
        private string nomCategorie;
        private string imageCategorie;

        public Categorie(int unId, string unNom, string uneImage)
        {
            NumeroCategorie = unId;
            NomCategorie = unNom;
            ImageCategorie = uneImage;
        }

        public int NumeroCategorie { get => numeroCategorie; set => numeroCategorie = value; }
        public string NomCategorie { get => nomCategorie; set => nomCategorie = value; }
        public string ImageCategorie { get => imageCategorie; set => imageCategorie = value; }
    }
}
