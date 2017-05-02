<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Trafikkskole._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Velkommen til trafikkskolequiz
            <asp:Label ID="Label1" runat="server"></asp:Label>!
&nbsp;</h2>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="ScoreLabel" runat="server"></asp:Label>
        </p>
        </div>

    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <h2>Quiz!</h2>
            <p>
                <asp:Label ID="QnrLabel" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:Label ID="QuestionLabel" runat="server" Font-Bold="True"></asp:Label>
            </p>
            <p>
                &nbsp;</p>
            <p>
                <asp:Image ID="Image1" runat="server" Visible="False" />
            </p>
            <br>
            <p>
                <asp:Label ID="AnswerAlt1" runat="server"></asp:Label>
                <asp:RadioButton ID="R1" runat="server" GroupName="Quiz" Visible="False"  />
                <asp:CheckBox ID="C1" runat="server" Visible="False" />
            </p>
            <p>
                <asp:Label ID="AnswerAlt2" runat="server"></asp:Label>
                <asp:RadioButton ID="R2" runat="server" GroupName="Quiz" Visible="False" />
                <asp:CheckBox ID="C2" runat="server" Visible="False" />
            </p>
            <p>
                <asp:Label ID="AnswerAlt3" runat="server"></asp:Label>
                <asp:RadioButton ID="R3" runat="server" GroupName="Quiz" Visible="False" />
                <asp:CheckBox ID="C3" runat="server" Visible="False" />
            </p>
            <p>
                <asp:Label ID="AnswerAlt4" runat="server"></asp:Label>
                <asp:RadioButton ID="R4" runat="server" GroupName="Quiz" Visible="False" />
                <asp:CheckBox ID="C4" runat="server" Visible="False" />
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Start quiz" />
            </p>
        </div>
    </div>

</asp:Content>
