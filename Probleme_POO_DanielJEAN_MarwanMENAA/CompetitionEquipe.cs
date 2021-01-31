using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    public class CompetitionEquipe:Competition
    {
        public List<Equipe> equipes_participantes;
        public List<Equipe> EquipesParticipantes
        {
            get { return equipes_participantes; }
        }
        public CompetitionEquipe(int nbmatch, int nbjours, string niveau, int nbjoueurs_minimal, string classement_max, string intitule, DateTime date_debut, DateTime date_fin, string lieu, List<Membre> participants, List<Entraineur> entraineurs_encadrants) :base(nbmatch, nbjours, niveau, nbjoueurs_minimal, classement_max, intitule, date_debut, date_fin, lieu, participants, entraineurs_encadrants)
        {
            
        }
        public override string ToString()
        {
            return "Les équipes participantes à cette competition sont : " +  equipes_participantes +base.ToString();
        }
    }
}
