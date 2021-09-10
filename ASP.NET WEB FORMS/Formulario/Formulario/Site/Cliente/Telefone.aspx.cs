using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Formulario.Site.Cliente
{
    public partial class Telefone : System.Web.UI.Page
    {
        TelefoneService telefoneService = new TelefoneService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int IdCliente = Convert.ToInt32(Session["IdCliente"]);
                CarregarTelefone(IdCliente);
            }
        }

        protected void btnCadastrarTelefone_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlTipoTelefone.SelectedValue).Equals(0))
            {
                String mensagem = "Por favor selecionar o Tipo de Telefone";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "MensagemDeAlert", "alert('" + mensagem + "');", true);
            }
            else
            {
                TipoTelefone telefone = new TipoTelefone();

                telefone.DDD = Convert.ToString(txtDDD.Text);
                telefone.Telefone = Convert.ToString(txtTelefone.Text);
                telefone.IdCliente = Convert.ToInt32(Session["IdCliente"]);
                telefone.IdTipoTelefone = Convert.ToInt32(ddlTipoTelefone.SelectedValue);
                if (Convert.ToInt32(Session["IdTelefone"]) != 0)
                {
                    telefone.IdTelefone = Convert.ToInt32(Session["IdTelefone"]);
                    Session.Remove("IdTelefone");
                }                

                telefoneService.InserirTelefone(telefone);
                
                var lista = telefoneService.TelefoneTipo(Convert.ToInt32(Session["IdCliente"]));
                gvTelefone.DataSource = lista;
                gvTelefone.DataBind();

                limpaCampos();
            }
        }

        public void CarregarTelefone(int IdCliente)
        {
            var lista = telefoneService.TelefoneTipo(IdCliente);

            Session["stcRetornoArquivos"] = lista;

            gvTelefone.DataSource = lista;
            gvTelefone.DataBind();
        }
        public void limpaCampos()
        {
            txtDDD.Text =
            txtTelefone.Text = string.Empty;
        }

        protected void gvTelefone_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Session["IdTelefone"] = (Convert.ToInt32(e.CommandArgument.ToString()));
                var telefone = telefoneService.EditarTelefone(Convert.ToInt32(Session["IdTelefone"]));

                txtDDD.Text = telefone.DDD;
                txtTelefone.Text = telefone.Telefone;

                ddlTipoTelefone.SelectedValue = Convert.ToString(telefone.IdTipoTelefone);
            }

            if (e.CommandName == "Deletar")
            {
                int IdCodigo = (Convert.ToInt32(e.CommandArgument.ToString()));
                telefoneService.DeletarTelefone(IdCodigo);
            }

            var lista = telefoneService.TelefoneTipo(Convert.ToInt32(Session["IdCliente"]));
            gvTelefone.DataSource = lista;
            gvTelefone.DataBind();
        }

        protected void gvTelefone_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTelefone.DataSource = Session["stcRetornoArquivos"];
            gvTelefone.PageIndex = e.NewPageIndex;
            gvTelefone.DataBind();
        }
    }
}