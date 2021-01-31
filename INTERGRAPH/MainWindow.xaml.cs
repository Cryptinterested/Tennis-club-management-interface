using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Probleme_POO_DanielJEAN_MarwanMENAA;

namespace INTERGRAPH
{
  
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        // AJUSTEMENT POUR LES CHANPS VISIBLES ET INVISIBLES
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl) //Permet de reinitilaiser l'Espace Membre
            {
                membre_nom.Text = String.Empty; membre_prenom.Text = String.Empty; membre_licence.Text = String.Empty;

                affichage_niveau.Visibility = Visibility.Hidden;
                choix_niveau.Visibility = Visibility.Hidden;
                cls.Visibility = Visibility.Hidden;
                cls1.Visibility = Visibility.Hidden;
                cotiscompet.Visibility = Visibility.Hidden;
                cotis.Visibility = Visibility.Hidden;
                competitions.Visibility = Visibility.Hidden;
                competitions1.Visibility = Visibility.Hidden;
                cours.Visibility = Visibility.Hidden;
                cours_reserve.Visibility = Visibility.Hidden;
                //cours_planning.Text = String.Empty;
                option_affichage.Text = String.Empty;
                option_affichage2.Text = String.Empty;
                nom_cap.Text = String.Empty;
                prenom_cap.Text = String.Empty;
                licence_cap.Text = String.Empty;
                ajout_membre.Visibility = Visibility.Hidden;

                
                if (Administration.IsSelected == false)
                {
                    mot_de_passe.Visibility = Visibility.Visible;
                    affich_mdp.Visibility = Visibility.Visible;
                    admin.Visibility = Visibility.Visible;
                    mot_de_passe.Clear();
                    action_admin.Visibility = Visibility.Hidden;
                }
            }
        }
       
        
        // CREATION DU CLUB

        Club tennisclub = new Club("TENNIS CLUB LEONARD DE VINCI", new DateTime(01 / 09 / 2019), 60, "Avenue Leonard de Vinci", 92400);


        // METHODE PERMETTANT D'AJOUTER UN MEMBRE 
        #region
        private void Ajout_Membre(object sender, RoutedEventArgs e)
        {
            if (Nom.Text != "" && Prenom.Text != "" && Adresse.Text != "" && Code_Postal.Text != "" && tel.Text != "" && date_naiss.Text != "" && (H.IsChecked == true || F.IsChecked == true) && (Loisir.IsChecked == true || Competition.IsChecked == true))
            {
                if (date_naiss.SelectedDate < DateTime.Now)
                {
                    TypeSex s;
                    if (H.IsChecked == true) s = TypeSex.M;
                    else s = TypeSex.F;

                    Membre nouveau;
                    bool ajout = true;

                    if (Competition.IsChecked == true)
                    {
                        nouveau = new MembreCompete(choix_niveau.Text, Nom.Text, Prenom.Text, (DateTime)date_naiss.SelectedDate, Adresse.Text, Convert.ToInt32(Code_Postal.Text), tel.Text, s);

                        foreach (Membre elt in tennisclub.Membres)
                        {
                            if (elt.Equals(nouveau)) ajout = false;
                        }
                        if (ajout)
                        {
                            nouveau.Numlicence = tennisclub.Numlicence;
                            tennisclub.Membres.Add(nouveau);
                            tennisclub.Numlicence++;
                            MessageBox.Show("Bienvenue " + nouveau.Prenom + "\nVotre numéro de licence à conserver précieusement : " + nouveau.Numlicence);

                        }
                        else
                        {
                            membre_existe.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        nouveau = new MembreLoisir(Nom.Text, Prenom.Text, date_naiss.DisplayDate, Adresse.Text, Convert.ToInt32(Code_Postal.Text), tel.Text, s);

                        foreach (Membre elt in tennisclub.Membres)
                        {
                            if (elt.Equals(nouveau)) ajout = false;
                        }
                        if (ajout)
                        {
                            nouveau.Numlicence = tennisclub.Numlicence;
                            tennisclub.Membres.Add(nouveau);
                            tennisclub.Numlicence++;
                            MessageBox.Show("Bienvenue " + nouveau.Prenom + "\n\nVotre numéro de licence à conserver précieusement : " + nouveau.Numlicence);

                        }
                        else
                        {
                            membre_existe.Visibility = Visibility.Visible;
                        }
                    }
                }
                else { MessageBox.Show("Retour vers la futur ?? Vous n'êtes pas encore né ??"); }
                //liste_membre.Visibility = Visibility.Visible;
                int taille = tennisclub.Membres.Count;
                //liste_membre.Items.Add(tennisclub.Membres[taille - 1].Nom + " " + tennisclub.Membres[taille - 1].Prenom);
                H.IsChecked = false; F.IsChecked = false; Loisir.IsChecked = false; Competition.IsChecked = false; Champs_requis.Visibility = Visibility.Hidden;
                Nom.Text = String.Empty; choix_niveau.Text = String.Empty; Prenom.Text = String.Empty; date_naiss.Text = String.Empty; Adresse.Text = String.Empty; Code_Postal.Text = String.Empty; tel.Text = String.Empty;
                affichage_niveau.Visibility = Visibility.Hidden;
                choix_niveau.Visibility = Visibility.Hidden;
            }
            else Champs_requis.Visibility = Visibility.Visible;

        }
        #endregion

        // DEFINITION DES CLASSEMENT  
        string[] level = new string[] { "TOP 100", "NC", "40", "30/5", "30/4", "30/3", "30/2", "30/1", "30", "15/5", "15/4", "15/3", "15/2", "15/1", "15", "5/6", "4/6", "3/6", "2/6", "1/6", "0", "-2/6", "-4/6", "-15" };
        
        // DEFINITION DES NIVEAUX
        string[] niveau = new string[] { "Mondial", "Europe", "National", "Régional", "Départemental" };
        
        // PERMET DE RENDRE VISIBLE LE MENU DEROULANT POUR CHOISIR LE CLASSEMENT LORS DE L'INSCRIPTION
        private void Competition_Click(object sender, RoutedEventArgs e)
        {
            choix_niveau.Visibility = Visibility.Visible;
            affichage_niveau.Visibility = Visibility.Visible;
            for (int i = 0; i < level.Length; i++) choix_niveau.Items.Add(level[i]);

        }

        // PERMET DE CACHER LE MENU DEROULANT POUR CHOISIR LE CLASSEMENT LORS DE L'INSCRIPTION

        private void Loisir_Click(object sender, RoutedEventArgs e)
        {
            choix_niveau.Visibility = Visibility.Hidden;
            affichage_niveau.Visibility = Visibility.Hidden;
        }

        // DONNE ACCES A L'ESPACE ADMINISTRATIF IL FAUT UN CODE 
        #region
        private void acces_admin(object sender, RoutedEventArgs e)
        {
            if (mot_de_passe.Password == "tennis2020")
            {
                mot_de_passe.Visibility = Visibility.Hidden;
                affich_mdp.Visibility = Visibility.Hidden;
                admin.Visibility = Visibility.Hidden;
                mot_pass_incorrect.Visibility = Visibility.Hidden;

                AccesAdministratif();
            }
            else
            {
                mot_pass_incorrect.Visibility = Visibility.Visible;
            }
        }
        #endregion


        // GERE L'ACCES ADMINISTRATIF ET LE CHARGEMENT DES DIFFERENTS MENU DEROULANTS ET DONNEES
        #region
        private void AccesAdministratif()
        {
            action_admin.Visibility = Visibility.Visible;

            // Add les autres entraineurs
            List<Entraineur> l = new List<Entraineur>();
            l.Add(new EntraineurSalarie("45614655461", DateTime.Now, 5, 2000, "Eude", "Michel", DateTime.Now, "kdpozekdp", 44500, "0745120123", TypeSex.M));

            tennisclub.Evenements.Add(new CompetitionSimple(5, 2, "TOP 100", 2,"championnat", DateTime.Now ,DateTime.Now,"club",l));
            tennisclub.Evenements.Add(new CompetitionEquipe(5, 2, "TOP 100", 2, "championnat", DateTime.Now, DateTime.Now, "club", l));
            tennisclub.Membres.Add(new EntraineurSalarie("45614655461", DateTime.Now, 5, 2000, "Eude", "Michel", DateTime.Now, "kdpozekdp", 44500, "0745120123", TypeSex.M));
            tennisclub.Membres.Add(new EntraineurSalarie("8465161", DateTime.Now, 10, 2050, "Claude", "Dominique", DateTime.Now, "dizejbibibp", 92000, "0744654463", TypeSex.F));
            tennisclub.Membres.Add(new EntraineurSalarie("498456131", DateTime.Now, 15, 2500, "Celestin", "Francis", DateTime.Now, "fjzefjkbzdp", 56000, "0609940209", TypeSex.M));
            tennisclub.Membres.Add(new EntraineurSalarie("45485416163", DateTime.Now, 20, 4000, "Didier", "Blandin", DateTime.Now, "kvgezhjbns", 3330, "08465146513", TypeSex.M));
            tennisclub.Membres.Add(new EntraineurNonSalarie("789465132", DateTime.Now, 24, 7895, "Stephanie", "Chasube", DateTime.Now, "uyhzeijodmkl", 789451, "07894500", TypeSex.F));
            tennisclub.Membres.Add(new EntraineurNonSalarie("7985461322", DateTime.Now, 2, 1095, "Chang", "Li", DateTime.Now, "ftyguhijokl", 89451, "0778965123", TypeSex.M));
            tennisclub.Membres.Add(new EntraineurNonSalarie("7889465132", DateTime.Now, 74, 6045, "Sylvie", "Latouche", DateTime.Now, "dijozll", 20000, "0788995500", TypeSex.F));
            tennisclub.Membres.Add(new EntraineurNonSalarie("784651320", DateTime.Now, 31, 1054, "Fanta", "Dialo", DateTime.Now, "mdyuioz", 46301, "07789541", TypeSex.F));
            tennisclub.Membres.Add(new EntraineurNonSalarie("98465132", DateTime.Now, 7, 4562, "Malik", "Zitoune", DateTime.Now, "yuziedkoml", 59051, "078845132", TypeSex.M));
            tennisclub.Membres.Add(new EntraineurNonSalarie("7894561320.", DateTime.Now, 45, 4320, "Gaspard", "Tetard", DateTime.Now, "kéiuolmml", 13000, "0652014522", TypeSex.M));

            string c = "\n";
            for (int i = 0; i < tennisclub.PlanningCours.Count; i++)
                c += tennisclub.PlanningCours[i] + "\n";

            Label cours = new Label();
            cours.HorizontalAlignment = HorizontalAlignment.Center;
            cours.Margin = new Thickness(44, 119, 0, 0);
            //cours.Content = "Liste des cours :  " + c;
            Grid_Membre.Children.Add(cours);


            foreach (Membre ent in tennisclub.Membres)
            {
                if (ent is Entraineur)
                {
                    entraineur_associe.Items.Add(ent.Nom + " " + ent.Prenom);
                    entraineur_stage_associe.Items.Add(ent.Nom + " " + ent.Prenom);
                    entraineurs_event_associe.Items.Add(ent.Nom + " " + ent.Prenom);
                    liste_membre2.Items.Add(ent.Nom + " " + ent.Prenom);
                    encadrants.Items.Add(ent.Nom + " " + ent.Prenom);
                    // LES ENTRAINEURS NE PEUVENT ETRE QUE CAPITAINE DANS UNE EQUIPE
                    liste_membre_compete.Items.Add(ent.Nom + " " + ent.Prenom);
                }
                if (ent.CotisationPayee == false) membre_cotis.Items.Add(ent.Nom + " " + ent.Prenom);

            }

            foreach (Membre ent in tennisclub.Membres)
            {
                if (ent is MembreCompete)
                {// On n'ajoute que des competiteurs pas d'entraineurs
                    liste_membre2.Items.Add(ent.Nom + " " + ent.Prenom);
                    membre_equipe1.Items.Add(ent.Nom + " " + ent.Prenom);
                    membre_equipe2.Items.Add(ent.Nom + " " + ent.Prenom);
                    membre_equipe3.Items.Add(ent.Nom + " " + ent.Prenom);
                    membre_equipe4.Items.Add(ent.Nom + " " + ent.Prenom);
                    liste_membre_compete.Items.Add(ent.Nom + " " + ent.Prenom);
                }
            }

            foreach (Competition comp in tennisclub.Evenements)
            {
                if (comp is CompetitionEquipe)
                {
                    liste_competition.Items.Add(comp.Intitule + " , niveau : " + comp.Niveau);
                    liste_compete.Text += "Debut :" + comp.DateDebut + "\nFin :" + comp.DateFin + "\n" + comp.Intitule + "\nNiveau : " + comp.Niveau;

                }
            }

            stat_aff.Items.Add("Nombre de Compétitions réalisées");
            stat_aff.Items.Add("Nombre de Compétitions restants");
            stat_aff.Items.Add("Récapitulatif compétitions par joueur");
            stat_aff.Items.Add("Nombre moyen de joueurs par compétition");
            stat_aff.Items.Add("Récapitulatif matchs du club");
            stat_aff.Items.Add("Résultats des différentes catégories");

            option_affichage.Items.Add("Cotisation non payée");
            option_affichage.Items.Add("Membres Loisir");
            option_affichage.Items.Add("Membres Hommes");
            option_affichage.Items.Add("Membres Femmes");
            option_affichage.Items.Add("Cotisation payée");
            option_affichage.Items.Add("Tous membres a-z");
            option_affichage.Items.Add("Membres Competition");



            foreach (string s in level)
            {
                niveau_requis.Items.Add(s);
                option_affichage.Items.Add(s);
                niveau_requis_stage.Items.Add(s);
                niveau_equipe.Items.Add(s);
                level_comp.Items.Add(s);
            }
        }
        #endregion

        // PERMET D'AFFICHER LES INFORMATIONS SUR UN MEMBRE DANS SON ESPACE
        #region
        private void afficher_infos_membre(object sender, RoutedEventArgs e)
        {
            bool present = false;
            foreach (Membre elt in tennisclub.Membres)
            {
                if (elt.Nom == membre_nom.Text && elt.Prenom == membre_prenom.Text && elt.Numlicence == Convert.ToInt32(membre_licence.Text))
                {
                    if (elt is MembreCompete)
                    {
                        cls.Visibility = Visibility.Visible;
                        cls.Content = ((MembreCompete)elt).Classement;
                        cls1.Visibility = Visibility.Visible;


                        competitions.Visibility = Visibility.Visible;
                        competitions.Content =  ((MembreCompete)elt).NbCompetitionAFaire;
                        competitions1.Visibility = Visibility.Visible;


                        cotiscompet.Visibility = Visibility.Visible;
                        cotiscompet.Content = ((MembreCompete)elt).CotisationPayee;
                        cotis.Visibility = Visibility.Visible;
                        

                        cours.Visibility = Visibility.Visible;

                        cours_reserve.Visibility = Visibility.Visible;
                        foreach (Cours c in ((MembreCompete)elt).Reserves)
                        {
                            cours_reserve.Text += c.ToString() + "\n\n";
                        }

                        present = true;
                    }
                    else
                    {
                        cotiscompet.Visibility = Visibility.Visible;
                        cotiscompet.Content = ((MembreLoisir)elt).CotisationPayee;
                        cotis.Visibility = Visibility.Visible;
                        

                        cours.Visibility = Visibility.Visible;

                        cours_reserve.Visibility = Visibility.Visible;
                        foreach (Cours c1 in ((MembreLoisir)elt).Reserves)
                        {
                            cours_reserve.Text += c1.ToString() + "\n\n";
                        }
                        present = true;

                        cls.Visibility = Visibility.Hidden;
                        cls1.Visibility = Visibility.Hidden;
                        competitions.Visibility = Visibility.Hidden;
                        competitions1.Visibility = Visibility.Hidden;
                    }


                }

            }
            if (!present) MessageBox.Show("Vous n'ête pas membre ! \nChamps inaccessible");
        }
        #endregion

        // PERMET D'AJOUTER UN COURS A LA LISTE DES COURS DISPONIBLES DANS LE CLUB
        #region
        private void ajout_cours(object sender, RoutedEventArgs e)
        {
            Entraineur ent1 = null;

            foreach (Membre ent2 in tennisclub.Membres)
            {
                if (ent2 is Entraineur)
                    if (entraineur_associe.Text == ((Entraineur)ent2).Nom + " " + ((Entraineur)ent2).Prenom) ent1 = (Entraineur)ent2;
            }
            if (ent1 != null && niveau_requis.Text != "" && date_cours.SelectedDate != null && (DateTime)date_cours.SelectedDate > DateTime.Now)
            {
                Cours c = new Cours(Convert.ToDateTime(date_cours.SelectedDate), ent1, niveau_requis.Text);

                if (tennisclub.PlanningCours.Find(x => x.Responsable.Nom == c.Responsable.Nom && x.Responsable.Prenom == c.Responsable.Prenom && x.DateCours == c.DateCours) == null)
                {
                    tennisclub.PlanningCours.Add(c);
                    MessageBox.Show("Cours Ajouté !");
                    liste_cours_dispo.Items.Add(c.DateCours + " " + c.Niveau);
                }
                else
                {
                    MessageBox.Show("Impossible d'ajouter ce cours !");
                }

            }
            else MessageBox.Show("Champs requis, date non cohérente");
        }
        #endregion

        // PERMET D'AFFICHER LES LES MEMBRES SELON LEURS CARACTERISTIQUES
        #region
        private void Affichage_multiple(object sender, RoutedEventArgs e)
        {

            TextBox b = new TextBox();
            b.Margin = new Thickness(366, 44, 19, 22);
            b.Width = 477;
            b.Height = 307;
          

            if (option_affichage.Text == "Cotisation non payée")
            {
                option_affichage2.Text = tennisclub.AfficheCotisNonPayee();
            }
            if (option_affichage.Text == "Membres Loisir")
            {

                option_affichage2.Text = tennisclub.AfficheLoisir();
            }
            if (option_affichage.Text == "Membres Hommes")
            {

                option_affichage2.Text = tennisclub.AfficheSexe(TypeSex.M);
            }
            if (option_affichage.Text == "Membres Femmes")
            {

                option_affichage2.Text = tennisclub.AfficheSexe(TypeSex.F);
            }
            if (option_affichage.Text == "Cotisation payée")
            {

                option_affichage2.Text = tennisclub.AfficheCotisPayee();
            }
            if (option_affichage.Text == "Tous membres a-z")
            {

                option_affichage2.Text = tennisclub.AfficheAlphabet();
            }
            if (option_affichage.Text == "Membres Competition")
            {

                option_affichage2.Text = tennisclub.AfficheCompet();
            }
            if (option_affichage.Text == "TOP 100" || option_affichage.Text == "NC" || option_affichage.Text == "40" || option_affichage.Text == "30/5" || option_affichage.Text == "30/4" || option_affichage.Text == "30/3" || option_affichage.Text == "30/2" || option_affichage.Text == "30/1" || option_affichage.Text == "30" || option_affichage.Text == "15/5" || option_affichage.Text == "15/4" || option_affichage.Text == "15/3" || option_affichage.Text == "15/2" || option_affichage.Text == "15/1" || option_affichage.Text == "15" || option_affichage.Text == "5/6" || option_affichage.Text == "4/6" || option_affichage.Text == "3/6" || option_affichage.Text == "2/6" || option_affichage.Text == "1/6" || option_affichage.Text == "0" || option_affichage.Text == "-2/6" || option_affichage.Text == "-4/6" || option_affichage.Text == "-15")
            {
                option_affichage2.Text = tennisclub.AfficheClassement(option_affichage.Text);
            }

        }
        #endregion

        // PERMET D AFFICHER LES COURS DU PLANNING
        #region
        private void afficher_cours_planning(object sender, RoutedEventArgs e)
        {
            
            cours_planning.Text = tennisclub.AffichCours();
            //cours_prevu.Children.Add(cours_planning);

            date_cours.Text = String.Empty;
            entraineur_associe.Text = String.Empty;
            niveau_requis.Text = String.Empty;
        }
        #endregion

        // PERMET D AJOUTER UN STAGE AU PLANNING DES EVENEMENTS
        #region
        private void ajout_stage(object sender, RoutedEventArgs e)
        {
            Entraineur ent1 = null;
            List<Entraineur> l = new List<Entraineur>();

            foreach (Membre ent2 in tennisclub.Membres)
            {
                if (ent2 is Entraineur)
                    foreach (String s in entraineur_stage_associe.SelectedItems)
                    {
                        if (s == ((Entraineur)ent2).Nom + " " + ((Entraineur)ent2).Prenom)
                        {
                            ent1 = (Entraineur)ent2;
                            l.Add(ent1);
                        }
                    }

            }
            if (l != null && niveau_requis_stage.Text != "" && date_stage_debut.Text != "" && date_stage_fin.Text != "" && (DateTime)date_stage_debut.SelectedDate < (DateTime)date_stage_fin.SelectedDate )
            {
                if (date_stage_debut.Text == date_stage_fin.Text || date_stage_debut.SelectedDate > date_stage_fin.SelectedDate && date_stage_debut.SelectedDate > DateTime.Now && date_stage_fin.SelectedDate > DateTime.Now) MessageBox.Show("Les dates de début et de fin sont incompatibles !");
                else
                {


                    Stage c = new Stage(niveau_requis_stage.Text, 50, 5, "Preparation", Convert.ToDateTime(date_stage_debut.SelectedDate), Convert.ToDateTime(date_stage_fin.SelectedDate), "Club", l);

                    if (tennisclub.Evenements.Find(x => x.DateDebut == Convert.ToDateTime(date_stage_debut.SelectedDate) && ((Stage)x).Niveau == niveau_requis_stage.Text) == null)
                    {
                        tennisclub.Evenements.Add(c);
                        MessageBox.Show("Stage Ajouté !");
                        date_stage_debut.Text = String.Empty;
                        date_stage_fin.Text = String.Empty;
                        entraineur_stage_associe.SelectedValue = null;
                        niveau_requis_stage.Text = String.Empty;

                    }
                    else
                    {
                        MessageBox.Show("Impossible d'ajouter ce stage !");
                    }
                }

            }
            else MessageBox.Show("Champs manquants ou dates incompatibles !");
        }
        #endregion

        // PERMET D AFFICHER LES COURS DU PLANNING
        #region
        private void afficher_stage_planning(object sender, RoutedEventArgs e)
        {
            TextBox stage_planning = new TextBox();
            stage_planning.Margin = new Thickness(-305, -95, 152, -155);
            stage_planning.Text = tennisclub.AffichStages();
            stage_prevu.Children.Add(stage_planning);
        }
        #endregion

        // PERMET D AJOUTER UN EVENEMENT AU PLANNING DES EVENEMENTS
        #region
        private void ajout_event(object sender, RoutedEventArgs e)
        {
            Entraineur ent1 = null;
            List<Entraineur> l = new List<Entraineur>();

            foreach (Membre ent2 in tennisclub.Membres)
            {
                if (ent2 is Entraineur)
                    foreach (String s in entraineurs_event_associe.SelectedItems)
                        if (s == ((Entraineur)ent2).Nom + " " + ((Entraineur)ent2).Prenom)
                        {
                            ent1 = (Entraineur)ent2;
                            l.Add(ent1);

                        }
            }
            if (l != null && date_event_debut.SelectedDate < date_event_fin.SelectedDate && date_event_debut.SelectedDate > DateTime.Now && date_event_fin.SelectedDate > DateTime.Now) //.DayOfWeek == DayOfWeek.Saturday || (date_event_debut.SelectedDate).Day == DayOfWeek.Sunday || (date_event_fin.SelectedDate).Day == DayOfWeek.Saturday || (date_event_fin.SelectedDate).Day == DayOfWeek.Sunday)// On ne peut choisir que les week end à régler
            {
                Evenement evenemt = new Evenement(intitule.Text, Convert.ToDateTime(date_event_debut.SelectedDate), Convert.ToDateTime(date_event_fin.SelectedDate), lieu.Text, l);
                tennisclub.Evenements.Add(evenemt);
                MessageBox.Show("Tournoi Ajouté !");
                intitule.Text = String.Empty;
                lieu.Text = String.Empty;
                date_event_debut.Text = String.Empty;
                date_event_fin.Text = String.Empty;
                entraineurs_event_associe.SelectedValue = null;
            }
            else
            {
                MessageBox.Show("Impossible d'ajouter ce tournoi !");
            }
        }
        #endregion

        // PERMET D AFFICHER LES COURS DU PLANNING
        #region
        private void afficher_event_planning(object sender, RoutedEventArgs e)
        {
            TextBox event_planning = new TextBox();
            event_planning.Margin = new Thickness(-305, -95, 152, -155);
            event_planning.Text = tennisclub.AffichEvent();
            event_prevu.Children.Add(event_planning);
        }
        #endregion

        // VARIABLE QUI NOUS PERMETTRA DE D AJOUTER UN UN CAPITAINE POUR UNE COMPETITION PRECISE
        Competition c = null;

        // PERMET D AJOUTER UN CAPITAINE POUR UNE COMPETITION
        #region
        private void ajout_capitaine(object sender, RoutedEventArgs e)
        {
           
            if (niveau_equipe.Text != "" && liste_membre2.Text != "" && liste_competition.Text != "" )
            {
                List<Competition> lis = new List<Competition>();
                foreach (Evenement ev in tennisclub.Evenements)
                    if (ev is Competition) lis.Add((Competition)ev);
                Competition comp = lis.Find(x => x.Intitule + " , niveau : " + x.Niveau == liste_competition.Text && x.Niveau == niveau_equipe.Text);


                if (comp != null)
                {


                    Membre m = null;
                    foreach (Membre ent2 in tennisclub.Membres)
                    {
                        if ((ent2 is Entraineur || ent2 is MembreCompete) && liste_membre2.Text == ent2.Nom + " " + ent2.Prenom)
                        {
                            m = ent2;
                            if (m is MembreCompete && niveau_equipe.Text != ((MembreCompete)m).Classement && ((MembreCompete)m).Classement != niveau_equipe.Text)
                            {
                                MessageBox.Show("Niveau Capitaine et equipe incompatibles");
                            }
                            else MessageBox.Show("Capitaine ajouté !");


                        }
                    }
                    c = comp;
                    tennisclub.creerEquipe(comp, m, niveau_equipe.Text);
                }
                else MessageBox.Show("Niveau de l'athlète incompatible avec la compétition ");
            }
            else MessageBox.Show("Champs Manquants !");

        }
        #endregion

        // PERMET DE CREER UNE EQUIPE
        #region
        private void creer_equipe(object sender, RoutedEventArgs e)
        {
            bool capitaine = false;
            if (nom_cap.Text != "" && prenom_cap.Text != "" && licence_cap.Text != "")
            {
                foreach (Equipe eq in tennisclub.EquipesCompet)
                {
                    if (eq.Capitaine.Nom == nom_cap.Text && eq.Capitaine.Prenom == prenom_cap.Text && eq.Capitaine.Numlicence == Convert.ToInt32(licence_cap.Text))
                    {
                        ajout_membre.Visibility = Visibility.Visible;
                        capitaine = true;
                    }

                }
                if(!capitaine) MessageBox.Show("Vous n'êtes pas capitaine !");
            }
            else MessageBox.Show("Champs_requis Manquants !");
        }
        #endregion

        // PERMET D AJOUTER 4 MEMBRES A UNE EQUIPE CREEE
        #region
        private void ajout(object sender, RoutedEventArgs e)
        {

            Equipe equi = null;
            if (nom_cap.Text != "" && prenom_cap.Text != "" && licence_cap.Text != "")
            {
                foreach (Equipe eq in tennisclub.EquipesCompet)
                {
                    if (eq.Capitaine.Nom == nom_cap.Text && eq.Capitaine.Prenom == prenom_cap.Text && eq.Capitaine.Numlicence == Convert.ToInt32(licence_cap.Text))
                    {
                        equi = eq;
                    }
                }

                if (membre_equipe1.Text != "" && membre_equipe2.Text != "" && membre_equipe3.Text != "" && membre_equipe4.Text != "" && membre_equipe4.Text != membre_equipe3.Text && membre_equipe4.Text != membre_equipe2.Text && membre_equipe4.Text != membre_equipe1.Text && membre_equipe3.Text != membre_equipe2.Text && membre_equipe3.Text != membre_equipe1.Text && membre_equipe2.Text != membre_equipe1.Text && membre_equipe1.Text != nom_cap.Text + " " + prenom_cap.Text && membre_equipe2.Text != nom_cap.Text + " " + prenom_cap.Text && membre_equipe3.Text != nom_cap.Text + " " + prenom_cap.Text && membre_equipe4.Text != nom_cap.Text + " " + prenom_cap.Text)
                {
                    Membre m1 = tennisclub.Membres.Find(x => (x.Nom + " " + x.Prenom) == membre_equipe1.Text);
                    Membre m2 = tennisclub.Membres.Find(x => (x.Nom + " " + x.Prenom) == membre_equipe2.Text);
                    Membre m3 = tennisclub.Membres.Find(x => (x.Nom + " " + x.Prenom) == membre_equipe3.Text);
                    Membre m4 = tennisclub.Membres.Find(x => (x.Nom + " " + x.Prenom) == membre_equipe4.Text);

                    if (((MembreCompete)m1).Classement == c.ClassementMax && ((MembreCompete)m2).Classement == c.ClassementMax && ((MembreCompete)m3).Classement == c.ClassementMax && ((MembreCompete)m4).Classement == c.ClassementMax)
                    {
                        tennisclub.AjouterMembreEquipe(equi, m1);
                        tennisclub.AjouterMembreEquipe(equi, m2);
                        tennisclub.AjouterMembreEquipe(equi, m3);
                        tennisclub.AjouterMembreEquipe(equi, m4);

                        MessageBox.Show("Equipe n° " + equi.NumEquipe + " créée ! \n Gardez préciseusement ce numéro !");
                    }
                    else MessageBox.Show("Niveau de joueur insuffisant");
                }
                else MessageBox.Show("Membres indentiques ou champs manquants !");

            }
            
            else MessageBox.Show("Champs Capitaine Manquants !");
        }
        #endregion

        // PERMET A UN MEMBRE DE RESERVER UN COURS 
        #region
        private void reserver_cours(object sender, RoutedEventArgs e)
        {
            Cours cou = tennisclub.PlanningCours.Find(x => x.DateCours + " " + x.Niveau == liste_cours_dispo.Text);
            Membre m = tennisclub.Membres.Find(x => x.Nom + " " + x.Prenom == cours_nom.Text + " " + cours_prenom.Text && x.Numlicence == Convert.ToInt32(cours_licence.Text));

            if (cou != null && m != null)
            {

                m.Reserves.Add(cou);
                MessageBox.Show("Cours réservé !");
                cours_nom.Text = String.Empty;
                cours_prenom.Text = String.Empty;
                cours_licence.Text = String.Empty;


            }
            else MessageBox.Show("Reservation Impossible !");
        }
        #endregion

        // PERMET D AJOUTER UNE COMPEITION A LA LISTE DES COMPETITION
        #region
        private void ajout_comp(object sender, RoutedEventArgs e)
        {
            if (date_comp_debut.SelectedDate > DateTime.Now || date_comp_debut.SelectedDate > DateTime.Now  && date_comp_debut.SelectedDate != null && date_comp_fin.SelectedDate != null && date_comp_debut.SelectedDate > date_comp_fin.SelectedDate && intit_comp.Text != "" && level_comp.Text != "" && encadrants.SelectedItem != null)
            {
                List<Entraineur> l = new List<Entraineur>();
                foreach (Membre m in tennisclub.Membres)
                {
                    if (m is Entraineur)
                        foreach (String s in encadrants.Items)
                            if (s == m.Nom + " " + m.Prenom)
                            {
                                l.Add((Entraineur)m);
                            }
                }
                if (eq.IsChecked == true)
                {
                    
                    tennisclub.Evenements.Add(new CompetitionEquipe(4, Convert.ToDateTime(date_comp_fin.SelectedDate).Subtract(Convert.ToDateTime(date_comp_debut.SelectedDate)).Days, level_comp.Text, 4, intit_comp.Text,Convert.ToDateTime(date_comp_debut.SelectedDate), Convert.ToDateTime(date_comp_fin.SelectedDate), "Club leonard de vinci", l));
                }
                else
                {
                    tennisclub.Evenements.Add(new CompetitionSimple(4, Convert.ToDateTime(date_comp_fin.SelectedDate).Subtract(Convert.ToDateTime(date_comp_debut.SelectedDate)).Days, level_comp.Text, 4, intit_comp.Text, Convert.ToDateTime(date_comp_debut.SelectedDate), Convert.ToDateTime(date_comp_fin.SelectedDate), "Club leonard de vinci", l));
                }
                MessageBox.Show("Compétition ajoutée !");
                date_comp_debut.Text = String.Empty;
                date_comp_fin.Text = String.Empty;
                intit_comp.Text = String.Empty;
                level_comp.Text = String.Empty;
                indiv.IsChecked = false;
                eq.IsChecked = false;
                encadrants.SelectedValue = false;
            }
            else MessageBox.Show("Champs manquants ! \nOu date de compétition incompatible");

        }
        #endregion

        // AFFICHE LA LISTE DES COMPEITIONS
        #region
        private void aff_comp(object sender, RoutedEventArgs e)
        {
            liste_compete.Text = tennisclub.AffichCompete();
        }
        #endregion

        // PERMET D AFFICHER LES STATISTIQUES DU CLUB
        #region
        private void choix_stat_affich(object sender, RoutedEventArgs e)
        {
            Statistiques stat = new Statistiques(tennisclub);
            grid_stat.Children.Clear();
            grid_stat.Children.Add(stat_aff);
            grid_stat.Children.Add(val);


            if (stat_aff.Text == "Récapitulatif compétitions par joueur")
            {
                liste_membre_compete.Visibility = Visibility.Visible;
                stat_button.Visibility = Visibility.Visible;
                select_membre.Visibility = Visibility.Visible;
                grid_stat.Children.Add(liste_membre_compete);
                grid_stat.Children.Add(stat_button);
                grid_stat.Children.Add(select_membre);
            }
            else
            {

                liste_membre_compete.Visibility = Visibility.Hidden;
                stat_button.Visibility = Visibility.Hidden;
                select_membre.Visibility = Visibility.Hidden;

                if (stat_aff.Text == "Nombre de Compétitions réalisées")
                {
                    Label l = new Label();
                    l.Content = "Nombre de compétitions réalisées : " + stat.CompetitionsRealisees();
                    l.Margin = new Thickness(365, 129, 105, 189);
                    l.Height = 51;
                    l.Width = 300;
                    l.Visibility = Visibility.Visible;
                    grid_stat.Children.Add(l);

                }
                if (stat_aff.Text == "Nombre de Compétitions restants")
                {
                    Label l = new Label();
                    l.Content = "Nombre de compétitions restants : " + stat.CompetitionsRestantes();
                    l.Margin = new Thickness(365, 129, 105, 189);
                    l.Height = 51;
                    l.Width = 300;
                    grid_stat.Children.Add(l);

                }

                if (stat_aff.Text == "Nombre moyen de joueurs par compétition")
                {
                    Label l = new Label();
                    l.Content = "Nombre de joueurs moyen par compétition : " + stat.NbMoyenJoueursParCompet();
                    l.Margin = new Thickness(365, 129, 105, 189);
                    l.Height = 51;
                    l.Width = 300;
                    grid_stat.Children.Add(l);


                }
                if (stat_aff.Text == "Récapitulatif matchs du club")
                {
                    Label l1 = new Label(); l1.Margin = new Thickness(392, 66, 31, 253); l1.Content = "Compétitions gagnées en  " + DateTime.Now.Year + " : " + stat.NbMatchGagnesParAnnee(DateTime.Now.Year);
                    Label l2 = new Label(); l2.Margin = new Thickness(393, 157, 35, 162); l2.Content = "Compétitions perdues en  " + DateTime.Now.Year + " : " + stat.NbMatchPerdusParAnnee(DateTime.Now.Year);
                    Label l3 = new Label(); l3.Margin = new Thickness(392, 235, 36, 84); l3.Content = "Nombre Matchs joués  en  " + DateTime.Now.Year + " : " + (stat.NbMatchPerdusParAnnee(DateTime.Now.Year) + stat.NbMatchGagnesParAnnee(DateTime.Now.Year));
                   
                    grid_stat.Children.Add(l1);
                    grid_stat.Children.Add(l2);
                    grid_stat.Children.Add(l3);

                }
                if (stat_aff.Text == "Résultats des différentes catégories")
                {
                   
                    Label homme = new Label(); homme.Margin = new Thickness(494, 31, 201, 302); homme.Content = "Hommes";
                    Label femme = new Label(); femme.Margin = new Thickness(588, 31, 106, 293); femme.Content = "Femmes";
                    Label jeune = new Label(); jeune.Margin = new Thickness(681, 31, 10, 293); jeune.Content = "Jeunes";
                    homme.Width = 72;homme.Height = 29;
                    femme.Width = 72; femme.Height = 29;
                    jeune.Width = 72; jeune.Height = 29;


                    Label l1 = new Label(); l1.Margin = new Thickness(317, 83, 10, 236); l1.Content = "Compétitions gagnées : " + "                        "+stat.NbMatchsGagnesParJoueurParLesHommes() + "                         " + stat.NbMatchsGagnesParJoueurParLesFemmes() + "                         " + stat.NbMatchsGagnesParJoueurParLesJuniors();
                    Label l2 = new Label(); l2.Margin = new Thickness(317, 165, 10, 156); l2.Content = "Compétitions perdues : " + "                        " + stat.NbMatchsPerdusParJoueurParLesHommes() + "                         " + stat.NbMatchsPerdusParJoueurParLesFemmes() + "                         " + stat.NbMatchsPerdusParJoueurParLesJuniors();
                    Label l3 = new Label(); l3.Margin = new Thickness(317, 250, 10, 69); l3.Content = "Nombre Matchs joués  : " + "                        "+(stat.NbMatchsGagnesParJoueurParLesHommes() + stat.NbMatchsPerdusParJoueurParLesHommes()) + "                         " + (stat.NbMatchsGagnesParJoueurParLesFemmes() + stat.NbMatchsPerdusParJoueurParLesFemmes()) + "                         " + (stat.NbMatchsGagnesParJoueurParLesJuniors() + stat.NbMatchsPerdusParJoueurParLesJuniors());

                    grid_stat.Children.Add(l1);
                    grid_stat.Children.Add(l2);
                    grid_stat.Children.Add(l3);
                    grid_stat.Children.Add(homme);
                    grid_stat.Children.Add(femme);
                    grid_stat.Children.Add(jeune);
                }
            }
        }
        #endregion

        // PERMET D AFFICHER LES STATISTIQUES POUR CHAQUE MEMBRE COMPETITION DU CLUB
        #region
        private void stat_membre(object sender, RoutedEventArgs e)
        {
            Statistiques stat = new Statistiques(tennisclub);
            grid_stat.Children.Clear();
            liste_membre_compete.Visibility = Visibility.Visible;
            stat_button.Visibility = Visibility.Visible;
            select_membre.Visibility = Visibility.Visible;
            grid_stat.Children.Add(liste_membre_compete);
            grid_stat.Children.Add(stat_button);
            grid_stat.Children.Add(select_membre);
            grid_stat.Children.Add(stat_aff);
            grid_stat.Children.Add(val);

            Membre m = tennisclub.Membres.Find(x => liste_membre_compete.Text == x.Nom + " " + x.Prenom);
            Label l1 = new Label(); l1.Margin = new Thickness(427, 57, 69, 262); l1.Content = "Compétitions gagnées : " + stat.NbMatchsGagnesParJoueur(m);
            Label l2 = new Label(); l2.Margin = new Thickness(427, 144, 69, 177); l2.Content = "Compétitions perdues : " + stat.NbMatchsPerdusParJoueur(m);
            Label l3 = new Label(); l3.Margin = new Thickness(427, 229, 69, 90); l3.Content = "Nombre Matchs joués  : " + (stat.NbMatchsGagnesParJoueur(m)+stat.NbMatchsPerdusParJoueur(m));
            l1.Height = 43;l1.Width = 257;
            l2.Height = 40; l2.Width = 257;
            l3.Height = 40; l3.Width = 257;
            grid_stat.Children.Add(l1);
            grid_stat.Children.Add(l2);
            grid_stat.Children.Add(l3);
        }
        #endregion

        // PERMET AU MEMBRE ADMINISTRATIF DE CHANGER LA COTISATION D UN MEMBRE SI CELUI CI EST VENU PAYER 
        #region
        private void regler_cotis(object sender, RoutedEventArgs e)
        {
            List<string> cot = new List<string>();
            foreach(String s in membre_cotis.Items)
            {
                Membre m = tennisclub.Membres.Find(x => x.Nom + " " + x.Prenom == s);
                if (m != null)
                {
                    m.CotisationPayee = true;
                    cot.Add(s);
                }
            }
            foreach (String s in cot) membre_cotis.Items.Remove(s);
            MessageBox.Show("Cotisation réglée pour ce/ces membres");
            
        }
        #endregion
    }
}
