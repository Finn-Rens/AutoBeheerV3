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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using AutoBeheerV3.Data;
using AutoBeheerV3.Controllers;

namespace AutoBeheerV3.Views
{
    /// <summary>
    /// Interaction logic for EigenarenWindow.xaml
    /// </summary>
    public partial class EigenarenWindow : Window
    {
        private EigenaarController eigenaarController;   
        public EigenarenWindow()
        {
            InitializeComponent();

            eigenaarController = new EigenaarController();

            dgEigenaren.ItemsSource = eigenaarController.Eigenaars;
        }

        private void btnNieuwEigenaar_Click(object sender, RoutedEventArgs e)
        {
            Eigenaar eigenaar = new Eigenaar();

            EigenaarWindow eigenaarWindow = new EigenaarWindow(eigenaarController, eigenaar);

            eigenaarWindow.ShowDialog();
            
        }

        private void btnWijzigGebruiker_Click(object sender, RoutedEventArgs e)
        {
            if (dgEigenaren != null) 
            {
                EigenaarWindow eigenaarWindow = new EigenaarWindow(eigenaarController, (Eigenaar)dgEigenaren.SelectedItem);

                eigenaarWindow.ShowDialog();
            }
        }

        private void btnVerwijderGebruiker_Click(object sender, RoutedEventArgs e)
        {
            if (dgEigenaren != null)
            {
                eigenaarController.VerwijderEigenaar((Eigenaar)dgEigenaren.SelectedItem);
            }
        }
    }
}
