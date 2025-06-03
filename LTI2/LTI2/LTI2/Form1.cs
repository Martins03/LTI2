using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Xml.Linq;

namespace LTI2
{
    public partial class Form1 : Form
    {
        private HttpClient _httpClient;
        private string _baseUrl;
        private TextBox txtNamespace;
        private Button btnListarPods;
        private DataGridView dgvPods;
        public Form1()
        {
            InitializeComponent();
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
        }

        public Form1(HttpClient httpClient, string baseUrl)
        {
            InitializeComponent();
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/api/v1/nodes");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Ligação bem sucedida!\n" + content.Substring(0, 300));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao contactar API Kubernetes:\n" + ex.Message);
            }
        }
        private async void CriarInterfaceDashboard()
        {
            mainContentPanel.Controls.Clear();

            var lblTitulo = new Label
            {
                Text = "Dashboard do Cluster Kubernetes",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            panel5.Controls.Add(lblTitulo);

            var dados = await ObterResumoCluster();

            int y = 70;
            foreach (var dado in dados)
            {
                var lbl = new Label
                {
                    Text = $"{dado.Key}: {dado.Value}",
                    Font = new Font("Segoe UI", 12),
                    Location = new Point(40, y),
                    AutoSize = true
                };
                panel5.Controls.Add(lbl);
                y += 35;
            }
        }

        private async Task<Dictionary<string, int>> ObterResumoCluster()
        {
            var resumo = new Dictionary<string, int>();

            try
            {
                var nodes = await ObterContagem("/api/v1/nodes");
                var pods = await ObterContagem("/api/v1/pods");
                var namespaces = await ObterContagem("/api/v1/namespaces");
                var services = await ObterContagem("/api/v1/services");
                var deployments = await ObterContagem("/apis/apps/v1/deployments");

                resumo["Nodes"] = nodes;
                resumo["Namespaces"] = namespaces;
                resumo["Pods"] = pods;
                resumo["Deployments"] = deployments;
                resumo["Services"] = services;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter dados do cluster: " + ex.Message);
            }

            return resumo;
        }

        private async Task<int> ObterContagem(string endpoint)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}{endpoint}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            return result.items.Count;
        }
        private void CriarInterfacePods()
        {
            panel5.Controls.Clear(); // Limpa o conteúdo do painel principal

            txtNamespace = new TextBox
            {
                Location = new Point(20, 20),
                Width = 200,
                Text = "default"
            };

            btnListarPods = new Button
            {
                Location = new Point(240, 18),
                Text = "Listar Pods",
                Width = 120
            };
            btnListarPods.Click += BtnListarPods_Click;

            dgvPods = new DataGridView
            {
                Location = new Point(20, 60),
                Width = 1000,
                Height = 600,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            panel5.Controls.Add(txtNamespace);
            panel5.Controls.Add(btnListarPods);
            panel5.Controls.Add(dgvPods);
        }

        private async void BtnListarPods_Click(object sender, EventArgs e)
        {
            string ns = txtNamespace.Text.Trim();

            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/api/v1/namespaces/{ns}/pods");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                var podsList = new List<object>();

                foreach (var item in result.items)
                {
                    podsList.Add(new
                    {
                        Nome = item.metadata.name.ToString(),
                        Status = item.status.phase.ToString(),
                        Node = item.spec.nodeName != null ? item.spec.nodeName.ToString() : "N/A",
                        IP = item.status.podIP != null ? item.status.podIP.ToString() : "N/A",
                        Inicio = item.status.startTime != null ? item.status.startTime.ToString() : "N/A"
                    });
                }

                dgvPods.DataSource = podsList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter pods: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            CriarInterfaceDashboard();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void btPods_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CriarInterfacePods();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            CriarInterfaceDashboard();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
