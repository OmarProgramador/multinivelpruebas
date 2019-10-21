<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VysorContratos.aspx.cs"  Inherits="MULTI_NIVEL.Views.VysorContratos" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Contrato - InResorts</title>
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <rsweb:ReportViewer ID="reportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" Height="761px" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="1135px" ShowExportControls="False" style="text-align: justify">
                <LocalReport ReportPath="Views\FilesContratos\Contrato.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
      
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    </form>
</body>
</html>
<!--SAMIRmERGE-->
