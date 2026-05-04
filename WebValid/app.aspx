<%@ Page Title="App" Language="C#" MasterPageFile="~/Site.Master"
   AutoEventWireup="true" CodeBehind="app.aspx.cs"
   Inherits="WebValid.app" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h2>Notícias de Tecnologia</h2>
  <p><a href="gestao_utilizadores.aspx" class="btn btn-warning btn-sm">
     Gestão de Utilizadores</a></p>

  <asp:GridView ID="gvNoticias" runat="server" AutoGenerateColumns="false"
     CssClass="table table-bordered table-hover">
    <Columns>
      <asp:TemplateField HeaderText="Imagem">
        <ItemTemplate>
          <a href='<%# Eval("Link") %>' target="_blank">
            <img src='<%# Eval("Imagem") %>' style="width:80px;height:60px;object-fit:cover;"/>
          </a>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:BoundField DataField="Titulo" HeaderText="Título"/>
      <asp:BoundField DataField="Data"   HeaderText="Data"/>
    </Columns>
  </asp:GridView>
</asp:Content>