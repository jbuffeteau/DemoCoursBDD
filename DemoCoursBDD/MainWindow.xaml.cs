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
using DemoClassesMetier;
using DemoGstBdd;

namespace DemoCoursBDD
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        GstBdd gst;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBdd();
            lstCategories.ItemsSource = gst.GetLesCategories();

            txtNumCateg.Text = gst.GetMaxIdCateg().ToString();
        }

        private void lstCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstCategories.SelectedItem !=null)
            {
                lstJeux.ItemsSource = gst.GetLesJeuxByIdCategorie((lstCategories.SelectedItem as Categorie).NumeroCategorie);
            }
        }

        private void btnAjouterCategorie_Click(object sender, RoutedEventArgs e)
        {
            gst.InsertCategorie(Convert.ToInt16(txtNumCateg.Text), txtNomCateg.Text);

            txtNomCateg.Text = "";
            txtNumCateg.Text = gst.GetMaxIdCateg().ToString();
            lstCategories.ItemsSource = gst.GetLesCategories();
        }
    }
}
