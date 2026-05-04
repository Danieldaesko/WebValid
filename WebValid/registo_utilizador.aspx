<%@ Page Title="Registo" Language="C#" MasterPageFile="~/Site.Master"
   AutoEventWireup="true" CodeBehind="registo_utilizador.aspx.cs"
   Inherits="WebValid.registo_utilizador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h2>Registo de Utilizador</h2>
  <div class="row"><div class="col-md-5">

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

    <div class="mb-3">
      <label>Confirmar Palavra-Passe</label>
      <asp:TextBox ID="txtPass2" runat="server" TextMode="Password" CssClass="form-control"/>
      <asp:RequiredFieldValidator ControlToValidate="txtPass2"
         ErrorMessage="Obrigatório" runat="server" ForeColor="Red"/>
      <asp:CompareValidator ControlToValidate="txtPass2" ControlToCompare="txtPass"
         ErrorMessage="Palavras-passe não coincidem" runat="server" ForeColor="Red"/>
    </div>

    <div class="mb-3">
      <label>Email</label>
      <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"/>
      <asp:RequiredFieldValidator ControlToValidate="txtEmail"
         ErrorMessage="Obrigatório" runat="server" ForeColor="Red"/>
      <asp:RegularExpressionValidator ControlToValidate="txtEmail"
         ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\\w+)*\.\w+"
         ErrorMessage="Email inválido" runat="server" ForeColor="Red"/>
    </div>

    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"/>
    <br/>
    <asp:Button ID="btnRegistar" runat="server" Text="Registar"
       CssClass="btn btn-primary" OnClick="btnRegistar_Click"/>

  </div></div>
</asp:Content>