using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NLog;

public partial class _Default : System.Web.UI.Page
{
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ogradsoyad"] != null)
        {
            lblad.Text = Session["ogradsoyad"].ToString();
            id = Convert.ToInt32(Session["idsi"]);
        }

        if (Session["kisiadsoyad"] != null && Session["idalma"] != null)
        {
            lblad.Text = Session["kisiadsoyad"].ToString();
            id = Convert.ToInt32(Session["idalma"]);
        }

       
        using (DBProjeTakipEntities1 ent = new DBProjeTakipEntities1())
        {
            TBLKULLANICILAR ku = new TBLKULLANICILAR();

            ku= (from k in ent.TBLKULLANICILAR
                        where k.OGRID == id
                        select k).FirstOrDefault();
            if (ku!=null)
            {
                txtad.Text = ku.OGRAD;
                txtsoyad.Text = ku.OGRSOYAD;
                txtnumara.Text = Convert.ToString(ku.OGRNO);
                txtbolum.Text = ku.BOLUM;
                txtdonem.Text = ku.DONEM;
                txteposta.Text = ku.EPOSTA;
                txtsifre.Text = ku.SIFRE;
            }
            else
            {
                Response.Redirect("Giris.aspx");
            }
        }
    }

    protected void BtnCikis_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.RemoveAll();
        Response.Redirect("Baslangic.aspx");

    }

    protected void BtnGoster_Click(object sender, EventArgs e)
    {
        txtsifre.TextMode = TextBoxMode.SingleLine;
    }

    protected void BtnGizle_Click(object sender, EventArgs e)
    {
        txtsifre.TextMode = TextBoxMode.Password;
        
    }
}