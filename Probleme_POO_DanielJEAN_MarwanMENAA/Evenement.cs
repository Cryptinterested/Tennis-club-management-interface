using System;
using System.Collections.Generic;
namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    public class Evenement
    {
        private string intitule;

        public string Intitule
        {
            get { return intitule; }
            set { intitule = value; }
        }

        private DateTime date_debut;

        public DateTime DateDebut
        {
            get { return date_debut; }
            set { date_debut = value; }
        }

        private DateTime date_fin;

        public DateTime DateFin
        {
            get { return date_fin; }
            set { date_fin = value; }
        }

        private string lieu;

        public string Lieu
        {
            get { return lieu; }
            set { lieu = value; }
        }

        private List<Membre> participant;

        public List<Membre> Participant
        {
            get { return participant; }
            set { participant = value; }
        }

        private List<Entraineur> entraineurs_encadrants;

        public List<Entraineur> EntraineursEncadrants 
        {
            get { return entraineurs_encadrants; }
            set { entraineurs_encadrants = value; }
        }

        public Evenement(string intitule, DateTime date_debut, DateTime date_fin, string lieu, List<Membre> participant, List<Entraineur> entraineurs_encadrants)
        {
            this.intitule = intitule;
            this.date_debut = date_debut;
            this.date_fin = date_fin;
            this.lieu = lieu;
            this.participant = participant;
            this.entraineurs_encadrants = entraineurs_encadrants;
        }

        public override string ToString()
        {
            string p = "", e = "";
            foreach (Membre m in participant) p += m.ToString() + "\n\n";
            foreach (Entraineur ent in entraineurs_encadrants) e += e.ToString() + "\n\n";
            return "L'événement : " + intitule + "\n Débute le : " + date_debut + "\n Fin : " + date_fin + "\n A lieu : " + lieu + "\n Participants : " + p + "\n Entraineurs Encadrants : " + e;
        }


    }
}
