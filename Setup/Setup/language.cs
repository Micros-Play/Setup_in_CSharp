using System;
using System.Windows.Forms;

namespace Setup
{
    public partial class language : Form
    {
        public language()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex) //Переключатель языка
            {
                case 0: //Выбран Русский
                    transform.comboBoxCaseSelected = "ru";
                    setup set_ru = new setup();
                    set_ru.label1.Text = language_ru.label1;
                    set_ru.label2.Text = language_ru.label2;
                    set_ru.checkBox1.Text = language_ru.checkBox1;
                    set_ru.button2.Text = language_ru.button1;
                    set_ru.Show();
                    this.Hide();
                    break;

                case 1: //Выбран Английский
                    transform.comboBoxCaseSelected = "en";
                    setup set_en = new setup();
                    set_en.label1.Text = language_en.label1;
                    set_en.label2.Text = language_en.label2;
                    set_en.checkBox1.Text = language_en.checkBox1;
                    set_en.button2.Text = language_en.button1;
                    set_en.Show();
                    this.Hide();
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
