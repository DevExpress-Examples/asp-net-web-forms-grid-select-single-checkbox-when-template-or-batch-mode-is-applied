<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dx:ASPxMenu ID="ASPxMenu1" runat="server">
			<Items>
				<dx:MenuItem Name="DataItemTemplate" NavigateUrl="~/DataItemTemplate.aspx" Text="Using DataItemTemplate">
				</dx:MenuItem>
				<dx:MenuItem Name="BatchEdit" NavigateUrl="~/BatchEdit.aspx" Text="Using BatchEdit mode">
				</dx:MenuItem>
			</Items>
		</dx:ASPxMenu>
	</div>
	</form>
</body>
</html>