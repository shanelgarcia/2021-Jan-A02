﻿<%@ Page Title="Filter Search Demo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchByDLL.aspx.cs" Inherits="WebApp.SamplePages.SearchByDLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Search Albums by Artist</h1>
    <div class="row">
        <div class="offset-3">
            <asp:Label ID="Label1" runat="server" Text="Select an Artist"></asp:Label>&nbsp;&nbsp;
            <asp:DropDownList ID="ArtistList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
            <asp:LinkButton ID="SearchAlbums" runat="server"><i class="fa fa-search"></i>Search</asp:LinkButton>
        </div>
    </div>
</asp:Content>