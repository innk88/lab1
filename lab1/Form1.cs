using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for(int i=0; i<1000; i=i+7)
            {
                sum+= i;
            }
            textBox1.Text = sum.ToString();
        }
        private double area(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            return Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            double x1=0, y1=0, x2=0, y2=0, x3=0, y3 = 0, x = 0, y = 0;
            bool to_double()
            {
                if (double.TryParse(textBox2.Text, out x1))
                {
                    x1 = Convert.ToDouble(textBox2.Text);
                    if (double.TryParse(textBox3.Text, out y1))
                    {
                        y1 = Convert.ToDouble(textBox3.Text);
                        if (double.TryParse(textBox4.Text, out x2))
                        {
                            x2 = Convert.ToDouble(textBox4.Text);
                            if (double.TryParse(textBox5.Text, out y2))
                            {
                                y2 = Convert.ToDouble(textBox5.Text);
                                if (double.TryParse(textBox6.Text, out x3))
                                {
                                    x3 = Convert.ToDouble(textBox6.Text);
                                    if (double.TryParse(textBox7.Text, out y3))
                                    {
                                        y3 = Convert.ToDouble(textBox7.Text);
                                        if (double.TryParse(textBox8.Text, out x) && double.TryParse(textBox9.Text, out y))
                                        {
                                            x = Convert.ToDouble(textBox8.Text);
                                            y = Convert.ToDouble(textBox9.Text);
                                            return true;
                                        }
                                        else textBox10.Text = "неправильный ввод x или y";
                                    }
                                    else textBox10.Text = "неправильный ввод y3";
                                }
                                else textBox10.Text = "неправильный ввод x3";
                            }
                            else textBox10.Text = "неправильный ввод y2";
                        }
                        else textBox10.Text = "неправильный ввод x2";
                    }
                    else textBox10.Text = "неправильный ввод y1";
                }
                else textBox10.Text = "неправильный ввод x1";
                return false;
            }
            bool is_correct()
            {
                if ((x1 == x2 && y1 == y2) || (x1 == x3 && y1 == y3) || (x3 == x2 && y3 == y2) || (x1==x2 && x2==x3) || (y1==y2 && y2==y3))
                {
                    textBox10.Text = "некорректный ввод координат";
                    return false;
                }
                else return true;
            }
            if (to_double() && is_correct())
            {
                double TriArea = area(x1, y1, x2, y2, x3, y3);
                double area1=area(x,y,x2,y2,x3,y3);
                double area2=area(x1,y1, x, y, x3, y3);
                double area3=area(x1, y1,x2, y2, x, y);
                if (TriArea == 0) textBox10.Text = "некорректный ввод координат";
                else
                {
                    if (TriArea == area1 + area2 + area3)
                    {
                        textBox10.Text = "входит";
                    }
                    else textBox10.Text = "не входит";
                }
            }
            
        }
        private bool isDigit(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            if(int.TryParse(input, out int digit)) return true;
            return false;
        }
        private bool IsName(string word)
        {
            string s = "";
            if (string.IsNullOrWhiteSpace(word))
            {
                return false;
            }
            foreach (char c in word)
            {
                if (!char.IsLetter(c))
                {
                   //textBox13.Text= ((int)c).ToString();
                    return false;
                }
            }
            //textBox13.Text = s;
            return char.IsUpper(word[0]);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string inputNames=textBox11.Text;
            if(inputNames != null) { 
                string[] names = inputNames.Split(new char[] {'\n', '\r' });
                //HashSet<string> uniqeFirstNames = new HashSet<string>();
               // HashSet<string> uniqeLastNames = new HashSet<string>();
                Dictionary<string, int> mapLastNames = new Dictionary<string, int>();
                Dictionary<string, int> mapFirstNames = new Dictionary<string, int>();
                Dictionary<string, int> mapFullNames = new Dictionary<string, int>();
                List<String> firstNames = new List<String>();
                List<String> lastNames = new List<String>();
                List<String> fullNames = new List<String>();
                foreach (string name in names)
                {
                    if (name != "" && name != null)
                    {
                        string[] nameParts = name.Split(new char[] { '.', ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        string firstName = "";
                        string lastName = "";
                        string FullName;
                        Regex.Replace(nameParts[1], @"[^a-zA-Zа-яА-Я]", "");
                        int result;
                        if (isDigit(nameParts[0]))
                        {
                            firstName = nameParts[2];
                            if (!mapFirstNames.ContainsKey(firstName))
                            {
                                mapFirstNames.Add(firstName, 1);
                            }
                            else mapFirstNames[firstName] += 1;
                            if (nameParts.Length > 3)
                            {
                                nameParts[3].Replace("\r", "");
                                if (IsName(nameParts[3]))
                                {
                                    Regex.Replace(nameParts[3], @"[^a-zA-Zа-яА-Я]", "");
                                    lastName = nameParts[3];
                                    FullName = firstName + lastName;
                                    if (!mapFullNames.ContainsKey(FullName))
                                    {
                                        mapFullNames.Add(FullName, 1);
                                    }
                                    else mapFullNames[FullName] += 1;
                                }
                            }
                        }
                        else
                        {
                            firstName = nameParts[1];
                            if (!mapFirstNames.ContainsKey(firstName))
                            {
                                mapFirstNames.Add(firstName, 1);
                            }
                            else mapFirstNames[firstName] += 1;
                            if (nameParts.Length > 1)
                            {
                                nameParts[2].Replace("\r", "");
                                if (IsName(nameParts[2]))
                                {
                                    Regex.Replace(nameParts[2], @"[^a-zA-Zа-яА-Я]", "");
                                    lastName = nameParts[2];
                                    FullName = firstName + lastName;
                                    if (!mapFullNames.ContainsKey(FullName))
                                    {
                                        mapFullNames.Add(FullName, 1);
                                    }
                                    else mapFullNames[FullName] += 1;
                                }
                            }
                        }
                    }
                }
                int maxNames = 0;
                foreach (var count in mapFirstNames.Values)
                {
                    if (count > maxNames && count!=1) maxNames = count;
                }
                int maxFullNames = 0;
                foreach (var count in mapFullNames.Values)
                {
                    if (count > maxFullNames && count != 1) maxFullNames = count;
                }
                textBox12.Text = maxFullNames.ToString();
                textBox13.Text = maxNames.ToString();
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
