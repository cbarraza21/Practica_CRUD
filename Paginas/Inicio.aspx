<%@ Page Title="" Language="C#" MasterPageFile="~/PC.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="PCRUD.Paginas.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
        <br />
        <div class="mx-auto" style="width:300px">
            <h2>Listado de personas</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col align-self-end">
                    <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-success form-control-sm" Text="Crear" OnClick="BtnCreate_Click"/>
                </div>
            </div>
        </div>
        <br />
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvpersonas" class="table table-borderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Gestion">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Ver" CssClass="btn form-control-sm btn-primary" ID="BtnRead" OnClick="BtnRead_Click"/>
                                <asp:Button runat="server" Text="Actualizar" CssClass="btn form-control-sm btn-primary" ID="BtnUpdate" OnClick="BtnUpdate_Click"/>
                                <asp:Button runat="server" Text="Eliminar" CssClass="btn form-control-sm btn-primary" ID="BtnDelete" OnClick="BtnDelete_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
