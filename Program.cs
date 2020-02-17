using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;

namespace finalProjet1
{
    class Program
    {
        
static void Main(string[] args)
{
    // À la création de l'instance de chiffrage, la clé et le IV sont également créés
    TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();

    byte[] iv = TDES.IV;
    byte[] key = TDES.Key;
    string cheminA = "";
    //C:\Users\joperec\Desktop\cooldoc.txt
    string text;

    Console.WriteLine("voulez entrer un texte ou definir un chemin d acces vers un fichier text a crypter? 1 ou 2");
    int choix;
    choix = int.Parse(Console.ReadLine());
    if (choix == 1)
    {
        Console.WriteLine("Entrez votre texte");
        text = Console.ReadLine();
    }
    else
    {
    
        Console.WriteLine("Entrez votre chemin d acces");
        cheminA = Console.ReadLine();
    // creation d'un streamReader pour charger un fichier texte
        StreamReader sr = new StreamReader(cheminA);
        text = sr.ReadToEnd();
        //Console.WriteLine(text);
        //Console.ReadKey();
    
    }

   

    


  //  string text = "texte en clair";

    Console.WriteLine("Mon texte en clair : {0}", text);

    // La même clé et le même IV sont utilisés pour le chiffrage et le déchiffrage
    byte[] cryptedTextAsByte = Crypt(text, key, iv);

    Console.WriteLine("Mon texte chiffré : {0}", Convert.ToBase64String(cryptedTextAsByte));

    String decryptedText = Decryp(cryptedTextAsByte, key, iv);

    Console.WriteLine("Mon texte déchiffré : {0}", decryptedText);
    Console.ReadLine();
}

static byte[] Crypt(string text, byte[] key, byte[] iv)
{
    byte[] textAsByte = Encoding.Default.GetBytes(text);

    TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();

    // Cet objet est utilisé pour chiffrer les données.
    // Il reçoit en entrée les données en clair sous la forme d'un tableau de bytes.
    // Les données chiffrées sont également retournées sous la forme d'un tableau de bytes
    var encryptor = TDES.CreateEncryptor(key, iv);

    byte[] cryptedTextAsByte = encryptor.TransformFinalBlock(textAsByte, 0, textAsByte.Length);

    return cryptedTextAsByte;
}

static string Decryp(byte[] cryptedTextAsByte, byte[] key, byte[] iv)
{
    TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();

    // Cet objet est utilisé pour déchiffrer les données.
    // Il reçoit les données chiffrées sous la forme d'un tableau de bytes.
    // Les données déchiffrées sont également retournées sous la forme d'un tableau de bytes
    var decryptor = TDES.CreateDecryptor(key, iv);

    byte[] decryptedTextAsByte = decryptor.TransformFinalBlock(cryptedTextAsByte, 0, cryptedTextAsByte.Length);

    return Encoding.Default.GetString(decryptedTextAsByte);
}


        
    }
}
