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

namespace FunStore
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        public AdminPanel()
        {
            InitializeComponent();
            AppData.modelOdb = new FunStoreEntities();
            DGridNedviz.ItemsSource = FunStoreEntities.GetContext().Game.ToList();
            DGridDogovor.ItemsSource = FunStoreEntities.GetContext().Programm.ToList();
            DGridUser.ItemsSource = FunStoreEntities.GetContext().User.ToList();
            
            DGridSotrudniki.ItemsSource = FunStoreEntities.GetContext().Prochee.ToList();
        }
        private void NedvizEditClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new GamePage((sender as Button).DataContext as Game));
        }

        private void NedvizAddClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new GamePage(null));
        }

        private void visiblePage(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                FunStoreEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridNedviz.ItemsSource = FunStoreEntities.GetContext().Game.ToList();
                DGridDogovor.ItemsSource = FunStoreEntities.GetContext().Programm.ToList();
                DGridUser.ItemsSource = FunStoreEntities.GetContext().User.ToList();
                
                DGridSotrudniki.ItemsSource = FunStoreEntities.GetContext().Prochee.ToList();

            }
        }

        private void UserAddClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UserAddEditPage(null));
        }

        private void btnEditClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UserAddEditPage((sender as Button).DataContext as User));
        }

        private void DogovorAddClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ProgramAddEditPage(null));
        }

        private void SotrudnikiAddClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ProcheeAddEditPage(null));
        }

        private void SotrudnikiDelClick(object sender, RoutedEventArgs e)
        {
            var nedvizForRemoving = DGridSotrudniki.SelectedItems.Cast<Prochee>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {nedvizForRemoving.Count()} элементы?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    FunStoreEntities.GetContext().Prochee.RemoveRange(nedvizForRemoving);
                    FunStoreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены");

                    DGridNedviz.ItemsSource = FunStoreEntities.GetContext().Prochee.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

      

        

        private void SotrudnikiEditClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ProcheeAddEditPage((sender as Button).DataContext as Prochee));
        }

        private void NedvizDelClick(object sender, RoutedEventArgs e)
        {
            var nedvizForRemoving = DGridNedviz.SelectedItems.Cast<Game>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {nedvizForRemoving.Count()} элементы?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    FunStoreEntities.GetContext().Game.RemoveRange(nedvizForRemoving);
                    FunStoreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены");

                    DGridNedviz.ItemsSource = FunStoreEntities.GetContext().Game.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void DogovorDelClick(object sender, RoutedEventArgs e)
        {
            var nedvizForRemoving = DGridDogovor.SelectedItems.Cast<Programm>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {nedvizForRemoving.Count()} элементы?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    FunStoreEntities.GetContext().Programm.RemoveRange(nedvizForRemoving);
                    FunStoreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены");

                    DGridNedviz.ItemsSource = FunStoreEntities.GetContext().Programm.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void UserDelClick(object sender, RoutedEventArgs e)
        {
            var nedvizForRemoving = DGridUser.SelectedItems.Cast<User>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {nedvizForRemoving.Count()} элементы?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    FunStoreEntities.GetContext().User.RemoveRange(nedvizForRemoving);
                    FunStoreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены");

                    DGridNedviz.ItemsSource = FunStoreEntities.GetContext().User.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

       

        


        private void usName(object sender, RoutedEventArgs e)
        {


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {

            Environment.Exit(0);

        }

        private void noAvtorizClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AvtorizPage());
        }
    }
}
