using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    public enum TypeSex { M,F}

    public abstract class Personne
    {
        private string nom;
        private string prenom;
        private DateTime naissance;
        private string adresse;
        private int code_postal;
        private string numtel;
        private TypeSex sexe;

        public string Nom { get { return nom; } }
        public string Prenom { get { return prenom; } }
        public DateTime Naissance { get { return naissance; } }
        public string Adresse { get { return adresse; } set { adresse = value; } } 
        public int CodePostal { get { return code_postal; } set { code_postal = value; } } 
        public string NumTel { get { return numtel; } set { numtel = value; } }
        public TypeSex Sexe { get { return sexe; } }

        public Personne(string nom, string prenom, DateTime naissance, string adresse, int code_postal, string numtel, TypeSex sexe)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.naissance = naissance;
            this.adresse = adresse;
            this.code_postal = code_postal;
            this.numtel = numtel;
            this.sexe = sexe;
        }

        public override string ToString()
        {
            return " Nom : " + nom + "\n Prénom : " + prenom + "\n Sexe : "+ sexe +"\n Date de naissance : " + naissance + "\n Adresse " + adresse + " " + code_postal + "\n Numéro de Téléphone : " + numtel;
        }
    }
}
