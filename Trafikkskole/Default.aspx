<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Trafikkskole._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        
    <script>
        function validateCheckbox(source, arg) {
            var $c1 = $('#<%= C1.ClientID %>');
            var $c2 = $('#<%= C2.ClientID %>');
            var $c3 = $('#<%= C3.ClientID %>');
            var $c4 = $('#<%= C4.ClientID %>');
            var $r1 = $('#<%= R1.ClientID %>');
            var $r2 = $('#<%= R2.ClientID %>');
            var $r3 = $('#<%= R3.ClientID %>');
            var $r4 = $('#<%= R4.ClientID %>');
            if ($c1.prop("checked") || $c2.prop("checked") || $c3.prop("checked") || $c4.prop("checked") || $r1.prop("checked") || $r2.prop("checked") || $r3.prop("checked") || $r4.prop("checked")) {
                arg.IsValid = true;
            } else {
                arg.IsValid = false;
            }
        }
</script> 
    
  

    <div class="jumbotron">
        <h2>Velkommen til trafikkskolequiz
            <asp:Label ID="Label1" runat="server"></asp:Label>!
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="ScoreLabel" runat="server" CssClass="alert" Font-Size="Smaller"></asp:Label>
        </h2>
        </div>
    
    
    <div class="row">
        <div class="col-md-5 col-md-offset-1">
            <h2>
                <asp:Label ID="QuizHeadingLabel" runat="server" CssClass="h4" ForeColor="Black"></asp:Label>
            </h2>
            
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="False"></asp:PlaceHolder>

            <p>
                <asp:Label ID="QnrLabel" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="QuestionLabel" runat="server" Font-Bold="True"></asp:Label>
            </p>
            
            <p><asp:CustomValidator id="vCbox"
                ClientValidationFunction="validateCheckbox" 
                ErrorMessage="<br/>Du må gjøre et valg" 
                ForeColor="Red"
                Display="Static"
                ValidationGroup="CB"
                runat="server" Enabled="False"></asp:CustomValidator>
            </p>
            
            <p>
                <asp:Label ID="AnswerAlt1" runat="server"></asp:Label>
                <asp:RadioButton ID="R1" ValidationGroup="CB" runat="server" GroupName="Quiz" Visible="False"  />
                <asp:CheckBox ID="C1" ValidationGroup="CB" runat="server" Visible="False" />
            </p>
            <p>
                <asp:Label ID="AnswerAlt2" runat="server"></asp:Label>
                <asp:RadioButton ID="R2" ValidationGroup="CB" runat="server" GroupName="Quiz" Visible="False" />
                <asp:CheckBox ID="C2" ValidationGroup="CB" runat="server" Visible="False" />
            </p>
            <p>
                <asp:Label ID="AnswerAlt3" runat="server"></asp:Label>
                <asp:RadioButton ID="R3" ValidationGroup="CB" runat="server" GroupName="Quiz" Visible="False" />
                <asp:CheckBox ID="C3" ValidationGroup="CB" runat="server" Visible="False" />
            </p>
            <p>
                <asp:Label ID="AnswerAlt4" runat="server"></asp:Label>
                <asp:RadioButton ID="R4" ValidationGroup="CB" runat="server" GroupName="Quiz" Visible="False" />
                <asp:CheckBox ID="C4" ValidationGroup="CB" runat="server" Visible="False" />
            </p>
            <p>
              
            </p>
            

        </div>
        <div class="col-md-6"> <p><asp:Image ID="Image1" runat="server" Visible="False" Width="300px" /></p> </div>
    </div>
    <div class="row">
        <div class="col-md-5 col-md-offset-1">
                        <p>
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Start quiz" CssClass=" btn-primary" CausesValidation="true" ValidationGroup="CB" /> 
            </p>
            

        </div>
        
    </div>
    
    

</asp:Content>
