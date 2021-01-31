using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
   public class ResultatEquipe:Resultat
    {
        private int identifiant_equipe;

        public int IdentifiantEquipe
        {
            get { return identifiant_equipe; }
            set { identifiant_equipe = value; }
        }

        private int identifiant_adversaire;

        public int IdentifiantAdversaire
        {
            get { return identifiant_adversaire; }
            set { identifiant_adversaire = value; }
        }

        public ResultatEquipe(int identifiant_equipe, int identifiant_adversaire, int resultat):base(resultat)
        {
            this.identifiant_equipe = identifiant_equipe;
            this.identifiant_adversaire = identifiant_adversaire;
        }

        public override string ToString()
        {
            return "Identifiant de l'équipe : " + identifiant_equipe + "\n Identifiant de l'équipe adverse : " + identifiant_adversaire + "\n Résultat : " + Result; 
        }
    }
}
