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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int newID = int.Parse(TBNewID.Text);
                int newYear = int.Parse(TBNewYear.Text);
                double newCost = double.Parse(TBNewCost.Text);
                cars.Add(new Car()
                {
                    ID = newID,
                    label = TBNewLabel.Text,
                    model = TBNewModel.Text,
                    year = newYear,
                    color = TBNewColor.Text,
                    cost = newCost,
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
