using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Sidescroller
{
    public partial class LoginMask : UserControl
    {
        public LoginMask()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Button))
                switchLoginMask(((Button)sender).Text);
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Button))
                switchLoginMask(((Button)sender).Text);
        }

        private void switchLoginMask(String buttonName)
        {
            switch (buttonName)
            {
                case "Login":
                    if (tbUsername.Text.Length >= 4)
                    {
                        if (tbPassword.Text.Length >= 8)
                        {
                            User user = SQLManager.Instance.selectUser(tbUsername.Text);
                            if (user != null)
                            {
                                if (PasswordHasher.VerifyHash(tbPassword.Text, user.getPassword()))
                                {
                                    this.Visible = false;
                                }
                                else
                                {
                                    highlightTextbox(tbPassword, "Incorrect password!");
                                }
                            }
                            else
                            {
                                highlightTextbox(tbUsername, "Unknown username!");
                            }
                        }
                        else
                        {
                            highlightTextbox(tbPassword, "Enter a valid password!");
                        }
                    }
                    else
                    {
                        highlightTextbox(tbUsername, "Enter a valid username!");
                    }                    
                    break;

                case "Cancel":
                    clearText();
                    btnCreateAccount.Text = "Create Account";
                    btnLogin.Text = "Login";
                    tbName.Visible = false;
                    break;

                case "Create":
                    // Username: >= 4 chars, keine Sonderzeichen
                    // Passwort: Keine Whitespaces, >= 8 chars
                    // Name: >= 3 chars
                    if (Regex.IsMatch(tbUsername.Text, "^[a-zA-Z0-9]{4,}$"))
                    {
                        if (!tbPassword.Text.Any(x => Char.IsWhiteSpace(x)) && tbPassword.Text.Length >= 8)
                        {
                            if (tbName.Text.Length >= 3)
                            {
                                User user = SQLManager.Instance.selectUser(tbUsername.Text);
                                if (user == null)
                                {
                                    if (SQLManager.Instance.insertUser(new User(0, tbUsername.Text, tbPassword.Text, tbName.Text)) == 1)
                                    {
                                        clearText();
                                        btnCreateAccount.Text = "Create Account";
                                        btnLogin.Text = "Login";
                                        tbName.Visible = false;
                                        MessageBox.Show("User was created successfully!");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Unexpected error");
                                    }
                                }
                                else
                                {
                                    highlightTextbox(tbUsername, "Username already exists!");
                                }
                            }
                            else
                            {
                                highlightTextbox(tbName, "Invalid name! The name requires at least 3 characters!");
                            }
                        }
                        else
                        {
                            highlightTextbox(tbPassword, "Invalid password! The password requires at least 8 symbols!\nWhitespace characters are not allowed!");
                        }
                    }
                    else
                    {
                        highlightTextbox(tbUsername, "Invalid username! The username requires at least 4 letters or numbers!");
                    }
                    break;

                case "Create Account":
                    clearText();
                    btnCreateAccount.Text = "Create";
                    btnLogin.Text = "Cancel";
                    tbName.Visible = true;
                    break;  
             
                default:
                    break;
            }

        }

        private void clearText()
        {
            tbUsername.Clear();
            tbPassword.Clear();
            tbName.Clear();
        }

        private void highlightTextbox(TextBox tb, string message)
        {
            tb.Focus();
            errorProvider1.SetError(tb, message);
            MessageBox.Show(message);
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
    }
}
