<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consultar.aspx.cs" Inherits="Formulario.Site.Cliente.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
            .GridGis {
            width: 100%;
            background-color: #FFFFFF;
            border: solid 1px #525252;
            border-collapse: collapse;
        }

            .GridGis td {
                padding: 2px;
            }

            .GridGis th {
                height: 20px;
                padding: 4px 6px;
                color: white;
                background: #000000;
                text-align: center;
            }
    </style>
    <br />
    <div>
        <asp:Label ID="lblNome" runat="server" Text="Nome"></asp:Label>
        <asp:TextBox ID="txtNome" runat="server" MaxLength="100"></asp:TextBox>
        <asp:Button ID="btnPesquisar" Text="Pesquisar" CssClass="btn btn-success" runat="server" Height="30px" OnClick="btnPesquisar_Click" />        
    </div>
    <br />
    <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="false" OnRowCommand="gvClientes_RowCommand" CssClass="GridGis">
        <Columns>
            <asp:BoundField DataField="CPF" HeaderText="CPF" />
            <asp:BoundField DataField="NOME" HeaderText="Nome do Cliente" />
            <asp:BoundField DataField="DataNascimento" HeaderText="Data Nascimento" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEditar" CssClass="btn btn-success" runat="server" Text="Editar"
                        CommandName="Editar"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdCliente") %>'>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDeletar" CssClass="btn btn-danger" runat="server" Text="Deletar"
                        CommandName="Deletar"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdCliente") %>'>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkAddTelefone" CssClass="btn btn-success" runat="server" Text="Adicionar Telefone"
                        CommandName="AdicionarTelefone"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdCliente") %>'>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkAddEndereco" CssClass="btn btn-success" runat="server" Text="Adicionar Endereco"
                        CommandName="AdicionarEndereco"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdCliente") %>'>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
