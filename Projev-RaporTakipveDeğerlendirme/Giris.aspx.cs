using System;
using System.Linq;
using NLog.Web;
using Microsoft.Extensions.Logging;
using System.IO;
using NLog;

public partial class Giris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //var logger = NLog.LogManager.Setup();

        // NLog.Common.InternalLogger.LogFile = "E:\\Logs\\log1.txt";
        // NLog.Common.InternalLogger.LogWriter = new StringWriter();
        //NLog.Common.InternalLogger.LogWriter.NewLine = "\n";

        // Internal Logger Test -> Fatal - Error - Warn - Info - Debug - Trace 
        //NLog.LogManager.GetLogger("dblogger").Warn("Giriş sayfasına geçildi");

        //Fatal	Üst Seviye : Sistem çökmeleri
        //Error : Uygulama hataları(Exceptions)
        //Warn :Uyarılar, yinede uygulama çalışmaya devam edebilir.
        //info:Bilgilendirme herhangi bir amaçlı olabilir. Kullanıcı bilgileri güncellendi vs.
        //Debug	Çalıştırılan sorgular, oturum süresinin bitmesi vs.
        //trace:Bir eylem başladı diğeri bitti gibi. Örn : Fonksiyon başlangıcı ve bitişi durumları( En Alt Seviye )

        // logger test ->
        Logger fileLogger = LogManager.GetLogger("file");//dosyaya loglama yapması için
        Logger dbLogger = LogManager.GetLogger("db");//veritabanına loglama yapıyor
        //fileLogger.Warn("File calısıyor");
        dbLogger.Fatal("db calısıyor");

    }
    
    //private static readonly Logger logger= LogManager.GetCurrentClassLogger();


    //GİRİŞ KISMI
    protected void BtnGiris_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtnumara.Text) && !string.IsNullOrEmpty(txtsifre.Text))
        {
            if (Kontrol(Convert.ToInt32(txtnumara.Text), txtsifre.Text) == 1)
            {
                if (isim == "ayşe çakır")
                {
                    
                    NLog.LogManager.GetLogger("Oturum açıldı").Info("Ayşe Çakır");
                    Response.Redirect("AdminGoruntule.aspx");
                }
                else
                {
                    NLog.LogManager.GetLogger("Oturum Açıldı").Info(isim);
                    Response.Redirect("ProjeKayit.aspx");
                }
            }
            else
            {
                NLog.LogManager.GetLogger("Login olmadı").Error("Giriş bilgileri yanlış");
                Araclar.MesajPenceresi("Lütfen Bilgilerinizi Kontrol Ediniz.");
            }
        }
        else
        {
            NLog.LogManager.GetLogger("Alanlar Boş OLamaz!").Error("Alanlar Boş Olamaz.");
            Araclar.MesajPenceresi("Alanlar boş geçilemez.");
        }
    }

    string isim;
    private int Kontrol(int numara, string sifre)
    {
        int deger=0;
        int id;
        using (DBProjeTakipEntities1 ent = new DBProjeTakipEntities1())
        {
            deger = ent.TBLKULLANICILAR.Where(x => x.OGRNO == numara && x.SIFRE == sifre).Count();
            // isim = (from k in ent.TBLKULLANICILAR where k.OGRNO == numara && k.SIFRE == sifre select k.OGRAD +" "+ k.OGRSOYAD).ToString();
            Session["ogradsoyad"] = isim =ent.TBLKULLANICILAR.Where(x=>x.OGRNO==numara && x.SIFRE==sifre).Select(x=>x.OGRAD +" "+ x.OGRSOYAD).FirstOrDefault();
            Session["idsi"] = id = ent.TBLKULLANICILAR.Where(x => x.OGRNO == numara && x.SIFRE == sifre).Select(x => x.OGRID).FirstOrDefault();
            if (deger == 0)
            {
                deger = 0;
            }
            else if (deger == -1)
            {
                deger = 0;
            }
            else
            {
                deger = 1;
                
            }
            //eğer deger 0 sa kayıt yok değilse kayıt var ancak -1 null için kontrol olmalı
        }
        return deger;
    }
}