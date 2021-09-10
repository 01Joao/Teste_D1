<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Endereco.aspx.cs" Inherits="Formulario.Site.Cliente.Endereco" %>

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
        <h1><b>ENDEREÇO</b></h1>
    </div>

    <div class="form-group ">
        <asp:Label ID="lblTipoEndereco" Width="142px" runat="server" Text="Tipo de Endereço:"></asp:Label>
        <asp:DropDownList ID="ddlTipoEndereco" runat="server" TabIndex="6" Width="178px">
            <asp:ListItem Value="0">--Selecione--</asp:ListItem>
            <asp:ListItem Value="1">Comercial</asp:ListItem>
            <asp:ListItem Value="2">Residencial</asp:ListItem>
        </asp:DropDownList>
    </div>

    <div class="form-group">
        <asp:Label ID="lblEndereco" Width="142px" runat="server" Text="Endereço:"></asp:Label>
        <asp:TextBox ID="txtEndereco" runat="server" TabIndex="6" Width="178px"></asp:TextBox>


        <asp:Label ID="lblBairro" runat="server" Text="Bairro:"></asp:Label>
        <asp:TextBox ID="txtBairro" runat="server" TabIndex="6" Width="178px"></asp:TextBox>


        <asp:Label ID="lblCidade" runat="server" Text="Cidade:"></asp:Label>
        <asp:TextBox ID="txtCidade" runat="server" TabIndex="6" Width="178px"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Button ID="btnCadastrarEndereco" CssClass="btn btn-success" runat="server" Text="Cadastrar" OnClick="btnCadastrarEndereco_Click" />
    </div>

    <asp:GridView ID="gvEndereco" runat="server" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="gvEndereco_PageIndexChanging" OnRowCommand="gvEndereco_RowCommand" CssClass="GridGis">
        <Columns>
            <asp:BoundField DataField="Endereco" HeaderText="Endereco" />
            <asp:BoundField DataField="Bairro" HeaderText="Bairro" />
            <asp:BoundField DataField="Cidade" HeaderText="Cidade" />
            <asp:BoundField DataField="DescricaoEndereco" HeaderText="Descricao" />
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEditar" CssClass="btn btn-success" runat="server" Text="Editar"
                        CommandName="Editar"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdEndereco") %>'>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDeletar" CssClass="btn btn-danger" runat="server" Text="Deletar"
                        CommandName="Deletar"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdEndereco") %>'>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerSettings Mode="NextPrevious" NextPageImageUrl="~/img/next.png" NextPageText="Pr&#243;ximo" PreviousPageImageUrl="~/img/back.png" LastPageText="" PreviousPageText="Anterior" />
        <PagerStyle HorizontalAlign="Right" />
    </asp:GridView>
</asp:Content>
