using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Mazer_Prodject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
  
        }
        // клас очиски
        public void cler() { 
        textBox1.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            label5.Text = "0";
            kar = 0;
        }

        // класс сохранения
        public void seve_file(string Name_File)
        {
            string path = @"C:\Сollections";

            if (listBox1.Items.Count > 0)
                {
                if (Directory.Exists(path))
                {
                    StreamWriter sw = new StreamWriter(@"C:\Сollections\" + Name_File + ".txt");

                    string[] st = new string[] { };

                    foreach (var item in listBox1.Items)
                        sw.WriteLine(item.ToString());
                    sw.Close();
                }
                else
                {
                    Directory.CreateDirectory(path);
                    StreamWriter sw = new StreamWriter(@"C:\Сollections\" + Name_File + ".txt");

                    string[] st = new string[] { };

                    foreach (var item in listBox1.Items)
                        sw.WriteLine(item.ToString());
                    sw.Close();
                }


                }
                else MessageBox.Show("Сайтов нет");
            

        }


        public void chek(int t)
        { 
            listBox2.Items.Clear();
            listBox3.Items.Clear();
         

            for (i = 0; i < kar; i++)
            {
                a[i] = listBox1.Items[i].ToString();
            }
            var g = a.GroupBy(i => i);
          
            foreach (var k in g)
            {

               listBox2.Items.Add(k.Key + " (" + k.Count() + ")");

                if (k.Count() > 3)
                {
                    listBox3.Items.Add((k.Key + " (" + k.Count() + ")"));
                }
                else;


            }
            
            Array.Clear(a, 0, a.Length);
            
           
        }
        // переменные
        int kar=0, i, namber;  String Name_File, s = ""; String[] a = new string[100]; 

        // добавление
        private void button1_Click(object sender, EventArgs e)
             
        {

            int j; string x;
            listBox2.Sorted = true;
            Name_File= textBox2.Text;

            if (textBox2.Text == "")
            {
                MessageBox.Show("Введите название коллекции");
            }
            else {
                textBox2.Hide();
                label7.Text = Name_File;

                if (comboBox1.SelectedIndex > -1)
            {
                namber = comboBox1.SelectedIndex + 1;
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Поле для водов сайтов пустое");
                }
               else
                {
                    x = textBox1.Text;
                    for (j = 0; j < namber; j++)
                    {
                        listBox1.Items.Add(x);
                        kar += 1;
                        chek(kar);
                        seve_file(Name_File);
                    }
                    textBox1.Clear();
                }

            }
            else  MessageBox.Show("Выберите количество");
            

            } 
            label5.Text = kar.ToString();
        }

        //сохронение
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Введите название коллекции");
            }
            else
            {
                Name_File = textBox2.Text;
                seve_file(Name_File);
            }
        }
        
        //копировать
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {

                listBox1.Items.Add(listBox1.SelectedItem.ToString());
                kar += 1;
                label5.Text = kar.ToString();
                chek(kar);
                seve_file(Name_File);

            }
             else MessageBox.Show("Не выбрано не одного элемента для копирования");


        }

        // очистка
        private void button5_Click(object sender, EventArgs e)
        {
            cler();
        }

        //удалить
        private void button3_Click(object sender, EventArgs e)
        {
           if (listBox1.SelectedIndex >-1){

                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    kar -= 1;
                     label5.Text = kar.ToString(); ;
                chek(kar);
                seve_file(Name_File);

            }
            else MessageBox.Show("Не выбрано не одного элемента для удаления");

        }
        
        // новая колекция
        private void новаяКолекцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.Show();
            label7.Text = "";
            textBox1.Clear();
            textBox2.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            label5.Text = "0";
            kar = 0;
            Name_File = "";
        }

        //загрузка
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cler();

                string[] readText = File.ReadAllLines(openFileDialog1.FileName);

                foreach (string s in readText)
                {
                    listBox1.Items.Add(s);
                    kar += 1;
                    chek(kar);

                }

                Name_File = Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName);
                textBox2.Text = Name_File; ;

            }
        }
        
        //Проверка
        private void button4_Click(object sender, EventArgs e)
        {
            chek(kar);

        }

        //пустые
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
       
        }
                     
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {
                   }

        private void button6_Click(object sender, EventArgs e)
        {
        }
         
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }
        
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
                   
        }
        
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            
        }
       
        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        
    }
}
