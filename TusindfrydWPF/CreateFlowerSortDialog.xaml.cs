using System.Windows;
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
        }
    }
}
