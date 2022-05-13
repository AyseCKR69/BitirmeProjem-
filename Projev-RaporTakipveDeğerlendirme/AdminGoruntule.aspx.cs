using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azure;
using NLog;

public partial class AdminGoruntule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ogradsoyad"] != null)
        {
            lblad.Text = Session["ogradsoyad"].ToString();
        }
    }

    
    private void DonemSecGetir()
    {
        string secim = ddldonemsecim.SelectedValue;
        using (DBProjeTakipEntities1 ent = new DBProjeTakipEntities1())
        {
            var kullanicilar = (from k in ent.TBLKULLANICILAR
                                where k.DONEM == secim
                                select new { k.OGRID, k.OGRAD, k.OGRSOYAD, k.OGRNO, k.BOLUM, k.DONEM, k.EPOSTA }).ToList();

            GvOgrListesi.DataSource = kullanicilar;
            GvOgrListesi.DataBind();
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        DonemSecGetir();
    }

    private void OgrProjeGetir(int id)
    {
        using (DBProjeTakipEntities1 ent = new DBProjeTakipEntities1())
        {
            var kullanicilar = (from k in ent.TBLPROJE
                                where k.OGRID == id
                                 select new { k.PROJEID,k.OGRID,k.PROJEAD,k.BAŞLAMA,k.BİTİŞ,k.AÇIKLAMA}).ToList();

            GvBilgiler.DataSource = kullanicilar;
            GvBilgiler.DataBind();
            
        }
    }

    private void OgrRaporGetir(int id)
    {
        using (DBProjeTakipEntities1 ent = new DBProjeTakipEntities1())
        {
            var kullanicilar = (from k in ent.TBLRAPOR
                                where k.OGRID == id
                                select new { k.RAPORID, k.OGRID, k.RAPORAD, k.YUKLENENTARIH, k.HAFTA,k.DOSYA}).ToList();

            GvRaporBilgiler.DataSource = kullanicilar;
            GvRaporBilgiler.DataBind();

        }
    }

    int ogrId;
    protected void GvOgrListesi_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int SatirNo = Convert.ToInt32(e.CommandArgument);
         ogrId = Convert.ToInt32(GvOgrListesi.Rows[SatirNo].Cells[1].Text);

        if (e.CommandName=="sec")
        {
            OgrProjeGetir(ogrId);
        }
        
    }


    protected void GvBilgiler_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int SatirNo = Convert.ToInt32(e.CommandArgument);
        ogrId = Convert.ToInt32(GvBilgiler.Rows[SatirNo].Cells[2].Text);

        if (e.CommandName == "sec")
        {
            OgrRaporGetir(ogrId);
        }
    }

    protected void GvRaporBilgiler_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int SatirNo = Convert.ToInt32(e.CommandArgument);
        string RaporString = GvRaporBilgiler.Rows[SatirNo].Cells[6].Text;

        if (e.CommandName=="indir")
        {
            //dosya yolunu giriyoruz
            string filePath = RaporString;
            //hangi tip old buradan
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();

        }
    }
}