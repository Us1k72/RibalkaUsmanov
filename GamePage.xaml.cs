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
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private Game _currentMaterial = new Game();

        public GamePage(Game selectedMaterials)
        {
            InitializeComponent();
            if (selectedMaterials != null)
                _currentMaterial = selectedMaterials;




            DataContext = _currentMaterial;
        }
        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentMaterial.GameName))
                errors.AppendLine("Укажите Название");
            if (_currentMaterial.GameJanr == null)
                errors.AppendLine("Укажите ЖАНР");
            if (_currentMaterial.GameStoimost == null)
                errors.AppendLine("Укажите Стоймость");
            if (_currentMaterial.GameIsdatel == null)
                errors.AppendLine("укажите Издателя");
            if (_currentMaterial.GameVipusk == null)
                errors.AppendLine("укажите Год выпуска");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMaterial.IdGame == 0)
                FunStoreEntities.GetContext().Game.Add(_currentMaterial);

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
