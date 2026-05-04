<%@ Page Title="Recuperar Palavra-Passe" Language="C#" MasterPageFile="~/Site.Master"
   AutoEventWireup="true" CodeBehind="recuperar.aspx.cs"
   Inherits="WebValid.recuperar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h2>Recuperar Palavra-Passe</h2>
  <div class="row">
    <div class="col-md-4">

      <div class="mb-3">
        <label>Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"/>
        <asp:RequiredFieldValidator ControlToValidate="txtEmail"
           ErrorMessage="Email obrigatório" runat="server" ForeColor="Red"/>
        <asp:RegularExpressionValidator ControlToValidate="txtEmail"
           ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\\w+)*\.\w+"
           ErrorMessage="Email inválido" runat="server" ForeColor="Red"/>
      </div>

      <asp:Label ID="lblMsg" runat="server"/>
      <br/>
      <asp:Button ID="btnRecuperar" runat="server" Text="Recuperar"
         CssClass="btn btn-primary" OnClick="btnRecuperar_Click"/>
      <br/><br/>
      <a href="login.aspx">← Voltar ao Login</a>

    </div>
  </div>
</asp:Content>