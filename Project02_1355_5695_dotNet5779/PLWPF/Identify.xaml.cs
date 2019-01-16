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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Identify.xaml
    /// </summary>
    public partial class Identify : Window
    {
        public Identify()
        {
            InitializeComponent();
        }

        
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            string id = txtID.Text;
            if (BL.FactorySingletonBL.Current.GetTester(id) != null)
            {
                //Identify identify = new Identify();
                //identify.Show();
                MessageBox.Show("tester");

            }
            else if (BL.FactorySingletonBL.Current.GetTrainee(id) != null)
            {
                //Identify identify = new Identify();
                //identify.Show();
                MessageBox.Show("trainee");

            }

            else
            {
                MessageBox.Show("not exist in the program");
            }
        }

        private void txtID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtID.Text != null)
            {
                btnOK.IsEnabled = true;
            }
                 
        }
    }
}
