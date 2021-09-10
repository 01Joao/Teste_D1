using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Formulario.Site.Cliente
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        ClienteService clienteService = new ClienteService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString() == "")
            {
                String mensagem = "Por favor preencher com o nome do cliente";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "MensagemDeAlert", "alert('" + mensagem + "');", true);
            }
            else
            {
                var lista = clienteService.ListarPessoa(txtNome.Text);

                gvClientes.DataSource = lista;
                gvClientes.DataBind();
            }
        }

        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Session["IdCliente"] = (Convert.ToInt32(e.CommandArgument.ToString()));
                Response.Redirect("Cadastrar.aspx");
            }

            if (e.CommandName == "Deletar")
            {
                int codigo = (Convert.ToInt32(e.CommandArgument.ToString()));
                clienteService.Deletar(codigo);

                var lista = clienteService.ListarPessoa(txtNome.Text);
                gvClientes.DataSource = lista;
                gvClientes.DataBind();
            }

            if (e.CommandName == "AdicionarTelefone")
            {
                Session["IdCliente"] = (Convert.ToInt32(e.CommandArgument.ToString()));
                Response.Redirect("Telefone.aspx");
            }

            if (e.CommandName == "AdicionarEndereco")
            {
                Session["IdCliente"] = (Convert.ToInt32(e.CommandArgument.ToString()));
                Response.Redirect("Endereco.aspx");
            }
        }
    }
}