using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TrouverMot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Chargement du dictionnaire
            var dictionnaire = ChargerDictionnaire("dictionnaire.txt");

            // Traitement des mots
            foreach (var motMelange in args)
            {
                var motTrouve = TrouverMot(motMelange, dictionnaire);
                if (motTrouve != null)
                {
                    Console.WriteLine($"{motMelange} correspond à {motTrouve}");
                }
                else
                {
                    Console.WriteLine($"{motMelange} : aucune correspondance trouvée");
                }
            }
        }

        static string TrouverMot(string motMelange, Dictionary<string, string> dictionnaire)
        {
            // Tri des lettres du mot mélangé
            var lettresTriees = motMelange.ToCharArray().OrderBy(c => c);
            var motTrié = new string(lettresTriees);

            // Recherche du mot dans le dictionnaire
            if (dictionnaire.TryGetValue(motTrié, out var motTrouve))
            {
                return motTrouve;
            }

            return null;
        }

        static Dictionary<string, string> ChargerDictionnaire(string fichierDictionnaire)
        {
            var dictionnaire = new Dictionary<string, string>();
            using (var reader = new StreamReader(fichierDictionnaire))
            {
                while (!reader.EndOfStream)
                {
                    var ligne = reader.ReadLine();
                    var mots = ligne.Split(';');
                    dictionnaire.Add(mots[0], mots[1]);
                }
            }

            return dictionnaire;
        }
    }
}
