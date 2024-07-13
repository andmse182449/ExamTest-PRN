
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
    /// <summary>
    /// Interaction logic for ViewDetalWindow.xaml
    /// </summary>
    public partial class ViewDetalWindow : Window
    {
        private string lessonID;
        public ObservableCollection<Question> Questions { get; set; }
        public ViewDetalWindow(string lessonID)
        {
            InitializeComponent();
            this.lessonID = lessonID;
            DataContext = this;
            LoadQuestion();


        }

        private void LoadQuestion()
        {
            QuestionService questionService = new QuestionService();
            List<Question> listQuestion = questionService.GetQuestionByLessonID(lessonID);
            Questions = new ObservableCollection<Question>(listQuestion);

        }



        private void ListStudentMarksButton_Click(object sender, RoutedEventArgs e)
        {
            ViewScoreWindow viewScoreWindow = new ViewScoreWindow(lessonID);
            viewScoreWindow.ShowDialog();


        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            AddQuestionWindow addQuestionWindow = new AddQuestionWindow(lessonID);
            addQuestionWindow.ShowDialog();
            this.Close();

        }
    }
}