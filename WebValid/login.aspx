<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master"
   AutoEventWireup="true" CodeBehind="login.aspx.cs"
   Inherits="WebValid.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h2>Login</h2>
  <div class="row">
    <div class="col-md-4">

      <div class="mb-3">
        <label>Utilizador</label>
        <asp:TextBox ID="txtUser" runat="server" CssClass="form-control"/>
        <asp:RequiredFieldValidator ControlToValidate="txtUser"
           ErrorMessage="Obrigatório" runat="server" ForeColor="Red"/>
      </div>

      <div class="mb-3">
        <label>Palavra-Passe</label>
        <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="form-control"/>
        <asp:RequiredFieldValidator ControlToValidate="txtPass"
           ErrorMessage="Obrigatório" runat="server" ForeColor="Red"/>
      </div>

      <asp:Label ID="lblMsg" runat="server" ForeColor="Red"/>
      <br/>
      <asp:Button ID="btnLogin" runat="server" Text="Entrar"
         CssClass="btn btn-success" OnClick="btnLogin_Click"/>
      <br/><br/>
      <a href="recuperar.aspx">Recuperar palavra-passe</a>
      <br/>
      <a href="registo_utilizador.aspx">Criar conta</a>

    </div>
  </div>
</asp:Content>
