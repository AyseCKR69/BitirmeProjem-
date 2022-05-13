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

public partial class RaporKayit : System.Web.UI.Page
{
    string ogrid;
    string projeid;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        NLog.LogManager.GetLogger("Rapor Kayıt Sayfası Açıldı").Warn("Rapor Kayıt Sayfasına Geçildi");
        Logger fileLogger = LogManager.GetLogger("file");//dosyaya loglama yapması için
        Logger dbLogger = LogManager.GetLogger("db");//veritabanına loglama yapıyor

        if (Session["ogradsoyad"]!=null)
        {
            lblad.Text = Session["ogradsoyad"].ToString();
            ogrid = Session["idsi"].ToString();

        }

        if (Session["kisiadsoyad"] != null)
        {
            lblad.Text = Session["kisiadsoyad"].ToString();
        }

        if (Session["secilenid"] != null)
        {
            projeid = Session["secilenid"].ToString();
        }
        
        //!string.IsNullOrEmpty(Session["secilenogrid"]).ToString()//OLMADI
        if (Session["secilenogrid"] != null)
        {
            ogrid = Session["secilenogrid"].ToString();
        }
        gridDoldur(Convert.ToInt32(ogrid));
    }

    
    protected void btnKayit_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlhafta.SelectedItem.Text) && !string.IsNullOrEmpty(txtRaporAd.Text) && 
            ddlhafta.SelectedItem.Value!="-1"  && ddldosyatur.SelectedItem.Value!="-1")
        { 
            RaporKayiti();
            gridDoldur(Convert.ToInt32(ogrid));
            NLog.LogManager.GetLogger("Rapor Kayıt Edildi.").Info("Rapor Kayıt Edildi.");
        }
        else
        {
            NLog.LogManager.GetLogger("Alanlar Boş Geçilemez").Error("Alanlar Boş Geçilemez.");
            Araclar.MesajPenceresi("Alanlar Boş Geçilemez. Hafta ve Dosya Türü Seçtiğinizden Emin Olunuz.");
        } 
    }

    private void RaporKayiti()
    {
        Araclar arac = new Araclar();

        using(DBProjeTakipEntities1 ent = new DBProjeTakipEntities1())
        {
            TBLRAPOR ra = new TBLRAPOR();

            ra.OGRID = Convert.ToInt32(ogrid);
            ra.YUKLENENTARIH =  DateTime.Now.ToLocalTime();
            ra.RAPORAD = txtRaporAd.Text;
            ra.HAFTA = Convert.ToInt32(ddlhafta.SelectedValue);
            ra.PROJEID = Convert.ToInt32(projeid);

            string yol=string.Empty;
            if (ddldosyatur.SelectedValue=="resim")
            {
                ra.DOSYA =yol= arac.ResimYukle(FuDosyaYukle, Server.MapPath("Resimler"));
            }
            else if (ddldosyatur.SelectedValue=="rapor")
            {
                ra.DOSYA =yol= arac.DosyaYukle(FuDosyaYukle, Server.MapPath("Raporlar"));
            }
            else if (ddldosyatur.SelectedValue=="ekdosyalar")
            {
                Araclar.MesajPenceresi("Sadece resim (jpeg/png) ve rapor (word/pdf) dosya türleri kabul edilir.Dosya Seçimine Dikkat Ediniz. ");
                yol = string.Empty;

            }
            else
            {
                Araclar.MesajPenceresi("Sadece resim (jpeg/png) ve rapor (word/pdf) dosya türleri kabul edilir.Dosya Seçimine Dikkat Ediniz. ");
                yol = string.Empty;
            }

            if (yol!=string.Empty)
            {
                ent.TBLRAPOR.Add(ra);
                ent.SaveChanges();
                Araclar.MesajPenceresi("İşlem Başarılı");
            }
            else
            {
                NLog.LogManager.GetLogger("Tekrar Kayıt Yapınız. Dosya Seçimine Dikkat Ediniz.").Error("Tekrar Kayıt Yapınız. Dosya Seçimine Dikkat Ediniz.");
                Araclar.MesajPenceresi("Tekrar Kayıt Yapınız. Dosya Seçimine Dikkat Ediniz.");
            }
        }
    }

   

    private void gridDoldur(int id)
    {
        using (DBProjeTakipEntities1 ent = new DBProjeTakipEntities1())
        {
            var degerler = (from k in ent.TBLRAPOR orderby k.RAPORID descending where k.OGRID==id select k).ToList();

            if (degerler==null)
            {
                Araclar.MesajPenceresi("Öğrenci henüz rapor yüklememiş.");
            }
            gvraporlistele.DataSource = degerler;
            gvraporlistele.DataBind();
        }
    }
}