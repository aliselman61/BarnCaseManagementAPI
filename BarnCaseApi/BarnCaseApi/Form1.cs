using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BarnCaseApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox3.MaxLength = 29;
            textBox1.MaxLength = 20;
            textBox2.MaxLength = 15;

            textBox4.UseSystemPasswordChar = true;
            textBox5.UseSystemPasswordChar = true;

            lblError.Visible = false;

            textBox3.TextChanged += TextBoxes_TextChanged;
            textBox4.TextChanged += TextBoxes_TextChanged;
            textBox5.TextChanged += TextBoxes_TextChanged;

            textBox1.KeyPress += OnlyLetters_KeyPress;
            textBox2.KeyPress += OnlyLetters_KeyPress;

            textBox3.KeyPress += textBox3_KeyPress;
            textBox4.KeyPress += PasswordBoxes_KeyPress;
            textBox5.KeyPress += PasswordBoxes_KeyPress;

            


        }

        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool show = ShowPassword.CheckState == CheckState.Checked;
            textBox4.UseSystemPasswordChar = !show;
            textBox5.UseSystemPasswordChar = !show;
            ShowPassword.Text = show ? "Hide Password" : "Show Password";
        }

        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            ValidateAll();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void PasswordBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void OnlyLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void ValidateAll()
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool emailEmpty = string.IsNullOrWhiteSpace(textBox3.Text);
            bool emailValid = Regex.IsMatch(textBox3.Text, emailPattern);
            bool passwordsMatch = textBox4.Text == textBox5.Text;
            string password = textBox4.Text;
            bool passwordRule = password.Length >= 8 &&
                                Regex.IsMatch(password, "[A-Z]") &&
                                Regex.IsMatch(password, "[a-z]") &&
                                Regex.IsMatch(password, "[0-9]");

            if (!emailEmpty && !emailValid)
            {
                lblError.Text = "Please enter a valid email address";
                lblError.ForeColor = Color.DarkRed;
            }
            else if (!string.IsNullOrEmpty(textBox4.Text) &&
                     !string.IsNullOrEmpty(textBox5.Text) &&
                     !passwordsMatch)
            {
                lblError.Text = "Passwords do not match";
                lblError.ForeColor = Color.DarkRed;
            }
            else if (!string.IsNullOrEmpty(password) && !passwordRule)
            {
                lblError.Text = "Password must be at least 8 characters, include uppercase, lowercase, and a number";
                lblError.ForeColor = Color.DarkRed;
            }
            else 
            {
                lblError.Text = "";
            }

            lblError.Visible = !string.IsNullOrEmpty(lblError.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidateAll();

            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(lblError.Text))
            {
                MessageBox.Show("Please correct the errors.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Registration successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        
        }
    }
}








