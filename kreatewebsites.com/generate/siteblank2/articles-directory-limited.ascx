 
 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="articles-directory-limited.ascx.cs" Inherits="Default" %>

 

    <asp:Repeater ID="RepLinks" runat="server"    >
<HeaderTemplate>

    
</HeaderTemplate>

<ItemTemplate>


												
		<li>					
			<asp:hyperlink ID="title"  runat="server" Text='<%# "<em><b>" + Eval("name") + "</b></em>" %>' NavigateUrl='<%#  Eval("url") %>' >  	 </asp:hyperlink>
            
           
            </li>	


</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Repeater>
             
 
 
 
