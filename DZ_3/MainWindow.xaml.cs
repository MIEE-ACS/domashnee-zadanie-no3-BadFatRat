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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DZ_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int number_of_right_answers = 0; // количество правильных ответов
        int number_of_wrong_answers = 0; // количество неправильных ответов 
        int right; // RadioButton с номером right содержит правильный ответ

        public MainWindow()
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            B1.Visibility = Visibility.Visible;
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            B1.Visibility = Visibility.Hidden;
            B2.Visibility = Visibility.Visible;
            label_4_q.Visibility = Visibility.Visible;
            RB_1.Visibility = Visibility.Visible;
            RB_2.Visibility = Visibility.Visible;
            RB_3.Visibility = Visibility.Visible;
            RB_4.Visibility = Visibility.Visible;
            right_answer_label.Visibility = Visibility.Visible;
            wrong_answer_label.Visibility = Visibility.Visible;
            Basis();
        }
        private void B2_Click(object sender, RoutedEventArgs e)
        {
            if (RB_1.IsChecked == true)
            {
                if (right == 1)
                    Labels(true);
                else
                    Labels(false);
                Basis();
            }
            else if (RB_2.IsChecked == true)
            {
                if (right == 2)
                    Labels(true);
                else
                    Labels(false);
                Basis();
            }
            else if (RB_3.IsChecked == true)
            {
                if (right == 3)
                    Labels(true);
                else
                    Labels(false);
                Basis();
            }
            else if (RB_4.IsChecked == true)
            {
                if (right == 4)
                    Labels(true);
                else
                    Labels(false);
                Basis();
            }
            else
            {
                MessageBox.Show("Выберите ответ!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Basis()
        {
            Random rnd = new Random();
            string sign; // плюс или минус в вопроск
            right = rnd.Next(1, 5); // выбор RadioButton в котором будет правильный ответ
            int rndSign = rnd.Next(1, 3); // выбор знака для вопроса 
            int answer; // правильный ответ
            int wrong1, wrong2, wrong3, wrong4; // переменные для получания случайных неправильных ответов
            int x = rnd.Next(1, 51);
            int y = rnd.Next(1, 51);
            if (rndSign == 1)
            {
                sign = "+";
                answer = x + y;
            }
            else
            {
                while (x < y)
                    y = rnd.Next(1, 51);
                sign = "-";
                answer = x - y;
            }
            string question = $"{x} {sign} {y} = ?";
            label_4_q.Content = question;
            switch (right)
            {
                case 1:
                    {
                        RB_1.Content = answer;
                        do
                        {
                            wrong2 = RBatton(answer);
                            wrong3 = RBatton(answer);
                            wrong4 = RBatton(answer);
                        } while (wrong2 == wrong3 || wrong3 == wrong4 || wrong2 == wrong4);
                        RB_2.Content = wrong2;
                        RB_3.Content = wrong3;
                        RB_4.Content = wrong4;
                        break;
                    }
                case 2:
                    {
                        RB_2.Content = answer;
                        do
                        {
                            wrong1 = RBatton(answer);
                            wrong3 = RBatton(answer);
                            wrong4 = RBatton(answer);
                        } while (wrong1 == wrong3 || wrong3 == wrong4 || wrong1 == wrong4);
                        RB_1.Content = wrong1;
                        RB_3.Content = wrong3;
                        RB_4.Content = wrong4;
                        break;
                    }
                case 3:
                    {
                        RB_3.Content = answer;
                        do
                        {
                            wrong1 = RBatton(answer);
                            wrong2 = RBatton(answer);
                            wrong4 = RBatton(answer);
                        } while (wrong1 == wrong2 || wrong2 == wrong4 || wrong1 == wrong4);
                        RB_1.Content = wrong1;
                        RB_2.Content = wrong2;
                        RB_4.Content = wrong4;
                        break;
                    }
                case 4:
                    {
                        RB_4.Content = answer;
                        do
                        {
                            wrong1 = RBatton(answer);
                            wrong2 = RBatton(answer);
                            wrong3 = RBatton(answer);
                        } while (wrong1 == wrong2 || wrong2 == wrong3 || wrong1 == wrong3);
                        RB_1.Content = wrong1;
                        RB_2.Content = wrong2;
                        RB_3.Content = wrong3;
                        break;
                    }
            }
        }
        static int RBatton(int b) // генерирует случайный неправильный ответ
        {
            Random rnd = new Random();
            int b1 = b;
            int a = b - 4;
            int c = b + 5;
            if (a < 0)
                a = 0;
            if (c > 100)
                c = 100;
            while (b1 == b)
                b1 = rnd.Next(a, c);
            return b1;
        }
        private void Labels(bool i)
        {
            if (i == false)
            {
                MessageBox.Show("Вы дали неправильный ответ.", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
                number_of_wrong_answers++;
                wrong_answer_label.Content = $"Неправильных ответов: {number_of_wrong_answers}";
            }
            else
            {
                MessageBox.Show("Вы дали правильный ответ!", "Результат", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                number_of_right_answers++;
                right_answer_label.Content = $"Правильных ответов: {number_of_right_answers}";
            }
        }
    }
}