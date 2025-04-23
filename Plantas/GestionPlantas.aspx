<%@ Page Title="Gestionar Plantas" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="GestionPlantas.aspx.cs" Inherits="ProyectoPlantas.GestionPlantas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de Plantas</h2>

    <asp:HiddenField ID="hfId" runat="server" />

    <label>Nombre de la Planta:</label><br />
    <asp:TextBox ID="txtNombre" runat="server" /><br /><br />

    <label>Descripción:</label><br />
    <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" /><br /><br />

    <label>Categoría:</label><br />
    <asp:DropDownList ID="ddlCategoria" runat="server" /><br /><br />

    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Planta" OnClick="btnAgregar_Click" />
    <asp:Button ID="btnModificar" runat="server" Text="Modificar Planta" OnClick="btnModificar_Click" />
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Planta" OnClick="btnEliminar_Click" /><br /><br />

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" />

    <hr />

    <asp:GridView ID="gvPlantas" runat="server" AutoGenerateColumns="false" AutoGenerateSelectButton="true"
        OnSelectedIndexChanged="gvPlantas_SelectedIndexChanged" CssClass="table" Width="100%">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="NombrePlanta" HeaderText="Nombre de la Planta" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:BoundField DataField="NombreCategoria" HeaderText="Categoría" />
        </Columns>
    </asp:GridView>
</asp:Content>
