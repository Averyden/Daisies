using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using Daisies;

namespace TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for CreateFlowerSortDialog.xaml
    /// </summary>
    public partial class CreateFlowerSortDialog : Window
    {

        public FlowerSort flowerSort { get; set; }
        public CreateFlowerSortDialog()
        {
            InitializeComponent();
        }

        public void AllFieldsFilled()
        {
            if (!String.IsNullOrEmpty(tbHalfLife.Text)
                && !String.IsNullOrEmpty(tbLineName.Text)
                && !String.IsNullOrEmpty(tbLineProductTime.Text)
                && !String.IsNullOrEmpty(tbSize.Text))
            {
                btnConfirmFlower.IsEnabled = true;
            } 
        }



        public void ShowErrorMessage()
        {
            // This is gonna be clumsy but whatevs, if it works.... it works.
            if (tbHalfLife.Text != "")
            {
                try
                {
                    int.Parse(tbHalfLife.Text);
                }
                catch
                {
                    errorMsg.Content = "Halveringstid er ikke sat til et heltal.";
                }
            }
            if (tbLineProductTime.Text != "")
            {
                try
                {
                    int.Parse(tbLineProductTime.Text);
                }
                catch
                {
                    errorMsg.Content = "Produktionstid er ikke sat til et heltal.";
                }
            }
            if (tbSize.Text != "")
            {
                try
                {
                    int.Parse(tbSize.Text);
                }
                catch
                {
                    errorMsg.Content = "Størrelse er ikke sat til et heltal.";
                }
            }
        }



        private void btnConfirmFlower_Click(object sender, RoutedEventArgs e)
        {
            flowerSort = new FlowerSort();
            flowerSort.Name = tbLineName.Text;
            flowerSort.PicturePath = $"assets/img/{tbLineImg.Text}";
            flowerSort.ProductionTime = int.Parse(tbLineProductTime.Text);
            flowerSort.HalfLife = int.Parse(tbHalfLife.Text);
            flowerSort.Size = int.Parse(tbSize.Text);


            
            DialogResult = true;
        }

        private void onChanged(object sender, TextChangedEventArgs e)
        {
            ShowErrorMessage();
            AllFieldsFilled();


        }

        private void flowerImg_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Uri resourceUri = new Uri($"assets/img/{tbLineImg.Text}", UriKind.Relative);
                flowerImg.Source = new BitmapImage(resourceUri);

            }
            catch (Exception ex)
            {
                imgMsg.Content = $"Image loading failed: {ex.Message}";
            }
        }
    }
}
