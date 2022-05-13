<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.master" AutoEventWireup="true" CodeFile="Kayit.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblad" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <table style="width: 100%; height: 499px; margin-bottom: 0px;">
        <tr>
            <td>
                <asp:Label Style="font-weight: bold;" ID="Label2" runat="server" Text="Adı:"></asp:Label></td>
            <td>
                <asp:TextBox CssClass="form-control" placeholder="Adınız" ID="txtad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Style="font-weight: bold;" ID="Label1" runat="server" Text="Soyadı:"></asp:Label></td>
            <td>
                <asp:TextBox CssClass="form-control" placeholder="Soyadınız" ID="txtsoyad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Style="font-weight: bold;" ID="Label3" runat="server" Text="Okul Numarası:"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="form-control" placeholder="Okul Numaranız" ID="txtnumara" runat="server" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Style="font-weight: bold;" ID="Label4" runat="server" Text="E-Posta:"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="form-control" placeholder="email@example.com" ID="txteposta" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Style="font-weight: bold;" ID="Label5" runat="server" Text="Şifre:"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="form-control" placeholder="Şifreniz" type="password" ID="txtsifre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Style="font-weight: bold;" ID="Label6" runat="server" Text="Bölüm:"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList CssClass="form-control" ID="rbbolum" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                    <asp:ListItem Value="bilgisayar">Bilgisayar</asp:ListItem>
                    <asp:ListItem Value="sbst">SBST</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Style="font-weight: bold;" ID="Label7" runat="server" Text="Dönem:"></asp:Label>
            </td>
            <td>
               
                    <asp:DropDownList CssClass="form-control" ID="ddldonem" runat="server">
                        <asp:ListItem Value="2021-2022-guz">2021-2022-GÜZ</asp:ListItem>
                        <asp:ListItem Value="2021-2022-bahar">2021-2022-BAHAR</asp:ListItem>
                    </asp:DropDownList>
                
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button Style="background-color: #669999; color: #FFF; -moz-border-radius: 16px; -webkit-border-radius: 16px; border-radius: 16px; font-weight: bold;"
                    ID="BtnKayit" runat="server" Text="KAYDET" OnClick="BtnKayit_Click" />
            </td>
        </tr>
    </table>

</asp:Content>




