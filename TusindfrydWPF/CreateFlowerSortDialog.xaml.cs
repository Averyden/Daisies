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
        public CreateFlowerSortDialog()
        {
            InitializeComponent();
        }

        public void updateUI()
        {
            if (tbHalfLife.Text == "" || tbLineName.Text == "" || tbLineProductTime.Text == "" || tbSize.Text == "")
            {
                btnConfirmFlower.IsEnabled = false;
            }
            else
            {
                btnConfirmFlower.IsEnabled = true;
            }

            if (tbLineImg.Text == "")
            {
                Uri fallbackUri = new Uri("assets/img/temp.png", UriKind.RelativeOrAbsolute);
                flowerImg.Source = new BitmapImage(fallbackUri);
                imgMsg.Content = "";
            }
            else
            {
                try
                {
                    Uri resourceUri = new Uri($"assets/img/{tbLineImg.Text}", UriKind.Relative);
                    BitmapImage jogn = new BitmapImage(resourceUri);
                    flowerImg.Source = new BitmapImage(resourceUri);
                    //imgMsg.Content = $"sucessfully loaded image: {resourceUri}";
                    imgMsg.Content = jogn.ToString();

                }
                catch (Exception ex)
                {
                    imgMsg.Content = $"Image loading failed: {ex.Message}";


                    Uri fallbackUri = new Uri("assets/img/temp.png", UriKind.RelativeOrAbsolute);
                    flowerImg.Source = new BitmapImage(fallbackUri);
                }
            }


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
            this.DialogResult = true;
        }

        private void onChanged(object sender, TextChangedEventArgs e)
        {
            updateUI();


        }

        private void flowerImg_LostFocus(object sender, RoutedEventArgs e)
        {
            Uri fallbackUri = new Uri("assets/img/temp.png", UriKind.Relative);
            flowerImg.Source = new BitmapImage(fallbackUri);
        }
    }
}
