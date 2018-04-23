Imports DevExpress.Web
Imports System
Imports System.Collections.Generic

Partial Public Class DataItemTemplate
	Inherits System.Web.UI.Page

	Public ReadOnly Property ListSource() As List(Of SampleDataRow)
		Get
			If Session("DataSource") Is Nothing Then
				Session("DataSource") = SampleDataSource.GetDataSource()
			End If
			Return TryCast(Session("DataSource"), List(Of SampleDataRow))
		End Get
	End Property

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If Not IsPostBack Then
			Session.Clear()
			ASPxGridView1.DataBind()
		End If
	End Sub

	Protected Sub ASPxGridView1_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
		ASPxGridView1.DataSource = ListSource
	End Sub

	Protected Sub cb_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim checkBox As ASPxCheckBox = DirectCast(sender, ASPxCheckBox)
		Dim container As GridViewDataItemTemplateContainer = CType(checkBox.NamingContainer, GridViewDataItemTemplateContainer)

		Dim key As String = String.Format("{0}|{1}", container.Column.FieldName, container.KeyValue)
		checkBox.ClientSideEvents.CheckedChanged = String.Format("function(s, e) {{ grid.PerformCallback('{0}|' + s.GetChecked()); }}", key)
	End Sub

	Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
		Dim parameters() As String = e.Parameters.Split(New Char() { "|"c }, StringSplitOptions.RemoveEmptyEntries)
		Dim fieldName As String = parameters(0)
		Dim keyValue As String = parameters(1)
		Dim isChecked As Boolean = Convert.ToBoolean(parameters(2))
		Dim rowWithResetFields As New SampleDataRow()
		rowWithResetFields.Id = Convert.ToInt32(keyValue)
		For i As Integer = 0 To ASPxGridView1.Columns.Count - 1
			If (Not isChecked) OrElse String.Equals(ASPxGridView1.DataColumns(i).FieldName, fieldName) Then
				SetFields(rowWithResetFields, ASPxGridView1.DataColumns(i).FieldName, isChecked)
			Else
                SetFields(rowWithResetFields, ASPxGridView1.DataColumns(i).FieldName, Not isChecked)
            End If
		Next i
		Dim findRow As SampleDataRow = TryCast(ListSource.Find(Function(r) r.Id = rowWithResetFields.Id), SampleDataRow)
		findRow.Field1 = rowWithResetFields.Field1
		findRow.Field2 = rowWithResetFields.Field2
		findRow.Field3 = rowWithResetFields.Field3
		findRow.Field4 = rowWithResetFields.Field4
		ASPxGridView1.DataBind()
	End Sub

	Private Sub SetFields(ByVal row As SampleDataRow, ByVal field As String, ByVal flag As Boolean)
		Select Case field
			Case "Field1"
				row.Field1 = flag
			Case "Field2"
				row.Field2 = flag
			Case "Field3"
				row.Field3 = flag
			Case "Field4"
				row.Field4 = flag
		End Select
	End Sub
End Class