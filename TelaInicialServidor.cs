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

namespace ServidorChatArquivo
{
    public partial class TelaInicialServidor : Form
    {
        public TelaInicialServidor()
        {
            InitializeComponent();
        }

        private void BtnChatServidor_Click(object sender, EventArgs e)
        {
            this.Hide();
            ServidorChat formservidorchat = new ServidorChat();
            formservidorchat.Show();
        }

        

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
// CRIADO E DESENVOLVIDO POR:
// LUCAS CELESTINO DINIZ
//lucascelestino.diniz@gmail.com