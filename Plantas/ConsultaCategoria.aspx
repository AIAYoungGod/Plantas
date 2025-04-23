<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaCategoria.aspx.cs" Inherits="ProyectoPlantas.ConsultaCategoria" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Consulta por Categoría</h2>

    <div style="margin-bottom: 20px;">
        <asp:Label ID="lblCategoria" runat="server" Text="Seleccione una categoría:" Font-Bold="true" />
        <br />
        <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"
            Width="250px">
        </asp:DropDownList>
    </div>

    <asp:GridView ID="gvPlantas" runat="server" AutoGenerateColumns="false" CssClass="table" BorderStyle="Solid"
        BorderColor="#ccc" GridLines="Both" Width="100%">
        <Columns>
            <asp:BoundField DataField="NombrePlanta" HeaderText="Nombre de la Planta" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:BoundField DataField="NombreCategoria" HeaderText="Categoría" />
        </Columns>
    </asp:GridView>
</asp:Content>
