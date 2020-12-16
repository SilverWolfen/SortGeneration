using System;
using System.IO;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace SortGeneration
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] goods = new string[] {"Чай", "кофе", "какао", "горячий шоколад","Цикорий", "Хлеб", "выпечка", "сладости",
                                                "Шоколад", "Конфеты", "Печенье", "Соки", "Лимонады", "Холодный чай", "Орехи", "Батончики",
                                                "Грибы", "Макароны", "крупы", "мука", "Молоко", "Сливки", "Сыр", "Яйца", "Масла", "Соус",
                                                "Специи", "Сиропы", "Овощи", "Морепродукты", "Полуфабрикаты", "Говядина", "Свинина",
                                                "Баранина", "Курица", "Фрукты", "Зелень", "Колбасы", "Балык", "Бекон", "Рыба", "Икра"};
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtEditor.Text = Directory.GetCurrentDirectory();
        }

        private void CreateFileBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            if (saveFileDialog.ShowDialog() == true)
            {
                Random rnd = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    int price = rnd.Next(1, 1000);
                    int goodsIndex = rnd.Next(0, goods.Length);
                    File.AppendAllText(saveFileDialog.FileName, string.Format("{0} || {1} || {2} \n", i + 1, goods[goodsIndex], price), System.Text.Encoding.UTF8);
                }
                txtEditor.Text = saveFileDialog.FileName;
            }
        }

        private void OpenFileBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                ResultBlock.Text = File.ReadAllText(openFileDialog.FileName);
                txtEditor.Text = openFileDialog.FileName;
            }
        }

        private void ParseBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                using (StreamReader sr = File.OpenText(openFileDialog.FileName))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitter = new String[] { "||" };
                        string[] cells = line.Split(splitter, StringSplitOptions.None);
                        
                        int price = Convert.ToInt32(cells[2]);
                        if (price < 100)
                        {
                            File.AppendAllText(openFileDialog.RestoreDirectory + "goods 1-100 price.txt", line + "\n", System.Text.Encoding.UTF8);
                        }
                        else if (price < 200)
                        {
                            File.AppendAllText(openFileDialog.RestoreDirectory + "goods 101-200 price.txt", line + "\n", System.Text.Encoding.UTF8);
                        }
                        else if (price < 300)
                        {
                            File.AppendAllText(openFileDialog.RestoreDirectory + "goods 201-300 price.txt", line + "\n", System.Text.Encoding.UTF8);
                        }
                        else if (price < 400)
                        {
                            File.AppendAllText(openFileDialog.RestoreDirectory + "goods 301-400 price.txt", line + "\n", System.Text.Encoding.UTF8);
                        }
                        else if (price < 500)
                        {
                            File.AppendAllText(openFileDialog.RestoreDirectory + "goods 401-500 price.txt", line + "\n", System.Text.Encoding.UTF8);
                        }
                        else if (price < 600)
                        {
                            File.AppendAllText(openFileDialog.RestoreDirectory + "goods 501-600 price.txt", line + "\n", System.Text.Encoding.UTF8);
                        }
                        else if (price < 700)
                        {
                            File.AppendAllText(openFileDialog.RestoreDirectory + "goods 601-700 price.txt", line + "\n", System.Text.Encoding.UTF8);
                        }
                        else if (price < 800)
                        {
                            File.AppendAllText(openFileDialog.RestoreDirectory + "goods 701-800 price.txt", line + "\n", System.Text.Encoding.UTF8);
                        }
                        else if (price < 900)
                        {
                            File.AppendAllText(openFileDialog.RestoreDirectory + "goods 801-900 price.txt", line + "\n", System.Text.Encoding.UTF8);
                        }
                        else if (price < 1000)
                        {
                            File.AppendAllText(openFileDialog.RestoreDirectory + "goods 901-1000 price.txt", line + "\n", System.Text.Encoding.UTF8);
                        }
                    }
                    txtEditor.Text = openFileDialog.FileName;
                }
            }
        }
    }
}
