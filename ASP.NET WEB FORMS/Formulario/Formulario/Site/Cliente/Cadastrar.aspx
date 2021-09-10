<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastrar.aspx.cs" Inherits="Formulario.Site.Cliente.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery.maskedinput-1.1.4.pack.js"></script>
    <script type="text/javascript">
        function mascaraData(campo, e) {
            var kC = (document.all) ? event.keyCode : e.keyCode;
            var data = campo.value;

            if (kC != 8 && kC != 46) {
                if (data.length == 2) {
                    campo.value = data += '/';
                }
                else if (data.length == 5) {
                    campo.value = data += '/';
                }
                else
                    campo.value = data;
            }
        }

        function mascaraMutuario(o, f) {
            v_obj = o
            v_fun = f
            setTimeout('execmascara()', 1)
        }

        function execmascara() {
            v_obj.value = v_fun(v_obj.value)
        }

        function cpfCnpj(v) {

            //Remove tudo o que não é dígito
            v = v.replace(/\D/g, "")

            if (v.length <= 14) { //CPF

                //Coloca um ponto entre o terceiro e o quarto dígitos
                v = v.replace(/(\d{3})(\d)/, "$1.$2")

                //Coloca um ponto entre o terceiro e o quarto dígitos
                //de novo (para o segundo bloco de números)
                v = v.replace(/(\d{3})(\d)/, "$1.$2")

                //Coloca um hífen entre o terceiro e o quarto dígitos
                v = v.replace(/(\d{3})(\d{1,2})$/, "$1-$2")
            }
            return v
        }
    </script>
    <style>
        h1 {
            font-size: 15px;
        }
    </style>
    <div class="container">
        <div class="row justify-content-center ">

            <div>
                <h1><b>DADOS DA PESSOA</b></h1>
            </div>

            <div class="form-group ">
                <asp:Label ID="lblNome" Width="142px" runat="server" Text="Nome:"></asp:Label>
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </div>

            <div class="form-group ">
                <asp:Label ID="lblCpf" Width="142px" runat="server" Text="CPF:"></asp:Label>
                <asp:TextBox ID="txtCpf" onkeypress="mascaraMutuario(this,cpfCnpj)" runat="server" MaxLength="14"></asp:TextBox>
            </div>

            <div class="form-group ">
                <asp:Label ID="lblRg" Width="142px" runat="server" Text="RG:"></asp:Label>
                <asp:TextBox ID="txtRg" runat="server" MaxLength="8"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblDataNasci" Width="142px" runat="server" CssClass="text format_data" Text="Data Nascimento:"></asp:Label>
                <asp:TextBox ID="txtDataNasci" onkeypress="mascaraData( this, event )" MaxLength="10" runat="server"></asp:TextBox>
            </div>

            <div>
                <h1><b>REDES SOCIAIS</b></h1>
            </div>

            <div class="form-group">
                <asp:Label ID="lblFacebook" Width="142px" runat="server" Text="Facebook:"></asp:Label>
                <asp:TextBox ID="txtFacebook" runat="server" Width="280px"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblLinkedin" Width="142px" runat="server" Text="Linkedin:"></asp:Label>
                <asp:TextBox ID="txtLinkedin" runat="server" TabIndex="6" Width="280px"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblTwitter" Width="142px" runat="server" Text="Twitter:"></asp:Label>
                <asp:TextBox ID="txtTwitter" runat="server" TabIndex="6" Width="280px"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblInstagram" Width="142px" runat="server" Text="Instagram:"></asp:Label>
                <asp:TextBox ID="txtInstagram" runat="server" TabIndex="6" Width="280px"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Button ID="btnInserir" CssClass="btn btn-success" runat="server" Text="Cadastrar" OnClick="btnInserir_Click" />
            </div>
        </div>
    </div>
</asp:Content>
