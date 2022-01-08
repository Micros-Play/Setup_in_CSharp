using System;
using System.Windows.Forms;

namespace Setup
{
    public partial class setup : Form
    {
        public setup()
        {
            InitializeComponent();
        }

        private void setup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); //При закрытии окошка закрывается программа
        }

        private void setup_Load(object sender, EventArgs e)
        {
            string PathDefault = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); //Дефолтный путь
            textBox1.Text = PathDefault + @"\Setup\"; //К дефолтному пути мы приписываем дополнительный каталог, который будет создан и там будет храниться наша программа.
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog select = new FolderBrowserDialog(); //Создаём обозреватель папок
            select.ShowDialog(); //Открываем
            textBox1.Text = select.SelectedPath + @"\Setup\"; //см выше про textBox1.Text
        }
        private void button2_Click(object sender, EventArgs e)
        {
            unpacking unpack = new unpacking();
            if (checkBox1.Checked)
            {
                transform.checkBoxChecked = true;
            }
            else
            {
                transform.checkBoxChecked = false;
            }
            if (transform.comboBoxCaseSelected == "ru") //Задаём условие, какой был выбран язык
            { //Если Русский
                unpack.label1.Text = language_ru.label1;
                unpack.label2.Text = language_ru.label3;
            }
            else if (transform.comboBoxCaseSelected == "en")
            { //Если Английский
                unpack.label1.Text = language_en.label1;
                unpack.label2.Text = language_en.label3;
            }
            transform.PathDirectory = textBox1.Text;
            unpack.Show();
            this.Hide();
        }
    }
}
