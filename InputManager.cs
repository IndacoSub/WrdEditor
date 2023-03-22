using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace WrdEditor
{
	internal class InputManager
	{

		internal static DialogResult Prompt(MessageBoxButtons btn, params string[] lines)
		{
			SystemSounds.Question.Play();
			string msg = string.Join(Environment.NewLine + Environment.NewLine, lines);
			return MessageBox.Show(msg, "Prompt", btn, MessageBoxIcon.Asterisk);
		}

		internal static DialogResult Print(string line)
		{
			MessageBoxButtons btn = new MessageBoxButtons();
			return MessageBox.Show(line, "Prompt", btn, MessageBoxIcon.Asterisk);
		}

		internal static DialogResult Ask(string line)
		{
			return MessageBox.Show(line, "Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
		}
	}
}
