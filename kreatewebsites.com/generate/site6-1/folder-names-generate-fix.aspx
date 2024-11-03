

 <%@ Page Language="C#" MasterPageFile="masterpage-6-1.master" AutoEventWireup="true" CodeFile="folder-names-generate-fix.aspx.cs" Inherits="Article" CodeFileBaseClass="BasePage" 

%>


 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Repeater ID="RepLinks" runat="server"    >
<HeaderTemplate>

    
</HeaderTemplate>

<ItemTemplate>


												
		<li>								
		<asp:hyperlink ID="title"  runat="server" Text='<%# Eval("name") %>' NavigateUrl='<%#  Eval("url") %>' >
            
            </asp:hyperlink>
            </li>	


</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Repeater>
             
    		</asp:Content>
 
 
 
