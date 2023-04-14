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
    /// Логика взаимодействия для VisitPage1xaml.xaml
    /// </summary>
    public partial class VisitPage1xaml : Page
    {
        Client clientContext;
        public VisitPage1xaml(Client clientContext)
        {
            InitializeComponent();
            this.clientContext = clientContext;
            visitDG.ItemsSource = MainWindow.DB.Visit.ToList().Where(item=>item.ClientId==clientContext.Id);
        }
        private void FilterDays()
        {
            var visits = MainWindow.DB.Visit.ToList().Where(item => item.ClientId == clientContext.Id);
            if (visitsCB.SelectedIndex == 0)
                visitDG.ItemsSource = visits.Where(item=>item.Date.DayOfWeek== DayOfWeek.Monday);
            if (visitsCB.SelectedIndex == 1)
                visitDG.ItemsSource = visits.Where(item => item.Date.DayOfWeek == DayOfWeek.Tuesday);
            if (visitsCB.SelectedIndex == 2)
                visitDG.ItemsSource = visits.Where(item => item.Date.DayOfWeek == DayOfWeek.Wednesday);
            if (visitsCB.SelectedIndex == 3)
                visitDG.ItemsSource = visits.Where(item => item.Date.DayOfWeek == DayOfWeek.Friday);
            if (visitsCB.SelectedIndex == 4)
                visitDG.ItemsSource = visits.Where(item => item.Date.DayOfWeek == DayOfWeek.Friday);
            if (visitsCB.SelectedIndex == 5)
                visitDG.ItemsSource = visits.Where(item => item.Date.DayOfWeek == DayOfWeek.Saturday);
            if (visitsCB.SelectedIndex == 6)
                visitDG.ItemsSource = visits.Where(item => item.Date.DayOfWeek == DayOfWeek.Sunday);
            if (visitsCB.SelectedIndex == 7)
                visitDG.ItemsSource = visits;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterDays();
        }
    }
}
