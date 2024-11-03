 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="articles-directory-limited-button.ascx.cs" Inherits="Default" %>

 

    <asp:Repeater ID="RepLinks" runat="server"    >
<HeaderTemplate>

    
</HeaderTemplate>

<ItemTemplate>


												

    <asp:hyperlink ID="buttonall"  runat="server" class="button button-alt" Text='<%# Eval("name") %>' NavigateUrl='<%#  Eval("url") %>' >           </asp:hyperlink>
    &nbsp;&nbsp;&nbsp;&nbsp;
</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Repeater>
             
 
 
 
