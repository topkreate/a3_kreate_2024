<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header_bak.ascx.cs" Inherits="Default" %>

<div id="header-wrapper">
  <div class="5grid-layout">
    <div class="row">
      <div class="12u">

        <header id="header">
          <h1>
            
              <asp:hyperlink ID="H1" class="mobileUI-site-name" runat="server"   >  	 </asp:hyperlink>
          </h1>
          <nav class="mobileUI-site-nav">
            
                 <asp:Repeater ID="RepLinks" runat="server"    >
<HeaderTemplate>

    
</HeaderTemplate>

<ItemTemplate>


												
					
			<asp:hyperlink ID="title"  runat="server" Text='<%#  Eval("name")  %>' NavigateUrl='<%#  Eval("url") %>' >  	 </asp:hyperlink>
            
           
   


</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Repeater>
   
             
          </nav>
        </header>

      </div>
    </div>
  </div>
</div>
