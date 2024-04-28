<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="article.aspx.cs" Inherits="Article" 
Title="Photos - Sale on Thanks Giving and Black Friday"  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesd" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
			<div id="main-wrapper" class="subpage">
				<div class="5grid-layout">
					<div class="row">
						<div class="9u">
					
							<!-- Content -->

								<article class="first">
														
					

															
																<h3><asp:label runat="server" ID="lblTitle"></asp:label></h3>
														
																
													
													


                                         
											
										
										
                                           

							
										
									<asp:Label ID="labeltext" runat="server"></asp:Label>	

                                                           														
                                     <uc1:ad728 ID="ad728" runat="server"></uc1:ad728>
										
		</article>							

						</div>
                            
                  <div class="3u">
						
							<!-- Sidebar -->
							
								<section>
									<h3>Ads</h3>
									<ul class="link-list">
									 <uc1:ad300 ID="ad300" runat="server"></uc1:ad300>
									</ul>
								</section>

								<section >
									<h3>Topics</h3>
								
									<ul class="link-list">
											 <uc1:articles ID="articles" runat="server"></uc1:articles>	
									</ul>
								</section>
						
                             <section class="last">
									<h3>More Topics</h3>
								
									<ul class="link-list">
											 <uc1:articlesd ID="articlesd" runat="server"></uc1:articlesd>	
									</ul>
								</section>
						</div>
					</div>
				</div>
			</div>
          	
																

</asp:Content>