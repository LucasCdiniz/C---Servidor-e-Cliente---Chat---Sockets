// CRIADO E DESENVOLVIDO POR:
// LUCAS CELESTINO DINIZ
//lucascelestino.diniz@gmail.com

/*  APS 5º SEMESTRE - REDES
    Projeto de Redes, com a utilização de sockets
    Utilzando a porta 2502, o Servidor é o primeiro a ser iniciado
    E ao iniciar o atendimento pelo servidor, ele abre o socket e aguarda algum cliente
    Que está na mesma rede responder, o cliente respondendo, ele é inserido no servidor, e 
    Podendo realizar a troca de mensagens entre clientes

    1º Iniciar o servidor, passando o IP de sua Rede, e clicando no botão "Iniciar Atendimento" o servidor aguarda um cliente iniciar uma Nova Conversa
    2º Iniciar dois Clientes, passando o IP do servidor, e inserindo seus Nomes, ao iniciarem uma Nova Conversa, o servidor registra a entrada destes clientes,
       e assim os clientes podem conversar entre si
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace ServidorChatArquivo
{
    
    public partial class ServidorChat : Form
    {
        private delegate void AtualizaStatusCallback(string strMensagem);
        public ServidorChat()
        {
            InitializeComponent();
        }

        private void BtnAtender_Click(object sender, EventArgs e)
        {
            if (txtIP.Text == string.Empty)
            {
                MessageBox.Show("Informe o endereço IP.");
                txtIP.Focus();
                return;
            }

            try
            {

                // Analisa o endereço IP do servidor informado no textbox
                IPAddress enderecoIP = IPAddress.Parse(txtIP.Text);

                // Cria uma nova instância do objeto ChatServidor
                ChatServidor mainServidor = new ChatServidor(enderecoIP);

                // Vincula o tratamento de evento StatusChanged a mainServer_StatusChanged
                ChatServidor.StatusChanged += new StatusChangedEventHandler(mainServidor_StatusChanged);

                // Inicia o atendimento das conexões
                mainServidor.IniciaAtendimento();

                // Mostra que nos iniciamos o atendimento para conexões
                rtbLog.AppendText("Monitorando as conexões...\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão : " + ex.Message);
            }
        }

        public void mainServidor_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            // Chama o método que atualiza o formulário
            this.Invoke(new AtualizaStatusCallback(this.AtualizaStatus), new object[] { e.EventMessage });
        }

        private void AtualizaStatus(string strMensagem)
        {
            // Atualiza o logo com mensagens
            rtbLog.AppendText(strMensagem + "\r\n");
        }

        private void BtnRetornar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaInicialServidor forminicial = new TelaInicialServidor();
            forminicial.Show();
        }
    }
}
// CRIADO E DESENVOLVIDO POR:
// LUCAS CELESTINO DINIZ
//lucascelestino.diniz@gmail.com