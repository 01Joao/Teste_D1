using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Formulario.Site.Cliente
{
    public partial class Endereco : System.Web.UI.Page
    {
        EnderecoService enderecoService = new EnderecoService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int IdCliente = Convert.ToInt32(Session["IdCliente"]);
                CarregarEndereco(IdCliente);
            }
        }

        protected void btnCadastrarEndereco_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlTipoEndereco.SelectedValue).Equals(0))
            {
                String mensagem = "Por favor selecionar o Tipo de Endereco";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "MensagemDeAlert", "alert('" + mensagem + "');", true);
            }
            else
            {
                TipoEndereco endereco = new TipoEndereco();

                endereco.Endereco = Convert.ToString(txtEndereco.Text);
                endereco.Bairro = Convert.ToString(txtBairro.Text);
                endereco.Cidade = Convert.ToString(txtCidade.Text);
                endereco.IdCliente = Convert.ToInt32(Session["IdCliente"]);
                endereco.IdTipoEndereco= Convert.ToInt32(ddlTipoEndereco.SelectedValue);
                if (Convert.ToInt32(Session["IdEndereco"]) != 0)
                {
                    endereco.IdEndereco = Convert.ToInt32(Session["IdEndereco"]);
                    Session.Remove("IdEndereco");
                }                

                enderecoService.InserirEndereco(endereco);

                var lista = enderecoService.EnderecoTipo(Convert.ToInt32(Session["IdCliente"]));
                gvEndereco.DataSource = lista;
                gvEndereco.DataBind();

                limpaCampos();
            }
        }

        public void CarregarEndereco(int IdCliente)
        {
            var lista = enderecoService.EnderecoTipo(IdCliente);

            Session["stcRetornoArquivos"] = lista;

            gvEndereco.DataSource = lista;
            gvEndereco.DataBind();
        }
        public void limpaCampos()
        {
            txtBairro.Text =
            txtCidade.Text =
            txtEndereco.Text = string.Empty;
        }

        protected void gvEndereco_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Session["IdEndereco"] = (Convert.ToInt32(e.CommandArgument.ToString()));
                var endereco = enderecoService.EditarEndereco(Convert.ToInt32(Session["IdEndereco"]));

                txtEndereco.Text = endereco.Endereco;
                txtBairro.Text = endereco.Bairro;
                txtCidade.Text = endereco.Cidade;

                ddlTipoEndereco.SelectedValue = Convert.ToString(endereco.IdTipoEndereco);
            }

            if (e.CommandName == "Deletar")
            {
                int IdCodigo = (Convert.ToInt32(e.CommandArgument.ToString()));
                enderecoService.DeletarEndereco(IdCodigo);
            }

            var lista = enderecoService.EnderecoTipo(Convert.ToInt32(Session["IdCliente"]));
            gvEndereco.DataSource = lista;
            gvEndereco.DataBind();
        }

        protected void gvEndereco_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEndereco.DataSource = Session["stcRetornoArquivos"];
            gvEndereco.PageIndex = e.NewPageIndex;
            gvEndereco.DataBind();
        }
    }
}