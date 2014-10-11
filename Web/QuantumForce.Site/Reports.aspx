<%@ Page Title="" Language="C#" MasterPageFile="~/QuantumForce.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="QuantumForce.Site.Reports" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table border="0" cellspacing ="2" cellpadding ="1" style="height: 32px; width: 100%">
       <tr><td class="auto-style5"><BR></td></tr>
       <tr>
            <td align ="right" class="auto-style5">Select Report:</td>
            <td class="auto-style2"><asp:DropDownList ID="ddlReports" runat="server" Height="20px" Width="180px" ></asp:DropDownList></td>
            <td  align ="right" class="auto-style4">Select Graph:</td>
           <td class="auto-style1"><asp:DropDownList ID="ddlGraphs" runat="server" Height="20px" Width="180px"></asp:DropDownList></td>
       </tr>
   </table>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

</asp:Content>




