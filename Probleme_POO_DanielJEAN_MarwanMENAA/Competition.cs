using System;
using System.Collections.Generic;
namespace Probleme_POO_DanielJEAN_MarwanMENAA
{

    public abstract class Competition : Evenement
    {
        private bool statut;

        public bool Statut
        {
            get { return statut; }

        }

        private int nbmatch;

        public int NbMatch
        {
            get { return nbmatch; }

        }

        private int nbjours;

        public int NbJours
        {
            get { return nbjours; }

        }

        private string niveau;

        public string Niveau
        {
            get { return niveau; }

        }

        private int nbjoueurs_minimal;

        public int NbJoueursMinimal
        {
            get { return nbjoueurs_minimal; }

        }

        private string classement_max;

        public string ClassementMax
        {
            get { return classement_max; }

        }

        private List<Club> present;

        public List<Club> Present
        {
            get { return present; }
        }

        public Competition(int nbmatch, int nbjours, string niveau, int nbjoueurs_minimal, string classement_max, string intitule,DateTime date_debut, DateTime date_fin, string lieu, List<Membre> participants, List<Entraineur> entraineurs_encadrants):base(intitule, date_debut, date_fin,lieu,participants,entraineurs_encadrants)
        {

            this.statut = false;
            this.nbmatch = nbmatch;
            this.nbjours = nbjours;
            this.niveau = niveau;
            this.nbjoueurs_minimal = nbjoueurs_minimal;
            this.classement_max = classement_max;

        }

        public override string ToString()
        {
            return "Statut : " + statut + "\n Nombre de match : " + nbmatch + "\n Nombre de jours : " + nbjours + "\n Niveau : " + niveau + "\n Nombre minimum de joueurs : " + nbjoueurs_minimal + "\n Classement maximum : " + classement_max;
        }

        public bool ChgtStatut(Competition c)
        {
            if (c.DateFin <= DateTime.Now) { c.statut = true; }
            else { c.statut = false; }
            return c.statut;
        }

        //public ResultatEquipe (CompetitionEquipe c,Equipe a,Equipe b)
        // {   
        //     if (c.DateFin <= DateTime.Now) { ResultatEquipe res1 = new ResultatEquipe(a.IdEquipe, b.IdEquipe, );
        // }

        // NOTE : il faut penser à gérer l'annulation d'une compétition par un club et donc le résultat induit par ceci

    }
}
