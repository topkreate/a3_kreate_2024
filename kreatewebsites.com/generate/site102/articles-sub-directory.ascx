 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="articles-sub-directory.ascx.cs" Inherits="Default" %>

 

    <asp:Repeater ID="RepLinks" runat="server"    >
<HeaderTemplate>

    
</HeaderTemplate>

<ItemTemplate>


											
					
			<asp:hyperlink ID="title" class="btn btn-link"  runat="server" Text='<%# "<em><b>" + Eval("name") + "</b></em>" %>' NavigateUrl='<%#  Eval("url") %>' >  	 </asp:hyperlink>
            



</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Repeater>
             
 
 
 
