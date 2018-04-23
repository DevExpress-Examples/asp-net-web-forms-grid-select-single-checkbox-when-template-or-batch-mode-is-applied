Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

''' <summary>
''' Summary description for SampleDataSource
''' </summary>
Public Class SampleDataSource
	Public Shared Function GetDataSource() As List(Of SampleDataRow)
		Dim list As New List(Of SampleDataRow)()
		list.Add(New SampleDataRow() With {.Id = 1, .Field1 = False, .Field2 = False, .Field3 = False, .Field4 = False})
		list.Add(New SampleDataRow() With {.Id = 2, .Field1 = False, .Field2 = False, .Field3 = False, .Field4 = False})
		list.Add(New SampleDataRow() With {.Id = 3, .Field1 = False, .Field2 = False, .Field3 = False, .Field4 = False})
		list.Add(New SampleDataRow() With {.Id = 4, .Field1 = False, .Field2 = False, .Field3 = False, .Field4 = False})
		Return list
	End Function
End Class