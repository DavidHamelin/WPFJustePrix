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

namespace TP_JustePrix
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int randomed;
        int numberTry;

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    NewGame();
        //}

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            int pickedNumber = PickANumber();

            if (pickedNumber != randomed)
            {
                pickedNumber = TryAgain(pickedNumber);
            }
            else
            {
                YouWin();
            }
        }

        void YouWin()
        {
            TextInfo.Text = "BRAVO tu as gagné !";
            TextInfo.FontSize += 10;
        }

        int PickANumber()
        {
            string picked = UserAnswer.Text;
            int pickedNumber;
            bool isNumber = int.TryParse(picked, out pickedNumber);
            if (isNumber == false)
            {
                TextInfo.Text = "Oops, il ne s'agit pas d'un nombre... Essaie encore !";
            }
            else
            {
                TextInfo.Text = string.Empty;
            }
            return pickedNumber;
        }

        private void TryAgain_Click(object sender, RoutedEventArgs e)
        {
            TextInfo.FontSize -= 10;
            NewGame();
        }

        void NewGame()
        {
            randomed = RandomPrice();
            TextInfo.Text = string.Empty;
            UserAnswer.Text = string.Empty;
            numberTry = 0;
            TryCounterUpdate();
        }

        int RandomPrice()
        {
            return new Random().Next(1, 51);
        }

        void TryCounterUpdate()
        {
            Counter.Text = "Nombre d'essais : " + numberTry;
        }
        
        int TryAgain(int pickedNumber)
        {
            if (pickedNumber > 0 && pickedNumber < 51)
            {
                if (pickedNumber > randomed)
                {
                    TextInfo.Text = "C'est trop grand !";
                }
                else if (pickedNumber < randomed)
                {
                    TextInfo.Text = "C'est trop petit !";
                }
            }
            else
            {
                TextInfo.Text = "Erreur ! Essayer de saisir un nombre entre 1 et 50 ";
            }
            
            numberTry += 1;
            TryCounterUpdate();
            return pickedNumber;
        }
    }
}
