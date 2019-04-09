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
using System.Media;

namespace JeuDuJustePrix_1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //1 mettre le using System.Media; __ 2Double clic sur ressources.resx dans l'explorateur de solution(une page va s'ouvrir) __ 3clic sur ajouter une ressources et ajouter un fichier existant___ 4une fois le fichier voulu selectionné fermer la fenetre pour l'ajouter a la ressource
        System.Media.SoundPlayer Highlander = new System.Media.SoundPlayer(JeuDuJustePrix_1.Properties.Resources.Highlander);

        int attempt;
        //Déclaration du compteur (en dehors des méthodes pour qu'il ne se réinitialise pas à 0 à chaque clic)
        //int counter = 0;
        //Déclaration de random pour générer le nombre aléatoire
        private Random random = new Random();
        //Déclaration de numberToFind (en dehors des méthodes pour qu'il soit accessible dans toutes les méthodes)
        private int numberToFind = 0;

        public MainWindow()
        {
            InitializeComponent();
            //Attribution du nomberToFind aléatoire compris entre 1 et 50 (+1 exclus)
            numberToFind = random.Next(1, 50) + 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    int userNombresEssais = int.Parse(TextBox.Text);
            //    if (userNombresEssais > 0 && userNombresEssais < 51) //vérification que le nombre est bien entre 1 et 50
            //    {
            //        counter++; //incémentation du compteur d'essais
            //        if (userNombresEssais > numberToFind) //si l'entrée de l'utilisateur est supérieur au nombre....
            //        {
            //            //MessageBox.Show("C'est moins !", "Le nombre juste !"); //pour que sa s'affiche dans une autre fenetre
            //            resultMessage.Text = "C'est moins !";//pour que je l'affiche directement sur ma page dans la Textbox
            //        }
            //        else if (userNombresEssais < numberToFind) //sinon l'entrée de l'utilisateur est inférieur au nombre....
            //        {
            //            //MessageBox.Show("C'est plus !", "Le nombre juste !");
            //            resultMessage.Text = "C'est plus !";
            //        }
            //        else //sinon c'est gagné avec affichage du nombre de tentatives!
            //        {
            //            MessageBox.Show($"Vous avez gagné en {counter} essais !", "Le nombre juste !");
            //            resultMessage.Text = "Bravo, vous avez gagné !";
            //        }

            //        UpdateTry();
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Erreur de saisie détectée", "Erreur", MessageBoxButton.OK);//pour affiché message d'erreur si c'est pas des chiffres
            //}
            //void UpdateTry()
            //{
            //    NombresEssais.Text = ($"Vous étes à {counter} essais !"); //au début de la page d'accueil j'ai mis "nombres d'essais à: 0"
            //}
            int number;
            if(int.TryParse(TextBox.Text, out number))
            {
                attempt++;
                if (number > numberToFind)
                {
                    resultMessage.Text = "C'est moins !";//pour que je l'affiche directement sur ma page dans la Textbox
                }
                else if (number < numberToFind)
                {
                    resultMessage.Text = "C'est plus !";
                }
                else
                {
                    Highlander.Play();
                    resultMessage.Text = $"Bravo, vous avez gagné en {attempt} essais!";
                    MessageBox.Show($"Vous avez gagné en {attempt} essais !", "Le nombre juste !");
                }
            }
            else
            {
                MessageBox.Show("Erreur de saisie détectée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
                NombresEssais.Text = ($"Vous étes à {attempt} essais !"); //au début de la page d'accueil j'ai mis "nombres d'essais à: 0"
        }

    }
}
