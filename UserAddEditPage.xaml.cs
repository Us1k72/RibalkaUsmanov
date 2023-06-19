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
    /// Логика взаимодействия для UserAddEditPage.xaml
    /// </summary>
    public partial class UserAddEditPage : Page
    {
        private User _currentMaterial = new User();

        public UserAddEditPage(User selectedMaterials)
        {
            InitializeComponent();

            if (selectedMaterials != null)
                _currentMaterial = selectedMaterials;

            DataContext = _currentMaterial;
            MaterialCombo.ItemsSource = FunStoreEntities.GetContext().Role.ToList();

        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();



            if (string.IsNullOrWhiteSpace(_currentMaterial.Name))
                errors.AppendLine("Укажите имя");
            if (_currentMaterial.Role == null)
                errors.AppendLine("Выберете роль");
            if (_currentMaterial.Login == null)
                errors.AppendLine("Введите логин");
            if (string.IsNullOrWhiteSpace(_currentMaterial.Password))
                errors.AppendLine("Введите пароль");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMaterial.Id == 0)
                FunStoreEntities.GetContext().User.Add(_currentMaterial);

            try
            {
                FunStoreEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


            Manager.MainFrame.GoBack();

        }

        private void btnCancelClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
