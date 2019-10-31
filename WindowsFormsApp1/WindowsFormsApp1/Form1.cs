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

namespace WindowsFormsApp1 {
	public partial class Form1 : Form {

		public string path = null;
		RegistryKey run = null;
		public Form1() {

			InitializeComponent();

            //AutoRun Reference path
			path = @"Software\Microsoft\Windows\CurrentVersion\Run";

            //Get CURRENT_USER
			RegistryKey userKey = Registry.CurrentUser;

            //Get Run reference
			run = userKey.OpenSubKey(path, true);
			
            //Get string  values from run
			string[] rks = run.GetValueNames();

			listBox1.Items.AddRange(rks);
		}

		private void button1_Click(object sender, EventArgs e) {
			run.SetValue(textBox1.Text.ToString(), textBox2.Text.ToString(), RegistryValueKind.DWord);
			listBox1.Items.Add(textBox1.Text.ToString());
		}

		private void button2_Click(object sender, EventArgs e) {

			run.DeleteValue(listBox1.GetItemText(listBox1.SelectedItem).ToString());
			listBox1.Items.Remove(listBox1.SelectedItems[0]);
		}
	}
}
