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

namespace ExamTest_PRN212
{
    /// <summary>
    /// Interaction logic for StudentResult.xaml
    /// </summary>
    public partial class StudentResult : Window
    {
        public StudentResult(int score, int totalQuestions)
        {
            InitializeComponent();
            DisplayResult(score, totalQuestions);
        }

        private void DisplayResult(int score, int totalQuestions)
        {
            double finalScore = (10.0 / totalQuestions) * score ;
            ResultText.Text = $"You scored {score} out of {totalQuestions}. Your final score is {finalScore}";
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
