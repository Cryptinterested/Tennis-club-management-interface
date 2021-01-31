using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    interface IClub
    {
        bool ajouterMembre(bool cotisationpayee, string nom, string prenom, DateTime naissance, string adresse, int code_postal, string numtel, TypeSex sexe, bool pratiqueCompete); // permet d'ajouter un membre à un club renvoie true si cest fait false si il existe déjà
        bool supprimerMembre(int numlicence); // permet de supprimer un membre du club renvoie false si la perosnne n'existe pas
        string AfficheLoisir(); // affiche les membres qui sont inscrits en loisir
        string AfficheCompet(); // affiche les membres qui fnt de la competition
        string AfficheAlphabet(); // Affiche par ordre alphabetique (utilisation de l'interface Icomprable)
        string AfficheClassement(string classement); // Affiche en fonction du classement du joueur
        string AfficheSexe(TypeSex t); // Affiche des membres par sexe

        string AfficheCotisPayee(); // Affiche les membres dont la cotisation a ete payee
        string AfficheCotisNonPayee(); // Affiche les membres dont la cotisation n'a pas été payée

    }
}
