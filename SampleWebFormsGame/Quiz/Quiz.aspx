<%@ Page AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="SampleWebFormsGame.Quiz.Quiz" Language="C#" MasterPageFile="~/Site.Master" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Timer ID="TimerGameClock" runat="server" Interval="1000" OnTick="TimerGameClock_OnTick" />

    <!-- To avoid bootstrap in-line styling custom saas classes should be introduced.-->

    <div class="jumbotron text-center">

        <div class="row bottom-spacer">
            <asp:Label CssClass="lead" ID="LabelQuestionSentence" runat="server" Wrap="True"></asp:Label>
        </div>

        <div class="row bottom-spacer">
            <asp:Button CssClass="btn btn-primary btn-lg" ID="ButtonYes" runat="server" OnClick="ButtonYes_OnClick" Text="Yes" />
            <asp:Button CssClass="btn btn-primary btn-lg" ID="ButtonNo" OnClick="ButtonNo_OnClick" runat="server" Text="No" />

        </div>

        <div class="row bottom-spacer">
            <asp:UpdatePanel ID="ClockUpdatePanel" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TimerGameClock" />
                </Triggers>
                <ContentTemplate>
                    <asp:Label ID="LabelGameClock" runat="server">00:00</asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="row bottom-spacer">
            <asp:Button CssClass="btn btn-warning btn-sm" ID="ButtonLeaveGame" OnClick="ButtonLeaveGame_OnClick" runat="server" Text="Leave game" />
        </div>

    </div>
</asp:Content>

