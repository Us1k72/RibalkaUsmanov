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
    /// Логика взаимодействия для ProgramAddEditPage.xaml
    /// </summary>
    public partial class ProgramAddEditPage : Page
    {
        private Programm  _currentMaterial = new Programm();

        public ProgramAddEditPage(Programm selectedMaterials)
        {
            InitializeComponent();
            if (selectedMaterials != null)
                _currentMaterial = selectedMaterials;

            DataContext = _currentMaterial;
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();



            if (string.IsNullOrWhiteSpace(_currentMaterial.ProgramName))
                errors.AppendLine("Укажите название");
            if (string.IsNullOrWhiteSpace(_currentMaterial.ProgramStoimost))
                errors.AppendLine("Укажите Стоймость");
            

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMaterial.IdProgramm == 0)
                FunStoreEntities.GetContext().Programm.Add(_currentMaterial);

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
