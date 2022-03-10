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
    /// Логика взаимодействия для WindowAddOrder.xaml
    /// </summary>
    public partial class WindowAddOrder : Window
    {
        private ApiWorker _api;

        public WindowAddOrder()
        {
            InitializeComponent();
            _api = ApiWorker.GetInstance();
        }

        private void ButtonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            if(TextBoxLat.Text.Trim()!=string.Empty&& TextBoxLong.Text.Trim() != string.Empty && TextBoxCoast.Text.Trim() != string.Empty)
            {
                _api.InsertOrder(float.Parse(TextBoxLat.Text), float.Parse(TextBoxLong.Text), int.Parse(TextBoxCoast.Text));
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
