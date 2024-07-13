
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ListLessonWindow : Window
    {
        public ObservableCollection<Lesson> Lessons { get; set; }

        public ListLessonWindow()
        {
            InitializeComponent();
            LoadData();
            DataContext = this;
        }

        private void LoadData()
        {
            LessonService lessonService = new LessonService();
            var lessons = lessonService.GetList();
            Lessons = new ObservableCollection<Lesson>(lessons);
            ExercisesDataGrid.ItemsSource = Lessons;
        }

        private void AddExerciseButton_Click(object sender, RoutedEventArgs e)
        {
            CreateLessonWindow createLessonWindow = new CreateLessonWindow();
            createLessonWindow.ShowDialog();
            this.Close();
        }

        private void ExercisesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Implement the logic for when the selection changes in the DataGrid
        }

        private void ViewDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement the logic for viewing details of the selected exercise
            if (sender is Button button && button.DataContext is Lesson selectedLesson)
            {
                ViewDetalWindow viewDetalWindow = new ViewDetalWindow(selectedLesson.LessonId);
                viewDetalWindow.ShowDialog();

            }
        }
    }
}