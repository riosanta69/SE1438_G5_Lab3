using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE1438_G5_Lab3.GUI
{
    class CheckoutValidate
    {
        public static int InputNumber(string str, TextBox txt)
        {
            int input = 0;
            if (!str.Equals(""))
            {
                try
                {
                    input = Convert.ToInt32(str);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Input a valid number !!");
                    txt.Text = "";
                    input = 0;
                }
            }
            return input;
        }

        public static bool checkInput(TextBox firstName, TextBox lastName, TextBox email, TextBox phone)
        {
            if (firstName.Text.Equals(""))
            {
                MessageBox.Show("First name required!");
                return false;
            }
            if (lastName.Text.Equals(""))
            {
                MessageBox.Show("Last name required!");
                return false;
            }
            if (email.Text.Equals(""))
            {
                MessageBox.Show("Email required!");
                return false;
            }
            if (!checkPhone(phone))
            {
                MessageBox.Show("Phone must be numbers!");
                return false;
            }
            return true;
        }

        public static bool checkPhone(TextBox phone)
        {
            string txt = phone.Text.Trim();

            if (txt.Length != 10)
                return false;

            foreach (char ch in txt)
            {
                if (!Char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
