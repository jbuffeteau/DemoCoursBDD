using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoClassesMetier;
using MySql.Data.MySqlClient;

namespace DemoGstBdd
{
    public class GstBdd
    {
        private MySqlConnection cnx;
        private MySqlCommand cmd;
        private MySqlDataReader dr;

        public GstBdd()
        {
            string chaine = "Server=localhost;Database=ludotheque;Uid=root;Pwd=;SslMode=none";
            cnx = new MySqlConnection(chaine);
            cnx.Open();
        }

        public List<Categorie> GetLesCategories()
        {
            List<Categorie> mesCategories = new List<Categorie>();

            // Ecrire votre RQT
            cmd = new MySqlCommand("SELECT categorie.idCateg,categorie.nomCateg,categorie.imageCateg from categorie", cnx);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Categorie uneNouvelleCategorie = new Categorie(Convert.ToInt16(dr[0].ToString()), dr[1].ToString(), dr[2].ToString());
                mesCategories.Add(uneNouvelleCategorie);
            }
            dr.Close();
            return mesCategories;
        }

        public List<Jeux> GetLesJeuxByIdCategorie(int idCateg)
        {
            List<Jeux> lesJeux = new List<Jeux>();

            cmd = new MySqlCommand("select idJeux, nomJeux, imageJeux from jeux where numCateg = " + idCateg , cnx);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Jeux unJeux = new Jeux(Convert.ToInt16(dr[0].ToString()), dr[1].ToString(), dr[2].ToString());
                lesJeux.Add(unJeux);
            }
            dr.Close();
            return lesJeux;
        }


        public int GetMaxIdCateg()
        {
            int maxId = 0;

            cmd = new MySqlCommand("select max(idCateg) from categorie", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            maxId = Convert.ToInt16(dr[0]) + 1;
            dr.Close();
            return maxId;
        }

        public void InsertCategorie(int numCateg, string nomCateg)
        {
            cmd = new MySqlCommand("insert into categorie values("+numCateg+",'"+nomCateg+ "','https://zupimages.net/up/19/34/5rph.jpg')", cnx);
            cmd.ExecuteNonQuery();
        }
    }
}
