using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    public class MembreCompete : Membre
    {

        private string classement;
        private int nbCompetitionAFaire;

        public MembreCompete(string classement,string nom, string prenom, DateTime naissance, string adresse, int code_postal, string numtel, TypeSex sexe)
        : base(nom, prenom, naissance, adresse, code_postal, numtel, sexe)
        {
            this.classement = classement;
            CotisationPayee = false; // par defaut il payent apres leur inscription
            this.nbCompetitionAFaire = 5;
        }

        public override string ToString()
        {
            return base.ToString() + "\n Classement : " + classement;
        }

        public string Classement
        {
            get { return classement; }
        }

        public int NbCompetitionAFaire
        {
            get { return nbCompetitionAFaire; }
        }

        
       
    }
}
