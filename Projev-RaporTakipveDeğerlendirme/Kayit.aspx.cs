using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using NLog.Web;//ben ekledim
using Microsoft.Extensions.Logging;//ben ekledim
using System.IO;//ben ekledim
using NLog;//ben ekledim

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NLog.LogManager.GetLogger("Kayıt Sayfası açıldı").Warn("Kayıt sayfasına geçildi");
        Logger fileLogger = LogManager.GetLogger("file");//dosyaya loglama yapması için
        Logger dbLogger = LogManager.GetLogger("db");//veritabanına loglama yapıyor

    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    string isim=string.Empty;
    private void KisiKayit()
    {
            using (DBProjeTakipEntities1 en = new DBProjeTakipEntities1())
            {
                TBLKULLANICILAR kullanıcı = new TBLKULLANICILAR();
                
                    kullanıcı.OGRAD = txtad.Text.ToLower();
                    kullanıcı.OGRSOYAD = txtsoyad.Text.ToLower();
                    kullanıcı.OGRNO = Convert.ToInt32(txtnumara.Text);
                    kullanıcı.EPOSTA = txteposta.Text.ToLower();
                    kullanıcı.SIFRE = txtsifre.Text.ToLower();
                    kullanıcı.BOLUM = rbbolum.SelectedValue;
                    kullanıcı.DONEM = ddldonem.SelectedValue;
                    en.TBLKULLANICILAR.Add(kullanıcı);
                    en.SaveChanges();
                    Session["kisiadsoyad"] = isim = txtad.Text + " " + txtsoyad.Text;
            } 
    }

    private void IdAlma(int numara)
    {
        using (DBProjeTakipEntities1 en = new DBProjeTakipEntities1())
        {
            int id;
            Session["idalma"] = id = en.TBLKULLANICILAR.Where(x => x.OGRNO == numara).Select(x => x.OGRID).FirstOrDefault();
        }
    }

    protected void BtnKayit_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtad.Text) && !string.IsNullOrEmpty(txtsoyad.Text) && !string.IsNullOrEmpty(txtnumara.Text)
             && !string.IsNullOrEmpty(txteposta.Text) && !string.IsNullOrEmpty(txtsifre.Text) 
             && !string.IsNullOrEmpty(rbbolum.SelectedValue)  && !string.IsNullOrEmpty(ddldonem.SelectedValue) 
             && txtnumara.Text.Length == 9)
        {
            //String.IsNullOrEmpty(txtnumara.Text)
            if (Kontrol(Convert.ToInt32(txtnumara.Text)) == 0)
            {
                KisiKayit();
                IdAlma( Convert.ToInt32(txtnumara.Text));
                NLog.LogManager.GetLogger("Kişi Kayıt Edildi.").Info(isim);
                Araclar.MesajPenceresi("Kaydınız Gerçekleştirilmiştir.");
                Response.Redirect("ProjeKayit.aspx");
               
            }
            else
            {
                txtad.Text = string.Empty;
                txtsoyad.Text = string.Empty;
                txtnumara.Text = string.Empty;
                txteposta.Text = string.Empty;
                txtsifre.Text = string.Empty;
                NLog.LogManager.GetLogger("Kişi Zaten Var.").Error("Kişi Zaten Var");
                Araclar.MesajPenceresi("kişi zaten var.");
            }
        }
        else
        {
            NLog.LogManager.GetLogger("Alanlar boş!").Error("Alanlar Boş OLamaz!");
            Araclar.MesajPenceresi("Alanlar Boş Geçilemez! , Şifrenizin 9 hane olduğundan emin olun!");
        }
    }
    
    private int Kontrol(int numara)
    {
        int deger = 1;
        using (DBProjeTakipEntities1 ent = new DBProjeTakipEntities1())
        {
             deger = ent.TBLKULLANICILAR.Where(x => x.OGRNO == numara).Count();
            if (deger==0)
            {
                deger=0;
            }
            else if (deger == -1)
            {
                deger = 1;
            }
            else 
            {
                deger=1;
            }
            //eğer deger 0 sa kayıt yok değilse kayıt var ancak -1 null için kontrol olmalı
        }
        return deger;
    }
}