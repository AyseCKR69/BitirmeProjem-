<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.master" AutoEventWireup="true" CodeFile="Giris.aspx.cs" Inherits="Giris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    
    <asp:Label ID="lblad" runat="server"></asp:Label>
   
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    
    <table style="width:100%; height:498px;">
        <tr>
            <td>
                <asp:Label style="font-weight: bold;" ID="Label1" runat="server" Text="Okul Numarası:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtnumara" CssClass="form-control" runat="server" placeholder="Okul Numaranız" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label style="font-weight: bold;" ID="Label2" runat="server" Text="Şifre:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtsifre" type="password"  CssClass="form-control" placeholder="Şifreniz" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button style="background-color: #669999; 
                                   color: #FFF; 
                                   -moz-border-radius: 16px; 
                                   -webkit-border-radius: 16px;
                                   border-radius: 16px; 
                                   font-weight: bold;" ID="BtnGiris" runat="server" Text="Giriş Yap" OnClick="BtnGiris_Click" />
            </td>
        </tr>
    </table>
    
</asp:Content>



