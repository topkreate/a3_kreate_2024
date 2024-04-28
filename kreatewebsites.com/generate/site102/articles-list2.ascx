 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="articles-list.ascx.cs" Inherits="Default" %>

 

    <asp:Repeater ID="RepLinks" runat="server"    >
<HeaderTemplate>

    
</HeaderTemplate>

<ItemTemplate>


												
									
		<asp:hyperlink ID="title"  runat="server" Text='<%# Eval("name") %>' NavigateUrl='<%#  Eval("url") %>' >         
            </asp:hyperlink>
            	
&nbsp;&nbsp;


</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Repeater>
             
 
 
 
