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
            <td>Workout:</td>
        </tr>
        <tr>
            <td class="tblWorkout-Cell"><input id="tbxWorkoutDate" runat="server" placeholder="Date" class="txtWorkoutDate"/></td>
            <td class="tblWorkout-Cell"><a id="btnSearch" runat="server" onserverclick="Date_Change" class="button" style="text-align:center">Load Workouts</a></td> 
            <td class="tblWorkout-Cell"><asp:DropDownList ID="ddlWorkoutName" runat="server" CssClass="ddlWorkoutName" OnSelectedIndexChanged="WorkoutName_Change"  AutoPostBack="true"></asp:DropDownList></td> 
            <td class="tblWorkout-Cell"><input id="txtNewWorkout" runat="server" class="txtNewWorkout" Visible="false" placeholder="Workout Name" /></td>  
        </tr>
        <tr>
            
        </tr>
    </table>



    <table>
        <tr class="tblWorkout-Row">
           
            
            <td></td>
        </tr>
        <tr class="tblWorkout-Row">
           
            <td><input id="txtEventName" runat="server" placeholder="EventName" class="txtEventName" /></td> 
            <td> <asp:DropDownList ID="ddlWorkoutType" runat="server" CssClass="ddlWorkoutType"></asp:DropDownList></td> 
        </tr>
    </table>



        
        
        
</asp:Content>
