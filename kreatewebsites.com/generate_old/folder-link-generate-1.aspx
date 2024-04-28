 

<%@ Page Language="C#" MasterPageFile="masterpage.Master" AutoEventWireup="true" CodeFile="folder-link-generate.aspx.cs" Inherits="Article" CodeFileBaseClass="BasePage" 

%>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
			<div id="main-wrapper" class="subpage">
				<div class="5grid-layout">
					<div class="row">
						<div class="9u">
					
							<!-- Content -->

								<article class="first">
														
					

															
																<h3><asp:label runat="server" ID="lblTitle"></asp:label></h3>

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

    
	</article>							

						</div>
                            
                  <div class="3u">
						
							<!-- Sidebar -->
							
								<section>
									<h3>Ads and Deals</h3>
									<ul class="link-list">
									 <uc1:ad300 ID="ad300" runat="server"></uc1:ad300>
									</ul>
								</section>

								<section class="last">
									<h3>Topics</h3>
								
									<ul class="link-list">
											 <uc1:articles ID="articles" runat="server"></uc1:articles>	
									</ul>
								</section>
						
						</div>
					</div>
				</div>
			</div>
          	
																

</asp:Content>
 
 

 
 
