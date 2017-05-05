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
        <p>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </p>
        </div>

    <div class="row">
        <div class="col-md-5 col-md-offset-1">
            <h2>Quiz!</h2>
            <p>
                <asp:Label ID="QnrLabel" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="QuestionLabel" runat="server" Font-Bold="True"></asp:Label>
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
            

        </div>
        <div class="col-md-6"> <p><asp:Image ID="Image1" runat="server" Visible="False" Height="300px" /></p> </div>
    </div>
    <div class="row">
        <div class="col-md-5 col-md-offset-1">
            
                        <p>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Start quiz" />
            </p>
            

        </div>
        
    </div>

</asp:Content>
