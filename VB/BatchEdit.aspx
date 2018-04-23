<%@ Page Language="vb" AutoEventWireup="true" CodeFile="BatchEdit.aspx.vb" Inherits="BatchEdit" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<script type="text/javascript">
		var rowIndex;
		var focusedColumn;

		function checkedChanged(s, e) {
			for (var i = 0; i < grid.GetColumnsCount() ; i++) {
				var column = grid.GetColumn(i);
				var editor = grid.GetEditor(i);

				if (editor == null || column == focusedColumn || column.fieldName == "Id")
					continue;
				grid.batchEditApi.SetCellValue(rowIndex, column.fieldName, false);
			}
		}

		function onBatchEditStartEditing(s, e) {
			rowIndex = e.visibleIndex;
			focusedColumn = e.focusedColumn;
		}
	</script>
	<form id="form1" runat="server">
		<div>
			<dx:ASPxGridView ID="ASPxGridView1" runat="server"
				ClientInstanceName="grid"
				KeyFieldName="Id"
				OnDataBinding="ASPxGridView1_DataBinding"
				OnCellEditorInitialize="ASPxGridView1_CellEditorInitialize"
				OnBatchUpdate="ASPxGridView1_BatchUpdate">
				<ClientSideEvents BatchEditStartEditing="onBatchEditStartEditing" />
				<SettingsEditing Mode="Batch">
					<BatchEditSettings ShowConfirmOnLosingChanges="false" />
				</SettingsEditing>
			</dx:ASPxGridView>
		</div>
	</form>
</body>
</html>