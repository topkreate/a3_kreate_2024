 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="Default" %>

<nav class="navbar navbar-expand-lg bg-white navbar-light shadow border-top border-5 border-primary sticky-top p-0">
    <a href="/" class="navbar-brand bg-primary d-flex align-items-center px-4 px-lg-5">
        <h2 class="mb-2 text-white"><asp:HyperLink class="mobileUI-site-name" id="myTitle" runat="server" /></h2>
    </a>
    <button type="button" class="navbar-toggler me-4" data-bs-toggle="collapse" data-bs-target="#navbarCollapse">
        <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarCollapse">
        <div class="navbar-nav ms-auto p-4 p-lg-0">
           
            <asp:Repeater ID="RepLinks" runat="server"    >

                <HeaderTemplate>

    
                </HeaderTemplate>

                <ItemTemplate>

   
			            <asp:hyperlink ID="Hyperlink2"  runat="server" Text='<%#  Eval("name")  %>' NavigateUrl='<%#  Eval("url") %>' >  	 </asp:hyperlink>									
		

                </ItemTemplate>



                <FooterTemplate>



                </FooterTemplate>

            </asp:Repeater>
             
 
 	        </div>
    </div>
</nav>