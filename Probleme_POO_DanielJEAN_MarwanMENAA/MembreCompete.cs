using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    public class MembreCompete : Membre
    {

        private string classement;
        //manque Nombre de compétitions à faire

        public MembreCompete(string classement,string nom, string prenom, DateTime naissance, string adresse, int code_postal, string numtel, TypeSex sexe)
        : base(nom, prenom, naissance, adresse, code_postal, numtel, sexe)
        {
            this.classement = classement;
            CotisationPayee = false; // par defaut il payent apres leur inscription
        }

        public override string ToString()
        {
            return base.ToString() + "\n  classement : " + classement;
        }

        public string Classement
        {
            get { return classement; }
        }

        
       
    }
}
