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
    /// Interaction logic for AutoWindow.xaml
    /// </summary>
    public partial class AutoWindow : Window
    {
        private AutoController _autoController;

        private Auto _auto;

        private EigenaarController _eigenaarController;

        public AutoWindow(AutoController autoController, EigenaarController eigenaarController, Auto auto)
        {
            InitializeComponent();

            _autoController = autoController;

            _auto = auto;

            _eigenaarController = eigenaarController;

            this.DataContext = _auto;
        }

        private int _errors = 0;
        public bool CanSave
        {
            get
            {
                return _errors == 0;
            }
        }

        private void txtPrijs_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                _errors++;
            }
            else
            {
                _errors--;
            }

            if (CanSave)
            {
                this.btnOpslaan.IsEnabled = true;
            }
            else
            {
                this.btnOpslaan.IsEnabled = false;
            }
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (_auto.Id == 0)
                {
                    _autoController.NieuwAuto(_auto);
                }
                else
                {
                    _autoController.WijzigAuto(_auto);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Er is een fout opgetreden {_auto.Kenteken} ");
            }

            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbEigenaar.ItemsSource = _eigenaarController.Eigenaars;
        }

    }
}
