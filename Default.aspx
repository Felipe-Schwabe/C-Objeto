<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CadastroClasse._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
    .custom-h1
    {
        text-align:center;
        background-image:linear-gradient(to right,white,#b2f2c5,#b2f2c5,white);
        font-family:Verdana, Geneva, Tahoma, sans-serif;
        border: 1px solid;
        width: 100%;
        padding: 15px;
    }
    .custom-h2
{
    text-align:center;
    background-image:linear-gradient(to right,#b2f2c5,white,white,white,white,white,#b2f2c5,#b2f2c5);
    font-family:Verdana, Geneva, Tahoma, sans-serif;
    border: 1px solid;
    width: 100%;
    padding: 15px;
}

</style>

    <main>
               <asp:UpdatePanel runat="server">
            <ContentTemplate runat="server">

           

       <div class="custom-h1">

           <h1 class="custom-titulo" >CADASTRO DE CONTATOS</h1>
        <br>Nome:<font color="#FF0000">*</font><asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br><br>
        Email:<font color="#FF0000">*</font><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br><br>
        Data De Nascimento:<font color="#FF0000">*</font><asp:TextBox ID="txtData" runat="server"></asp:TextBox><br><br>
        CPF:<font color="#FF0000">*</font><asp:TextBox ID="txtCPF" runat="server"></asp:TextBox><br><br>
        Estado:<asp:TextBox ID="txtEstado" runat="server"></asp:TextBox><br><br>
        Cidade:<asp:TextBox ID="txtCidade" runat="server"></asp:TextBox><br><br>
        Endereço:<asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox><br><br>
           

        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" CommandName="Cadastrar"   CssClass="btn btn-dark"/> <asp:Button ID="btnExcluir" runat="server" Text="Apagar" OnClick="btnApagar_Click" CssClass="btn btn-dark"/> <br><br>
          

       </div>
                </ContentTemplate>
            </asp:UpdatePanel>       
        <asp:UpdatePanel runat="server">
    <ContentTemplate runat="server">
        <br />

<asp:TextBox ID="txtPesquisar" runat="server" placeholder="Nome do cadastro" CssClass="form-control"></asp:TextBox> 
<asp:Button ID="Button1" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" class="btn btn-light" />
        <asp:Button ID="voltarbtn" runat="server" Text="Limpar Pesquisa" class="btn btn-light" OnClick="voltarbtn_Click" />

<asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="True"> </asp:GridView>

         <div>
               <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" class="custom-h2">
    <Columns>

        <asp:BoundField DataField="Nome" HeaderText="Nome"/>
        <asp:BoundField DataField="Email" HeaderText="Email"/>
        <asp:BoundField DataField="Data" HeaderText="Data de Nascimento"/>
        <asp:BoundField DataField="CPF" HeaderText="CPF"/>
        <asp:BoundField DataField="Estado" HeaderText="Estado"/>
        <asp:BoundField DataField="Cidade" HeaderText="Cidade"/>
        <asp:BoundField DataField="Endereco" HeaderText="Endereço"/>
        <asp:TemplateField>
            <ItemTemplate> 
                <asp:Button ID="btnEdit" runat="server" Text="Editar" OnClick="btnEdit_Click" class="btn btn-outline-dark" CommandArgument='<%# Eval("Id") %>' />
            </ItemTemplate>
        </asp:TemplateField>    

        <asp:TemplateField> 
            <ItemTemplate>
                <asp:Button ID="btnExcluir" runat="server" Text="Excluir"  OnClick="btnExcluir_Click1" class="btn btn-outline-dark" CommandName="Deletar" CommandArgument='<%# Eval("Id") %>' />
            </ItemTemplate>
        </asp:TemplateField>

       

    </Columns>

</asp:GridView>       
                    
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
       
             
    </main>

</asp:Content>
