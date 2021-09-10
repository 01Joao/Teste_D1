<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Telefone.aspx.cs" Inherits="Formulario.Site.Cliente.Telefone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        h1 {
            font-size: 15px;
        }

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
    <div>
        <h1><b>TELEFONE</b></h1>
    </div>

    <div class="form-group ">
        <asp:Label ID="lblTipoTelefone" Width="142px" runat="server" Text="Tipo de Telefone:"></asp:Label>
        <asp:DropDownList ID="ddlTipoTelefone" runat="server" TabIndex="6" Width="178px">
            <asp:ListItem Value="0">--Selecione--</asp:ListItem>
            <asp:ListItem Value="1">Comercial</asp:ListItem>
            <asp:ListItem Value="2">Residencial</asp:ListItem>
            <asp:ListItem Value="3">Celular</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <asp:Label ID="lblDDD" Width="142px" runat="server" Text="DDD:"></asp:Label>
        <asp:TextBox ID="txtDDD" runat="server" TabIndex="6" Width="40px"></asp:TextBox>

        <asp:Label ID="lblTelefone" runat="server" Text="Telefone:"></asp:Label>
        <asp:TextBox ID="txtTelefone" runat="server" TabIndex="6" Width="178px"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Button ID="btnCadastrarTelefone" CssClass="btn btn-success" runat="server" Text="Cadastrar" OnClick="btnCadastrarTelefone_Click" />
    </div>

    <asp:GridView ID="gvTelefone" runat="server" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="gvTelefone_PageIndexChanging" OnRowCommand="gvTelefone_RowCommand" CssClass="GridGis">
        <Columns>
            <asp:BoundField DataField="DDD" HeaderText="DDD" />
            <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
            <asp:BoundField DataField="Descricao" HeaderText="Descricao" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEditar" CssClass="btn btn-success" runat="server" Text="Editar"
                        CommandName="Editar"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdTelefone") %>'>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDeletar" CssClass="btn btn-danger" runat="server" Text="Deletar"
                        CommandName="Deletar"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdTelefone") %>'>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
         <PagerSettings Mode="NextPrevious" NextPageImageUrl="~/img/next.png" NextPageText="Pr&#243;ximo" PreviousPageImageUrl="~/img/back.png" LastPageText="" PreviousPageText="Anterior" />
        <PagerStyle HorizontalAlign="Right" />
    </asp:GridView>
</asp:Content>
