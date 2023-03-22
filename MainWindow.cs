using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WrdEditor.V3Lib;

namespace WrdEditor
{
	public partial class MainWindow : Form
	{
		private string loadedWrdLocation;
		private WrdFile loadedWrd;
		private string loadedStxLocation;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void CommandsPage_Click(object sender, EventArgs e)
		{

		}

		private void StringsPage_Click(object sender, EventArgs e)
		{

		}

		private void newScriptToolStripMenuItem_Click(object sender, EventArgs e)
		{
			loadedWrd = new WrdFile();
			loadedWrdLocation = string.Empty;
			InputManager.Print("New WRD file created. Remember to save to a file before closing!");
		}

		private void openScriptToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "WRD script files (*.wrd)|*.wrd|All files (*.*)|*.*";
			if (openFileDialog.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}

			if (string.IsNullOrWhiteSpace(openFileDialog.FileName))
			{
				MessageBox.Show("ERROR: Specified file name is empty or null.");
				return;
			}

			loadedWrd = new WrdFile();
			loadedWrd.Load(openFileDialog.FileName);
			loadedWrdLocation = openFileDialog.FileName;

			InputManager.Print($"Loaded WRD file: {new FileInfo(openFileDialog.FileName).Name}");

			// Clear the StackPanel of old entries
			wrdCommandTextBox.Text = string.Empty;

			// Generate a string for every command in the WRD
			StringBuilder sb = new StringBuilder();
			foreach (WrdCommand command in loadedWrd.Commands)
			{
				sb.Append(command.Opcode);
				sb.Append('|');
				sb.AppendJoin(", ", command.Arguments);
				sb.Append('\n');
			}
			wrdCommandTextBox.Text = sb.ToString();
			InputManager.Print((string)wrdCommandTextBox.Text.Length.ToString());

			// Check if we need to prompt the user to open an external STX file for strings
			wrdStringsTextBox.Text = string.Empty;
			if (loadedWrd.UsesExternalStrings)
			{
				if (InputManager.Ask("The WRD file references external string data, load an STX file?") == DialogResult.Yes)
				{
					OpenFileDialog openStxDialog = new OpenFileDialog();
					openStxDialog.Filter = "STX text files (*.stx)|*.stx|All files (*.*)|*.*";

					if (openStxDialog.ShowDialog() == DialogResult.Cancel)
					{
						return;
					}

					if (string.IsNullOrWhiteSpace(openStxDialog.FileName))
					{
						MessageBox.Show("ERROR: Specified file name is empty or null.");
						return;
					}

					StxFile stx = new StxFile();
					stx.Load(openStxDialog.FileName);
					loadedStxLocation = openStxDialog.FileName;

					foreach (string str in stx.StringTables.First().Strings)
					{
						wrdStringsTextBox.Text += str.Replace("\n", "\\n").Replace("\r", "\\r") + '\n';
					}
				}
			}
			else
			{
				foreach (string str in loadedWrd.InternalStrings)
				{
					wrdStringsTextBox.Text += str.Replace("\n", "\\n").Replace("\r", "\\r") + '\n';
				}
			}
		}

		private void saveScriptToolStripMenuItem_Click(object sender, EventArgs e)
		{

			if (loadedWrd == null)
				return;

			// Parse the command textbox and replace loadedWRD's commands with the contents
			loadedWrd.Commands.Clear();

			string[] lines = wrdCommandTextBox.Text.Split('\n');
			for (int lineNum = 0; lineNum < lines.Length; ++lineNum)
			{
				// Do this as opposed to using StringSplitOptions above because we need to count line numbers correctly
				if (string.IsNullOrWhiteSpace(lines[lineNum]))
					continue;

				string opcode = lines[lineNum].Split('|').First();

				// Verify the opcode is valid
				if (!WrdCommandHelper.OpcodeNames.Contains(opcode))
				{
					MessageBox.Show($"ERROR: Invalid opcode at line {lineNum}.");
					return;
				}

				//string[] args = lines[lineNum].Substring(opcode.Length + 1, lines[lineNum].Length - (opcode.Length + 1)).Split(", ", StringSplitOptions.RemoveEmptyEntries);
				string[] args = lines[lineNum][(opcode.Length + 1)..].Split(", ", StringSplitOptions.RemoveEmptyEntries);

				// Verify that we are using the correct argument types for each command
				int opcodeId = Array.IndexOf(WrdCommandHelper.OpcodeNames, opcode);
				for (int argNum = 0; argNum < args.Length; ++argNum)
				{
					// Verify the number of arguments is correct
					int expectedArgCount = WrdCommandHelper.ArgTypeLists[opcodeId].Count;
					if (args.Length < expectedArgCount)
					{
						MessageBox.Show($"ERROR: Command at line {lineNum} expects {expectedArgCount} arguments, but got {args.Length}.");
						return;
					}
					else if (args.Length > expectedArgCount)
					{
						if (opcodeId != 1 && opcodeId != 3)
						{
							MessageBox.Show($"ERROR: Command at line {lineNum} expects {expectedArgCount} arguments, but got {args.Length}.");
							return;
						}
					}

					switch (WrdCommandHelper.ArgTypeLists[opcodeId][argNum % expectedArgCount])
					{
						case 1:
						case 2:
							bool isNumber = ushort.TryParse(args[argNum], out _);
							if (!isNumber)
							{
								MessageBox.Show($"ERROR: Argument {argNum} at line {lineNum} must be a number between {ushort.MinValue} and {ushort.MaxValue}.");
								return;
							}
							break;
					}
				}

				loadedWrd.Commands.Add(new WrdCommand { Opcode = opcode, Arguments = args.ToList() });
			}

			if (!loadedWrd.UsesExternalStrings)
			{
				loadedWrd.InternalStrings.Clear();

				string[] strings = wrdStringsTextBox.Text.Split('\n');
				foreach (string str in strings)
				{
					loadedWrd.InternalStrings.Add(str.Replace("\\n", "\n").Replace("\\r", "\r"));
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(loadedStxLocation) && loadedWrd.UsesExternalStrings)
				{
					string[] strings = wrdStringsTextBox.Text.Split('\n');
					List<string> stringTable = new List<string>();
					foreach (string str in strings)
					{
						stringTable.Add(str.Replace("\\n", "\n").Replace("\\r", "\r"));
					}

					StxFile stx = new StxFile();
					stx.StringTables.Add((stringTable, 0));

					stx.Save(loadedStxLocation);
				}
			}

			loadedWrd.Save(loadedWrdLocation);
		}

		private void saveScriptAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "WRD script files (*.wrd)|*.wrd|All files (*.*)|*.*";
			if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}

			if (string.IsNullOrWhiteSpace(saveFileDialog.FileName))
			{
				MessageBox.Show("ERROR: Specified file name is empty or null.");
				return;
			}

			loadedWrdLocation = saveFileDialog.FileName;
			saveScriptToolStripMenuItem_Click(sender, e);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			wrdCommandTextBox.Text += "Test";
		}
	}
}
