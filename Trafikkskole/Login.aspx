<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Trafikkskole.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container">
        <div class="row">
            <div class="col-sm-8 col-md-6 col-md-offset-4">
                <h1>Martin's trafikkskole</h1><br/>
                <div>

                   <h4 class="text-left">Tast inn brukernavn og passord:</h4>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Placeholder="Epost"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="reqName1" controltovalidate="TextBox1" forecolor="Red" errormessage="*Påkrevd" />
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Passord"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="reqName2" controltovalidate="TextBox2" forecolor="Red" errormessage="*Påkrevd" />
                        
                        <br />
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Logg inn" CssClass="btn-primary" OnClick="Button1_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" CssClass="alert-danger text-right"></asp:Label>
                        <p class="text-center">
                            <a href="/Register">Opprett en konto</a>
                        </p>
                    
                </div>
                
                <div>
                    <p>Dette er en skoleoppgave jeg har laget i ASP.NET som student ved Høgskolen i Sørøst-Norge.<br/> Kildekoden til nettsiden finner du på min <a href="https://github.com/pnitram/Trafikkskole/">GitHub side.</a></p>
                </div>


            </div>
        </div>
    </div>


</asp:Content>