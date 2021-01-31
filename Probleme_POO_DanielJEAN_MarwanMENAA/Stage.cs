using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
   public class Stage:Evenement
    {
        private int age;

        public int Age
        {
            get { return age; }
        }

        private string niveau;

        public string Niveau
        {
            get { return niveau; }
        }

        private bool cout; //J'ai mis un bool parce que finalement le prix du stage on s'en fiche on veut juste savoir si le membre a payé ou non 

        public bool Cout
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


        public Stage(int age, string niveau, bool cout, int nombremax_compteur,string intitule, DateTime date_debut, DateTime date_fin, string lieu, List<Membre> participant, List<Entraineur> entraineurs_encadrants ):base(intitule, date_debut, date_fin, lieu, participant, entraineurs_encadrants)
        {
            this.age = age;
            this.niveau = niveau;
            this.cout = cout;
            this.nombremax_compteur = nombremax_compteur;
        }

        public override string ToString()
        {
            return "Age : " + age + "\n Niveau : " + niveau + "\n Coût : " + cout;
        }
    }
}
