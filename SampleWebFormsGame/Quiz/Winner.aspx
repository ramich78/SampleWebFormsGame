<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Winner.aspx.cs" Inherits="SampleWebFormsGame.Quiz.Winner" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron text-center">
        <h1>You did great!</h1>
        <h3>Your time was: <asp:Label ID="LabelElapsedTime" runat="server"/></h3>
        <asp:GridView ID="GridViewResults" 
                      ItemType="SampleWebFormsGame.Models.GameResult" 
                      AutoGenerateColumns="True" 
                      SelectMethod="Select"
                      runat="server">

        </asp:GridView>
    </div>
</asp:Content>
