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
    /// Логика взаимодействия для CreateAc.xaml
    /// </summary>
    public partial class CreateAc : Page
    {
        public CreateAc()
        {
            InitializeComponent();
        }
        private void create(object sender, RoutedEventArgs e)
        {
            if (AppData.modelOdb.User.Count(x => x.Login == tbLogin.Text) > 0)
            {
                MessageBox.Show("Пользователь уже существует");
                return;
            }
            try
            {
                User userObj = new User()
                {
                    Login = tbLogin.Text,
                    Name = tbName.Text,
                    Password = tbPass.Password,
                    IdRole = 3
                };
                AppData.modelOdb.User.Add(userObj);
                AppData.modelOdb.SaveChanges();
                MessageBox.Show("Пользователь создан");
                Manager.MainFrame.GoBack();
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении");
            }
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
