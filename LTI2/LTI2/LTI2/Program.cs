using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTI2
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Passa o HttpClient para o formulário principal (Form1)
                Application.Run(new Form1(loginForm.HttpClient, loginForm.BaseUrl));
            }
            else
            {
                // Sai se o login for cancelado ou falhar
                Application.Exit();
            }

        }
    }
}
