# ASPxGridView - How to select a checkbox in a row if DataItemTemplate or BatchEdit is used


<p>This example illustrates how to select a single check box when the DataItemTemplate or Batch Editing is used in ASPxGridView.<br><br><strong>Batch Editing mode</strong></p>
<p>It is necessary to handle ASPxGridView's CellEditorInitialize event to assign ASPxCheckBox' client-side CheckedChanged event handler to the client grid. So, it is possible to set a check box’ state in the CheckedChanged event handler using batchEditApi. To determine which row cell to update, subscribe to ASPxGridView's client-side BatchEditStartEditing event and get a row index and focused column in this event handler.<br><br><strong>DataItemTemplate</strong></p>
<p>Place ASPxCheckBox to the DataItemTemplate of corresponding columns. Handle the ASPxCheckBox.Init event and subscribe to the client-side CheckedChanged event there. Pass the required parameters in the client-side CheckedChanged event handler to get a checked check box and send a callback to ASPxGridView. On this callback, check or uncheck check boxes and save their state to ASPxGridView's data source.</p>

<br/>


