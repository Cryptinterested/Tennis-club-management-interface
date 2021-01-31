using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    public class ResultatJoueur:Resultat
    {
        private int numlicence_joueur;
        public int NumLicenceJoueur
        {
            get { return numlicence_joueur; }
        }
        private int numlicence_adversaire;
        public int NumLicenceAdversaire
        {
            get { return numlicence_adversaire; }
        }

        public ResultatJoueur(int numlicence_joueur, int numlicence_adversaire, int resultat):base(resultat)
        {
            this.numlicence_joueur = numlicence_joueur;
            this.numlicence_adversaire = numlicence_adversaire;
        }

        public override string ToString()
        {
            return "Numéro de licence du joueur : " + numlicence_joueur + "\n Numéro de licence de l'adversaire : " + numlicence_adversaire + " \n Résultat : " + Result;
        }
    }
}
