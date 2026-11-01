using System;
using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.VisualBasic
{
    internal class Interaction
    {
        private static string titleText;
        private static string promptText;
        private static string defaultText;

        internal static string InputBox(string v1, string v2, string v3)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
 
            form.Text = titleText;
            label.Text = promptText;
            textBox.Text = defaultText;
            buttonOk.Text = "OK";
            buttonOk.DialogResult = DialogResult.OK;

            label.SetBounds(20, 20, 260, 20);
            textBox.SetBounds(20, 45, 240, 20);
            buttonOk.SetBounds(180, 80, 80, 30);

            form.ClientSize = new Size(280, 130);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.MinimizeBox = false;
            form.MaximizeBox = false;

            form.Controls.AddRange(new Control[] { label, textBox, buttonOk });
            form.AcceptButton = buttonOk;

            if (form.ShowDialog() == DialogResult.OK)
            {
                return textBox.Text;
            }

            return defaultText;
        }
    }
}