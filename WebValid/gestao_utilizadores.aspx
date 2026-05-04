<%@ Page Title="Gestão de Utilizadores" Language="C#" MasterPageFile="~/Site.Master"
   AutoEventWireup="true" CodeBehind="gestao_utilizadores.aspx.cs"
   Inherits="WebValid.gestao_utilizadores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h2>Gestão de Utilizadores</h2>
  <p><a href="app.aspx" class="btn btn-secondary btn-sm">← Voltar</a></p>

  <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false"
     DataKeyNames="Id" CssClass="table table-striped"
     OnRowEditing="gvUsers_RowEditing"
     OnRowUpdating="gvUsers_RowUpdating"
     OnRowCancelingEdit="gvUsers_RowCancelingEdit"
     OnRowDeleting="gvUsers_RowDeleting">
    <Columns>
      <asp:BoundField DataField="Id"         HeaderText="ID"        ReadOnly="true"/>
      <asp:BoundField DataField="Utilizador" HeaderText="Utilizador"/>
      <asp:BoundField DataField="Email"      HeaderText="Email"/>
      <asp:CommandField ShowEditButton="true" ShowDeleteButton="true"
         EditText="✏️" DeleteText="🗑️" UpdateText="💾" CancelText="❌"
         ButtonType="Button"/>
    </Columns>
  </asp:GridView>
</asp:Content>
