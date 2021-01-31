using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
   public class Stage:Evenement
    {
        private int age;

        /*public int Age
        {
            get { return age; }
        }*/

        private string niveau;

        public string Niveau
        {
            get { return niveau; }
            set { niveau = value; }
        }

        private double cout;
        public double Cout
        {
            get { return cout; }
            set { cout = value; }
        }

        private int nombremax_compteur;

        public int NombreMaxCompteur
        {
            get { return nombremax_compteur; }
            set { nombremax_compteur = value; }
        }


        public Stage(string niveau, double cout, int nombremax_compteur,string intitule, DateTime date_debut, DateTime date_fin, string lieu, List<Entraineur> entraineurs_encadrants ):base(intitule, date_debut, date_fin, lieu, entraineurs_encadrants)
        {
            //this.age = age;
            this.niveau = niveau;
            this.cout = cout;
            this.nombremax_compteur = nombremax_compteur;
        }

        public override string ToString()
        {
            string s = "";
            foreach (Entraineur e in EntraineursEncadrants) s += e.ToString() + "\n";
            return "Debut :" + DateDebut +"\n"+ "Fin :" +DateFin + "\n" + "Age : " + age + "\n Niveau : " + niveau + "\n Coût : " + cout + "\n Encadrants :" + s;
        }
    }
}
