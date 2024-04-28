 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="Default" %>


    <asp:Repeater ID="RepLinks" runat="server"    >
<HeaderTemplate>

    
</HeaderTemplate>

<ItemTemplate>

    <li>
			<asp:hyperlink ID="Hyperlink2"  runat="server" Text='<%#  Eval("name")  %>' NavigateUrl='<%#  Eval("url") %>' >  	 </asp:hyperlink>									
		
    </li>
</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Repeater>
             
 