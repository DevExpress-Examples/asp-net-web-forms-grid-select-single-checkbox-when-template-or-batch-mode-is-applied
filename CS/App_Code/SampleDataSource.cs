using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SampleDataSource
/// </summary>
public class SampleDataSource
{
    public static List<SampleDataRow> GetDataSource()
    {
        List<SampleDataRow> list = new List<SampleDataRow>();
        list.Add(new SampleDataRow() { Id = 1, Field1 = false, Field2 = false, Field3 = false, Field4 = false });
        list.Add(new SampleDataRow() { Id = 2, Field1 = false, Field2 = false, Field3 = false, Field4 = false });
        list.Add(new SampleDataRow() { Id = 3, Field1 = false, Field2 = false, Field3 = false, Field4 = false });
        list.Add(new SampleDataRow() { Id = 4, Field1 = false, Field2 = false, Field3 = false, Field4 = false });
        return list;
    }
}