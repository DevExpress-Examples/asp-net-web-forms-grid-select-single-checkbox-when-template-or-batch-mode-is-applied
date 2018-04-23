using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

public partial class BatchEdit : System.Web.UI.Page
{
    public List<SampleDataRow> ListSource
    {
        get
        {
            if (Session["DataSource"] == null)
                Session["DataSource"] = SampleDataSource.GetDataSource();
            return Session["DataSource"] as List<SampleDataRow>;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Clear();
            ASPxGridView1.DataBind();
        }
    }

    protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
    {
        ASPxGridView1.DataSource = ListSource;
    }

    protected void ASPxGridView1_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
    {
        if (e.Editor is ASPxCheckBox)
        {
            ASPxCheckBox editor = (ASPxCheckBox)e.Editor;
            editor.ClientSideEvents.CheckedChanged = "checkedChanged";
        }
    }

    protected void ASPxGridView1_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        foreach (var args in e.UpdateValues)
            UpdateItem(args.Keys, args.NewValues);
        e.Handled = true;
    }

    protected SampleDataRow UpdateItem(OrderedDictionary keys, OrderedDictionary newValues)
    {
        int id = Convert.ToInt32(keys["Id"]);
        SampleDataRow rowToUpdate = ListSource.Find(i => i.Id == id);
        rowToUpdate.Id = Convert.ToInt32(newValues["Id"]);
        rowToUpdate.Field1 = Convert.ToBoolean(newValues["Field1"]);
        rowToUpdate.Field2 = Convert.ToBoolean(newValues["Field2"]);
        rowToUpdate.Field3 = Convert.ToBoolean(newValues["Field3"]);
        rowToUpdate.Field4 = Convert.ToBoolean(newValues["Field4"]);
        return rowToUpdate;
    }
}