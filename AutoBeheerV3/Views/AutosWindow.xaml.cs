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
using AutoBeheerV3.Controllers;
using System.Security.Principal;
using System.Threading;
using AutoBeheerV3.Data;

namespace AutoBeheerV3.Views
{
    /// <summary>
    /// Interaction logic for AutosWindow.xaml
    /// </summary>
    public partial class AutosWindow : Window
    {
        private AutoController autoController;

        private EigenaarController eigenaarController;

        public AutosWindow()
        {
            InitializeComponent();

            autoController = new AutoController();

            eigenaarController = new EigenaarController();

            dgAutos.ItemsSource = autoController.Autos;

            IPrincipal principal = Thread.CurrentPrincipal;
        }

        
        private void btnNieuwAuto_Click(object sender, RoutedEventArgs e)
        {
            Auto auto = new Auto();

            auto.Bouwjaar = DateTime.Now;
            auto.Prijs = 0;

            AutoWindow autoWindow = new AutoWindow(autoController, eigenaarController, auto);

            autoWindow.ShowDialog();
        }

        private void btnVerwijderAuto_Click(object sender, RoutedEventArgs e)
        {
            if (dgAutos.SelectedItem != null) 
            {
                autoController.VerwijderAuto((Auto)dgAutos.SelectedItem); 
            }
        }

        private void btnWijzigenAuto_Click(object sender, RoutedEventArgs e)
        {
            if (dgAutos.SelectedItem != null) 
            {
                AutoWindow autoWindow = new AutoWindow(autoController, eigenaarController, (Auto)dgAutos.SelectedItem);

                autoWindow.ShowDialog();
            } 
        }

        private void btnEigenaar_Click(object sender, RoutedEventArgs e)
        {
            EigenarenWindow eigenarenWindow = new EigenarenWindow();

            eigenarenWindow.ShowDialog();
        }
    }
}
