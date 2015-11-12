<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/mpSecure.master" AutoEventWireup="true" CodeBehind="wpLogWorkout.aspx.cs" Inherits="WorkoutLogger.Page.wpLogWorkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

    <script>
        $(document).on('ready', function () {
            $('#tbxDate').datepicker();
        });


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div id="divWorkout">
        <input id="tbxDate" runat="server" type="text" placeholder="Date" onclick="Date_Change"/>
        <asp:DropDownList ID="ddlWorkoutName" runat="server"></asp:DropDownList>
    </div>
        <div></div>

        <div></div>
</asp:Content>
