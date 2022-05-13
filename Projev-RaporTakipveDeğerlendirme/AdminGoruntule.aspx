<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.master" AutoEventWireup="true" CodeFile="AdminGoruntule.aspx.cs" Inherits="AdminGoruntule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Label ID="lblad" runat="server"></asp:Label>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <table style="width: 100%; height:500px;">
        <tr>
            <td>
                <asp:DropDownList Style="border: 1px solid #d1e0e0; border-radius: 5px; padding: 5px;" ID="ddldonemsecim" runat="server">
                    <asp:ListItem Value="2021-2022-guz">2021-2022-GÜZ</asp:ListItem>
                    <asp:ListItem Value="2021-2022-bahar">2021-2022-BAHAR</asp:ListItem>
                </asp:DropDownList>
                <asp:Button Style="background-color: #669999; color: #FFF; -moz-border-radius: 16px; -webkit-border-radius: 16px; border-radius: 16px; font-weight: bold;" ID="btngoruntule" runat="server" OnClick="Button1_Click" Text="Görüntüle" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="panel1" runat="server" Height="145px" Style="Max-width:99%" ScrollBars="Vertical">
                    <asp:GridView CssClass="table table-striped  table table-hover" ID="GvOgrListesi" runat="server" OnRowCommand="GvOgrListesi_RowCommand">
                        <Columns>
                            <asp:ButtonField ControlStyle-CssClass="btn btn-secondary" CommandName="sec" Text="Seç" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="panel2" runat="server"  Height="108px" Style="Max-width:99%" ScrollBars="Vertical">
                    <asp:GridView CssClass="table table-striped  table table-hover" ID="GvBilgiler" runat="server" OnRowCommand="GvBilgiler_RowCommand">
                        <Columns>
                            <asp:ButtonField  ControlStyle-CssClass="btn btn-secondary"  CommandName="sec" Text="Seç" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="panel3" runat="server"  Height="121px" Style="Max-width:99%" ScrollBars="Vertical">
                    <asp:GridView CssClass="table table-striped  table table-hover" ID="GvRaporBilgiler" runat="server" OnRowCommand="GvRaporBilgiler_RowCommand">
                        <Columns>
                            <asp:ButtonField ControlStyle-CssClass="btn btn-secondary" CommandName="indir" Text="İndir" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>

