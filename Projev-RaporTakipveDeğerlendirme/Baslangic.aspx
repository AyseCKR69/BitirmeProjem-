<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.master" AutoEventWireup="true" CodeFile="Baslangic.aspx.cs" Inherits="Baslangic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Label ID="lblad" runat="server"></asp:Label>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <br />
    <div style="width: 100%; height: 475px;">
        <p class="text-center display-6" style="color:#476b6b">HOŞGELDİNİZ</p>
        <br />
       
        <br />
        <asp:Label ID="Label1" CssClass="text-center" runat="server">
        Bu uygulama öğrencilerin projelerini yükleyebileceği aynı zamanda projelerine ait raporlarını yükleyebileceği bir 
        proje-rapor takip uygulamasıdır.Öğrenciler kayıt olduktan sonra projeyi yükleyecekleri sayfaya yönlendirilmektedir bu sayfada öğrenciler projelerini
        yükleyebilmektedir, orada bulunan gridview deki sil butonuna basınca projeyi silebilmektedirler aynı zamanda rapor ekle butonuna basarak projelerine
        ait raporlar ekleyebilmektedirler. Rapor ekle sayfasında raporlarını ekledikten sonra öğrenciler için raporları listelenir. Öğrenci kendi adının olduğu 
        yere basınca öğrenci bilgilerinin görüntülendiği sayfaya yönlendirilir oradan çıkış yapılabilir.Dersin Öğretmeninin öğrencilerin yüklediği proje ve 
        raporları görüntüleyebileceği bir sayfa bulunmaktadır.
        </asp:Label>
        <br />
        <br />
        <p class="text-danger text-center">Kayıt olmadıysanız kayıt olunuz.</p>
    </div>
</asp:Content>



