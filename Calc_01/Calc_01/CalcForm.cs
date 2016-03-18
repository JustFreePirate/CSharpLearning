using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/* Идея в том, чтобы сделать строку для ввода и парсить лишь момент нажатия "="
 * Если хоть в чем-то пользователь ошибся, то строку не меняем на экране и выводим сообщение об ошибке
 * Если выражение корректно, то считаем его и выводим результат
 * Одна строка для парсинга её и кидаем в парсер
 * Парсер жует всю строку сразу и выдает ответ в виде числа или ошибки
 * ошибки будем распознавать по исключениям
 */

namespace Calc_01
{
    public partial class CalcForm : Form
    {
        public CalcForm()
        {
            InitializeComponent();
            
        }

        private void CalcForm_Load(object sender, EventArgs e)
        {
            
        }


        private void updateTextBox() {
            textBox.Text = currentExpression;
        }


        //Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            currentExpression += "1";
            updateTextBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentExpression += "2";
            updateTextBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentExpression += "3";
            updateTextBox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentExpression += "4";
            updateTextBox();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentExpression += "5";
            updateTextBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentExpression += "6";
            updateTextBox();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currentExpression += "7";
            updateTextBox();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            currentExpression += "0";
            updateTextBox();
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            currentExpression += "-";
            updateTextBox();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            currentExpression += "+";
            updateTextBox();
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            currentExpression += "*";
            updateTextBox();
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            currentExpression += "/";
            updateTextBox();
        }

        private void buttonLeftBracket_Click(object sender, EventArgs e)
        {
            currentExpression += "(";
            updateTextBox();
        }

        private void buttonRightBracket_Click(object sender, EventArgs e)
        {
            currentExpression += ")";
            updateTextBox();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (currentExpression.Length > 0)
            {
                currentExpression = currentExpression.Substring(0, currentExpression.Length - 1);
            }
            updateTextBox();
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            currentExpression = "";
            updateTextBox();
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            
            Int64 ans;
            Parser parser = new Parser();
            try
            {
                if (currentExpression.Length > 0)
                {
                    ans = parser.evaluate(currentExpression);
                }
                else ans = 0;
                currentExpression = Convert.ToString(ans);
                textBox1.Text = "";
            } catch (Exception except) {
                //syntax error
                textBox1.Text = except.Message;
            }
            updateTextBox();
        }

        

        private string currentExpression;
    }
}
