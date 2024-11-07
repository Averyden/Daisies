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

        }
    }
}