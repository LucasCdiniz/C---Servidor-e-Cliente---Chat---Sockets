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

// NAMESPACES USADOS:

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
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ClienteChatArquivo
{
    public partial class Chat : Form
    {
        // Variáveis referentes ao nome do usuário
        private string NomeUsuario = "Desconhecido";
        private StreamWriter stwEnviador;
        private StreamReader strReceptor;
        private TcpClient tcpServidor;

        // Atualizar o formulário com as mensagens da outra thread
        private delegate void AtualizaLogCallBack(string strMotivo);
        // Definir o formulário para o estado de "Desconectado" da outra thread
        private delegate void FechaConexaoCallBack(string strMotivo);
        private Thread mensagemThread;
        private IPAddress endereçoIP;
        private bool conectado;

        public Chat()
        {
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaInicial forminicio = new TelaInicial();
            forminicio.Show();
        }

        private void BtnConectar_Click(object sender, EventArgs e)
        {
            if(conectado == false)
            {
                InicializarConexao();
            }
            else
            {
                FechaConexao("Desconectado a pedido do usuário. . .");
            }
        }

        private void InicializarConexao()
        {
            try
            {
                // Tratatamento e conversão di endereço IP informado
                endereçoIP = IPAddress.Parse(txtServidorIP.Text);
                // Inicia uma nova conexão TCP com o Chat - Servidor
                tcpServidor = new TcpClient();
                tcpServidor.Connect(endereçoIP, 2502);

                // Verfica se está conectado ou não


                conectado = true;

                //  Pegando as informações do txtUsuario
                NomeUsuario = txtUsuario.Text;

                // Desabilitação e Habilitação dos campos apropriados

                txtServidorIP.Enabled = false;
                txtUsuario.Enabled = false;
                rtbMensagem.Enabled = true;
                btnEnviar.Enabled = true;
                btnConectar.Text = "Desconectado";

                // Faz o envio do nome do usuário ao Servidor
                stwEnviador = new StreamWriter(tcpServidor.GetStream());
                stwEnviador.WriteLine(txtUsuario.Text);
                stwEnviador.Flush();

                // Inicia a Thread para poder receber as mensagens e a nova comunicação
                mensagemThread = new Thread(new ThreadStart(ReceberMensagens));
                mensagemThread.Start();


            }
            catch(Exception ex)
            {
                // Tratamento de erro caso ocorra algum erro na conexão com o servidor
                MessageBox.Show("Erro: " + ex.Message, "Erro na conexão com o servidor",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void ReceberMensagens()
        {

            // Recebe a resposta do Servidor
            strReceptor = new StreamReader(tcpServidor.GetStream());
            string ConRespostas = strReceptor.ReadLine();
            // Se o primeiro caracter da resposta for 1, a conexão é feita com sucesso
            if(ConRespostas[0] == '1')
            {
                // O formulário é atualizado para avisar que está conectado
                this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { "Conectado com Sucesso!" });
            }
            else // Se o ´rimeiro caracter NÃO FOR 1, a conexão falhou
            {
                string Motivo = "Não Conectado";
                // Pega o motivo da mensagem
                Motivo += ConRespostas.Substring(2, ConRespostas.Length - 2);
                // Atualiza o form mostrando o motivo da falha
                this.Invoke(new FechaConexaoCallBack(this.FechaConexao), new object[] { Motivo });
                // Sai do método
                return;
            }

            // Mas, enquanto tiver conectado, ele vai ler as linhas que estão chegando do Servidor

            while (conectado)
            {
                // Exibe a mensagem
                this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { strReceptor.ReadLine() });
            }
        }

        private void AtualizaLog(string strMensagem)
        {
            // Anexa o texto ao final de cada linha
            rtbLog.AppendText(strMensagem + "\r\n");
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            EnviaMensagem();
        }

        private void RtbMensagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Enviando a mensagem pressionando Enter
            if(e.KeyChar == (char)13)
            {
                EnviaMensagem();
            }
        }

        // Método que faz o envio para o servidor
        private void EnviaMensagem()
        {
            if(rtbMensagem.Lines.Length >= 1)
            {
                stwEnviador.WriteLine(rtbMensagem.Text);
                stwEnviador.Flush();
                rtbMensagem.Lines = null;
            }
            rtbMensagem.Text = "";
        }

        // Fechando a conexão com o servidor
        private void FechaConexao(string Motivo)
        {
            // Inicialmente mostra o porquê de ter encerrado a conexão
            rtbLog.AppendText(Motivo + "\r\n");
            // Habilita e desabilita os controles 
            txtServidorIP.Enabled = true;
            txtUsuario.Enabled = true;
            rtbMensagem.Enabled = false;
            btnEnviar.Enabled = false;
            btnConectar.Text = "Conectado";

            // Fecha os objetos:
            conectado = false;
            stwEnviador.Close();
            strReceptor.Close();
            tcpServidor.Close();
        }

        public void OnApplicationExit(object sender, EventArgs e)
        {
            if(conectado == true)
            {
                // Fecha tudo
                conectado = false;
                stwEnviador.Close();
                strReceptor.Close();
                tcpServidor.Close();
            }
        }

        
    }
}
// CRIADO E DESENVOLVIDO POR:
// LUCAS CELESTINO DINIZ
//lucascelestino.diniz@gmail.com