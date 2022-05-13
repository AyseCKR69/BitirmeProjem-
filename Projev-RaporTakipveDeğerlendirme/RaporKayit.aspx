<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.master" AutoEventWireup="true" CodeFile="RaporKayit.aspx.cs" Inherits="RaporKayit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblad" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table style="width: 100%; height: 365px">
        <tr>
            <td>
                <asp:Label Style="font-weight: bold;" ID="Label1" runat="server" Text="Rapor Adı:"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="form-control" ID="txtRaporAd" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Style="font-weight: bold;" ID="Label2" runat="server" Text="Hafta:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="form-control" ID="ddlhafta" runat="server">
                    <asp:ListItem Value="-1">Seçiniz</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 29px">
                <asp:Label Style="font-weight: bold;" ID="Label4" runat="server" Text="Dosya Türü:"></asp:Label>
            </td>
            <td style="height: 29px">

                <asp:DropDownList CssClass="form-control" ID="ddldosyatur" runat="server">
                    <asp:ListItem Value="-1">Seçiniz</asp:ListItem>
                    <asp:ListItem Value="resim">Resim</asp:ListItem>
                    <asp:ListItem Value="rapor">Rapor</asp:ListItem>
                    <asp:ListItem Value="ekdosyalar">Ek Dosyalar</asp:ListItem>

                </asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Style="font-weight: bold;" ID="Label3" runat="server" Text="Dosya:"></asp:Label>
            </td>
            <td>
                <asp:FileUpload CssClass="form-control" ID="FuDosyaYukle" runat="server" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button Style="padding: 5px; width: 70px; margin: 5px; background-color: #669999; color: #FFF; -moz-border-radius: 16px; -webkit-border-radius: 16px; border-radius: 16px; font-weight: bold;" ID="btnKayit" runat="server" Text="Kaydet" OnClick="btnKayit_Click" />
            </td>
        </tr>

    </table>
    <asp:Panel ID="panel1" runat="server" Height="133px" Style="Max-width:99.5%;" ScrollBars="Vertical">
        <asp:GridView CssClass="table table-striped  table table-hover" ID="gvraporlistele" runat="server">
        </asp:GridView>
    </asp:Panel>
</asp:Content>
