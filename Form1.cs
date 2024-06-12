using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCC24_Test01
{
    public partial class Form1 : Form
    {

        private readonly string[] user_arrays = { "guest", "admin" };
        private readonly string[] pass_arrays = { "guest", "shiga" };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !textBox2.UseSystemPasswordChar;
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            Application.UseWaitCursor = true;
            await Task.Delay(100);
            Application.UseWaitCursor = false;

            if (!radioButton1.Checked)
            {
                errMsg("アカウント所有者以外のログインは許可されていません");
                return;
            }

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errMsg("ユーザーIDが入力されていません");
                return;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errMsg("パスワードが入力されていません");
                return;
            }

            if (textBox2.TextLength < 4)
            {
                errMsg("パスワードは４文字以上です");
                return;
            }

            int user_number = Array.IndexOf(user_arrays, textBox1.Text);

            if (user_number == -1)
            {
                errMsg("ユーザーIDが存在しません");
                return;
            }

            if (textBox2.Text != pass_arrays[user_number])
            {
                errMsg("パスワードが違います");
                return;
            }


            MessageBox.Show("ログインに成功しました", "認証成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }

        private void errMsg(string msg)
        {
            MessageBox.Show(msg + "\r\n再度確認して下さい", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            radioButton1.Checked = false;
        }
    }
}
