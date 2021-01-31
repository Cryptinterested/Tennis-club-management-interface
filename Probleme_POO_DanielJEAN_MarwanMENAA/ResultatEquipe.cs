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

        private Resultat res;

        public Resultat Res
        {
            get { return res; }
            set { res = value; }
        }

        public ResultatEquipe(int identifiant_equipe, int identifiant_adversaire, Resultat res):base()
        {
            this.identifiant_equipe = identifiant_equipe;
            this.identifiant_adversaire = identifiant_adversaire;
            this.res = res;
        }

        public override string ToString()
        {
            return "Identifiant de l'équipe : " + identifiant_equipe + "\n Identifiant de l'équipe adverse : " + identifiant_adversaire + "\n Résultat : " + res; 
        }
    }
}
