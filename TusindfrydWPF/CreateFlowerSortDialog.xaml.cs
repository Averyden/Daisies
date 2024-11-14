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


        public void intBoxes_LostFocus(object sender, RoutedEventArgs e)
        {
            // This is gonna be clumsy but whatevs, if it works.... it works.
            bool valid = true;
            if (!String.IsNullOrEmpty(tbHalfLife.Text))
            {
                valid = false;
                try
                {
                    int.Parse(tbHalfLife.Text);
                }
                catch
                {
                    errorMsg.Content = "Halveringstid er ikke sat til et heltal.";
                }
            }
            if (!String.IsNullOrEmpty(tbLineProductTime.Text))
            {
                valid = false;
                try
                {
                    int.Parse(tbLineProductTime.Text);
                }
                catch
                {
                    errorMsg.Content = "Produktionstid er ikke sat til et heltal.";
                }
            }
            if (!String.IsNullOrEmpty(tbSize.Text))
            {
                valid = false;
                try
                {
                    int.Parse(tbSize.Text);
                }
                catch
                {
                    errorMsg.Content = "Størrelse er ikke sat til et heltal.";
                }
            } 
            if (valid == true)
            {
                errorMsg.Content = string.Empty;
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

        private void onChanged(object sender, TextChangedEventArgs e) // This will change the ok button to toggle between enabled and disabled
        {
            bool filled = false;
            if (!String.IsNullOrEmpty(tbHalfLife.Text)
                && !String.IsNullOrEmpty(tbLineName.Text)
                && !String.IsNullOrEmpty(tbLineProductTime.Text)
                && !String.IsNullOrEmpty(tbSize.Text))
            {
                filled = true;
            }

            // Allow it to be toggled
            if (filled)
            {
                btnConfirmFlower.IsEnabled = true;
            } else
            {
                btnConfirmFlower.IsEnabled = false;
            }

        }

        private void tbLineImg_LostFocus(object sender, RoutedEventArgs e)
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
