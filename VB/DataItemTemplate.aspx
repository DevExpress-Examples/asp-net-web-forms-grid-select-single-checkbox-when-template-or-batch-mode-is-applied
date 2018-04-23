<%@ Page Language="vb" AutoEventWireup="true" CodeFile="DataItemTemplate.aspx.vb" Inherits="DataItemTemplate" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dx:ASPxGridView ID="ASPxGridView1" runat="server"
			ClientInstanceName="grid" KeyFieldName = "Id"
			OnDataBinding="ASPxGridView1_DataBinding"
			OnCustomCallback="ASPxGridView1_CustomCallback">
			<Columns>
				<dx:GridViewDataCheckColumn FieldName="Field1" VisibleIndex="1">
					<DataItemTemplate>
						<dx:ASPxCheckBox ID="cb" runat="server" Checked='<%#Eval("Field1")%>' OnInit="cb_Init" />
					</DataItemTemplate>
				</dx:GridViewDataCheckColumn>
				<dx:GridViewDataCheckColumn FieldName="Field2" VisibleIndex="2">
					<DataItemTemplate>
						<dx:ASPxCheckBox ID="cb" runat="server" Checked='<%#Eval("Field2")%>' OnInit="cb_Init" />
					</DataItemTemplate>
				</dx:GridViewDataCheckColumn>
				<dx:GridViewDataCheckColumn FieldName="Field3" VisibleIndex="3">
					<DataItemTemplate>
						<dx:ASPxCheckBox ID="cb" runat="server" Checked='<%#Eval("Field3")%>' OnInit="cb_Init" />
					</DataItemTemplate>
				</dx:GridViewDataCheckColumn>
				<dx:GridViewDataCheckColumn FieldName="Field4" VisibleIndex="4">
					<DataItemTemplate>
						<dx:ASPxCheckBox ID="cb" runat="server" Checked='<%#Eval("Field4")%>' OnInit="cb_Init" />
					</DataItemTemplate>
				</dx:GridViewDataCheckColumn>
			</Columns>
		</dx:ASPxGridView>
	</div>
	</form>
</body>
</html>