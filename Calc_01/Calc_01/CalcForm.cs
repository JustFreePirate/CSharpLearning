using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            opPressed = false;
            button0_Click(null, null);
            buttonPlus_Click(null, null);
        }

        //как только нажимается клавиша, если был нажат оператор, то currentNum = num
        // если не был нажат оператор то currentNum *= 10, +num
        private void button1_Click(object sender, EventArgs e)
        {
            if (opPressed)
            {
                opPressed = false;
                currentNumber = 0;
            }
            currentNumber *= 10;
            currentNumber += 1;
            updateTextBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (opPressed)
            {
                opPressed = false;
                currentNumber = 0;
            }
            currentNumber *= 10;
            currentNumber += 2;
            updateTextBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (opPressed)
            {
                opPressed = false;
                currentNumber = 0;
            }
            currentNumber *= 10;
            currentNumber += 3;
            updateTextBox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (opPressed)
            {
                opPressed = false;
                currentNumber = 0;
            }
            currentNumber *= 10;
            currentNumber += 4;
            updateTextBox();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (opPressed)
            {
                opPressed = false;
                currentNumber = 0;
            }
            currentNumber *= 10;
            currentNumber += 5;
            updateTextBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (opPressed)
            {
                opPressed = false;
                currentNumber = 0;
            }
            currentNumber *= 10;
            currentNumber += 6;
            updateTextBox();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (opPressed)
            {
                opPressed = false;
                currentNumber = 0;
            }
            currentNumber *= 10;
            currentNumber += 7;
            updateTextBox();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (opPressed)
            {
                opPressed = false;
                currentNumber = 0;
            }
            currentNumber *= 10;
            currentNumber += 8;
            updateTextBox();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (opPressed)
            {
                opPressed = false;
                currentNumber = 0;
            }
            currentNumber *= 10;
            currentNumber += 9;
            updateTextBox();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (opPressed)
            {
                opPressed = false;
                currentNumber = 0;
            }
            currentNumber *= 10;
            updateTextBox();
        }



        //Операторы -- >

        //как только нажимается оператор, он сразу пушатся в парсер вместе с числом, 
        //но его можно заменить, если нажать после на другой.
        private void buttonMult_Click(object sender, EventArgs e)
        {
            if (!opPressed)
            {
                parser.addNum(currentNumber);
                parser.addOp('*');
            }
            else if (!lastOp.Equals('('))
            {
                parser.changeTopOp('*');
            }
            opPressed = true;
            currentNumber = parser.getTop();
            updateTextBox();
            lastOp = '*';
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            if (!opPressed)
            {
                parser.addNum(currentNumber);
                parser.addOp('/');
            }
            else if (!lastOp.Equals('('))
            {
                parser.changeTopOp('/');
            }
            currentNumber = parser.getTop();
            opPressed = true;
            updateTextBox();
            lastOp = '/';
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (!opPressed)
            {
                parser.addNum(currentNumber);
                parser.addOp('+');
            }
            else if (!lastOp.Equals('(') )
            {
                parser.changeTopOp('+');
            }
            currentNumber = parser.getTop();
            opPressed = true;
            updateTextBox();
            lastOp = '+';
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (!opPressed)
            {
                parser.addNum(currentNumber);
                parser.addOp('-');
            }
            else if (!lastOp.Equals('(')) //если последний оператор - левая скобка, то его уже нельзя изменить
            {
                parser.changeTopOp('-');
            }
            opPressed = true;
            currentNumber = parser.getTop();
            updateTextBox();
            lastOp = '-';
        }



        private void buttonEqual_Click(object sender, EventArgs e)
        {
            if (opPressed && !lastOp.Equals(')') && !lastOp.Equals('=')) //были нажаты +-*/(
            {
                parser.popTopOp(); //снять с верхушки уже добавленный оператор
            }
            if (!opPressed && !lastOp.Equals('='))
            {
                parser.addNum(currentNumber);
            }
            parser.calculate();
            currentNumber = parser.getTop();
            lastOp = '=';
            opPressed = true;
            updateTextBox();
        }

        private void buttonRightBracket_Click(object sender, EventArgs e)
        {
            if (countLeftBrackets > 0)
            {
                if (opPressed)
                {
                    if (!lastOp.Equals(')') && !lastOp.Equals('(')) //было нажато +-*/
                    {
                        parser.popTopOp(); //снимаем их
                    }
                }
                else
                {
                    parser.addNum(currentNumber);
                }
                parser.addOp(')');
                countLeftBrackets--;
                lastOp = ')';
                
                
                opPressed = true;
                currentNumber = parser.getTop();
                updateTextBox();
            }
        }
        //левая скобка уже не меняется на другой оператор
        private void buttonLeftBracket_Click(object sender, EventArgs e)
        {
            if (opPressed)
            {
                parser.addOp('(');
                currentNumber = parser.getTop();
                updateTextBox();
                lastOp = '(';
                countLeftBrackets++;
            }

        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            parser.clear();
            currentNumber = 0;
            opPressed = false;
            buttonPlus_Click(null, null); //0 + ...
            updateTextBox();
        }

        private void buttonDel_Click(object sender, EventArgs e) //del last symbol
        {
            if (!opPressed)
            {
                currentNumber /= 10;
                updateTextBox();
            }
        }





        private void radioButtonOct_CheckedChanged(object sender, EventArgs e)
        {
            button8.Enabled = false; //there are no buttons 8 and 9 in oct
            button9.Enabled = false;
        }

        private void radioButtonDec_CheckedChanged(object sender, EventArgs e)
        {
            button8.Enabled = true; //there are buttons 8 and 9 in dec
            button9.Enabled = true;
        }



        private void updateTextBox()
        {
            textBox.Text = currentNumber.ToString();
            char[] ops = parser.getOps();
            Array.Reverse(ops);
            Int64[] nums = parser.getNums();
            Array.Reverse(nums);
            textBox1.Text = string.Join(",", nums);
            textBox2.Text = string.Join(",", ops);
        }




        private bool opPressed = false;
        private char lastOp;
        private Int64 currentNumber = 0;
        private Parser parser = new Parser();
        private int countLeftBrackets = 0;



        //как только нажимается оператор, он сразу пушатся в парсер вместе с числом, но его можно заменить, если нажать после на другой.
        //как только нажимается клавиша, если был нажат оператор, то currentNum = num
        // если не был нажат оператор то currentNum *= 10, +num
        //если нажали равно, и оператор был нажат, то последний оператор не считается
        //если нажали равно и оператор не был нажат, то просто считаем значение выражения
    }
}
