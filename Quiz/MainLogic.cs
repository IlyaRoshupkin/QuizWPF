using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Quiz
{
    class MainLogic
    {
        private StackPanel spAnswers;
        Image image;
        string currentAnswer;
        QuestionDataBase data;

        /// <summary>
        /// TextBlock creation for alphabet appearing
        /// </summary>
        /// <param name= "Txt">Text for the appearing</param>
        /// <param name="ToSp">StackPanel for TextBlock appearing</param>
        /// <returns>Created TextBlock</returns>
        public TextBlock CreateTb(string Txt, StackPanel ToSp)
        {
            var tb = new TextBlock()
            {
                Text = Txt,
                FontSize = 25,
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(3),
                Background = Brushes.Coral,
                Width = 30,
                Height = 40,
            };

            tb.MouseDown += (s, e) =>
            {
                ToSp.Children.Add(CreateTbAlp((s as TextBlock).Text, ToSp));
                CheckAnswer();
            };
            return tb;
        }


        /// <summary>
        /// Answer checking
        /// </summary>
        private void CheckAnswer()
        {
            string word = String.Empty;
            foreach (var e in spAnswers.Children) word += (e as TextBlock).Text;
            if (word == currentAnswer)
            {
                MessageBox.Show($"Правильно! Это {currentAnswer.ToUpper()}");
                LoadNewQuestion();
            }
        }

        /// <summary>
        /// Question loading (image and answer saving)
        /// </summary>
        private void LoadNewQuestion()
        {
            var q = data.CurrentQuestion;
            image.Source = q.Picture;
            currentAnswer = q.Answer;
            spAnswers.Children.Clear();
        }

        /// <summary>
        /// TextBlock creation for answers appearing
        /// </summary>
        /// <param name="text">Text for appearing</param>
        /// <param name="toSp">StackPanel for TextBlock adding</param>
        /// <returns>Created TextBlock</returns>
        public TextBlock CreateTbAlp(string Txt, StackPanel stackPanel)
        {
            var tb = new TextBlock()
            {
                Text = Txt,
                FontSize = 30,
                Background = Brushes.LightBlue,
                Margin = new Thickness(3),
                Padding = new Thickness(10)
            };
            tb.MouseDown += (s, e) => { stackPanel.Children.Remove((s as TextBlock)); };
            return tb;
        }

        /// <summary>
        /// Class creaion with app main logic
        /// </summary>
        /// <param name="SPAlphabet">Link on StackPanel for alphabet appearing</param>
        /// <param name="SPAnswers">Link on StackPanel for answers appearing</param>
        /// <param name="pic">Link on Image for picture appearing</param>
        public MainLogic (StackPanel SPAlphabet, StackPanel SPAnswers, Image pic)
        {
            data = new QuestionDataBase();
            image = pic;
            spAnswers = SPAnswers;

            for (int i = (int)'а'; i <= (int)'я'; i++)
            {
                SPAlphabet.Children.Add(CreateTb($"{(char)i}", spAnswers));
                if (i == (int)'е') { SPAlphabet.Children.Add(CreateTb($"{'ё'}", SPAnswers)); }
            }
            LoadNewQuestion();
        }
    }
}
