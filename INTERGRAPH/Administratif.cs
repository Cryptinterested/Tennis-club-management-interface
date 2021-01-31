using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    class Administratif : Membre
    {

        private string iban;
        private double salaire;
        private DateTime dateEntree;
        private string poste; // secretaire, president, trésorier

        public Administratif(string poste,string iban, double salaire, DateTime dateEntree, string nom, string prenom, DateTime naissance, string adresse, int code_postal, string numtel, TypeSex sexe):
            base (nom, prenom, naissance, adresse, code_postal, numtel, sexe)
        {
            this.iban = iban;
            this.salaire = salaire;
            this.dateEntree = dateEntree;
            this.poste = poste;
        }

        public override string ToString() // AFFICHAGE DU MEMBRE ADMINISTRATIF
        {
            return "Salaire : " + salaire + "\n Poste : " + poste + "\n Date d'entrée : " + dateEntree + "\n Iban : " + iban;
        }
    }
}
