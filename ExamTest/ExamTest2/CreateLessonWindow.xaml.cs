
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
    /// Interaction logic for CreateLessonWindow.xaml
    /// </summary>
    public partial class CreateLessonWindow : Window
    {
        public CreateLessonWindow()
        {
            InitializeComponent();
        }

        private void CreateLessonButton_Click(object sender, RoutedEventArgs e)
        {
            string lessonId = LessonIdTextBox.Text.Trim();
            string lessonName = LessonNameTextBox.Text.Trim();
            DateTime? createDate = CreateDatePicker.SelectedDate;

            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(lessonId) || string.IsNullOrWhiteSpace(lessonName) || !createDate.HasValue)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bài học.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            LessonService lessonService = new LessonService();

            // Kiểm tra xem LessonID đã tồn tại chưa
            if (lessonService.CheckExitLessonID(lessonId))
            {
                MessageBox.Show("Mã bài học đã tồn tại. Vui lòng chọn mã khác.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Tạo đối tượng Lesson mới
            Lesson newLesson = new Lesson
            {
                LessonId = lessonId,
                LessonName = lessonName,
                LessonStatus = true,
                DateCreate = DateOnly.FromDateTime(createDate.Value)
            };

            // Thêm bài học mới
            try
            {
                lessonService.CreateNewLesson(newLesson);
                MessageBoxResult result = MessageBox.Show("Bài học đã được tạo thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);


                if (result == MessageBoxResult.OK)
                {
                    // Tạo một instance mới của ListLessonWindow
                    ListLessonWindow listLessonWindow = new ListLessonWindow();

                    // Hiển thị ListLessonWindow
                    listLessonWindow.Show();

                    // Đóng cửa sổ hiện tại (CreateLessonWindow)
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi tạo bài học: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
