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
    /// Логика взаимодействия для ProcheeAddEditPage.xaml
    /// </summary>
    public partial class ProcheeAddEditPage : Page
    {
        private Prochee _currentMaterial = new Prochee();

        public ProcheeAddEditPage(Prochee selectedMaterials)
        {
            InitializeComponent();
            if (selectedMaterials != null)
                _currentMaterial = selectedMaterials;




            DataContext = _currentMaterial;
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentMaterial.TypeProchee))
                errors.AppendLine("Укажите ТИП ");
            if (_currentMaterial.NameProchhe == null)
                errors.AppendLine("Укажите Название");
            if (_currentMaterial.PlatformProchee == null)
                errors.AppendLine("Укажите дом");
            if (_currentMaterial.StoimostProchee == null)
                errors.AppendLine("укажите Квартиру");
       

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMaterial.IdProchee == 0)
                FunStoreEntities.GetContext().Prochee.Add(_currentMaterial);

            try
            {
                FunStoreEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


            Manager.MainFrame.Navigate(new AdminPanel());
        }

        private void btnCancelClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
