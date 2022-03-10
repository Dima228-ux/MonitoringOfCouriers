using Microsoft.Maps.MapControl.WPF;
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
using GMap.NET;
using GMap.NET.MapProviders;
using System.Net;
using GMap.NET.WindowsPresentation;
using DbEntities;

namespace WpfAppiClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WindowAdmin : Window
    {

        public WindowAdmin(User user)
        {
            InitializeComponent();
        }

        public IWebProxy WebReqest { get; private set; }

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


            //GMapProvider.WebProxy = WebReqest.GetSystemWebProxy();
            GMapProvider.WebProxy.Credentials = CredentialCache.DefaultCredentials;



            //double Lath;
            //double Long;
            //GMap.NET.WindowsPresentation.GMapMarker marker = new GMap.NET.WindowsPresentation.GMapMarker(new PointLatLng(Lath, Long));

            //BitmapImage bitmap = new BitmapImage();
            //bitmap.BeginInit();
            //bitmap.UriSource = new Uri(@"D:\Рабочий стол\Рабочий стол\Картинки, видео  и музыка\pizza-logo-design-template_15146-192.jpg");
            //bitmap.EndInit();
            //Image image = new Image();
            //image.Source = bitmap;
            //marker.Shape = image;
            //gmap.Markers.Add(marker);


            //marker.Shape = new Image
            //{
            //    Source = new BitmapImage(new Uri(@"D:\Рабочий стол\Рабочий стол\Картинки, видео  и музыка\pizza-logo-design-template_15146-192.jpg")),
            //    Width = 25,
            //    Height = 25,
            //    ToolTip = "Метка",
            //    Visibility = Visibility.Visible
            //};
            //gmap.Markers.Add(marker);

            //         RoutingProvider routingProvider =
            //gmap.MapProvider as RoutingProvider ?? GMapProviders.OpenStreetMap;

            //         MapRoute route = routingProvider.GetRoute(
            //             new PointLatLng(53.266978741524575, 34.35876398454452), //start
            //             new PointLatLng(53.26528651807835, 34.35962524700253), //end
            //             false, //avoid highways 
            //             false, //walking mode
            //             (int)gmap.Zoom);

            //         GMapRoute gmRoute = new GMapRoute(route.Points);

            //         gmap.Markers.Add(gmRoute);

            //var track = new List<PointLatLng>();

            //PointLatLng point1 = new PointLatLng(53.266978741524575, 34.35876398454452); //start
            //PointLatLng point2 = new PointLatLng(53.26528651807835, 34.35962524700253);//end

            //var routeMarker = new GMapMarker(track.First());
            //routeMarker.Route.AddRange(track);

            //// don't forget to add the marker to the map
            //gmap.Markers.Add(routeMarker);

            //GMapRoute gmRoute = new GMapRoute(route.Points);

            //gmap.Markers.Add(gmRoute);

        }

        private void ButtonMark_Click(object sender, RoutedEventArgs e)
        {


            GMap.NET.WindowsPresentation.GMapMarker marker = new GMap.NET.WindowsPresentation.GMapMarker(new PointLatLng(53.266978741524575, 34.35876398454452));

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

        private void ButtonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            WindowAddOrder windowAddOrder = new WindowAddOrder();
            this.Hide();
            windowAddOrder.ShowDialog();
            this.Show();
        }

        private void ButtonRegistedNewUser_Click(object sender, RoutedEventArgs e)
        {
            WindowRegisted windowRegisted = new WindowRegisted();
            this.Hide();
            windowRegisted.ShowDialog();
            this.Show();
        }
    }
}
