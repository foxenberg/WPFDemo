using demo.Date;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        Date.Client contextClient;
        List<Tag> ClientsTag = new List<Tag>();
        List<Tag> Tags = new List<Tag>();
        public AddClientPage(Client postClient)
        {
            InitializeComponent();
            genderCB.ItemsSource = MainWindow.DB.Gender.ToList();
            contextClient = postClient;
            this.DataContext = contextClient;
            var emails = MainWindow.DB.Client.ToList();

            ClientsTag = contextClient.ClientTag.Select(item => item.Tag).ToList();
            Tags = MainWindow.DB.Tag.ToList().Where(item => !ClientsTag.Any(t => t.Id == item.Id)).ToList();
            TagsFilter();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            EmailAddressAttribute emailAddress = new EmailAddressAttribute();
            if (nameTB.Text != "" && surnameTB.Text != "" &&
                patronymicTB.Text != "" && emailTB.Text != "" && phoneTB.Text != ""
                && dateBirthTB.Text != "" && genderCB.SelectedItem != null)/* && photoImg != null*/
            {
                if (Regex.IsMatch(phoneTB.Text, "^[0-9+-/(/)]{1,}$"))
                {
                    if (emailAddress.IsValid(emailTB.Text))
                    {
                        if (contextClient.Id == 0)
                        {

                            contextClient.AddedDate = DateTime.Today;
                            MainWindow.DB.Client.Add(contextClient);
                        }
                        MainWindow.DB.ClientTag.RemoveRange(contextClient.ClientTag);
                        foreach (var tag in ClientsTag)
                        {
                            MainWindow.DB.ClientTag.Add(new ClientTag() { ClientId = contextClient.Id, TagId = tag.Id });
                        }
                        MainWindow.DB.SaveChanges();
                        NavigationService.GoBack();

                    }
                    else MessageBox.Show("email неккоректный!");
                }
                else MessageBox.Show("Неккоректный номер телефона!");
            }
            else MessageBox.Show("Введите все данные!");
        }

        private void surnameTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsLetter(e.Text, 0))) e.Handled = true;
        }

        private void nameTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsLetter(e.Text, 0))) e.Handled = true;
        }

        private void patronymicTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsLetter(e.Text, 0))) e.Handled = true;
        }

        private void emailTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //EmailAddressAttribute emailAttribute = new EmailAddressAttribute();
            //foreach (var email in MainWindow.DB.Client.ToList())
            //{
            //    if (!emailAttribute.IsValid(email.Email))
            //        e.Handled = true;

            //}
        }

        private void phoneTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)) && (e.Text != ")") && (e.Text != "(") && (e.Text != "-") && (e.Text != "+")) e.Handled = true;
        }

        private void SearchImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg"
            };
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextClient.Photo = File.ReadAllBytes(dialog.FileName);
                photoImg.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }




        private void idSP_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (contextClient.Id == 0)
            {
                idSP.Visibility = Visibility.Hidden;
            }
            else
                idSP.Visibility = Visibility.Visible;
        }

        private void LVClientTag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tag selectedTag = ((DataGrid)sender).SelectedItem as Tag;
            if (selectedTag == null) return;
            ClientsTag.Remove(selectedTag);
            Tags.Add(selectedTag);
            TagsFilter();
        }

        private void LVTag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tag selectedTag = ((DataGrid)sender).SelectedItem as Tag;
            if (selectedTag == null) return;
            Tags.Remove(selectedTag);
            ClientsTag.Add(selectedTag);
            TagsFilter();
        }
        private void TagsFilter()
        {
            LVClientTag.ItemsSource = null;
            LVClientTag.ItemsSource = ClientsTag;
            LVTag.ItemsSource = null;
            LVTag.ItemsSource = Tags;
        }
        //public partial class Client
        //{
        //    public DateTime LastDateVisit
        //    {
        //        get
        //        {
        //            DateTime time = new DateTime();
        //            foreach (var item in Visit)
        //            {
        //                if (item.Date > time)
        //                {
        //                    time = item.Date;
        //                }
        //            }
        //            return time;
        //        }
        //    }
        //    public int CountOfVisit
        //    {
        //        get { return Visit.Count; }
        //    }
        //}
    }
}
