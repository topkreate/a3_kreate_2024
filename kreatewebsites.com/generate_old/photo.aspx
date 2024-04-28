<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="photo.aspx.cs" Inherits="Photo" 
 CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdir" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	<div id="main-wrapper" class="subpage">
				<div class="5grid-layout">
					<div class="row">
						<div class="3u">
						
							<!-- Sidebar 1 -->
							
								<section>
									<h3>Main Topic</h3>
									<ul class="link-list">
										<uc1:articleshome ID="articleshome" runat="server"></uc1:articleshome>	
									</ul>
								</section>

								<section>
									<h3>Related Topics </h3>
									
									<ul class="link-list">
										<uc1:articlesdir ID="articlesdir" runat="server"></uc1:articlesdir>	
									</ul>
								</section>
						
						</div>
						<div class="6u mobileUI-main-content">
					
							<!-- Content --><article class="first">
								
					
				
                                             <h2><asp:label runat="server" ID="lblTitle"></asp:label></h2>
											
										
										
                                           

                                        <asp:image ID="imgMainImage" runat="server" width="450"></asp:image>

									<p><asp:Label ID="labeltext" runat="server"></asp:Label></p>
										

                                 Read More Articles :
            <uc1:articles2 ID="articles2" runat="server"></uc1:articles2>	
										
               <br />
                                               <p><asp:Label ID="labellinks" runat="server"></asp:Label></p>
                                                 </article>							

						</div>
						<div class="3u">
						
							<!-- Sidebar 2 -->
							
								<section>
									<h3>Ads and Deals</h3>
									<ul class="link-list">
										
                                         <uc1:ad300 ID="ad300" runat="server"></uc1:ad300>
									</ul>
								</section>

								<section class="last">
									<h3>Main Articles</h3>
									<ul class="link-list">
										 <uc1:articles ID="articles" runat="server"></uc1:articles>	
									</ul>
								</section>
						
						</div>
					</div>
				</div>
			</div>

		</asp:Content>







