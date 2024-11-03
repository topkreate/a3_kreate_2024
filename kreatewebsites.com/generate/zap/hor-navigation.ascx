 
 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="hor-navigation.ascx.cs" Inherits="Default" %>

 

    <asp:Repeater ID="RepLinks" runat="server"    >
<HeaderTemplate>

    
</HeaderTemplate>

<ItemTemplate>


												
						
			
            
           <asp:hyperlink ID="Hyperlink1"  class="nav-item nav-link" runat="server" Text='<%#  Eval("name")  %>' NavigateUrl='<%#  Eval("url") %>' >  	 </asp:hyperlink>
          

</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Repeater>
             
 
 
 
