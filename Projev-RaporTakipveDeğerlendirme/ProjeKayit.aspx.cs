using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NLog.Web;//ben ekledim
using Microsoft.Extensions.Logging;//ben ekledim
using System.IO;//ben ekledim
using NLog;//ben ekledim

public partial class ProjeKayit : System.Web.UI.Page
{
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        NLog.LogManager.GetLogger("Proje Kayıt Sayfası açıldı").Warn("Proje Kayıt sayfasına geçildi");
        Logger fileLogger = LogManager.GetLogger("file");//dosyaya loglama yapması için
        Logger dbLogger = LogManager.GetLogger("db");//veritabanına loglama yapıyor

        if (Session["ogradsoyad"] !=null)
        {
            lblad.Text = Session["ogradsoyad"].ToString();
            id = Session["idsi"].ToString();

        }

        if (Session["kisiadsoyad"] != null && Session["idalma"]!=null)
        {
            lblad.Text = Session["kisiadsoyad"].ToString();

            id = Session["idalma"].ToString();
        }
        gridDoldur(Convert.ToInt32(id));
    }


    private void Ekle()
    {
        using(DBProjeTakipEntities1 ent= new DBProjeTakipEntities1())
        {
            TBLPROJE pro = new TBLPROJE();

            pro.OGRID = Convert.ToInt32(id);
            pro.PROJEAD = txtprojead.Text;
            pro.BAŞLAMA = Convert.ToDateTime(txtprojebaslama.Text);
            pro.BİTİŞ = Convert.ToDateTime(txtprojebitis.Text);
            pro.AÇIKLAMA = txtaciklama.Text; 
            ent.TBLPROJE.Add(pro);
            ent.SaveChanges();
            
        }
    }
    private void gridDoldur( int id)
    {
        using(DBProjeTakipEntities1 ent= new DBProjeTakipEntities1())
        {
            var degerler = (from k in ent.TBLPROJE orderby k.PROJEID descending where k.OGRID==id select k).ToList();

            gvlistele.DataSource = degerler;
            gvlistele.DataBind();
        }
    }

    private void Sil(int deger)
    {
        using(DBProjeTakipEntities1 ent = new DBProjeTakipEntities1())
        {
            TBLPROJE pro = new TBLPROJE();
            pro=(from k in ent.TBLPROJE where k.PROJEID == deger select k).FirstOrDefault();
            ent.TBLPROJE.Remove(pro);
            ent.SaveChanges();
            NLog.LogManager.GetLogger("Proje Silindi.").Info("Proje Silindi.");
        }
        gridDoldur(Convert.ToInt32(id));
    }

    protected void btnkayit_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtprojead.Text) && !string.IsNullOrEmpty(txtprojebaslama.Text) 
            && !string.IsNullOrEmpty(txtaciklama.Text) && !string.IsNullOrEmpty(txtprojebitis.Text))
        {
            Ekle();
            gridDoldur(Convert.ToInt32(id));
            NLog.LogManager.GetLogger("Proje Kayıt Edildi.").Info("Proje Kayıt Edildi.");
            //master_MasterPage ma = new master_MasterPage();
            //ma.Getir();
        }
        else
        {
            NLog.LogManager.GetLogger("Alanlar Boş Olamaz.").Error("Alanlar Boş Olamaz.");
            Araclar.MesajPenceresi("Alanlar Boş Geçilemez.");
        }
      
    }

    protected void gvlistele_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int SatirNo = Convert.ToInt32(e.CommandArgument);
        int SatirId = Convert.ToInt32(gvlistele.Rows[SatirNo].Cells[2].Text);
        int OgrId = Convert.ToInt32(gvlistele.Rows[SatirNo].Cells[3].Text);

        if (e.CommandName=="sil")
        {
            Sil(SatirId);
        }
        else if (e.CommandName=="raporekle")
        {
            Session["secilenid"] = SatirId;
            Session["secilenogrid"] = OgrId;
            Response.Redirect("RaporKayit.aspx");

        }
    }
}