using demo.Date;
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

namespace demo.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Login != null)
            {
                loginTB.Text = Properties.Settings.Default.Login;
            }
        }


        private void comeB_Click(object sender, RoutedEventArgs e)
        {
            var user = MainWindow.DB.User.FirstOrDefault(i=>i.Login==loginTB.Text&&i.Password==passwordTB.Text);
            if(user==null)
            {
                MessageBox.Show("Такого клиента не существует");
                return;
            }
            if (remember.IsChecked.GetValueOrDefault())
            {
                Properties.Settings.Default.Login = user.Login;
                Properties.Settings.Default.Save();
            }
            else 
            {
                Properties.Settings.Default.Login = null;
                Properties.Settings.Default.Save();
            }
            NavigationService.Navigate(new Pages.ViewClientPage());
        }
    }
}
