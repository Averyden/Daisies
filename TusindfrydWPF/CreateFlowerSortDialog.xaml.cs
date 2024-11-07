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
        public CreateFlowerSortDialog()
        {
            InitializeComponent();
        }

        public void updateOKBtn()
        {
            if(tbHalfLife.Text == "" || tbLineName.Text == "" || tbLineProductTime.Text == "" || tbSize.Text == "")
            {
                btnConfirmFlower.IsEnabled = false;
            } else
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

            try
            {
                Uri resourceUri = new Uri($"assets/img/{tbLineImg.Text}", UriKind.Relative);
                flowerImg.Source = new BitmapImage(resourceUri);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Image loading failed: " + ex.Message);


                Uri fallbackUri = new Uri("assets/img/temp.png", UriKind.RelativeOrAbsolute);
                flowerImg.Source = new BitmapImage(fallbackUri);
            }
        }

        private void flowerImg_LostFocus(object sender, RoutedEventArgs e)
        {
            Uri fallbackUri = new Uri("assets/img/temp.png", UriKind.Relative);
            flowerImg.Source = new BitmapImage(fallbackUri);
        }
    }
}
