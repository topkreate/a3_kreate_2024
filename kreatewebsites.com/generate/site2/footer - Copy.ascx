 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="footer - Copy.ascx.cs" Inherits="Default" %>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-sub-directory.ascx" TagName="articlesub" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdirectory" TagPrefix="uc1" %>
<%@ Register Src="articles-directory-limited.ascx" TagName="articlesdirectorylimited" TagPrefix="uc1" %>
	<div id="footer-wrapper">
				<footer id="footer" class="5grid-layout">
					<div class="row">
						<div class="8u">
						
							<!-- Links -->
								<section>
									<h2><asp:hyperlink ID="footerhead" runat="server"></asp:hyperlink></h2>
							
									<div class="5grid">
										<div class="row">
											<div class="3u">
												<ul class="link-list last-child">
													<uc1:articleshome ID="Articleshome3" runat="server"></uc1:articleshome>
													
												</ul>
											</div>
											<div class="3u">
												<ul class="link-list last-child">
													<uc1:articles ID="articles1" runat="server"></uc1:articles>
												</ul>
											</div>
											<div class="3u">
												<ul class="link-list last-child">
													<uc1:articlesub ID="Articlesub1" runat="server"></uc1:articlesub>
												</ul>
											</div>
											<div class="3u">
												<ul class="link-list last-child">
													
												</ul>
											</div>
										</div>
									</div>
								</section>

						</div>
						<div class="4u">
							
							<!-- Blurb -->
								<section>
									<h2>About US</h2>
									<p>
										
									</p>
								</section>
						
						</div>
					</div>
				</footer>
			</div>

		<!-- Copyright -->
			<div id="copyright">
				
                &copy; Copyright.  Design: <asp:HyperLink ID="cright" runat="server" ></asp:HyperLink> | <asp:HyperLink ID="sitemap" runat="server" ></asp:HyperLink>  | <asp:HyperLink ID="privacypolicy" runat="server" > | <asp:hyperlink ID="footerfooter" runat="server"> </asp:hyperlink></asp:HyperLink> 
			</div>


			
								
								
							