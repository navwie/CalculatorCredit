using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FTPZ
{
    public partial class Form1 : Form
    {
        double baseRate, monthlyRate, sumOfLoan, paymentOneMonth,finalSum;
        int numberOfYears = 0;
        String monthP, finalP;

        //Звіт
        private void makeReport_Click(object sender, EventArgs e)
        {
            mReport.AppendText("Калькулятор кредитов" + "\n" + "\n");
            mReport.AppendText("Сума кредиту:" + "\t" + loan.Text + "\n" + "\n");
            mReport.AppendText("На кількість років:" + "\t" + years.Text + "\n" + "\n");
            mReport.AppendText("Базова ставка:" + "\t" + rate.Text + "\n" + "\n");
            mReport.AppendText("Помісячна оплата:" + "\t" + paymentMonth.Text + "\n" + "\n");
            mReport.AppendText("Підсумкова сума:" + "\t" + paymentFinal.Text + "\n" + "\n");
        }
        //


        private void Calc_Click_1(object sender, EventArgs e)
        {
            //Перевірка на введення даних
            try
            {
                sumOfLoan = Convert.ToDouble(loan.Text);
                numberOfYears = Convert.ToInt32(years.Text);
            }
            catch
            {
                if (loan.Text == "" || years.Text == "")
                {
                    MessageBox.Show("Незаповненi поля");
                }
                else
                {
                    MessageBox.Show("Введенi некорректнi значення");
                }
                baseRate = 15;
                loan.Clear();
                rate.Text = baseRate.ToString();
                years.Clear();
                paymentOneMonth = 0;
                finalSum = 0;
                mReport.Clear();
                return;

            }
             //

            baseRate = Convert.ToDouble(rate.Text);
            monthlyRate = baseRate / 1200;

            if (sumOfLoan == 0 || sumOfLoan < 1000)
            {
                MessageBox.Show("Сума кредиту не може бути меньше однієї тисячи гривень!");
                baseRate = 15;
                loan.Clear();
                rate.Text = baseRate.ToString();
                years.Clear();
                paymentOneMonth = 0;
                finalSum = 0;
                mReport.Clear();
                return;
            }

            if (numberOfYears == 0 || numberOfYears < 0)
            {
                MessageBox.Show("Невiрнi значення. Будь ласка, введiть корректнi данi!");
                baseRate = 15;
                rate.Text = baseRate.ToString();
                years.Clear();
                paymentOneMonth = 0;
                finalSum = 0;
                loan.Clear();
                mReport.Clear();
                return;
            }


            if (sumOfLoan >= 40000)
            {
                MessageBox.Show("Обговорюється індивідуально");
                baseRate = 15;
                rate.Text = baseRate.ToString();
                years.Clear();
                paymentOneMonth = 0;
                finalSum = 0;
                loan.Clear();
                mReport.Clear();
                return;
            }

            else if ((sumOfLoan > 1000 && sumOfLoan < 10000) || numberOfYears < 3)
            {
                paymentOneMonth = Math.Ceiling(sumOfLoan * monthlyRate / (1 - 1 / Math.Pow(1 + monthlyRate, numberOfYears * 12)));
            }
            else if (sumOfLoan > 10000 && sumOfLoan < 19999)
            {
                baseRate -= 1;
                rate.Text = baseRate.ToString();
                monthlyRate = baseRate / 1200;
                paymentOneMonth = Math.Ceiling(sumOfLoan * monthlyRate / (1 - 1 / Math.Pow(1 + monthlyRate, numberOfYears * 12)));

            }
            else if (sumOfLoan >= 20000 && sumOfLoan < 40000)
            {
                baseRate -= 2;
                rate.Text = baseRate.ToString();
                monthlyRate = baseRate / 1200;
                paymentOneMonth = Math.Ceiling(sumOfLoan * monthlyRate / (1 - 1 / Math.Pow(1 + monthlyRate, numberOfYears * 12)));

            }

            if (numberOfYears > 10)
            {
                MessageBox.Show("Обговорюється індивідуально");
                return;
            }

            else if (numberOfYears > 3 && numberOfYears < 5)
            {
                baseRate += 1;
                rate.Text = baseRate.ToString();
                monthlyRate = baseRate / 1200;
                paymentOneMonth = Math.Ceiling(sumOfLoan * monthlyRate / (1 - 1 / Math.Pow(1 + monthlyRate, numberOfYears * 12)));
            }
            else if (numberOfYears > 4 && numberOfYears < 11)
            {
                baseRate += 2;
                rate.Text = baseRate.ToString();
                monthlyRate = baseRate / 1200;
                paymentOneMonth = Math.Ceiling(sumOfLoan * monthlyRate / (1 - 1 / Math.Pow(1 + monthlyRate, numberOfYears * 12)));
            }

            monthP = Convert.ToString(paymentOneMonth);
            monthP = paymentOneMonth.ToString();
            paymentMonth.Text = (monthP);


            finalSum = Math.Ceiling(paymentOneMonth * numberOfYears * 12);
            finalP = finalSum.ToString();
            paymentFinal.Text = (finalP);

            loan.Text = sumOfLoan.ToString();

        }

        public Form1()
        {
            InitializeComponent();
        }


        public void ClearButton_Click_1(object sender, EventArgs e)
        {
            baseRate = 15;
            loan.Clear();
            rate.Text = baseRate.ToString();
            years.Clear();
            paymentMonth.Text = " ";
            paymentFinal.Text = "";
            mReport.Clear();
        }


        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Ви впевнені що хочете вийти? ", "Калькулятор кредитов", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    }
}
