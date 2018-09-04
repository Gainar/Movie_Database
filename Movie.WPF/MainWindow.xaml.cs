using System.Windows;
using System.Windows.Controls;
using Movie.Core.Models;
using Movie.Proxy.Proxy;

namespace Movie.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
            Year.Visibility = Visibility.Hidden;
            YearL.Visibility = Visibility.Hidden;
            ChangeVisible(Visibility.Hidden);
            ViewWindow.Visibility = Visibility.Hidden;
            Delete.Visibility = Visibility.Hidden;
            Edit.Visibility = Visibility.Hidden;
        }

        private async void View_Click(object sender, RoutedEventArgs e)
        {
            #region Initialization    
            ViewWindow.Items.Clear();
            ViewWindow.Visibility = Visibility.Visible;
            Year.Visibility = Visibility.Hidden;
            YearL.Visibility = Visibility.Hidden;
            ChangeVisible(Visibility.Hidden);

            #endregion
            var desktopRepo = new Desktop();
            var x = await desktopRepo.View();
            
            foreach (var item in x)
            {
                if (item.Title.Trim().Length > 8)
                {
                    ViewWindow.Items.Add(item.Title.Trim() + "\t" + item.Year + "\t" + item.Genre.Trim() + "\t" + item.Type.Trim() + "\t" + item.Rating + "\t" + item.Name.Trim());
                }
                else
                {
                    ViewWindow.Items.Add(item.Title.Trim() + "\t\t" + item.Year + "\t" + item.Genre.Trim() + "\t" + item.Type.Trim() + "\t" + item.Rating + "\t" + item.Name.Trim());
                }
            }
        }

        private void PAdd_Click(object sender, RoutedEventArgs e)
        {
            #region Initialization

            ViewWindow.Visibility = Visibility.Hidden;
            Year.Visibility = Visibility.Visible;
            YearL.Visibility = Visibility.Visible;
            ChangeVisible(Visibility.Visible);
            PAdd.Visibility = Visibility.Hidden;
            MessageBox.Show("Enter informations.");
            #endregion

        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {

            var mov = new MovieCreator()
            {
                Title = Title.Text,
                Year = int.Parse(Year.Text),
                Genre = Genre.Text,
                Type = Type.Text,
                Rating = int.Parse(Rating.Text),
                Name = Name.Text
            };
            var desktopRepo = new Desktop();
            desktopRepo.Add(mov);
            PAdd.Visibility = Visibility.Visible;
            Year.Visibility = Visibility.Hidden;
            YearL.Visibility = Visibility.Hidden;
            ChangeVisible(Visibility.Hidden);
            ViewWindow.Items.Clear();
            View_Click(sender, e);

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ViewWindow.Visibility = Visibility.Hidden;
            PAdd.Visibility = Visibility.Visible;
            Delete.Visibility = Visibility.Hidden;
            Edit.Visibility = Visibility.Hidden;
            Year.Visibility = Visibility.Hidden;
            YearL.Visibility = Visibility.Hidden;
            ChangeVisible(Visibility.Hidden);

        }

        private  void Delete_Click(object sender, RoutedEventArgs e)
        {
            var x = ViewWindow.SelectedItem.ToString().Split('\t');
            var desktopRepo = new Desktop();
            desktopRepo.Delete(x[0]);
            ViewWindow.Items.Clear();
            View_Click(sender, e);
            Delete.Visibility = Visibility.Hidden;
            Edit.Visibility = Visibility.Hidden;
            Year.Visibility = Visibility.Hidden;
            YearL.Visibility = Visibility.Hidden;
            ChangeVisible(Visibility.Hidden);

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var mov = new MovieCreator();
            var x = ViewWindow.SelectedItem.ToString().Split('\t');
            var i = x[1] == "" ? 2 : 1;
            mov.Title = x[0];
            mov.Year = Year.Text == "" ? int.Parse(x[i]) : int.Parse(Year.Text);
            mov.Genre = Genre.Text == "" ? x[i + 1] : Genre.Text;
            mov.Type = Type.Text == "" ? x[i + 2] : Type.Text;
            mov.Rating = Rating.Text == "" ? int.Parse(x[i + 3]) : int.Parse(Rating.Text);
            mov.Name = Name.Text == "" ? x[i + 4] : Name.Text;
            var desktopRepo = new Desktop();
            desktopRepo.Edit(mov);
            View_Click(sender, e);
            Delete.Visibility = Visibility.Hidden;
            Edit.Visibility = Visibility.Hidden;
            Year.Visibility = Visibility.Hidden;
            YearL.Visibility = Visibility.Hidden;
            ChangeVisible(Visibility.Hidden);

        }

        private void ViewWindow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Delete.Visibility = Visibility.Visible;
            Edit.Visibility = Visibility.Visible;
            Year.Visibility = Visibility.Visible;
            YearL.Visibility = Visibility.Visible;
            ChangeVisible(Visibility.Visible);

        }
        private void ChangeVisible(Visibility x)
        {
            Year.Visibility = x;
            Genre.Visibility = x;
            Type.Visibility = x;
            Rating.Visibility = x;
            Name.Visibility = x;
            YearL.Visibility = x;
            GenreL.Visibility = x;
            TypeL.Visibility = x;
            RatingL.Visibility = x;
            NameL.Visibility = x;
            if (x == Visibility.Visible)
            {
                Title.Text = null;
                Year.Text = null;
                Genre.Text = null;
                Type.Text = null;
                Rating.Text = null;
                Name.Text = null;
            }
        }
    }
}
