using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace LTI2
{
    public partial class LoginForm : Form
    {
        public string BaseUrl { get; private set; }
        public HttpClient HttpClient { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string ip = txtIP.Text.Trim();
            string port = txtPort.Text.Trim();
            string token = txtToken.Text.Trim();

            if (string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(port))
            {
                MessageBox.Show("Preenche o IP e a Porta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BaseUrl = $"http://{ip}:{port}";

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
            };

            HttpClient = new HttpClient(handler);

            // Só usa token se NÃO estiver na porta 8001
            if (port != "8001")
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    MessageBox.Show("Preenche o token para autenticação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                HttpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            HttpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = HttpClient.GetAsync($"{BaseUrl}/api/v1/nodes").Result;
                response.EnsureSuccessStatusCode();
                MessageBox.Show("Login bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao ligar à API.\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void lblToken_Click(object sender, EventArgs e)
        {

        }
    }
}
