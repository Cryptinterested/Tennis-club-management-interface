using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    public class CompetitionSimple:Competition 
       
    {
        private List<Membre> liste_participants;

        private ResultatJoueur res;
        public ResultatJoueur Res
        {
            get { return res; }
        }
        public List<Membre> Liste_participants
        {
            get { return liste_participants; }
        }
        
        public CompetitionSimple(int nbmatch, int nbjours, string niveau, int nbjoueurs_minimal, string intitule, DateTime date_debut, DateTime date_fin, string lieu, List<Entraineur> entraineurs_encadrants) :base(nbmatch,nbjours,niveau,nbjoueurs_minimal,intitule, date_debut, date_fin, lieu, entraineurs_encadrants)
        {
            this.res = null;
        }

        public override string ToString()
        {
            return  base.ToString();
        }
    }
}
