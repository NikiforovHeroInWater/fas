using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Расчёт_заплаты
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        
        string razr;
        private void par5name_Click(object sender, EventArgs e)
        {

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            //уверен ли пользователь в очистке
            DialogResult result = MessageBox.Show("Вы уверенны, что хотите очистить все поля?","Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {

                //очистка полей

                //Поле выбора стажа
                stajBox.Text = "";
                //Поле выбора разряда
                razr1.Checked = false;
                razr2.Checked = false;
                razr3.Checked = false;
                //поле почас. оплаты
                oneHrPay.Text = "";
                //очистка рабоч дня
                dayLength.Text = "";
                //очистка кол-ва раб.дней
                kolDay.Text = "";
                //очистка налоговой ставки
                txtNalogi.Text = "";
            }
        }
        int ID = 0;
        private void saveBtn_Click(object sender, EventArgs e)
        {
            
            //Соглашение на сохранение
            DialogResult result1 = MessageBox.Show("Вы уверенны, что хотите сохранить данные?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result1 == DialogResult.Yes)
            {
                
                ID += 1;
                //Сохранение пароля в текстовый документ
                Directory.CreateDirectory("C:\\Users\\isip\\Desktop\\sotr");
                //File.Create("C:\\Users\\isip\\Desktop\\pass\\pswrd.txt");
                FileStream fs0 = new FileStream("C:\\Users\\isip\\Desktop\\sotr\\IDs.txt", FileMode.OpenOrCreate, FileAccess.Write);
                fs0.Close();
                FileStream fs = new FileStream("C:\\Users\\isip\\Desktop\\sotr\\IDs.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(Convert.ToString(ID) + " " + stajBox.SelectedIndex + " " + razr +" "+ oneHrPay.Text + " " + dayLength.SelectedIndex + " " + kolDay.SelectedIndex + " " + txtNalogi.Text);
                sw.Close();
                fs.Close();
                MessageBox.Show($"Данные сотрудника под ID №{ID} сохранены");
            }
            
        }

        private void oneHrPay_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void oneHrPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ограничение на ввод только цифр
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtNalogi_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ограничение на ввод только цифр
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void razr1_CheckedChanged(object sender, EventArgs e)
        {
            razr = "1";
        }

        private void razr2_CheckedChanged(object sender, EventArgs e)
        {
            razr = "2";
        }

        private void razr3_CheckedChanged(object sender, EventArgs e)
        {
            razr = "3";
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            DialogResult result2 = MessageBox.Show("Вы уверенны, что хотите УДАЛИТЬ данные?", "ВНИМАНИЕ!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (result2 == DialogResult.Yes)
            {
                File.Delete("C:\\Users\\isip\\Desktop\\sotr\\IDs.txt");
            }
            MessageBox.Show("Удаление успешно");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
