using System;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using Setup.Properties;
using System.Threading.Tasks;
using IWshRuntimeLibrary;

namespace Setup
{
    public partial class unpacking : Form
    {
        public unpacking()
        {
            InitializeComponent();

        }

        async void unpacking_Load(object sender, EventArgs e)
        {
            //Программное отображение процесса распаковки файлов в директорию
            string PathDirectory = transform.PathDirectory; //Вызываем из класса переменную, в которой поместили путь для распаковки
            if (!Directory.Exists(PathDirectory)) //Задаём условие для проверки наличия директории
            {
                Directory.CreateDirectory(PathDirectory); //Если не существует, то создаём
            }
            else
            {
                Directory.Delete(PathDirectory, true); //Если существует, то перезаписывает
                Directory.CreateDirectory(PathDirectory);
            }
            string Unpacking = PathDirectory + @"\Release.zip"; //Создаём переменную для переноса архива с программой
            System.IO.File.WriteAllBytes(Unpacking, Resources.Release); //Переносим
            string zipPath = Unpacking; //Создаём переменную для местоположения архива
            ZipFile.ExtractToDirectory(zipPath, PathDirectory); //Распаковываем архив
            System.IO.File.Delete(Unpacking); //Удаляем архив, оставляя программу и директорию

            //Графическое отображение процесса распаковки файлов в директорию
            string[] files = Directory.GetFiles(PathDirectory, "*.*", SearchOption.AllDirectories); //Заносим в массив кол-во содержимого файлов
            int quantity = files.Length; //Создаём переменную, которая заносит кол-во содержимого
            progressBar1.Maximum = quantity; //Прогресс бар = кол-во содержимому
            for (; quantity > 0; quantity--) //Цикл для отображения информации на графический интерфейс
            {
                label3.Text = files[quantity - 1]; //Т.к. массив считает не с 1, а с 0, то уменьшаем кол-во на -1
                progressBar1.Value++; //Увеличивается шкала на + %
                await Task.Delay(100); //Задержка в мс
            }
            if (transform.checkBoxChecked == true) //Если указали создать ярлык на рабочем столе
            {
                WshShell shell = new WshShell(); //Создаём скрипт
                string shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Setup.lnk"; //Создаём переменную пути рабочего стола
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath); //Создаём ярлык
                shortcut.WorkingDirectory = PathDirectory; //Указываем рабочую папку
                shortcut.TargetPath = PathDirectory + @"\ETLauncher.exe"; //Указываем исполняемый файл
                shortcut.Save(); //Сохраняем
            }
            if (progressBar1.Value == progressBar1.Maximum)
            {
                await Task.Delay(500);
                done don = new done();
                if (transform.comboBoxCaseSelected == "ru") //Задаём условие, какой был выбран язык
                { //Если Русский
                    don.label1.Text = language_ru.label1;
                    don.label2.Text = language_ru.label4;
                    don.button1.Text = language_ru.button2;
                }
                else if (transform.comboBoxCaseSelected == "en")
                { //Если Английский
                    don.label1.Text = language_en.label1;
                    don.label2.Text = language_en.label4;
                    don.button1.Text = language_en.button2;
                }
                don.Show();
                this.Hide();
            }
        }

        private void unpacking_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
