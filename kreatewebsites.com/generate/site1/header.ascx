 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="Default" %>

<div id="header-wrapper">
				<header class="5grid-layout" id="site-header">
					<div class="row">
						<div class="12u">
							<div id="logo">
								<h1> <asp:HyperLink class="mobileUI-site-name" id="myTitle" runat="server" /></h1>
							</div>
 
        
          <nav class="mobileUI-site-nav" id="site-nav">  
<ul>
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
             
 
 	</ul>
							</nav>
						</div>
					</div>
				</header>
			</div>