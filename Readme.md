<!-- default file list -->
*Files to look at*:

* [SampleDataRow.cs](./CS/App_Code/SampleDataRow.cs) (VB: [SampleDataRow.vb](./VB/App_Code/SampleDataRow.vb))
* [SampleDataSource.cs](./CS/App_Code/SampleDataSource.cs) (VB: [SampleDataSource.vb](./VB/App_Code/SampleDataSource.vb))
* [BatchEdit.aspx](./CS/BatchEdit.aspx) (VB: [BatchEdit.aspx](./VB/BatchEdit.aspx))
* [BatchEdit.aspx.cs](./CS/BatchEdit.aspx.cs) (VB: [BatchEdit.aspx.vb](./VB/BatchEdit.aspx.vb))
* [DataItemTemplate.aspx](./CS/DataItemTemplate.aspx) (VB: [DataItemTemplate.aspx](./VB/DataItemTemplate.aspx))
* [DataItemTemplate.aspx.cs](./CS/DataItemTemplate.aspx.cs) (VB: [DataItemTemplate.aspx.vb](./VB/DataItemTemplate.aspx.vb))
* **[Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))**
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# ASPxGridView - How to select a checkbox in a row if DataItemTemplate or BatchEdit is used


<p>This example illustrates how to select a single check box when the DataItemTemplate or Batch Editing is used in ASPxGridView.<br><br><strong>Batch Editing mode</strong></p>
<p>It is necessary to handle ASPxGridView's CellEditorInitialize event to assign ASPxCheckBox' client-side CheckedChanged event handler to the client grid. So, it is possible to set a check box’ state in the CheckedChanged event handler using batchEditApi. To determine which row cell to update, subscribe to ASPxGridView's client-side BatchEditStartEditing event and get a row index and focused column in this event handler.<br><br><strong>DataItemTemplate</strong></p>
<p>Place ASPxCheckBox to the DataItemTemplate of corresponding columns. Handle the ASPxCheckBox.Init event and subscribe to the client-side CheckedChanged event there. Pass the required parameters in the client-side CheckedChanged event handler to get a checked check box and send a callback to ASPxGridView. On this callback, check or uncheck check boxes and save their state to ASPxGridView's data source.</p>

<br/>


