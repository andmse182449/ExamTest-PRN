
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
    /// Interaction logic for ViewScoreWindow.xaml
    /// </summary>
    public partial class ViewScoreWindow : Window
    {
        public ObservableCollection<Score> Scores { get; set; }
        private string lessonID;
        public ViewScoreWindow(string lessonID)
        {
            InitializeComponent();
            this.lessonID = lessonID;
            DataContext = this;
            LoadData();
        }

        public void LoadData()
        {
            ScoreService scoreService = new ScoreService();
            List<Score> listScores = scoreService.GetList(lessonID);
            Scores = new ObservableCollection<Score>(listScores);
            ScoresDataGrid.ItemsSource = Scores;

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
