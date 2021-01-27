using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using ChinookSystem.BLL;
using ChinookSystem.ViewModels;
#endregion
namespace WebApp.SamplePages
{
    public partial class SearchByDLL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                LoadArtistList();
            }
        }

        private void LoadArtistList()
        {
            ArtistController sysmgr = new ArtistController();
            List<SelectionList> info = sysmgr.Artists_DDList();

            //sort ascending
            info.Sort((x,y) => x.DisplayField.CompareTo(y.DisplayField));

            //ddl setup
            ArtistList.DataSource = info;
            //ArtistList.DataTextField = "DisplayField";
            ArtistList.DataTextField = nameof(SelectionList.DisplayField);
            ArtistList.DataValueField = nameof(SelectionList.ValueField);
            ArtistList.DataBind();

            //prompt line
            ArtistList.Items.Insert(0, new ListItem("Select...", "0"));
        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}