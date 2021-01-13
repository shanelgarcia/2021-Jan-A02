﻿<%@ Page Title="Artist Albums List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArtistAlbums.aspx.cs" Inherits="WebApp.SamplePages.ArtistAlbums" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Artist Albums List(ODS)</h1>

    <asp:GridView ID="ArtistAlbumList" runat="server" 
        AutoGenerateColumns="False" 
        DataSourceID="ArtistAlbumListODS" 
        AllowPaging="True"
        CssClass="table table-striped">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
            <asp:BoundField DataField="ReleaseYear" HeaderText="ReleaseYear" SortExpression="ReleaseYear"></asp:BoundField>
            <asp:BoundField DataField="ArtistName" HeaderText="ArtistName" SortExpression="ArtistName"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ArtistAlbumListODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Albums_GetArtistAlbums" 
        TypeName="ChinookSystem.BLL.AlbumController"></asp:ObjectDataSource>
</asp:Content>
