 

<%@ Page Language="C#" MasterPageFile="masterpage_blank.Master" AutoEventWireup="true" CodeFile="folder-names-generate-button.aspx.cs" Inherits="Article" CodeFileBaseClass="BasePage" 

%>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 

    <asp:Repeater ID="RepLinks" runat="server"    >
<HeaderTemplate>

    
</HeaderTemplate>

<ItemTemplate>


								
		<asp:hyperlink ID="buttonall"  runat="server" Text='<%# Eval("name") %>' NavigateUrl='<%#  Eval("url") %>' >           </asp:hyperlink>
 


</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Repeater>

    
		</asp:Content>
             
 
 
 
