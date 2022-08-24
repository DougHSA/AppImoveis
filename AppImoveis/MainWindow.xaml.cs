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

namespace AppImoveis
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new View.Aluguel());
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            if (GridPrincipal != null)
            {
                switch (index)
                {
                    case 0:
                        GridPrincipal.Children.Clear();
                        GridPrincipal.Children.Add(new View.Aluguel());
                        break;

                    case 1:
                        GridPrincipal.Children.Clear();
                        GridPrincipal.Children.Add(new View.Cadastro());
                        break;

                    case 2:
                        GridPrincipal.Children.Clear();
                        GridPrincipal.Children.Add(new View.Consulta());
                        break;

                    case 3:
                        GridPrincipal.Children.Clear();
                        //GridPrincipal.Children.Add(new Limites());

                        break;


                    case 4:
                        GridPrincipal.Children.Clear();
                        //GridPrincipal.Children.Add(new Login(3));
                        //GridPrincipal.Children.Add(new MenuBD());

                        break;

                    case 5:
                        logOff();
                        break;

                    default:
                        break;
                }
            }
        }

    public void logOff()
    {
        //Client.Dispose();
        this.Close();

    }

    private void MoveCursorMenu(int index)
    {
        TrainsitionigContentSlide.OnApplyTemplate();
        GridCursor.Margin = new Thickness(0, (0 + (100 * index)), 0, 0);
    }

}
}
