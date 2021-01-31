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

        public ResultatEquipe res;
        public ResultatEquipe Res
        {
            get { return res; }
        }
        public CompetitionEquipe(int nbmatch, int nbjours, string niveau, int nbjoueurs_minimal,  string intitule, DateTime date_debut, DateTime date_fin, string lieu, List<Entraineur> entraineurs_encadrants) 
            :base(nbmatch, nbjours, niveau, nbjoueurs_minimal,intitule, date_debut, date_fin, lieu, entraineurs_encadrants)
        {
            this.res = null;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
