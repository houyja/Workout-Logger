<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/mpMain.Master" AutoEventWireup="true" CodeBehind="wpAccountRegistration.aspx.cs" Inherits="WorkoutLogger.Page.wpAccountRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../StyleSheet/ssRegister.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

    <script>
        function ErrorMessage(message, e)
        {
            $('#ContentPlaceHolder1_divError').text(message);
            $('#ContentPlaceHolder1_divError').show();
            e.preventDefault();
        }

        function SetTextErrorControl(controlid)
        {
            $(controlid).attr('class', 'txtError');
        }

        function RemoveAllTextErrorControls()
        {
            $('#ContentPlaceHolder1_txtUsername').attr('class', 'txtRegister');
            $('#ContentPlaceHolder1_txtPassword').attr('class', 'txtRegister');
            $('#ContentPlaceHolder1_txtConfirmPassword').attr('class', 'txtRegister');
            $('#ContentPlaceHolder1_txtFirstName').attr('class', 'txtRegister');
            $('#ContentPlaceHolder1_txtLastName').attr('class', 'txtRegister');
            $('#ContentPlaceHolder1_txtBirthday').attr('class', 'txtRegister');
        }

        function IsDate(controlid)
        {
            var dtRegex = new RegExp(/\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/);
            return dtRegex.test($(controlid).val());
        }

        function IsEquals(controlidone, controlidtwo)
        {
            return $(controlidone).val() == $(controlidtwo).val();
        }

        function IsNull(controlid)
        {
            return $(controlid).val().length == 0;
        }

        $(document).ready(function () {
            $('#ContentPlaceHolder1_lnkSubmitAccount').click(function (e) {

                $('#ContentPlaceHolder1_divError').hide();

                RemoveAllTextErrorControls();

                if (IsNull('#ContentPlaceHolder1_txtUsername')) {
                    ErrorMessage("*Please Insert Username", e);
                    SetTextErrorControl('#ContentPlaceHolder1_txtUsername');
                }
                else if (IsNull('#ContentPlaceHolder1_txtPassword')) {
                    ErrorMessage("*Please Insert Password", e);
                    SetTextErrorControl('#ContentPlaceHolder1_txtPassword');
                }
                else if (IsNull('#ContentPlaceHolder1_txtConfirmPassword')) {
                    ErrorMessage("*Please Confirm Password", e);
                    SetTextErrorControl('#ContentPlaceHolder1_txtConfirmPassword');
                }
                else if (IsNull('#ContentPlaceHolder1_txtFirstName')) {
                    ErrorMessage("*Please insert First Name", e);
                    SetTextErrorControl('#ContentPlaceHolder1_txtFirstName');
                }
                else if (IsNull('#ContentPlaceHolder1_txtLastName')) {
                    ErrorMessage("*Please insert Last Name", e);
                    SetTextErrorControl('#ContentPlaceHolder1_txtLastName');
                }
                else if (IsNull('#ContentPlaceHolder1_txtBirthday')) {
                    ErrorMessage("*Please insert Birthday", e);
                    SetTextErrorControl('#ContentPlaceHolder1_txtBirthday');
                }
                else if ($('#ContentPlaceHolder1_ddlGender').val() == "Select Gender") {
                    ErrorMessage("*Please Select Gender Option", e);
                }
                else if (!IsEquals('#ContentPlaceHolder1_txtPassword', '#ContentPlaceHolder1_txtConfirmPassword')) {
                    ErrorMessage("*Passwords do not match", e);
                    SetTextErrorControl('#ContentPlaceHolder1_txtPassword');
                    SetTextErrorControl('#ContentPlaceHolder1_txtConfirmPassword');
                }
                else if(!IsDate('#ContentPlaceHolder1_txtBirthday')){
                    ErrorMessage("*Birthday not a valid date", e);
                    SetTextErrorControl('#ContentPlaceHolder1_txtBirthday');
                }
            });
        });

        $(document).on('ready', function () {
            $('#txtBirthday').datepicker();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divPage" class="Page">
        <h1>Registration</h1>

    <div class="PageDivider-left">
        <table class="tblRegister">
            <tr>
                <td class="tblRegister-Cell"><input id="txtUsername" runat="server" placeholder="Username" class="txtRegister" /></td>
            </tr>
            <tr>
                <td class="tblRegister-Cell"><input id="txtPassword" runat="server" placeholder="Password" class="txtRegister"/></td>
            </tr>
            <tr>
                <td class="tblRegister-Cell"><input id="txtConfirmPassword" runat="server" placeholder="Confirm Password" class="txtRegister"/></td>
            </tr>
            <tr>
                <td class="tblRegister-Cell"><input id="txtFirstName" runat="server" placeholder="First Name" class="txtRegister"/></td>
            </tr>
            <tr>
                <td class="tblRegister-Cell"><input id="txtLastName" runat="server" placeholder="Last Name" class="txtRegister"/></td>
            </tr>
            <tr>
                <td class="tblRegister-Cell"><input id="txtBirthday" runat="server" placeholder="Birthday" ClientIDMode="Static" class="txtRegister"/></td>
            </tr>
            <tr>
                <td class="tblRegister-Cell"><asp:DropDownList ID="ddlGender" runat="server" CssClass="ddlRegister"></asp:DropDownList></td>
            </tr>
            <tr>
                <td class="tblRegister-Cell"><a id="lnkSubmitAccount" runat="server" class="button" onserverclick="lnkSubmitAccount_ServerClick">Submit</a>
                    <a href="wpAccountLogin.aspx" id="lnkLogin" runat="server" class="button" style="float:right">Login</a>
                </td>
            </tr>
        </table>
        <div id="divError" runat="server" class="divError"> this is test text</div>
    </div>
    
    <div id="divQuote" class="PageDivider-right" runat="server">
    </div>

    </div>
</asp:Content>
