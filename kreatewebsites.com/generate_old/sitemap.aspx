

 <%@ Page Language="C#" MasterPageFile="masterpage.Master" AutoEventWireup="true" CodeFile="sitemap.aspx.cs" Inherits="Article" CodeFileBaseClass="BasePage" 

%>


 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="footer-wrapper">
			<div class="5grid-layout">
				<div class="row">
					<div class="8u">
						
						<section>
							<h2>HTML 5 Lessons</h2>
							<div class="5grid">
								<div class="row">
									<div class="3u">
										<ul class="link-list">
										
                                      
										
        

                                     

               

							



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
             

										</ul>
									</div>
								

                                    	</div>
							</div>
						</section>
					
					</div>
					<div class="4u">

						<section>
							<h2>Lesons for HTML 5</h2>
							<p>Become HTML5 Expert</p>
							<footer class="controls">
								<a href="http://www.htmll5.com/Sitemap.html" class="button">See complete list</a>
							</footer>
						</section>

					</div>
				</div>
				<div class="row">
					<div class="12u">

						<div id="copyright">
							&copy;  All rights reserved. | Design: <a href="http://www.htmll5.com/">HTML Information</a> |  <a href="http://www.htmll5.com/privacypolicy.html">Privacy Policy</a>
						</div>

					</div>
				</div>
			</div>
		</div>
    		</asp:Content>
 
 
 
