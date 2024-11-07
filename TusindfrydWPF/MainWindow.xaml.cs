using System.Security;
using System.Windows;
using Daisies;

namespace TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<FlowerSort> flowerSorts;
        public MainWindow()
        {
            InitializeComponent();
            flowerSorts = new List<FlowerSort>();
        }

        private void createFlowerSortFinal(string name, string path, int proTime, int HLX, int size)
        {
            FlowerSort sort = new FlowerSort(name, path, proTime, HLX, size);
            
        }

        private void btnCreateSort_Click(object sender, RoutedEventArgs e)
        {
            CreateFlowerSortDialog createWindow = new CreateFlowerSortDialog();
            createWindow.ShowDialog();
            if (createWindow.DialogResult == true)
            {
                if(createWindow.tbLineImg.Text != "") {
                    FlowerSort flower = new FlowerSort(createWindow.tbLineName.Text, $"assets/img/{createWindow.tbLineImg.Text}", int.Parse(createWindow.tbLineProductTime.Text), int.Parse(createWindow.tbHalfLife.Text), int.Parse(createWindow.tbSize.Text));
                    flowerSorts.Add(flower);
                } else
                {
                    FlowerSort flower = new FlowerSort(createWindow.tbLineName.Text, int.Parse(createWindow.tbLineProductTime.Text), int.Parse(createWindow.tbHalfLife.Text), int.Parse(createWindow.tbSize.Text));
                    flowerSorts.Add(flower);
                }

                foreach (var flower in flowerSorts)
                {
                    sortList.Text = $"{flower.Name}, {flower.PicturePath}, {flower.ProductionTime}, {flower.HalfLife}, {flower.Size}\n";
                }
            }
        }

    }
}