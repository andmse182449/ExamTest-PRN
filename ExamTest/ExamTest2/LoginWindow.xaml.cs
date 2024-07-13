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
using Repository.Models;
using Services;

namespace ExamTest_PRN212
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LessonService lessonService = new();
        private ScoreService scoreService = new();
        public LoginWindow()
        {
            InitializeComponent();
            /*      this.Closing += StudentScreen_Closing;*/
        }
        private void StudentScreen_Closing(object sender, CancelEventArgs e)
        {
            // Show a confirmation dialog
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to close the application?",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            // If the user chooses "No", cancel the close
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
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
            if (account.Role == 0)
            {
                string lessonId = lessonIdTextBox.Text;
                string accountId = emailBx.Text;

                if (scoreService.GetAScore(lessonId, accountId) == null)
                {

                    if (string.IsNullOrWhiteSpace(lessonIdTextBox.Text))
                    {
                        MessageBox.Show("The exam code is required !", "Exam Code Required!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }
                    else if (lessonService.GetALesson(lessonId) == null)
                    {

                        MessageBox.Show("Wrong Exam Code !", "No Exam Founded!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else if (lessonService.GetALesson(lessonId) != null && lessonService.GetALesson(lessonId).LessonStatus == true)
                    {
                        // Open the quiz window with sample data
                        StudentQuestions quizScreen = new StudentQuestions(lessonId);
                        quizScreen.userName = account.Username;
                        quizScreen.lessionID = lessonId;
                        quizScreen.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied!", "Out of permission", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
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
    }
}