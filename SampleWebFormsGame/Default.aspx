<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleWebFormsGame._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron text-center">
        <h1>Sample Web Forms Game</h1>
        <div runat="server" id="divNotLoggedInUserContent" visible="False">
            <p class="lead">Log in to play this great game!</p>
        </div>
        <div runat="server" id="divLoggedInUserContent" visible="False">
            <a class="btn btn-default" href="/Quiz/Quiz.aspx">Start the game!</a>
        </div>
    </div>

</asp:Content>
