﻿using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Repository.Models;
using Services;

namespace ExamTest
{
    public partial class ListLessonWindow : Window
    {
        public ObservableCollection<Lesson> Lessons { get; set; }
        private LessonService _lesSer = new(); 

        public ListLessonWindow()
        {
            InitializeComponent();
            LoadData();
            DataContext = this;
        }

        private void LoadData()
        {
            try
            {
                LessonService lessonService = new LessonService();
                var lessons = lessonService.GetList();
                Lessons = new ObservableCollection<Lesson>(lessons);
                ExercisesDataGrid.ItemsSource = Lessons;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading data: " + ex.Message);
                MessageBox.Show("An error occurred while loading data.");
            }
        }

        private void AddExerciseButton_Click(object sender, RoutedEventArgs e)
        {
            CreateLessonWindow createLessonWindow = new CreateLessonWindow();
            createLessonWindow.ShowDialog();
            this.Close();
        }

        private void ExercisesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedExercise = ExercisesDataGrid.SelectedItem as Lesson;
            if (selectedExercise != null)
            {
                if (selectedExercise.LessonStatus == true)
                {
                    btnDisable.IsEnabled = true;
                    btnEnable.IsEnabled = false;
                }
                else
                {
                    btnEnable.IsEnabled = true;
                    btnDisable.IsEnabled = false;
                }
            }
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

        private void BtnDisable_Click(object sender, RoutedEventArgs e)
        {

            var selectedExercise = ExercisesDataGrid.SelectedItem as Lesson;
            LessonService lessonService = new LessonService();
            lessonService.DisableLesson(selectedExercise);
            LoadData(); // Reload data after disabling a lesson
            btnDisable.IsEnabled = false;
            btnEnable.IsEnabled = false;
        }

        private void BtnEnable_Click(object sender, RoutedEventArgs e)
        {

            var selectedExercise = ExercisesDataGrid.SelectedItem as Lesson;
            LessonService lessonService = new LessonService();
            lessonService.EnableLesson(selectedExercise);
            LoadData(); // Reload data after enabling a lesson
            btnDisable.IsEnabled = false;
            btnEnable.IsEnabled = false;

        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtkeyword.Text.ToLower();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                // Reset to show all exercises if keyword is empty
                LoadData();
            }
            else
            {
                // Filter exercises based on keyword
                var filteredExercises = _lesSer.search(keyword);
                ExercisesDataGrid.ItemsSource = filteredExercises;
            }
        }
        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }
    }
    public class BooleanToStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return (bool)value ? "Enabled" : "Disabled";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
