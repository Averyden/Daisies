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

        public void updateUI()
        {

            if (tbLineImg.Text == "")
            {
                Uri fallbackUri = new Uri("assets/img/temp.png", UriKind.RelativeOrAbsolute);
                flowerImg.Source = new BitmapImage(fallbackUri);
                imgMsg.Content = "";
            }
            else
            { // TODO: figure out how I can make it actually reach the fallback, using File.Exists is gonna rule out absolute paths and doesn't even work in this context with relative paths either.
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
            updateUI(); // Split up and remove later.
            AllFieldsFilled();


        }

        private void flowerImg_LostFocus(object sender, RoutedEventArgs e)
        {
            Uri fallbackUri = new Uri("assets/img/temp.png", UriKind.Relative);
            flowerImg.Source = new BitmapImage(fallbackUri);
        }
    }
}
