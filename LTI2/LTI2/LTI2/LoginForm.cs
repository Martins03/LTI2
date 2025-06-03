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

            if (string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(port) || string.IsNullOrWhiteSpace(token))
            {
                MessageBox.Show("Preenche todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BaseUrl = $"https://{ip}:{port}";
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true // Ignorar SSL
            };

            HttpClient = new HttpClient(handler);
            HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
            HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Teste simples à API do Kubernetes
                var response = HttpClient.GetAsync($"{BaseUrl}/api/v1/nodes").Result;
                response.EnsureSuccessStatusCode();

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
