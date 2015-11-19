<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/mpMain.Master" AutoEventWireup="true" CodeBehind="wpAccountLogin.aspx.cs" Inherits="WorkoutLogger.Page.wpAccountLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../StyleSheet/ssLogin.css" rel="stylesheet" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js">
    </script>

    <script>
        $(document).ready(function () {
            $('#ContentPlaceHolder1_lnkSubmit').click(function (e) {

                if ($('#ContentPlaceHolder1_txtUsername').val().length == 0) {
                    $('#ContentPlaceHolder1_divError').text("*Please insert Username");
                    $('#ContentPlaceHolder1_divError').show();
                    e.preventDefault();
                }
                else if($('#ContentPlaceHolder1_txtPassword').val().length == 0)
                {
                    $('#ContentPlaceHolder1_divError').text("*Please insert Password");
                    $('#ContentPlaceHolder1_divError').show();
                    e.preventDefault();
                }
                else
                {
                    $('#ContentPlaceHolder1_lblError').hide();
                }
            });
        });      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="divPage" class="Page">
            <h1>Sign In</h1>


            <div class="PageDivider-left">
                <table class="tblLogin">
                    <tr>
                        <td class="tblLogin-Cell">
                            <input id="txtUsername" type="text" placeholder="Username" class="txtLogin" runat="server"/>
                        </td>
                    </tr>
                    <tr >
                        <td class="tblLogin-Cell">
                            <input id="txtPassword" type="password" placeholder="Password" class="txtLogin" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="tblLogin-Cell">
                            <a id="lnkSubmit" class="button" runat="server" onserverclick="Submit_ServerClick" >Login </a>
                            <a href="wpAccountRegistration.aspx" id="lnkRegister" class="button" runat="server" style="float:right" >Register</a>
                        </td>
                    </tr>
                </table>
                <div id="divError" runat="server" class="divError"></div>
            </div>

            <div id="divQuote" class="PageDivider-right" runat="server"></div>
        </div>






        

        
</asp:Content>
