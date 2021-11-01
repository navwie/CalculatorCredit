using System;
using System.Windows.Forms;

namespace FTPZ
{
    public partial class Form1 : Form
    {
        double InterestRate, monthlyInterestRate, loanAmount, MonthlyPayment,TotalPayment;

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Подвердите если хотите выйти","Калькулятор кредитов", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if(iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InterestRate = 15;
            textBox1.Clear();
            textBox3.Text = InterestRate.ToString();
            textBox4.Clear();
            IbIMonthlyPayment.Text = " ";
            IbITotalPayment.Text = "";
           // richTextBox1.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                loanAmount = Convert.ToDouble(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Введенi некорректнi значення або незаповненi поля");
                InterestRate = 15;
                textBox1.Clear();
                textBox3.Text = InterestRate.ToString();
                textBox4.Clear();
                MonthlyPayment = 0;
                TotalPayment = 0;
                return;

            }

            int numberOfYears = 0;
            try
            {
                numberOfYears = Convert.ToInt32(textBox4.Text);
            }
            catch
            {
                MessageBox.Show("Введенi некорректнi значення або незаповненi поля");
                InterestRate = 15;
                textBox1.Clear();
                textBox3.Text = InterestRate.ToString();
                textBox4.Clear();
                MonthlyPayment = 0;
                TotalPayment = 0;
                return;
            }

            InterestRate = Convert.ToDouble(textBox3.Text);
            monthlyInterestRate = InterestRate / 1200;

            if(loanAmount == 0 || loanAmount < 1000)
            {
                MessageBox.Show("Невiрнi значення. Сума кредиту не меньше однієї тисячи гривень!");
                InterestRate = 15;
                textBox1.Clear();
                textBox3.Text = InterestRate.ToString();
                textBox4.Clear();
                MonthlyPayment = 0;
                TotalPayment = 0;
                return;
            }

            if (numberOfYears == 0 || numberOfYears < 0 )
            {
                MessageBox.Show("Невiрнi значення. Будь ласка, введiть корректнi данi!");
                InterestRate = 15;
                textBox3.Text = InterestRate.ToString();
                textBox4.Clear();
                MonthlyPayment = 0;
                TotalPayment = 0;
                textBox1.Clear();
                return;
            }


            if (loanAmount >= 40000)
            {
                MessageBox.Show("Обговорюється індивідуально");
                InterestRate = 15;
                textBox3.Text = InterestRate.ToString();
                textBox4.Clear();
                MonthlyPayment = 0;
                TotalPayment = 0;
                textBox1.Clear();
                return;
            }

            else if((loanAmount > 1000 && loanAmount < 10000)  || numberOfYears < 3)
            {
                MonthlyPayment = Math.Ceiling(loanAmount * monthlyInterestRate / (1 - 1 / Math.Pow(1 + monthlyInterestRate,
                    numberOfYears * 12)));
            }
            else if(loanAmount > 10000 && loanAmount < 19999)
            {
                InterestRate -= 1;
                textBox3.Text = InterestRate.ToString();
                monthlyInterestRate = InterestRate / 1200;
                MonthlyPayment = Math.Ceiling(loanAmount * monthlyInterestRate / (1 - 1 / Math.Pow(1 + monthlyInterestRate,
                numberOfYears * 12)));

            }
            else if(loanAmount >= 20000 && loanAmount < 40000)
            {
                InterestRate -= 2;
                textBox3.Text = InterestRate.ToString();
                monthlyInterestRate = InterestRate / 1200;
                MonthlyPayment = Math.Ceiling(loanAmount * monthlyInterestRate / (1 - 1 / Math.Pow(1 + monthlyInterestRate,
                numberOfYears * 12)));

            }

            if(numberOfYears > 10)
            {
                MessageBox.Show("Обговорюється індивідуально");
                InterestRate = 15;
                textBox3.Text = InterestRate.ToString();
                textBox4.Clear();
                MonthlyPayment = 0;
                TotalPayment = 0;
                textBox1.Clear();
                return;
            }

            else if (numberOfYears > 3 && numberOfYears < 5)
            {
                InterestRate += 1;
                textBox3.Text = InterestRate.ToString();
                monthlyInterestRate = InterestRate / 1200;
                MonthlyPayment = Math.Ceiling(loanAmount * monthlyInterestRate / (1 - 1 / Math.Pow(1 + monthlyInterestRate,
                numberOfYears * 12)));
            }
            else if (numberOfYears > 4 && numberOfYears < 11)
            {
                InterestRate += 2;
                textBox3.Text = InterestRate.ToString();
                monthlyInterestRate = InterestRate / 1200;
                MonthlyPayment = Math.Ceiling(loanAmount * monthlyInterestRate / (1 - 1 / Math.Pow(1 + monthlyInterestRate,
                numberOfYears * 12)));
            }

            iMonthlyPayment = Convert.ToString(MonthlyPayment);
            iMonthlyPayment = MonthlyPayment.ToString();
            IbIMonthlyPayment.Text = (iMonthlyPayment);


            TotalPayment = Math.Ceiling( MonthlyPayment * numberOfYears * 12);
            iTotalPayment = TotalPayment.ToString();
            IbITotalPayment.Text = (iTotalPayment);

            textBox1.Text = loanAmount.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        
        String iMonthlyPayment, iTotalPayment;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
