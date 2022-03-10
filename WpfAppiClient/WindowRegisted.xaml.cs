using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppiClient
{
    /// <summary>
    /// Логика взаимодействия для WindowRegisted.xaml
    /// </summary>
    public partial class WindowRegisted : Window
    {
        private ApiWorker _api;

        public WindowRegisted()
        {
            InitializeComponent();
            _api = ApiWorker.GetInstance();
        }

        private void ButtonReg_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin.Text.Trim() != string.Empty && TextPassword.Text.Trim() != string.Empty && TextName.Text.Trim() != string.Empty&& TextBoxSurname.Text.Trim()!=string.Empty && TextBoxStatus.Text.Trim()!=string.Empty)
            {
                _api.RegistedNewUser(TextName.Text,TextBoxLogin.Text,TextPassword.Text.Trim(),TextBoxStatus.Text,TextBoxSurname.Text);

                TextBoxLogin.Text = string.Empty;
                TextPassword.Text = string.Empty;
                TextName.Text = string.Empty;
                TextBoxSurname.Text = string.Empty;
                TextBoxStatus.Text = string.Empty;

                MessageBox.Show("Добавление прошло успешно");
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
