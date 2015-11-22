<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/mpSecure.master" AutoEventWireup="true" CodeBehind="wpLogWorkout.aspx.cs" Inherits="WorkoutLogger.Page.wpLogWorkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="../StyleSheet/ssMain.css" rel="stylesheet" />
    <link href="../StyleSheet/ssLogWorkout.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

    <script>
    </script>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

    <table>
        <tr>
            <td style="width:25%">
                <input id="tbxWorkoutDate" runat="server" placeholder="Date" class="txtWorkoutDate" />
            </td>
            <td style="width:20%">
                <a id="btnSearch" runat="server" onserverclick="Date_Change" class="button">Load Workouts</a>
            </td>
            <td style="width:25%">
                <asp:DropDownList ID="ddlWorkoutName" runat="server" CssClass="ddlWorkoutName"></asp:DropDownList>
            </td>
            <td style="width:25%">
                <input id="txtNewWorkout" runat="server" class="txtNewWorkout" />
            </td>
        </tr>
    </table>
        
        
        
</asp:Content>
