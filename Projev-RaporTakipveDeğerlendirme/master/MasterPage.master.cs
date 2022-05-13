using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class master_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
        Getir();

    }

    
    public  void Getir()
    {
        using(DBProjeTakipEntities1 ent = new DBProjeTakipEntities1())
        {  
           
            var asıldeger= (from k in ent.TBLPROJE join o in ent.TBLKULLANICILAR on k.OGRID equals o.OGRID
                            orderby k.PROJEID descending select new {k.PROJEID,o.OGRNO,k.PROJEAD}).ToList();
            GvSon.DataSource= asıldeger;
            GvSon.DataBind();
        }
    }
}
