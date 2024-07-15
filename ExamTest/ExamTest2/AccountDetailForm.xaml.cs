using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ExamTest2
{
    /// <summary>
    /// Interaction logic for AccountDetailForm.xaml
    /// </summary>
    public partial class AccountDetailForm : Window
    {
        public string? username { get; set; }
        private AccountService _accService = new();
        public bool IsReadOnlyUsername => username != null; // Determines if username should be read-only

        public string AddUpdateButtonLabel => username == null ? "Add" : "Update"; // Determines the label for the Add/Update button
        public AccountDetailForm()
        {
            InitializeComponent();
        }
        private void AccountForm_Load(object sender, RoutedEventArgs e)
        {
            role.Items.Clear();
            role.Items.Add(new ComboBoxItem { Content = "Student", Tag = 0 });
            role.Items.Add(new ComboBoxItem { Content = "Teacher", Tag = 1 });

            if (this.username != null)
            {
                var account = _accService.GetAccount(username);



                user.Text = account.Username;
                name.Text = account.FullName;
                pass.Text = account.Password;

                // Select the correct role in ComboBox based on selectedAccount.Role
                foreach (ComboBoxItem item in role.Items)
                {
                    if ((int)item.Tag == account.Role)
                    {
                        role.SelectedItem = item;
                        break;
                    }
                }
                lblTitle.Content = "Update Account";
                user.IsReadOnly = true;
            }
            else
            {
                // Set UI elements for add new account scenario
                lblTitle.Content = "Add Account";
                user.IsReadOnly = true;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            int selectedRole = (int)(role.SelectedItem as ComboBoxItem).Tag;
            Account account = new()
            {

                Password = pass.Text.Trim(),
                FullName = name.Text.Trim(),
                Role = selectedRole,
            };
            if (username == null)
            {
                var res = _accService.GetAccount(user.Text.Trim());
                if (res != null)
                {
                    MessageBox.Show("User Name existed !", "User name existed!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                _accService.AddAccount(account);
            }
            else
                _accService.UpdateAccount(account);

            Close();
        }
        private void role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lblTitle.Content.Equals("Add Account"))
            {
                if (role.SelectedItem is ComboBoxItem selectedItem)
                {
                    string roleName = selectedItem.Content.ToString();
                    if (roleName == "Student")
                    {
                        user.Text = "ST" + Convert.ToString(_accService.CountStudent() + 1);
                    }
                    else if (roleName == "Teacher")
                    {
                        user.Text = "TE" + Convert.ToString(_accService.CountTeacher() + 1);
                    }
                }
            }
        }
    }
}
