using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{

    public class Equipe
    {
        private static int numEquipe = 1;
        private Competition participe;
        private Membre Capitaine;
        private int nbPointGagnes;
        private List<Membre> participantCompet;
        private int idEquipe;
        private string niveau;

        public Equipe(Competition participe, Membre Capitaine, string niveau) // A la creation de chaque equipe le nombre de points gagnés est 0
        {
            // Penser à ne permettre le choix que de certains membres pour etre capitaine

            this.participe = participe;
            this.Capitaine = Capitaine;
            this.nbPointGagnes = 0;
            this.idEquipe = numEquipe;
            participantCompet.Add(Capitaine);
            this.niveau = niveau;
            numEquipe++;
        }

        public List<Membre> ParticipantCompet
        {
            get { return participantCompet; } 
        }

        public int IdEquipe
        {
            get { return idEquipe; }
        }

        public string Niveau
        {
            get { return niveau; }
        }

        public override string ToString()
        {
            return "Equipe :" + idEquipe + "\n Capitaine :" + Capitaine.ToString() + "\n Nombre points gagnés en competition : " + nbPointGagnes;
        }
    }
}
