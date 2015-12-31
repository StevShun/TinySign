using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
namespace MapResigner
{
	public class Form2 : Form
	{
		private TextBox textBox1;
		private Label label1;
		private Button button1;
		private Label label2;
		private TextBox textBox2;
		private Label label3;
		private Container components = null;
		public bool validated = false;
		private bool iniexist = false;
		public Form2()
		{
			this.InitializeComponent();
			this.button1.set_Enabled(false);
			if (File.Exists("cmr.ini"))
			{
				this.iniexist = true;
				StreamReader streamReader = File.OpenText("cmr.ini");
				string text = streamReader.ReadLine();
				this.textBox1.set_Text(text);
				text = streamReader.ReadLine();
				this.textBox2.set_Text(text);
				streamReader.Close();
			}
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.textBox1 = new TextBox();
			this.label1 = new Label();
			this.button1 = new Button();
			this.label2 = new Label();
			this.textBox2 = new TextBox();
			this.label3 = new Label();
			base.SuspendLayout();
			this.textBox1.set_Location(new Point(0, 40));
			this.textBox1.set_Name("textBox1");
			this.textBox1.set_Size(new Size(120, 20));
			this.textBox1.set_TabIndex(0);
			this.textBox1.set_Text("");
			this.label1.set_Location(new Point(24, 16));
			this.label1.set_Name("label1");
			this.label1.set_Size(new Size(80, 16));
			this.label1.set_TabIndex(1);
			this.label1.set_Text("Product Key: *");
			this.button1.set_Location(new Point(72, 88));
			this.button1.set_Name("button1");
			this.button1.set_Size(new Size(104, 32));
			this.button1.set_TabIndex(2);
			this.button1.set_Text("Okay!");
			this.button1.add_Click(new EventHandler(this.button1_Click));
			this.label2.set_Location(new Point(136, 16));
			this.label2.set_Name("label2");
			this.label2.set_Size(new Size(120, 16));
			this.label2.set_TabIndex(3);
			this.label2.set_Text("Email: *");
			this.textBox2.set_Location(new Point(136, 40));
			this.textBox2.set_Name("textBox2");
			this.textBox2.set_Size(new Size(112, 20));
			this.textBox2.set_TabIndex(4);
			this.textBox2.set_Text("");
			this.textBox2.add_TextChanged(new EventHandler(this.textBox2_TextChanged));
			this.label3.set_Location(new Point(8, 64));
			this.label3.set_Name("label3");
			this.label3.set_Size(new Size(232, 16));
			this.label3.set_TabIndex(5);
			this.label3.set_Text("*Denotes Required Field");
			this.set_AutoScaleBaseSize(new Size(5, 13));
			base.set_ClientSize(new Size(280, 126));
			base.get_Controls().Add(this.label3);
			base.get_Controls().Add(this.textBox2);
			base.get_Controls().Add(this.label2);
			base.get_Controls().Add(this.button1);
			base.get_Controls().Add(this.label1);
			base.get_Controls().Add(this.textBox1);
			base.set_Name("Form2");
			this.set_Text("Enter Key");
			base.ResumeLayout(false);
		}
		private void button1_Click(object sender, EventArgs e)
		{
			if (!this.iniexist)
			{
				StreamWriter streamWriter = File.CreateText("cmr.ini");
				streamWriter.WriteLine(this.textBox1.get_Text());
				streamWriter.WriteLine(this.textBox2.get_Text());
				streamWriter.Close();
			}
			try
			{
				string text = string.Concat(new string[]
				{
					"http://members.lycos.co.uk/coolspot31/script.php?key1=",
					this.textBox1.get_Text(),
					"&email=",
					this.textBox2.get_Text(),
					"&username=",
					SystemInformation.get_UserName()
				});
				WebClient webClient = new WebClient();
				Stream stream = webClient.OpenRead(text);
				StreamReader streamReader = new StreamReader(stream);
				bool flag = false;
				int num = 0;
				while (!flag)
				{
					string text2 = streamReader.ReadLine();
					if (text2.get_Length() >= 1)
					{
						char[] array = text2.ToCharArray(0, 1);
						num = (int)array[0];
					}
					if (num == 2 || num == 3)
					{
						flag = true;
					}
				}
				if (num == 2)
				{
					base.Close();
				}
				else
				{
					this.validated = true;
					base.Close();
				}
			}
			catch (WebException ex)
			{
				MessageBox.Show(ex.get_Message(), "Exception");
			}
		}
		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			this.button1.set_Enabled(true);
		}
	}
}
