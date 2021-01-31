using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    class Statistiques // CLASEE PERMETTANT D'AVOIR LES PRINCIPALES STATISTIQUES DU CLUB
    {
        private Club club_tennis;

        public Statistiques(Club clubtennis)
        {
            this.club_tennis = clubtennis;
        }
        public Club ClubTennis { get { return club_tennis; } }

        public delegate int Operation();
        public int Affichage(Operation o)
        {
            return o();
        }

        public int CompetitionsRealisees()
        {
            int c = 0;
            foreach (Evenement e in club_tennis.Evenements)
            {
                if (e is Competition && ((Competition)e).Statut == true)
                {
                    c++;
                }
            }
            return c;
        }

        public int CompetitionsRestantes()
        {
            int c = 0;
            foreach (Evenement e in club_tennis.Evenements)
            {
                if (e is Competition && ((Competition)e).Statut == false)
                {
                    c++;
                }
            }
            return c;
        }

        public int NbMatchJouesParMembreSimple(Membre m)
        {
            int c = 0;

            foreach (Competition compete in club_tennis.Evenements)
            {
                if (compete is CompetitionSimple && (m is MembreCompete || m is Entraineur))
                {
                    if (((CompetitionSimple)compete).Liste_participants.Contains(m))
                    {
                        c++;
                    }
                }
            }
            return c;
        }

        public int NbMatchJouesParMembreEquipe(Membre m)
        {
            /*int c = 0;
            foreach (Competition compete in club_tennis.Evenements)
            {
                if (compete is CompetitionEquipe && (m is MembreCompete || m is Entraineur))
                {
                    foreach (Equipe equ in compete.EquipesParticipantes)
                    {
                        if (equ.ParticipantCompet.Contains(m))
                        {
                            c += compete.NbMatch;
                        }
                    }
                }
            }*/

            return 1;
        }

        public int NbMatchJouesParMembre(Membre m)
        {
            /*int c = 0;

            foreach (CompetitionSimple compete in club_tennis.Evenements)
            {
                if (m is MembreCompete || m is Entraineur)
                {
                    if (compete.ListeParticipants.Contains(m))
                    {
                        c ++;
                    }
                }
            }

            foreach (CompetitionEquipe compete in club_tennis.Evenements)
            {
                if (m is MembreCompete || m is Entraineur)
                {

                    foreach (Equipe equ in compete.EquipesParticipantes)
                    {
                        if (equ.ParticipantCompet.Contains(m))
                        {
                            c ++;
                        }
                    }
                }
            }*/

            return 1;
        }

        public int NbMatchsGagnesParJoueur(Membre m)
        {
            int c = 0;

            foreach (Resultat res in club_tennis.ResultatCompetition)
            {
                if (res is ResultatJoueur && (m.Numlicence == ((ResultatJoueur)res).NumLicenceJoueur) && ((ResultatJoueur)res).Result > 0)
                {
                    c++;
                }
            }

            foreach (Resultat res in club_tennis.ResultatCompetition)
            {
                if (res is ResultatEquipe)
                {
                    Equipe e = club_tennis.EquipesCompet.Find(x => x.IdEquipe == ((ResultatEquipe)res).IdentifiantEquipe);
                    if (e != null && ((ResultatEquipe)res).Result > 0) c++;
                }
            }
            return c;
        }

        public int NbMatchsPerdusParJoueur(Membre m)
        {
            int c = 0;

            foreach (Resultat res in club_tennis.ResultatCompetition)
            {
                if (res is ResultatJoueur && (m.Numlicence == ((ResultatJoueur)res).NumLicenceJoueur) && ((ResultatJoueur)res).Result == 0)
                {
                    c++;
                }
            }

            foreach (Resultat res in club_tennis.ResultatCompetition)
            {
                if (res is ResultatEquipe)
                {
                    Equipe e = club_tennis.EquipesCompet.Find(x => x.IdEquipe == ((ResultatEquipe)res).IdentifiantEquipe);
                    if (e != null && ((ResultatEquipe)res).Result == 0) c++;
                }
            }
            return c;
        }

        public double NbMoyenJoueursParCompet()
        {
            double c = 0;
            double n = 0;
            foreach (Competition compete in club_tennis.Evenements)
            {
                if (compete is CompetitionSimple && compete.Statut == true)
                {
                    c += ((CompetitionSimple)compete).Liste_participants.Count;
                    n++;
                }
            }
            foreach (Competition compete in club_tennis.Evenements)
            {
                if (compete is CompetitionEquipe && compete.Statut == true)
                {
                    c += ((CompetitionEquipe)compete).EquipesParticipantes.Count * 5;
                    n++;
                }
            }
            return c / n;
        }


        public int NbMatchsGagnesParJoueurParAnnee(Membre m, int annee)
        {
            int c = 0;

            foreach (Competition compete in club_tennis.Evenements)
            {
                if (compete is CompetitionSimple && compete.DateFin.Year == annee && (m is MembreCompete || m is Entraineur))
                {
                    if (((CompetitionSimple)compete).Res != null)
                        if (((CompetitionSimple)compete).Res.Result > 0)
                        {
                        c++;
                        }
                }
            }
            foreach (Competition compete in club_tennis.Evenements)
            {
                if (compete is CompetitionEquipe && compete.DateFin.Year == annee && (m is MembreCompete || m is Entraineur))
                {
                    if (((CompetitionSimple)compete).Res != null)

                        if (((CompetitionEquipe)compete).Res.Result > 0)
                         {
                            c++;
                        }
                }
            }
            return c;
        }

      
        public int NbMatchsGagnesParJoueurParAnnee(int annee)
        {
            int c = 0;
            foreach( Membre m in club_tennis.Membres)
            {
                c += NbMatchsGagnesParJoueurParAnnee(m, annee);
            }
            return c;
        }

        public int NbMatchsPerdusParJoueurParAnnee(Membre m, int annee)
        {
            int c = 0;

            foreach (Competition compete in club_tennis.Evenements)
            {
                if (compete is CompetitionSimple && compete.DateFin.Year == annee && (m is MembreCompete || m is Entraineur))
                {
                    if(((CompetitionSimple)compete).Res != null)
                        if (((CompetitionSimple)compete).Res.Result == 0)
                        {
                            c++;
                        }
                }
            }
            foreach (Competition compete in club_tennis.Evenements)
            {
                if (compete is CompetitionEquipe && compete.DateFin.Year == annee && (m is MembreCompete || m is Entraineur))
                {

                    if (((CompetitionEquipe)compete).Res.Result == 0)
                    {
                        c++;
                    }
                }
            }
            return c;
        }

        public int NbMatchPerdusParAnnee(int annee)
        {
            int c = 0;
            foreach (Membre m in club_tennis.Membres)
            {
                c += NbMatchsPerdusParJoueurParAnnee(m, annee);
            }
            return c;
        }

        public int NbMatchGagnesParAnnee(int annee)
        {
            int c = 0;
            foreach (Membre m in club_tennis.Membres)
            {
                c += NbMatchsGagnesParJoueurParAnnee(m, annee);
            }
            return c;
        }

        public int NbMatchsGagnesParJoueurParLesFemmes()
        {
            int c = 0;
            foreach (Membre m in club_tennis.Membres)
            { if (m.Sexe == TypeSex.F && m.Naissance.Year-DateTime.Now.Year >18)
                {
                    c += NbMatchsGagnesParJoueur(m);
                }
            }
            return c;
        }

        public int NbMatchsPerdusParJoueurParLesFemmes()
        {
            int c = 0;
            foreach (Membre m in club_tennis.Membres)
            {
                if (m.Sexe == TypeSex.F && m.Naissance.Year - DateTime.Now.Year > 18)
                {
                    c += NbMatchsPerdusParJoueur(m);
                }
            }
            return c;
        }



        public int NbMatchsGagnesParJoueurParLesHommes()
        {
            int c = 0;
            foreach (Membre m in club_tennis.Membres)
            {
                if (m.Sexe == TypeSex.M && m.Naissance.Year - DateTime.Now.Year > 18)
                {
                    c += NbMatchsGagnesParJoueur(m);
                }
            }
            return c;
        }

        public int NbMatchsPerdusParJoueurParLesHommes()
        {
            int c = 0;
            foreach (Membre m in club_tennis.Membres)
            {
                if (m.Sexe == TypeSex.M && m.Naissance.Year - DateTime.Now.Year > 18)
                {
                    c += NbMatchsPerdusParJoueur(m);
                }
            }
            return c;
        }


        public int NbMatchsGagnesParJoueurParLesJuniors()
        {
            int c = 0;
            foreach (Membre m in club_tennis.Membres)
            {
                if ( m.Naissance.Year - DateTime.Now.Year <= 18)
                {
                    c += NbMatchsGagnesParJoueur(m);
                }
            }
            return c;
        }

        public int NbMatchsPerdusParJoueurParLesJuniors()
        {
            int c = 0;
            foreach (Membre m in club_tennis.Membres)
            {
                if (m.Naissance.Year - DateTime.Now.Year <= 18)
                {
                    c += NbMatchsPerdusParJoueur(m);
                }
            }
            return c;
        }
    }
}

  

