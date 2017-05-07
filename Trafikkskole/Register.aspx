<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Trafikkskole.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
    
        <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <h1>Martin's trafikkskole</h1><br/>
                <div>

                   <h4 class="col-md-offset-3">Opprett en konto:</h4>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Placeholder="Fornavn"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="reqName1" controltovalidate="TextBox1" forecolor="Red" errormessage="*Påkrevd" />
                        
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"  Placeholder="Etternavn"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="reqName2" controltovalidate="TextBox2" forecolor="Red" errormessage="*Påkrevd" />
                        
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Placeholder="Epost"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="reqEmail" controltovalidate="TextBox3" forecolor="Red" errormessage="*Påkrevd" />
                        
                        &nbsp;&nbsp;&nbsp;
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" forecolor="Red" ErrorMessage="Feil format på epost!" ControlToValidate="TextBox3" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Passord"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="reqPassword" controltovalidate="TextBox4" forecolor="Red" errormessage="*Påkrevd" />
                    
                        &nbsp;&nbsp;&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox4" ErrorMessage="Må inneholde minst 6 tegn!" ForeColor="Red" ValidationExpression="^.{6,}$"></asp:RegularExpressionValidator>
                    
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Bekreft passord"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="reqConfirmPassword" controltovalidate="TextBox4" forecolor="Red" errormessage="*Påkrevd" />
                    

                        &nbsp;&nbsp;&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox5" ErrorMessage="Må inneholde minst 6 tegn!" ForeColor="Red" ValidationExpression="^.{6,}$"></asp:RegularExpressionValidator>
                    

                        <br />
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Registrer og logg inn" CssClass="btn-primary" OnClick="Button1_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" CssClass="alert-danger text-right"></asp:Label>
                        
                </div>

            </div>
        </div>
    </div>
    

</asp:Content>
