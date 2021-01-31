using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    public class EntraineurSalarie : Entraineur
    {

        double salaire;
        public EntraineurSalarie(string iban, DateTime entree, int nbCoursAFaire, double salaire, string nom, string prenom, DateTime naissance, string adresse, int code_postal, string numtel, TypeSex sexe) :
        base(iban, entree, nbCoursAFaire ,nom, prenom, naissance, adresse, code_postal, numtel, sexe)
        {
            this.salaire = salaire;
        }

        public override string ToString()
        {
            return base.ToString() + "\n";
        }
    }
}
