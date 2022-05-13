<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.master" AutoEventWireup="true" CodeFile="ProjeKayit.aspx.cs" Inherits="ProjeKayit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Label ID="lblad" runat="server"></asp:Label>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table id="ogrgorecek" class="w-100" style="height:310px;">
        <tr>
            <td style="width: 311px">
                <asp:Label Style="font-weight: bold;" ID="Label1" runat="server" Text="Proje Adı:"></asp:Label>
            </td>
            <td style="width: 1130px">
                <asp:TextBox CssClass="form-control" ID="txtprojead" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 311px">
                <asp:Label Style="font-weight: bold;" ID="Label2" runat="server" Text="Başlama Tarihi:"></asp:Label>
            </td>
            <td style="width: 1130px">
                <asp:TextBox CssClass="form-control"  TextMode="Date" ID="txtprojebaslama" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 311px">
                <asp:Label Style="font-weight: bold;" ID="Label3" runat="server" Text="Bitiş Tarihi:"></asp:Label>
            </td>
            <td style="width: 1130px">
                <asp:TextBox CssClass="form-control"  TextMode="Date" ID="txtprojebitis" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 311px">
                <asp:Label Style="font-weight: bold;" ID="Label4" runat="server" Text="Açıklama:"></asp:Label>
            </td>
            <td style="width: 1130px">
                <asp:TextBox CssClass="form-control" ID="txtaciklama" runat="server" Height="66px" TextMode="MultiLine"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td style="width: 311px">&nbsp;</td>
            <td style="width: 1130px">
                <br />
                <asp:Button Style="padding: 3px; background-color: #669999; color: #FFF; -moz-border-radius: 16px; -webkit-border-radius: 16px; border-radius: 16px; font-weight: bold;" ID="btnkayit" runat="server" Text="Kaydet" OnClick="btnkayit_Click" />

            </td>
        </tr>

    </table>
    <br />
    <asp:Panel ID="panel1" runat="server" Height="165px"  Style="Max-width:99.5%;" ScrollBars="Vertical">
        <asp:GridView CssClass="table table-striped  table table-hover" ID="gvlistele" runat="server" OnRowCommand="gvlistele_RowCommand">
            <Columns>
                <asp:ButtonField ControlStyle-CssClass="btn btn-danger" CommandName="sil" Text="Sil" />
                <asp:ButtonField ControlStyle-CssClass="btn btn-success" CommandName="raporekle" Text="RaporEkle" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>



