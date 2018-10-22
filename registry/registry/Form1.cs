using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace registry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Show_Click(object sender, EventArgs e)
        {
            ShowReg();
            
        }

        private void ShowReg()
        {
            listView1.Clear();
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            foreach (var item in registryKey.GetValueNames())
            {
                listView1.Items.Add(item);
            }
            registryKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            foreach (var item in registryKey.GetValueNames())
            {
                listView1.Items.Add(item);
            }

        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                    registryKey.SetValue(textBox1.Text, textBox2.Text);
                    
                }
                else MessageBox.Show("Please enter Name Program!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ShowReg();
                textBox1.Clear();
                textBox2.Clear();
            }
            
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                registryKey.DeleteValue(listView1.SelectedItems[0].Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ShowReg();
            }
            
        }
    }
}
