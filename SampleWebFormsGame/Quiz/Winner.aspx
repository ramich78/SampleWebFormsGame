<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Winner.aspx.cs" Inherits="SampleWebFormsGame.Quiz.Winner" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron text-center">
        <h1>You did great!</h1>
        <h3>Your time was:
        <asp:Label ID="LabelElapsedTime" runat="server" /></h3>
        <asp:GridView CssClass="custom-grid" ID="GridViewResults"
            HorizontalAlign="Center"
            ItemType="SampleWebFormsGame.Models.GameResult"
            AutoGenerateColumns="False"
            SelectMethod="SelectData"
            runat="server">
            <Columns>
                <asp:TemplateField HeaderText="Position">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:DynamicField DataField="PlayerName" HeaderText="Player Name" />
                <asp:DynamicField DataField="TimeToComplete" HeaderText="Time to complete" />
                <asp:DynamicField DataField="DateOfGameCompletion" HeaderText="Date of game" />
            </Columns>

        </asp:GridView>
    </div>
</asp:Content>
