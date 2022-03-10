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
using CommunicationEntities;
using DbEntities;
using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using Newtonsoft.Json;
using System.Net;

namespace WpfAppiClient
{
    /// <summary>
    /// Логика взаимодействия для WindowСourier.xaml
    /// </summary>
    public partial class WindowСourier : Window
    {
        private User _user;
        private List<Order> _freeOrders;
        private Order _selectedOrder;
        List<Order> _orders;
        private ApiWorker _api;
        //завести лист заказами без курьера и его присваиваем листу и удаляем из списка 
        public WindowСourier(User user)
        {
            InitializeComponent();

            _api = ApiWorker.GetInstance();
            _user = user;
            _freeOrders = new List<Order>();
            _orders = new List<Order>();
        }

        private void mapView_Loaded(object sender, RoutedEventArgs e)
        {
            // Настройки для компонента GMap
            gmap.Bearing = 0;
            // Перетаскивание правой кнопки мыши
            gmap.CanDragMap = true;
            // Перетаскивание карты левой кнопкой мыши
            gmap.DragButton = MouseButton.Left;

            //gmap.CenterCrossPen= new PointLatLng(53.266978741524575, 34.35876398454452);

            //gmap.GrayScaleMode = true;
            GMapMarker gMapMarker = new GMapMarker(new PointLatLng(53.266978741524575, 34.35876398454452));

            gmap.Markers.Add(gMapMarker);

            // Все маркеры будут показаны
            //gmap.MarkersEnabled = true;
            gmap.MaxZoom = 18;
            gmap.MinZoom = 2;

            gmap.Zoom = 18;
            // Курсор мыши в центр карты
            gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;

            // Скрытие внешней сетки карты
            gmap.ShowTileGridLines = false;
            // При загрузке 10-кратное увеличение
            gmap.Zoom = 10;

            gmap.ShowCenter = false;

            // Чья карта используется
            gmap.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;

            // Загрузка этой точки на карте
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.Position = new GMap.NET.PointLatLng(53.266978741524575, 34.35876398454452);

            GMapProvider.WebProxy.Credentials = CredentialCache.DefaultCredentials;

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Response response = await _api.GetFreeOrders(true);
            _freeOrders = JsonConvert.DeserializeObject<List<Order>>(response.Data);
            _orders = _freeOrders;
            list.ItemsSource = _freeOrders;
            ButtonChoose.IsEnabled = false;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedOrder = (Order)list.SelectedItem;
            //gmap = null;
            if (list.SelectedItem != null)
            {
                ButtonChoose.IsEnabled = true;
                GMap.NET.WindowsPresentation.GMapMarker marker = new GMap.NET.WindowsPresentation.GMapMarker(new PointLatLng(_selectedOrder.Lat, _selectedOrder.Long));

                marker.Shape = new Image
                {
                    Source = new BitmapImage(new Uri(@"D:\Users\al_ul\source\repos\MonitoringOfCouriers\WpfAppiClient\Resourses\metkaMap.png")),
                    Width = 25,
                    Height = 25,
                    ToolTip = marker,
                    Visibility = Visibility.Visible
                };
                gmap.Markers.Add(marker);
            }
            else
            {
                ButtonChoose.IsEnabled = false;
            }

        }

        private  async void ButtonChoose_Click(object sender, RoutedEventArgs e)
        {
            
            Response response = await _api.UpdateStatusCourier(_user.Id);
            Response response1 = await _api.UpdateStatusOrder(_user.Id, _selectedOrder.Id);
            _freeOrders.Remove(_selectedOrder);
            list.ItemsSource = null;
            list.ItemsSource = _freeOrders;
            MessageBox.Show("Добавление прошло успешно");

           
        }
    }
}
