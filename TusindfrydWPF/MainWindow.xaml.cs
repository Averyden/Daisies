using System.Security;
using System.Windows;
using System.Windows.Documents;
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



        private void btnCreateSort_Click(object sender, RoutedEventArgs e)
        {
            CreateFlowerSortDialog createWindow = new CreateFlowerSortDialog();
            createWindow.ShowDialog();
            if (createWindow.DialogResult == true)
            {
                flowerSorts.Add(createWindow.flowerSort);
                sortList.Text = string.Empty;
                foreach (var flower in flowerSorts)
                {
                    sortList.Text = $"{flower.Name}\n";
                }
            }
        }

    }
}