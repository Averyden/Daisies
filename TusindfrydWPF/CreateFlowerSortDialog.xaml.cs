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
            if(tbHalfLife.Text == "" || tbLineName.Text == "" || tbLineProductTime.Text == "" || tbSize.Text == "")
            {
                btnConfirmFlower.IsEnabled = false;
            } else
            {
                btnConfirmFlower.IsEnabled = true;
            }

            if (tbHalfLife.Text != "" || tbLineProductTime.Text != "" || tbSize.Text != "") { 
                try
                {
                    int.Parse(tbHalfLife.Text);
                    int.Parse(tbLineProductTime.Text);
                    int.Parse(tbSize.Text);
                }
                catch {
                    errorMsg.Content = "Produktionstid, halveringstid, eller størrelse er ikke et heltal.";
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

            try
            {
                Uri resourceUri = new Uri($"assets/img/{tbLineImg.Text}", UriKind.Relative);
                flowerImg.Source = new BitmapImage(resourceUri);
                imgMsg.Content = $"sucessfully loaded image: {resourceUri}";
               
            }
            catch (Exception ex)
            {
                imgMsg.Content = $"Image loading failed: {ex.Message}";


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
