using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using Utility;
namespace MapResigner
{
	public class Form1 : Form
	{
		private const int SIGN_START = 2048;
		private const int SIG_POS = 720;
		private const int INIT_SUM = 0;
		private OpenFileDialog openFileDialog1;
		private Button button1;
		private Label label1;
		private TextBox siggy;
		private Label label2;
		private Label label3;
		private Button button2;
		private Container components = null;
		private bool sigentered = false;
		private bool annoy = false;
		public Form1()
		{
			this.InitializeComponent();
			this.annoy = true;
			this.siggy.set_Enabled(false);
			this.button2.set_Enabled(false);
		}
		public void Lock()
		{
			this.button1.set_Enabled(false);
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
			ResourceManager resourceManager = new ResourceManager(typeof(Form1));
			this.openFileDialog1 = new OpenFileDialog();
			this.button1 = new Button();
			this.label1 = new Label();
			this.siggy = new TextBox();
			this.label2 = new Label();
			this.label3 = new Label();
			this.button2 = new Button();
			base.SuspendLayout();
			this.button1.set_Location(new Point(24, 24));
			this.button1.set_Name("button1");
			this.button1.set_Size(new Size(80, 56));
			this.button1.set_TabIndex(0);
			this.button1.set_Text("Open Map");
			this.button1.add_Click(new EventHandler(this.button1_Click));
			this.label1.set_Location(new Point(24, 144));
			this.label1.set_Name("label1");
			this.label1.set_Size(new Size(272, 16));
			this.label1.set_TabIndex(1);
			this.label1.set_Text("Current Map: ");
			this.siggy.set_Location(new Point(312, 96));
			this.siggy.set_Name("siggy");
			this.siggy.set_RightToLeft(0);
			this.siggy.set_Size(new Size(64, 20));
			this.siggy.set_TabIndex(2);
			this.siggy.set_Text("00000000");
			this.siggy.add_TextChanged(new EventHandler(this.textBox1_TextChanged));
			this.label2.set_Location(new Point(24, 96));
			this.label2.set_Name("label2");
			this.label2.set_Size(new Size(272, 40));
			this.label2.set_TabIndex(3);
			this.label2.set_Text("The box at the right shows the correct signature of the map. If the map is not recognized, you must input a value.");
			this.label3.set_Location(new Point(24, 168));
			this.label3.set_Name("label3");
			this.label3.set_Size(new Size(272, 16));
			this.label3.set_TabIndex(4);
			this.label3.set_Text("Map Signature: ");
			this.button2.set_Location(new Point(312, 24));
			this.button2.set_Name("button2");
			this.button2.set_Size(new Size(72, 56));
			this.button2.set_TabIndex(5);
			this.button2.set_Text("Sign Map");
			this.button2.add_Click(new EventHandler(this.button2_Click));
			this.set_AutoScaleBaseSize(new Size(5, 13));
			this.set_BackgroundImage((Image)resourceManager.GetObject("$this.BackgroundImage"));
			base.set_ClientSize(new Size(400, 398));
			base.get_Controls().Add(this.button2);
			base.get_Controls().Add(this.label3);
			base.get_Controls().Add(this.label2);
			base.get_Controls().Add(this.siggy);
			base.get_Controls().Add(this.label1);
			base.get_Controls().Add(this.button1);
			base.set_Name("Form1");
			this.set_Text("coolspot31's map resigner");
			base.ResumeLayout(false);
		}
		private bool signMap(int blockSize, FileStream map)
            // blocksize is the block of data passed from another function
		{
			Application.DoEvents();
            // Check if the passed data is divisible by 4. If not, then explode
			if (blockSize % 4 != 0)
			{
				Exception ex = new Exception("Block size must be divisible by 4");
				throw ex;
			}
			new BinaryReader(map);

            // Create unsigned integer 0 (u is keyword for unsigned)
			uint num = 0u;

            // Set FS position to map header @ byte 2048
			map.Seek(2048L, 0);

            // Set var array equal to the block of data received
			byte[] array = new byte[blockSize];

            // do until the FS's position is not equal to the FS's length
			while (map.get_Position() != map.get_Length())
			{
				Application.DoEvents();
                // Create var num2 and set equal to data read
				int num2 = map.Read(array, 0, blockSize);
                // Do this until the data read is nothing and exit
				if (num2 == 0)
				{
					break;
				}
                // Put this junk into memory
				MemoryStream memoryStream = new MemoryStream(array, 0, num2, false, false);
                // Read from memory?
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				while (memoryStream.get_Position() != memoryStream.get_Length())
				{
                    // XOr through the data in memory 
					num ^= binaryReader.ReadUInt32();
				}
			}
            // Set FS to signature position
			map.Seek(720L, 0);
			BinaryWriter binaryWriter = new BinaryWriter(map);
            // Write XOr results to signature
			binaryWriter.Write(num);
			return true;
		}
		private byte[] ReadSig(FileStream themap)
		{
			byte[] array = new byte[4];
			themap.Seek(720L, 0);
			BinaryReader binaryReader = new BinaryReader(themap);
			binaryReader.Read(array, 0, 4);
			return this.Magic(array);
		}
		private string ReadName(FileStream themap)
		{
			Encoding aSCII = Encoding.get_ASCII();
			byte[] array = new byte[16];
			themap.Seek(408L, 0);
			BinaryReader binaryReader = new BinaryReader(themap);
			binaryReader.Read(array, 0, 16);
			char[] array2 = new char[aSCII.GetCharCount(array, 0, array.Length)];
			aSCII.GetChars(array, 0, array.Length, array2, 0);
			return new string(array2);
		}
		private byte[] Magic(byte[] signature)
		{
			byte[] array = new byte[4];
			for (int i = 0; i < 4; i++)
			{
				array[i] = signature[3 - i];
			}
			return array;
		}
		[STAThread]
		private static void Main()
		{
			Application.Run(new Form1());
		}
		private void button1_Click(object sender, EventArgs e)
		{
			if (this.annoy)
			{
				this.openFileDialog1.set_InitialDirectory("desktop");
				this.openFileDialog1.set_Filter("map files (*.map)|*.map|All files (*.*)|*.*");
				this.openFileDialog1.ShowDialog();
				if (this.openFileDialog1.get_FileName() != "")
				{
					try
					{
						FileStream fileStream = new FileStream(this.openFileDialog1.get_FileName(), 3, 3, 0);
						this.label3.set_Text("Map Signature: " + HexEncoding.ToString(this.ReadSig(fileStream)));
						string text = this.ReadName(fileStream);
						this.label1.set_Text("Current Map: " + text);
						this.button2.set_Enabled(true);
						this.siggy.set_Enabled(false);
						if (text == "containment\0\0\0\0\0")
						{
							this.siggy.set_Text("C2C92A58");
						}
						else
						{
							if (text == "warlock\0\0\0\0\0\0\0\0\0")
							{
								this.siggy.set_Text("E9BE57DA");
							}
							else
							{
								if (text == "deltatap\0\0\0\0\0\0\0\0")
								{
									this.siggy.set_Text("AA8BD1D1");
								}
								else
								{
									if (text == "triplicate\0\0\0\0\0\0")
									{
										this.siggy.set_Text("EF1C8ED8");
									}
									else
									{
										if (text == "gemini\0\0\0\0\0\0\0\0\0\0")
										{
											this.siggy.set_Text("B3BA50BE");
										}
										else
										{
											if (text == "dune\0\0\0\0\0\0\0\0\0\0\0\0")
											{
												this.siggy.set_Text("41EBDE02");
											}
											else
											{
												if (text == "elongation\0\0\0\0\0\0")
												{
													this.siggy.set_Text("5C9AC5FD");
												}
												else
												{
													if (text == "backwash\0\0\0\0\0\0\0\0")
													{
														this.siggy.set_Text("DAF43F38");
													}
													else
													{
														if (text == "turf\0\0\0\0\0\0\0\0\0\0\0\0")
														{
															this.siggy.set_Text("95677C3A");
														}
														else
														{
															this.siggy.set_Enabled(true);
															this.button2.set_Enabled(false);
														}
													}
												}
											}
										}
									}
								}
							}
						}
						fileStream.Close();
					}
					catch (IOException ex)
					{
						MessageBox.Show(ex.get_Message(), "Error Accessing File");
					}
				}
			}
		}
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			this.button2.set_Enabled(true);
			this.sigentered = true;
		}
		private void button2_Click(object sender, EventArgs e)
		{
			if (this.annoy && this.openFileDialog1.get_FileName() != "")
			{
				try
				{
					FileStream fileStream = new FileStream(this.openFileDialog1.get_FileName(), 3, 3, 0);
					if (this.sigentered)
					{
						byte[] signature = new byte[4];
						byte[] array = new byte[4];
						byte[] array2 = new byte[4];
						int num;

                        // This var takes the sig entered by user and returns an array using HexEncoding class
						signature = HexEncoding.GetBytes(this.siggy.get_Text(), out num);

						// array2 is set equal to the array returned by the Magic function which does something w/ it?
                        array2 = this.Magic(signature);

                        // FS is set to 4 bytes before the end of the file
                        fileStream.Seek(fileStream.get_Length() - 4L, 0);

                        // Write array2 to last 4 bytes of the file
						BinaryWriter binaryWriter = new BinaryWriter(fileStream);
						binaryWriter.Write(array2);

                        // Pass FS in blocks of 4096 bytes to signMap function - which writes the signature
						this.signMap(4096, fileStream);

                        // Re-read the signature from map
						string text = HexEncoding.ToString(this.ReadSig(fileStream));
                        // Put signature in textbox
						this.label3.set_Text("Map Signature: " + text);
                        // Read signature from map again?????????
						array = this.ReadSig(fileStream);
                        // Goto last 4 bytes
						fileStream.Seek(fileStream.get_Length() - 4L, 0);
						BinaryWriter binaryWriter2 = new BinaryWriter(fileStream);
                        // Write sig to last 4 bytes
						binaryWriter2.Write(this.Magic(array));
                        // XOr through again at 4096 bytes and write signature to 720
						this.signMap(4096, fileStream);
                        // Re-re-read the freakin signature and set the label equal to it
						array = this.ReadSig(fileStream);
						text = HexEncoding.ToString(array);
						this.label3.set_Text("Map Signature: " + text + " Complete!");
					}
					fileStream.Close();
				}
				catch (IOException ex)
				{
					MessageBox.Show(ex.get_Message(), "Error Accessing File");
				}
			}
		}
	}
}
