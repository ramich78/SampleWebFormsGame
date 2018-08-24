<%@ Page AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="SampleWebFormsGame.Quiz.Quiz" Language="C#" MasterPageFile="~/Site.Master"%>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    
        <div>
            <asp:TextBox ID="TextBoxQuestionSentence" runat="server" Wrap="True"></asp:TextBox>
        </div>
        <div>
            <asp:Button CssClass="btn-success" ID="ButtonYes" runat="server" OnClick="ButtonYes_OnClick" Text="Yes"/>
            <asp:Button CssClass="btn-warning" ID="ButtonNo" OnClick = "ButtonNo_OnClick" runat="server" Text="No" />
            <asp:Button CssClass="btn-danger" ID="ButtonLeaveGame" OnClick="ButtonLeaveGame_OnClick" runat="server" Text="Leave game"/>
        </div>    

</asp:Content>

