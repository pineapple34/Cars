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
        ObservableCollection<Car> cars = new ObservableCollection<Car>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            cars.Add(new Car(TBNewID.Text, TBNewLabel.Text, TBNewModel.Text, TBNewYear.Text, TBNewColor.Text, TBNewCost.Text, TBNewRegNum.Text));
            DGcars.ItemsSource = cars;
        }
    }
    public class Car
    {
        public int ID, year;
        public double cost;
        public string label, model, color, regNum;

        public Car(string newID, string newLabel, string newModel, string newYear, string newColor, string newCost, string newRegNum)
        {
            ID = int.Parse(newID);
            label = newLabel;
            model = newModel;
            year = int.Parse(newYear);
            color = newColor;
            cost = double.Parse(newCost);
            regNum = newRegNum;
        }
    }
}
