using System.Windows.Forms;

namespace WrdEditor
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			newScriptToolStripMenuItem = new ToolStripMenuItem();
			openScriptToolStripMenuItem = new ToolStripMenuItem();
			saveScriptToolStripMenuItem = new ToolStripMenuItem();
			saveScriptAsToolStripMenuItem = new ToolStripMenuItem();
			TabControl = new TabControl();
			CommandsPage = new TabPage();
			wrdCommandTextBox = new RichTextBox();
			StringsPage = new TabPage();
			wrdStringsTextBox = new RichTextBox();
			menuStrip1.SuspendLayout();
			TabControl.SuspendLayout();
			CommandsPage.SuspendLayout();
			StringsPage.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(784, 24);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newScriptToolStripMenuItem, openScriptToolStripMenuItem, saveScriptToolStripMenuItem, saveScriptAsToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// newScriptToolStripMenuItem
			// 
			newScriptToolStripMenuItem.Name = "newScriptToolStripMenuItem";
			newScriptToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
			newScriptToolStripMenuItem.Size = new Size(206, 22);
			newScriptToolStripMenuItem.Text = "New Script";
			newScriptToolStripMenuItem.Click += newScriptToolStripMenuItem_Click;
			// 
			// openScriptToolStripMenuItem
			// 
			openScriptToolStripMenuItem.Name = "openScriptToolStripMenuItem";
			openScriptToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
			openScriptToolStripMenuItem.Size = new Size(206, 22);
			openScriptToolStripMenuItem.Text = "Open Script";
			openScriptToolStripMenuItem.Click += openScriptToolStripMenuItem_Click;
			// 
			// saveScriptToolStripMenuItem
			// 
			saveScriptToolStripMenuItem.Name = "saveScriptToolStripMenuItem";
			saveScriptToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
			saveScriptToolStripMenuItem.Size = new Size(206, 22);
			saveScriptToolStripMenuItem.Text = "Save Script";
			saveScriptToolStripMenuItem.Click += saveScriptToolStripMenuItem_Click;
			// 
			// saveScriptAsToolStripMenuItem
			// 
			saveScriptAsToolStripMenuItem.Name = "saveScriptAsToolStripMenuItem";
			saveScriptAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
			saveScriptAsToolStripMenuItem.Size = new Size(206, 22);
			saveScriptAsToolStripMenuItem.Text = "Save Script As...";
			saveScriptAsToolStripMenuItem.Click += saveScriptAsToolStripMenuItem_Click;
			// 
			// TabControl
			// 
			TabControl.Controls.Add(CommandsPage);
			TabControl.Controls.Add(StringsPage);
			TabControl.Dock = DockStyle.Fill;
			TabControl.Location = new Point(0, 24);
			TabControl.Name = "TabControl";
			TabControl.SelectedIndex = 0;
			TabControl.Size = new Size(784, 387);
			TabControl.TabIndex = 1;
			// 
			// CommandsPage
			// 
			CommandsPage.Controls.Add(wrdCommandTextBox);
			CommandsPage.Location = new Point(4, 24);
			CommandsPage.Name = "CommandsPage";
			CommandsPage.Padding = new Padding(3);
			CommandsPage.Size = new Size(776, 359);
			CommandsPage.TabIndex = 0;
			CommandsPage.Text = "CommandsPage";
			CommandsPage.UseVisualStyleBackColor = true;
			CommandsPage.Click += CommandsPage_Click;
			// 
			// wrdCommandTextBox
			// 
			wrdCommandTextBox.Dock = DockStyle.Fill;
			wrdCommandTextBox.Location = new Point(3, 3);
			wrdCommandTextBox.Name = "wrdCommandTextBox";
			wrdCommandTextBox.Size = new Size(770, 353);
			wrdCommandTextBox.TabIndex = 1;
			wrdCommandTextBox.Text = "";
			// 
			// StringsPage
			// 
			StringsPage.Controls.Add(wrdStringsTextBox);
			StringsPage.Location = new Point(4, 24);
			StringsPage.Name = "StringsPage";
			StringsPage.Padding = new Padding(3);
			StringsPage.Size = new Size(776, 359);
			StringsPage.TabIndex = 1;
			StringsPage.Text = "StringsPage";
			StringsPage.UseVisualStyleBackColor = true;
			StringsPage.Click += StringsPage_Click;
			// 
			// wrdStringsTextBox
			// 
			wrdStringsTextBox.Dock = DockStyle.Fill;
			wrdStringsTextBox.Location = new Point(3, 3);
			wrdStringsTextBox.Name = "wrdStringsTextBox";
			wrdStringsTextBox.Size = new Size(770, 353);
			wrdStringsTextBox.TabIndex = 1;
			wrdStringsTextBox.Text = "";
			// 
			// MainWindow
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(784, 411);
			Controls.Add(TabControl);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			MinimumSize = new Size(800, 450);
			Name = "MainWindow";
			Text = "WRDEditor by CaptainSwag101 -- WinForms";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			TabControl.ResumeLayout(false);
			CommandsPage.ResumeLayout(false);
			StringsPage.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private TabControl TabControl;
		private TabPage CommandsPage;
		private TabPage StringsPage;
		private ToolStripMenuItem newScriptToolStripMenuItem;
		private ToolStripMenuItem openScriptToolStripMenuItem;
		private ToolStripMenuItem saveScriptToolStripMenuItem;
		private ToolStripMenuItem saveScriptAsToolStripMenuItem;
		private RichTextBox wrdCommandTextBox;
		private RichTextBox wrdStringsTextBox;
	}
}