using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    public abstract class Entraineur : Membre
    {

        private int nbCoursAFaire;
        private string iban;
        private DateTime entree;
        public Entraineur(string iban, DateTime entree, int nbCours, string nom, string prenom, DateTime naissance, string adresse, int code_postal,string numtel, TypeSex sexe):
        base(nom, prenom, naissance, adresse, code_postal, numtel, sexe)
        {
            CotisationPayee = true; // ils ne payent pas les cotisations
            this.nbCoursAFaire = nbCours;
            this.iban = iban;
            this.entree = entree;
        }
    }
}
