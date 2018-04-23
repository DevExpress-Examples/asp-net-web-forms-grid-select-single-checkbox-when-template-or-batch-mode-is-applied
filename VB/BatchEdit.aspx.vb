Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Collections.Specialized

Partial Public Class BatchEdit
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

	Protected Sub ASPxGridView1_CellEditorInitialize(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewEditorEventArgs)
		If TypeOf e.Editor Is ASPxCheckBox Then
			Dim editor As ASPxCheckBox = CType(e.Editor, ASPxCheckBox)
			editor.ClientSideEvents.CheckedChanged = "checkedChanged"
		End If
	End Sub

	Protected Sub ASPxGridView1_BatchUpdate(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs)
		For Each args In e.UpdateValues
			UpdateItem(args.Keys, args.NewValues)
		Next args
		e.Handled = True
	End Sub

	Protected Function UpdateItem(ByVal keys As OrderedDictionary, ByVal newValues As OrderedDictionary) As SampleDataRow
'INSTANT VB NOTE: The variable id was renamed since Visual Basic does not handle local variables named the same as class members well:
		Dim id_Renamed As Integer = Convert.ToInt32(keys("Id"))
		Dim rowToUpdate As SampleDataRow = ListSource.Find(Function(i) i.Id = id_Renamed)
		rowToUpdate.Id = Convert.ToInt32(newValues("Id"))
		rowToUpdate.Field1 = Convert.ToBoolean(newValues("Field1"))
		rowToUpdate.Field2 = Convert.ToBoolean(newValues("Field2"))
		rowToUpdate.Field3 = Convert.ToBoolean(newValues("Field3"))
		rowToUpdate.Field4 = Convert.ToBoolean(newValues("Field4"))
		Return rowToUpdate
	End Function
End Class