using System.ComponentModel;
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
using ExamTest;
using ExamTest2;
using Repository.Models;
using Services;

namespace ExamTest_PRN212
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginStaffWindow : Window
    {
        
        public LoginStaffWindow()
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
            else if (account.Role == 1 && account.Status == 0)
            {

                ListLessonWindow listLessonWindow = new ListLessonWindow();
                listLessonWindow.Show();
                this.Close();
            }
            else if (account.Role == 2 && account.Status == 0)
            {

                AccountManagementForm accountManagement = new AccountManagementForm();
                accountManagement.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login Fail!", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }



        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow staffWindow = new LoginWindow();
            staffWindow.Show();
            this.Close();
        }




    }
}