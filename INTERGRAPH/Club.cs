using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    public class Club : IClub
    {
        private static int numlicence = 10001; // Initialisation du numero de licence, ce nombre sera le numero de licence du premier membre

        public int Numlicence { get { return numlicence; } set { numlicence = value; } }

        private string nom;
        private DateTime creation;
        private List<Evenement> evenements;
        private List<Resultat> resultat_competition;
        private int montant_cotisation;
        private string adresse;
        private int code_postal;
        private List<Membre> membres;
        private List<Cours> planningCours;
        private List<Equipe> equipesCompet;

        public string Nom { get { return nom; } }
        public DateTime Creation { get { return creation; } }
        public List<Evenement> Evenements { get { return evenements; } }
        public List<Resultat> ResultatCompetition { get { return resultat_competition; } }
        public int MontantCotisation { get { return montant_cotisation; } }
        public string Adresse { get { return adresse; } }
        public int CodePostal { get { return code_postal; } }
        public List<Membre> Membres { get { return membres; } }
        public List<Cours> PlanningCours { get { return planningCours; } }
        public List<Equipe> EquipesCompet { get { return equipesCompet; } }



        public Club(string nom, DateTime creation, int montant_cotisation, string adresse, int code_postal)
        {
            this.nom = nom;
            this.creation = creation;
            this.montant_cotisation = montant_cotisation;
            this.adresse = adresse;
            this.code_postal = code_postal;
            membres = new List<Membre>();
            planningCours = new List<Cours>();
            evenements = new List<Evenement>();
            equipesCompet = new List<Equipe>();
            resultat_competition = new List<Resultat>();
           
        }

        public override string ToString()
        {
            return "Nom du club : " + nom + "\n  Date de création du club : " + creation + "\n Adresse : " + adresse + " " + code_postal + "\n Montant de la cotisation : " + montant_cotisation + "\n Nombre d'évènements cette saison : \n" + evenements.Count;
        }

        
        // PERMET D'AJOUTER UN MEMBRE A LA LISTE DES MEMBRES 
        public bool ajouterMembre(bool cotisationpayee, string nom, string prenom, DateTime naissance, string adresse, int code_postal, string numtel, TypeSex sexe, bool pratiqueCompete)  // permet d'ajouter un membre à un club renvoie true si cest fait false si il existe déjà
        {
            //pratiqueCompete définie si c'est loisir ou compétition
            Membre nouveau;
            bool ajout = true;

            if (!pratiqueCompete) nouveau = new MembreLoisir(nom, prenom, naissance, adresse, code_postal, numtel, sexe);
            else
            {
                Console.WriteLine("Classement :");
                string classement = Console.ReadLine();
                nouveau = new MembreCompete(classement, nom, prenom, naissance, adresse, code_postal, numtel, sexe);
            }
            for (int i = 0; i < membres.Count; i++)
            {
                if (nouveau.Numlicence == membres[i].Numlicence)
                {
                    ajout = false;
                }
            }
            if (ajout == true)
            {
                nouveau.Numlicence = numlicence;
                membres.Add(nouveau);
                numlicence++;
            }

            return ajout; // true si ajout réussi
        }

        public bool supprimerMembre(int numlicence) // permet de supprimer un membre du club renvoie false si la perosnne n'existe pas
        {
            bool supp = false;
            Membre asupp = membres.Find(x => x.Numlicence == numlicence);
            if (asupp != null)
            {
                membres.Remove(asupp);
                supp = true;
            }

            return supp; // return true si membre supprimé
        }
        public string AfficheLoisir()  // affiche les membres qui sont inscrits en loisir
        {
            String res="";
            for (int i = 0; i < membres.Count; i++)
            {
                if (membres[i] is MembreLoisir)  res += ((MembreLoisir)membres[i]).ToString() + "\n\n ";
            }

            return res;
        }
        public string AfficheCompet() // affiche les membres qui fnt de la competition
        {
            String res = "";
            for (int i = 0; i < membres.Count; i++)
            {
                if (membres[i] is MembreCompete) res += ((MembreCompete)membres[i]).ToString() + "\n\n";
            }
            return res;
        }

        public string AfficheAlphabet() // Affiche par ordre alphabetique (utilisation de l'interface Icomprable)
        {
            membres.Sort();
            String res = "";
            for (int i = 0; i < membres.Count; i++) res += membres[i].ToString() + "\n\n";

            return res;
        }
        public string AfficheClassement(string classement) // Affiche en fonction du classement du joueur
        {
            String res = "";
            for (int i = 0; i < membres.Count; i++)
            {
                if (membres[i] is MembreCompete && ((MembreCompete)membres[i]).Classement == classement)
                    res += ((MembreCompete)membres[i]).ToString() + "\n\n";
            }
            return res;
        }
        public string AfficheSexe(TypeSex t) // Affiche des membres par sexe
        {
            String res = "";
            List<Membre> bysexe = membres.FindAll(x => x.Sexe == t);
            for (int i = 0; i < bysexe.Count; i++) res += bysexe[i].ToString() + "\n\n";

            return res;
        }

        public string AfficheCotisPayee() // Affiche les membres dont la cotisation a ete payee
        {
            String res = "";
            List<Membre> paye = membres.FindAll(x => x.CotisationPayee == true);
            for (int i = 0; i < paye.Count; i++) res += paye[i].ToString() + "\n\n";

            return res;
        }
        public string AfficheCotisNonPayee() // Affiche les membres dont la cotisation n'a pas été payée
        {
            String res = "";
            List<Membre> nonpaye = membres.FindAll(x => x.CotisationPayee == false);
            for (int i = 0; i < nonpaye.Count; i++) res += nonpaye[i].ToString() + "\n\n";

            return res;
        }

        public delegate string Operation();
        public string AffichagePersonnalise(Operation o)
        {
           return o();
        }

        public void creerEquipe(Competition c, Membre cap, string niveau) // Crees une nouvelle equipe avec son capitaine et le niveau requis pour y etre
        {
            if (cap is MembreCompete || cap is Entraineur)
            {
                Equipe e = new Equipe(c, cap, niveau);
                equipesCompet.Add(e);
                e.IdEquipe = e.NumEquipe;
                e.NumEquipe++;
            }
        }

        public void AjouterMembreEquipe(Equipe e, Membre m) // Ajoute un membre à l'equipe e si il a le niveau requis
        {
            if (m is MembreCompete || m is Entraineur)
                if (m is MembreCompete)
                    if (((MembreCompete)m).Classement == e.Niveau)
                        (e.ParticipantCompet).Add(m);
        }
        public void AjoutEvenement(Evenement e) // AJOUTER UN EVENEMENT QUELCONQUE
        {
            evenements.Add(e);
        }

        public void inscriptionEvenement(Evenement e, Membre m) // Inscrit un membre à un evenement qu'il soit un stage, une competition ou un evenement quelconque
        {
            if (e is Stage)
            {
                if (m is MembreCompete)
                    if (((Stage)e).Niveau == ((MembreCompete)m).Classement) (e.Participant).Add(m);
            }

            if (e is CompetitionSimple)
            {
                if (m is MembreCompete)
                    if (((Competition)e).Niveau == ((MembreCompete)m).Classement) (e.Participant).Add(m);
            }
            else
            {
                (e.Participant).Add(m);
            }
        }

        // AFFICHE LE PLANNIG DES COURS
        public string AffichCours()
        {
            string s = "";
            foreach (Cours c in planningCours)
            {
                s += c.ToString() + "\n\n";
            }
            return s;
        }

        // AFFICHE LE PLANNING DES STAGES
        public string AffichStages()
        {
            string s = "";
          
                foreach (Evenement ev in evenements)
                {
                   
                    if (ev is Stage)
                    {
                        s += ((Stage)ev).ToString() + "\n\n";
                    }
                }
            
            return s;
        }

        // AFFICHE UN EVENEMENT QUELCONQUE
        public string AffichEvent()
        {
            string s = "";
            foreach (Evenement e in evenements)
            {
                if (e is Stage || e is Competition) s = s;
                else s += ((Evenement)e).ToString() + "\n\n";
            }
            return s;
        }

        // AFFICHE LA LISTE DE COMPETITIONS
        public string AffichCompete()
        {
            string s = "";
            foreach (Evenement e in evenements)
            {
                if (e is Competition) s += ((Competition)e).ToString() + "\n\n";
            }
            return s;
        }
    }
    
}
