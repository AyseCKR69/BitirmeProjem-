using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;//page nesnesi için
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Araclar
/// </summary>
public class Araclar
{
    public Araclar()
    {
        //
        // TODO: Add constructor logic here
        //
        //var logger = NLogBuilder.
    }

    public static void MesajPenceresi(string message)
    {
        string cleanMessage = message.Replace("'", "\'");
        Page page = HttpContext.Current.CurrentHandler as Page;
        string script = string.Format("alert('{0}');", cleanMessage);
        if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
        {
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true /* addScriptTags */);
        }
    }

    public string DosyaYukle(FileUpload fuResimYukle, string dosyaYol)
    {
        string yol = string.Empty;
        if (fuResimYukle.HasFile)
            try
            {
                if (fuResimYukle.PostedFile.ContentType == "application/pdf" || fuResimYukle.PostedFile.ContentType == "application/msword" || fuResimYukle.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
                {
                    //if (fuResimYukle.PostedFile.ContentLength < 204800)
                    //{
                        yol = dosyaYol + "\\" + DateTime.Now.ToShortDateString() + "_" + fuResimYukle.FileName;
                        fuResimYukle.SaveAs(yol);
                }
                else
                {
                    Araclar.MesajPenceresi("Word Dosyası Seçin.");
                    //lblMesaj.Text = "Resim dosyası seçin.";
                }

            }
            catch (Exception ex)
            {
                Araclar.MesajPenceresi("Hata Oluştu:" + ex.Message.ToString());
               // lblMesaj.Text = "Hata Oluştu: " + ex.Message.ToString();
            }
        else
        {
            Araclar.MesajPenceresi("Dosya Seçin ve KAYIT Butonuna Tıklayın.");
            //lblMesaj.Text = "Dosya Seçin ve GÖNDER Butonuna Tıklayın.";
        }
        return yol;
    }

    public string ResimYukle(FileUpload fuResimYukle, string dosyaYol)
    {
        string yol = string.Empty;
        if (fuResimYukle.HasFile)
            try
            {
                if (fuResimYukle.PostedFile.ContentType == "image/jpeg" || fuResimYukle.PostedFile.ContentType == "image/png")
                {
                    if (fuResimYukle.PostedFile.ContentLength < 204800)
                    {
                        yol = dosyaYol + "\\" + DateTime.Now.ToShortDateString() + "_" + fuResimYukle.FileName;
                        fuResimYukle.SaveAs(yol);
                    }
                    else
                    {
                        Araclar.MesajPenceresi("Maksimum boyut 200KB olmalıdır.");
                    }
                }
                else
                {
                    Araclar.MesajPenceresi("Word Dosyası Seçin.");
                    //lblMesaj.Text = "Resim dosyası seçin.";
                }

            }
            catch (Exception ex)
            {
                Araclar.MesajPenceresi("Hata Oluştu:" + ex.Message.ToString());
                // lblMesaj.Text = "Hata Oluştu: " + ex.Message.ToString();
            }
        else
        {
            Araclar.MesajPenceresi("Dosya Seçin ve KAYIT Butonuna Tıklayın.");
            //lblMesaj.Text = "Dosya Seçin ve GÖNDER Butonuna Tıklayın.";
        }
        return yol;
    }
}