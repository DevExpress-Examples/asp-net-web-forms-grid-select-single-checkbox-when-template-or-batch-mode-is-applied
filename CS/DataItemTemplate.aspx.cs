using DevExpress.Web;
using System;
using System.Collections.Generic;

public partial class DataItemTemplate : System.Web.UI.Page
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

    protected void cb_Init(object sender, EventArgs e)
    {
        ASPxCheckBox checkBox = (ASPxCheckBox)sender;
        GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)checkBox.NamingContainer;

        string key = string.Format("{0}|{1}", container.Column.FieldName, container.KeyValue);
        checkBox.ClientSideEvents.CheckedChanged = string.Format("function(s, e) {{ grid.PerformCallback('{0}|' + s.GetChecked()); }}", key);
    }

    protected void ASPxGridView1_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] parameters = e.Parameters.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        string fieldName = parameters[0];
        string keyValue = parameters[1];
        bool isChecked = Convert.ToBoolean(parameters[2]);
        SampleDataRow rowWithResetFields = new SampleDataRow();
        rowWithResetFields.Id = Convert.ToInt32(keyValue);
        for (int i = 0; i < ASPxGridView1.Columns.Count; i++)
        {
            if (!isChecked || string.Equals(ASPxGridView1.DataColumns[i].FieldName, fieldName))
                SetFields(rowWithResetFields, ASPxGridView1.DataColumns[i].FieldName, isChecked);
            else
                SetFields(rowWithResetFields, ASPxGridView1.DataColumns[i].FieldName, !isChecked);
        }
        SampleDataRow findRow = ListSource.Find(r => r.Id == rowWithResetFields.Id) as SampleDataRow;
        findRow.Field1 = rowWithResetFields.Field1;
        findRow.Field2 = rowWithResetFields.Field2;
        findRow.Field3 = rowWithResetFields.Field3;
        findRow.Field4 = rowWithResetFields.Field4;
        ASPxGridView1.DataBind();
    }

    private void SetFields(SampleDataRow row, string field, bool flag)
    {
        switch (field)
        {
            case "Field1":
                row.Field1 = flag;
                break;
            case "Field2":
                row.Field2 = flag;
                break;
            case "Field3":
                row.Field3 = flag;
                break;
            case "Field4":
                row.Field4 = flag;
                break;
        }
    }
}