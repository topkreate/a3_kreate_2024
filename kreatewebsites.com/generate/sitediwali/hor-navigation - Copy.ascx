 
 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="hor-navigation - Copy.ascx.cs" Inherits="Default" %>

 

    <asp:Repeater ID="RepLinks" runat="server"    >
<HeaderTemplate>

    
</HeaderTemplate>

<ItemTemplate>


												
						
			<!-- <asp:hyperlink ID="title"  class="nav-item nav-link" runat="server" Text='<%# "<em><b>" + Eval("name") + "</b></em>" %>' NavigateUrl='<%#  Eval("url") %>' >  	 </asp:hyperlink> -->
            
           <asp:hyperlink ID="Hyperlink1"  class="nav-item nav-link" runat="server" Text='<%#  Eval("name")  %>' NavigateUrl='<%#  Eval("url") %>' >  	 </asp:hyperlink>
          

</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Repeater>
             
 
 
 
