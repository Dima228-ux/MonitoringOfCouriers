using CommunicationEntities;
using DbEntities;
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
using Newtonsoft.Json;

namespace WpfAppiClient
{
    /// <summary>
    /// Логика взаимодействия для WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        private ApiWorker _api;

        public WindowLogin()
        {
            InitializeComponent();
            _api =  ApiWorker.GetInstance();
        }

        private  async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {// запос логин и пароль  после закрепа заказа убрать из лист бокса 

            Response response = await _api.GetUserByLoginPassword(TextBoxLogin.Text, Password.Password);
            User user = JsonConvert.DeserializeObject<User>(response.Data);

            if (user.Type=="admin")
            {
                WindowAdmin windowAdmin = new WindowAdmin(user);
                this.Hide();
                windowAdmin.ShowDialog();
                this.Show();

            }
            else if (user.Type == "courier" )
            {

                WindowСourier windowCourier = new WindowСourier(user);
                this.Hide();
                windowCourier.ShowDialog();
                this.Show();
            }

        }
    }
}
