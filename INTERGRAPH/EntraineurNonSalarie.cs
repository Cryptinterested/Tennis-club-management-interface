using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    public class EntraineurNonSalarie : Entraineur
    {

        private double remunarationHoraire;
        public EntraineurNonSalarie(string iban, DateTime entree, int nbCoursAFaire, double remuneration, string nom, string prenom, DateTime naissance, string adresse, int code_postal, string numtel, TypeSex sexe) :
        base(iban, entree, nbCoursAFaire, nom, prenom, naissance, adresse, code_postal, numtel, sexe)
        {
            CotisationPayee = true; // ils ne payent pas les cotisations
            this.remunarationHoraire = remuneration;
        }

        public override string ToString()
        {
            return base.ToString() + "\n Rémunération horaire : " + remunarationHoraire;
        }
          
    }
}
