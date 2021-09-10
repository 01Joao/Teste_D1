using Service;
using System;
using System.Web.UI.WebControls;

namespace Formulario.Site.Cliente
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ClienteService clienteService = new ClienteService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Convert.ToInt32(Session["IdCliente"]) != 0)
                {
                    int codigo = Convert.ToInt32(Session["IdCliente"]);
                    CarregarFormulario(codigo);
                }   
            }
        }

        void CarregarFormulario(int codigo)
        {
            var cliente = clienteService.CarregarPessoa(codigo);

            if (cliente != null)
            {
                txtNome.Text = cliente.Nome;
                txtCpf.Text = cliente.Cpf;
                txtDataNasci.Text = cliente.DataNascimento.ToString();
                txtRg.Text = cliente.RG;
                txtFacebook.Text = cliente.Facebook;
                txtLinkedin.Text = cliente.Linkedin;
                txtTwitter.Text = cliente.Twitter;
                txtInstagram.Text = cliente.Instagram;
            }
        }
        public void limpaCampos()
        {
            txtNome.Text =
            txtCpf.Text =
            txtDataNasci.Text =
            txtRg.Text = 
            txtFacebook.Text =
            txtLinkedin.Text =
            txtTwitter.Text =
            txtInstagram.Text = string.Empty;
        }
        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Domain.Entities.Cliente cliente = new Domain.Entities.Cliente();

            if (Convert.ToInt32(Session["IdCliente"]) != 0)
            {
                cliente.IdCliente = Convert.ToInt32(Session["IdCliente"]);
                Session.Remove("IdCliente");
            }

            cliente.Nome = txtNome.Text;
            cliente.Cpf = txtCpf.Text;
            cliente.DataNascimento = Convert.ToDateTime(txtDataNasci.Text).ToString("dd/MM/yyyy");
            cliente.RG = txtRg.Text;
            cliente.Facebook = txtFacebook.Text;
            cliente.Linkedin = txtLinkedin.Text;
            cliente.Twitter = txtTwitter.Text;
            cliente.Instagram = txtInstagram.Text;
            
            clienteService.GravarPessoa(cliente);

            limpaCampos();
        }
    }   
}