
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

namespace ExamTest
{
    /// <summary>
    /// Interaction logic for AddQuestionWindow.xaml
    /// </summary>
    public partial class AddQuestionWindow : Window
    {
        private string lessonID;
        public AddQuestionWindow(string lessonID)
        {
            InitializeComponent();
            this.lessonID = lessonID;
        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            string questionText = QuestionTextBox.Text;
            string optionA = OptionATextBox.Text;
            string optionB = OptionBTextBox.Text;
            string optionC = OptionCTextBox.Text;
            string optionD = OptionDTextBox.Text;
            string correctAnswer = CorrectAnswerComboBox.Text;

            if (string.IsNullOrWhiteSpace(questionText) || string.IsNullOrWhiteSpace(optionA) || string.IsNullOrWhiteSpace(optionB) || string.IsNullOrWhiteSpace(optionC) || string.IsNullOrWhiteSpace(optionD) || string.IsNullOrWhiteSpace(correctAnswer))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin câu hỏi.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            QuestionService questionService = new QuestionService();
            Question newQuestion = new Question
            {
                QuestionText = questionText,
                OptionA = optionA,
                OptionB = optionB,
                OptionC = optionC,
                OptionD = optionD,
                CorrectAnswer = correctAnswer,
                LessonId = lessonID

            };

            try
            {
                questionService.CreateNewQuestion(newQuestion);
                MessageBoxResult result = MessageBox.Show("Câu hỏi đã được tạo thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);


                if (result == MessageBoxResult.OK)
                {
                    // Tạo một instance mới của ListLessonWindow
                    ViewDetalWindow viewDetalWindow = new ViewDetalWindow(lessonID);

                    // Hiển thị ListLessonWindow
                    viewDetalWindow.Show();

                    // Đóng cửa sổ hiện tại (CreateLessonWindow)
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi tạo câu hỏi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
