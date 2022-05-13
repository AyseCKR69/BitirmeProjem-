<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.master" AutoEventWireup="true" CodeFile="HakkımızdaKisi.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblad" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width: 100%; height:499px;">
    <tr>
        <td>
            <asp:Label style="font-weight: bold;" ID="Label1" runat="server" Text="Kişi Ad:"></asp:Label>
        </td>
        <td>
            <asp:TextBox  CssClass="form-control" ID="txtad" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="height: 26px">
            <asp:Label style="font-weight: bold;" ID="Label2" runat="server" Text="Kişi Soyad:"></asp:Label>
        </td>
        <td style="height: 26px">
            <asp:TextBox  CssClass="form-control" ID="txtsoyad" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label style="font-weight: bold;" ID="Label3" runat="server" Text="Kişi Numarası:"></asp:Label>
        </td>
        <td>
            <asp:TextBox  CssClass="form-control" ID="txtnumara" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="height: 27px">
            <asp:Label style="font-weight: bold;" ID="Label4" runat="server" Text="Bölümü:"></asp:Label>
        </td>
        <td style="height: 27px">
            <asp:TextBox  CssClass="form-control" ID="txtbolum" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label style="font-weight: bold;" ID="Label5" runat="server" Text="Dönemi:"></asp:Label>
        </td>
        <td>
            <asp:TextBox  CssClass="form-control" ID="txtdonem" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label style="font-weight: bold;" ID="Label6" runat="server" Text="E-Posta:"></asp:Label>
        </td>
        <td>
            <asp:TextBox  CssClass="form-control" ID="txteposta" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label style="font-weight: bold;" ID="Label7" runat="server" Text="Şifre:"></asp:Label>
        </td>
        <td>
            <asp:TextBox style="border:1px solid #d1e0e0; border-radius: 5px; padding:5px;" ID="txtsifre" runat="server" textMode="Password" Enabled="False"></asp:TextBox>
            <asp:Button style="background-color: #669999; color: #FFF; -moz-border-radius: 16px; -webkit-border-radius: 16px;border-radius: 16px; font-weight: bold;" ID="BtnGoster" runat="server" Text="Göster" OnClick="BtnGoster_Click" />
            <asp:Button style="background-color: #669999; color: #FFF; -moz-border-radius: 16px; -webkit-border-radius: 16px;border-radius: 16px; font-weight: bold;" ID="Btngizle" runat="server" Text="Gizle" OnClick="BtnGizle_Click" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button style="background-color: #669999; color: #FFF; -moz-border-radius: 16px; -webkit-border-radius: 16px;border-radius: 16px; font-weight: bold;" ID="BtnCikis" runat="server" OnClick="BtnCikis_Click" Text="Çıkış Yap" />
        </td>
    </tr>
</table>
</asp:Content>

