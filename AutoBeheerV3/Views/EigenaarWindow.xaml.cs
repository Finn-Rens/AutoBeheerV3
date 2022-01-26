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
using AutoBeheerV3.Data;

namespace AutoBeheerV3.Views
{
    /// <summary>
    /// Interaction logic for EigenaarWindow.xaml
    /// </summary>
    public partial class EigenaarWindow : Window
    {
        private EigenaarController _eigenaarController;

        private Eigenaar _eigenaar;
        public EigenaarWindow(EigenaarController eigenaarController, Eigenaar eigenaar)
        {
            InitializeComponent();

            _eigenaarController = eigenaarController;

            _eigenaar = eigenaar;

            this.DataContext = _eigenaar;
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_eigenaar.Id == 0)
                {
                    _eigenaarController.NieuwEigenaar(_eigenaar);
                }
                else 
                {
                    _eigenaarController.WijzigEigenaar(_eigenaar);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Er is een fout opgetreden {_eigenaar.Naam}");
            }

            this.Close();
        }

        private void btnSluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
