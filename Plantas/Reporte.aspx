<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="ProyectoPlantas.Reporte" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Reporte de Cantidad de Plantas por Categoría</h2>

    <asp:GridView ID="gvReporte" runat="server" AutoGenerateColumns="true" CssClass="table" BorderStyle="Solid"
        BorderColor="#ccc" GridLines="Both" Width="100%">
    </asp:GridView>
</asp:Content>
