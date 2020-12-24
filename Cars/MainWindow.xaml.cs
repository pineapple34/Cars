using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Cars
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Car> cars = new ObservableCollection<Car>();
        public ObservableCollection<Car> carsFiltered = new ObservableCollection<Car>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cars.Add(new Car()
                {
                    ID = int.Parse(TBNewID.Text),
                    label = TBNewLabel.Text,
                    model = TBNewModel.Text,
                    year = int.Parse(TBNewYear.Text),
                    color = TBNewColor.Text,
                    cost = double.Parse(TBNewCost.Text),
                    regNum = TBNewRegNum.Text
                });
                DGcars.ItemsSource = cars;
            }
            catch (Exception)
            {
                MessageBox.Show("Неверные данные");
            }
        }

        private void Btnshow_Click(object sender, RoutedEventArgs e)
        {
            int RBcheck = 0;
            if ((bool)RBall.IsChecked) RBcheck = 0;
            if ((bool)RBlabel.IsChecked) RBcheck = 1;
            if ((bool)RBmodelAndYears.IsChecked) RBcheck = 2;
            if ((bool)RByearAndCost.IsChecked) RBcheck = 3;

            switch (RBcheck)
            {
                case 0:
                    DGcars.ItemsSource = cars;
                    break;
                case 1:
                    carsFiltered.Clear();
                    foreach (Car car in cars)
                    {
                        if (car.label == TBlabel.Text) carsFiltered.Add(car);
                    }
                    DGcars.ItemsSource = carsFiltered;
                    break;
                case 2:
                    carsFiltered.Clear();
                    try
                    {
                        foreach (Car car in cars)
                        {
                            if (car.model == TBmodel.Text && DateTime.Now.Year - car.year >= int.Parse(TByears.Text)) carsFiltered.Add(car);
                        }
                        DGcars.ItemsSource = carsFiltered;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Неверные данные");
                    }
                    break;
                case 3:
                    carsFiltered.Clear();
                    try
                    {
                        foreach (Car car in cars)
                        {
                            if (car.year == int.Parse(TByear.Text) && int.Parse(TBcost.Text) - car.cost < 0) carsFiltered.Add(car);
                        }
                        DGcars.ItemsSource = carsFiltered;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Неверные данные");
                    }
                    break;
            }
        }
    }
    public class Car
    {
        public int ID { get; set; }
        public string label { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public double cost { get; set; }
        public string regNum { get; set; }
    }
}
