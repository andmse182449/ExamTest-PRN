using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Repository.Models;
using Services;

namespace ExamTest2
{
    /// <summary>
    /// Interaction logic for AccountManagementForm.xaml
    /// </summary>
    public partial class AccountManagementForm : Window
    {
        private AccountService _service = new AccountService();
        public AccountManagementForm()
        {
            InitializeComponent();
            LoadData();
            dgAccountList.AutoGeneratingColumn += DgAccountList_AutoGeneratingColumn;
        }
        private void DgAccountList_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Scores" || e.PropertyName == "Role")
            {
                e.Cancel = true; // This prevents the column from being generated
            }
        }

        public void LoadData()
        {
            var result = _service.GetAllAccounts();
            dgAccountList.ItemsSource = null; //xoa luoi lay danh sach moi
            dgAccountList.ItemsSource = result;
            role.Items.Clear();
            role.Items.Add(new ComboBoxItem { Content = "Student", Tag = 0 });
            role.Items.Add(new ComboBoxItem { Content = "Teacher", Tag = 1 });

            // Select the default role
            role.SelectedIndex = 0;

        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            // Show a confirmation message box
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Perform any necessary cleanup operations here

                // Close the main window
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void dgAccountList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedAccount = dgAccountList.SelectedItem as Account;
            if (selectedAccount != null)
            {
                user.Text = selectedAccount.Username;
                fulllname.Text = selectedAccount.FullName;
                password.Text = selectedAccount.Password;

                // Select the correct role in ComboBox based on selectedAccount.Role
                foreach (ComboBoxItem item in role.Items)
                {
                    if (item.Tag.ToString() == selectedAccount.Role.ToString())
                    {
                        role.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtkeyword.Text) == true)
            {
                LoadData();
            }
            var result = _service.Search(txtkeyword.Text.Trim());
            dgAccountList.ItemsSource = null;
            dgAccountList.ItemsSource = result;

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {


            if (string.IsNullOrWhiteSpace(user.Text))
            {
                MessageBox.Show("The user name is required !", "User Name required!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            _service.Delete(user.Text);

            var result = _service.GetAllAccounts();
            dgAccountList.ItemsSource = null;
            dgAccountList.ItemsSource = result;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(user.Text))
            {
                MessageBox.Show("The updated id is required !", "Search keyword required!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            AccountDetailForm bookForm = new AccountDetailForm();
            bookForm.username = user.Text;
            bookForm.ShowDialog();

            var result = _service.Search(txtkeyword.Text.Trim());
            dgAccountList.ItemsSource = null;
            dgAccountList.ItemsSource = result;

        }



        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AccountDetailForm bookForm = new AccountDetailForm();
            bookForm.username = null;
            bookForm.ShowDialog();

            var result = _service.Search(txtkeyword.Text.Trim());
            dgAccountList.ItemsSource = null;
            dgAccountList.ItemsSource = result;
        }
    }
}
