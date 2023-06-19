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
    /// Логика взаимодействия для AvtorizPage.xaml
    /// </summary>
    public partial class AvtorizPage : Page
    {
        public AvtorizPage()
        {
            InitializeComponent();
            AppData.modelOdb = new FunStoreEntities();
        }
        private void Vhod(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppData.modelOdb.User.FirstOrDefault(x => x.Login == btLogin.Text && x.Password == tbPass.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя не существует!");
                }
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            Manager.MainFrame.Navigate(new AdminPanel());
                            break;
                        case 2:
                            Manager.MainFrame.Navigate(new AdminPanel());
                            break;
                        case 3:
                            Manager.MainFrame.Navigate(new TovarPage());
                            break;
                    }
                }
            }
            catch
            {

            }
        }

        private void reg(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CreateAc());
        }

        private void guestclick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new TovarPage());
        }
    }
}
