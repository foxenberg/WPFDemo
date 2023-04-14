using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Логика взаимодействия для ViewClientPage.xaml
    /// </summary>
    public partial class ViewClientPage : Page
    {
        int actualPage;
        public ViewClientPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow.DB = new Date.CompanyDBEntities();
            clientsDG.ItemsSource = MainWindow.DB.Client.ToList();
            var genderList = MainWindow.DB.Gender.ToList();
            genderCB.ItemsSource = genderList;
            genderList.Insert(0, new Date.Gender() { Name="Все"});
            genderCB.SelectedIndex = 0;
            pageCB.SelectedIndex = 0;
            pageCB.ItemsSource = new List<string> { "Все","10","50","200"};
            Filters();
        }
        

        private void Filters()
        {
            var filterClients =(IEnumerable <Date.Client>) MainWindow.DB.Client;
            if (!string.IsNullOrWhiteSpace(surnameFilter.Text))
            {
                var search = surnameFilter.Text.ToLower();
                filterClients = filterClients.Where(item => item.Lastname.ToLower().Contains(search)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(nameFilter.Text))
            {
                var search = nameFilter.Text.ToLower();
                filterClients = filterClients.Where(item => item.Firstname.ToLower().Contains(search)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(patronymicFilter.Text))
            {
                var search = patronymicFilter.Text.ToLower();
                filterClients = filterClients.Where(item => item.Patronymic.ToLower().Contains(search)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(phoneFilter.Text))
            {
                var search = phoneFilter.Text.ToLower();
                filterClients = filterClients.Where(item => item.PhoneNumber.ToLower().Contains(search)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(emailFilter.Text))
            {
                var search = emailFilter.Text.ToLower();
                filterClients = filterClients.Where(item => item.Email.ToLower().Contains(search)).ToList();
            }
            if (genderCB.SelectedIndex > 0)
            {
                var search = genderCB.SelectedItem as Date.Gender;
                filterClients = filterClients.Where(item => item.GenderId == search.Id).ToList();
            }
            if (pageCB.SelectedIndex > 0 && filterClients.Count() > 0)
            {
                int itemsOnPage = Convert.ToInt32(pageCB.SelectedItem);
                filterClients = filterClients.Skip(itemsOnPage * actualPage).Take(itemsOnPage);
                if (filterClients.Count() == 0)
                {
                    actualPage--;
                    Filters();
                    return;
                }
            }
            if(birthCB.IsChecked==true)
            {
                filterClients = filterClients.Where(item => item.BirthDate.Month==DateTime.Now.Month);
            }
            clientsDG.ItemsSource = filterClients.ToList();
            ItemCount.Text = $"{filterClients.Count()}/{MainWindow.DB.Client.Count()}";

        }
        private void pageCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PagesFilter();
        }

        private void genderCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filters();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.AddClientPage(new Date.Client() { BirthDate = DateTime.Today }));
        }

        private void nameFilter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsLetter(e.Text, 0))) e.Handled = true;
        }

        private void surnameFilter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsLetter(e.Text, 0))) e.Handled = true;
        }

        private void patronymicFilter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsLetter(e.Text, 0))) e.Handled = true;
        }

        private void phoneFilter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0))) e.Handled = true;
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedClient = clientsDG.SelectedItem as Date.Client;
            if (selectedClient == null) return;
            clientsDG.ItemsSource = null;
            NavigationService.Navigate(new AddClientPage(selectedClient));
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedClient = clientsDG.SelectedItem as Date.Client;
            if (selectedClient == null) return;
            if (selectedClient.VisitsCount== 0)
            {
                MainWindow.DB.Client.Remove(selectedClient);
                MainWindow.DB.SaveChanges();
                Filters();
            }
            else MessageBox.Show("Невозможно удалить");
            
        }

        private void nameFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualPage = 0;
            Filters();
        }

        private void patronymicFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualPage = 0;
            Filters();
        }

        private void surnameFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualPage = 0;
            Filters();
        }

        private void phoneFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualPage = 0;
            Filters();
        }

        private void emailFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualPage = 0;
            Filters();
        }
        private void PagesFilter()
        {
            actualPage = 0;
            Filters();
        }

        private void rightBtn_Click(object sender, RoutedEventArgs e)
        {
            actualPage++;
            Filters();
        }

        private void leftBtn_Click(object sender, RoutedEventArgs e)
        {
            actualPage--;
            if (actualPage < 0) actualPage = 0;
            Filters();
        }

        private void birthCB_Checked(object sender, RoutedEventArgs e)
        {
            Filters();
        }

        private void birthCB_Unchecked(object sender, RoutedEventArgs e)
        {
            Filters();
        }

        private void visitBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedClient = clientsDG.SelectedItem as Date.Client;
            if (selectedClient == null)
            {
                MessageBox.Show("Выберите клиента!");
                return;
            }
            if (selectedClient.VisitsCount == 0) MessageBox.Show("У данного клиента нет информации о посещении!");
            else
            {
                NavigationService.Navigate(new Pages.VisitPage1xaml(selectedClient));
            }
          
        }
    }
}
