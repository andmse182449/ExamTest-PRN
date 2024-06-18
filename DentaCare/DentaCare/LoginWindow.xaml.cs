using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Repositories.Models;
using Services;

namespace DentaCare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            AccountService service = new AccountService();
            Account? account = service.CheckLogin(emailBx.Text, passwordBx.Password);
            if (account == null)
            {
                MessageBox.Show("Login Fail!", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (account.RoleId != 3)
            {
                MessageBox.Show("You have no credentials!", "Access denied !", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
/*                BookManagementForm bookManagementForm = new BookManagementForm();
                this.Hide();
                bookManagementForm.ShowDialog();*/

            }



        }
    }
}