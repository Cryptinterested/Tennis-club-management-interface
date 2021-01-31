using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    public class CompetitionSimple:Competition 
       
    {
        private List<Membre> liste_participants;

        public List<Membre> ListeParticipants
        {
            get { return liste_participants; }
        }
        
        public CompetitionSimple(int nbmatch, int nbjours, string niveau, int nbjoueurs_minimal, string classement_max, string intitule, DateTime date_debut, DateTime date_fin, string lieu, List<Membre> participants, List<Entraineur> entraineurs_encadrants) :base(nbmatch,nbjours,niveau,nbjoueurs_minimal,classement_max,intitule, date_debut, date_fin, lieu, participants, entraineurs_encadrants)
        {
            
        }

        public override string ToString()
        {
            return "Les participants à cette competition sont : " + liste_participants + base.ToString();
        }
    }
}
