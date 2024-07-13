using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Identity.Client;
using Repositories;
using Repository.Models;
using Services;

namespace ExamTest_PRN212
{
    public partial class StudentQuestions : Window
    {
        private List<Question> questions;
        public string? userName {  get; set; }
        public string? lessionID { get; set; }
        private QuestionService _quesService = new();
        private ScoreService _scoreService = new(); 
        private int currentQuestionIndex = 0;

        // Dictionary to store user's selected choices
        private Dictionary<int, string> userChoices = new Dictionary<int, string>();

        public StudentQuestions(string lessonId)
        {
            InitializeComponent();
            LoadQuestions(lessonId);
            DisplayQuestion();
        }

        private void LoadQuestions(string lessonId)
        {
            // Load questions for the given lesson
            questions = _quesService.GetAllQuestions(lessonId);

            if (questions == null || questions.Count == 0)
            {
                MessageBox.Show("No questions found for this lesson.");
                this.Close();
            }

            // Initialize progress bar maximum value
            QuestionProgressBar.Maximum = questions.Count;
        }

        private void DisplayQuestion()
        {
            if (currentQuestionIndex < 0 || currentQuestionIndex >= questions.Count)
                return;

            var currentQuestion = questions[currentQuestionIndex];
            QuestionText.Text = $"{currentQuestionIndex + 1}. {currentQuestion.QuestionText}";
            OptionsPanel.Children.Clear();

            // Add options as RadioButtons
            AddOption("A", currentQuestion.OptionA);
            AddOption("B", currentQuestion.OptionB);
            AddOption("C", currentQuestion.OptionC);
            AddOption("D", currentQuestion.OptionD);

            // Enable/disable navigation buttons
            PreviousButton.IsEnabled = currentQuestionIndex > 0;
            NextButton.IsEnabled = currentQuestionIndex < questions.Count - 1;

            // Restore previous choice if exists
            if (userChoices.ContainsKey(currentQuestion.QuestionId))
            {
                foreach (RadioButton rb in OptionsPanel.Children)
                {
                    if ((string)rb.Tag == userChoices[currentQuestion.QuestionId])
                    {
                        rb.IsChecked = true;
                        break;
                    }
                }
            }

            // Update progress bar value
            UpdateProgressBar();
        }

        private void AddOption(string optionLabel, string optionText)
        {
            var radioButton = new RadioButton
            {
                Content = $"{optionLabel}: {optionText}",
                GroupName = "Options",
                Tag = optionLabel // Store the option label in the Tag property
            };
            radioButton.Checked += Option_Checked;
            OptionsPanel.Children.Add(radioButton);
        }
        private void Option_Checked(object sender, RoutedEventArgs e)
        {
            // Save the current choice when an option is checked
            SaveCurrentChoice();

            // Update progress bar based on the number of questions answered
            UpdateProgressBar();
        }
        private void SaveCurrentChoice()
        {
            // Save the currently selected option for the current question
            foreach (RadioButton rb in OptionsPanel.Children)
            {
                if (rb.IsChecked == true)
                {
                    var currentQuestion = questions[currentQuestionIndex];
                    userChoices[currentQuestion.QuestionId] = (string)rb.Tag; // Save the user's choice
                    break;
                }
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Save the choice for the current question before submitting
            SaveCurrentChoice();

            if (userChoices.Count == questions.Count || SubmitCheckBox.IsChecked == true)
            {
                // Calculate the total score
               
                int totalScore = CalculateScore();
                ShowResult(totalScore);
            }
            else
            {
                MessageBox.Show("Please answer all questions before submitting.");
            }
        }

        private int CalculateScore()
        {
            int score = 0;
            foreach (var question in questions)
            {
                if (userChoices.TryGetValue(question.QuestionId, out string userChoice) &&
                    userChoice == question.CorrectAnswer)
                {
                    score++;
                }
            }
            return score;
        }

        private void ShowResult(int totalScore)
        {
            // Calculate the final score based on a maximum score of 10
            double maxScore = 10.0; // Assuming maximum possible score is 10
            double finalScore = (maxScore / questions.Count) * totalScore;

            // Create and show the result window with the total score
            Score score = new()
            {
                Username = this.userName,
                LessonId = this.lessionID,
                Score1 = (int)Math.Round(finalScore),
                TakenAt = DateTime.Now
            };
            _scoreService.CreateAScore(score);

            StudentResult resultWindow = new StudentResult(totalScore, questions.Count);
            resultWindow.Show();
            this.Close();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            // Save the choice for the current question before navigating
            SaveCurrentChoice();

            if (currentQuestionIndex > 0)
            {
                currentQuestionIndex--;
                DisplayQuestion();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Save the choice for the current question before navigating
            SaveCurrentChoice();

            if (currentQuestionIndex < questions.Count - 1)
            {
                currentQuestionIndex++;
                DisplayQuestion();
            }
        }

        private void UpdateProgressBar()
        {
            // Count how many questions have been answered
            int answeredQuestionsCount = userChoices.Count;
            QuestionProgressBar.Value = answeredQuestionsCount;
        }

        private void SubmitCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Enable the Submit button when the CheckBox is checked
            SubmitButton.IsEnabled = true;
        }

        private void SubmitCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Disable the Submit button when the CheckBox is unchecked
            SubmitButton.IsEnabled = false;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.System && e.SystemKey == Key.F4) // Alt+F4
            {
                e.Handled = true;
            }

            if ((Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt ||
                (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control ||
                (Keyboard.Modifiers & ModifierKeys.Windows) == ModifierKeys.Windows)
            {
                e.Handled = true;
            }
        }

    }
}
