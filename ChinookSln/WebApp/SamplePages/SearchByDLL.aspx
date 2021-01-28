<%@ Page Title="Filter Search Demo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchByDLL.aspx.cs" Inherits="WebApp.SamplePages.SearchByDLL" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Search Albums by Artist</h1>
    <div class="row">
        <div class="offset-3">
            <asp:Label ID="Label1" runat="server" Text="Select an Artist"></asp:Label>&nbsp;&nbsp;
            <asp:DropDownList ID="ArtistList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
            <asp:LinkButton ID="SearchAlbums" runat="server" OnClick="SearchAlbums_Click"><i class="fa fa-search"></i>Search</asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="offset-3">
            <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
        </div>
    </div>

    <div class="row">
        <div class="offset-3">
            <asp:GridView ID="ArtistAlbum_Grid" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" GridLines="Horizontal" BorderStyle="Ridge">
                <Columns>
                    <asp:TemplateField HeaderText="Album">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Release">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("ReleaseYear") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Artist">
                        <ItemTemplate>
                            <asp:DropDownList ID="Artist_List" runat="server" DataSourceID="Artist_ListODS" DataTextField="DisplayField" DataValueField="ValueField" selectedvalue='<%# Eval("ArtistId") %>' Width="250px"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No albums found for selection.
                </EmptyDataTemplate>
            </asp:GridView>

            <asp:ObjectDataSource ID="Artist_ListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Artists_DDList" TypeName="ChinookSystem.BLL.ArtistController"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
