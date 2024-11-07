using System.Windows;
using System.Windows.Media.Imaging;
using Daisies;
using System.IO;

namespace TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for CreateFlowerSortDialog.xaml
    /// </summary>
    public partial class CreateFlowerSortDialog : Window
    {
        public CreateFlowerSortDialog()
        {
            InitializeComponent();
        }

        public void updateOKBtn()
        {
            if (tbHalfLife.Text == "" || tbLineName.Text == "" || tbLineProductTime.Text == "" || tbSize.Text == "")
            {
                btnConfirmFlower.IsEnabled = false;
            }
            else
            {
                btnConfirmFlower.IsEnabled = true;
            }
        }



        private void btnConfirmFlower_Click(object sender, RoutedEventArgs e)
        {

        }

        private void onChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            updateOKBtn();

            string imagePath = $"assets/img/{tbLineImg.Text}";
            Uri resourceUri;

            // Check if the file exists before setting the source
            if (File.Exists(imagePath))
            {
                resourceUri = new Uri(imagePath, UriKind.Relative);
            }
            else
            {
                Console.WriteLine("Image file not found, loading fallback.");
                resourceUri = new Uri("assets/img/temp.png", UriKind.RelativeOrAbsolute);
            }


            flowerImg.Source = new BitmapImage(resourceUri);
        }
        private void flowerImg_LostFocus(object sender, RoutedEventArgs e)
        {
            Uri fallbackUri = new Uri("assets/img/temp.png", UriKind.Relative);
            flowerImg.Source = new BitmapImage(fallbackUri);
        }
    }
}
