
<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="~/article.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdirectory" TagPrefix="uc1" %>
<%@ Register Src="articles-directory-limited.ascx" TagName="articlesdirectorylimited" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad120.ascx" TagName="ad120" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad160.ascx" TagName="ad160" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_display.ascx" TagName="facebook" TagPrefix="uc1" %>
<%@ Register Src="articles-directory-limited-button.ascx" TagName="articlesbutton" TagPrefix="uc1" %>
<%@ Register Src="articles-sub-directory-limited-button.ascx" TagName="articlessubdirectorybutton" TagPrefix="uc1" %>
<%@ Register Src="articles-list-limited-button.ascx" TagName="articleslistbutton" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<body class="right-sidebar">
			<!-- Header Wrapper -->

			<div id="header-wrapper">
				<div class="5grid-layout">
					<div class="row">
						<div class="12u">
						
							<!-- Header -->
								<header id="header">
								
								
								</header>

						</div>
					</div>
				</div>
			</div>


   <!-- Main Wrapper -->
			<div id="main-wrapper">
				<div class="5grid-layout">
					<div class="row">
						<div class="8u mobileUI-main-content">

							<!-- Content -->
								<div id="content">
									<article class="last">
	
							
											
                                             
											
											<h2><asp:Label runat="server" ID="title"></asp:Label></h2>
										<span> <asp:Label ID="metadesc" runat="server" ></asp:Label></span>	
										
                                            <asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium"></asp:Label>

								
										<br />
                                         <br />
										
							           
                                     

										<uc1:articlesbutton ID="articlesbutton" runat="server"></uc1:articlesbutton>	


									<!--	<uc1:articleslistbutton ID="articleslistbutton" runat="server"></uc1:articleslistbutton>		-->										
										</article>
								</div>

						</div>
						<div class="4u">
						
							<!-- Sidebar -->
								<div id="sidebar">

									<section>
										
										<h3>Articles</h3>
										<p>
                                            <!-- <uc1:ad300 ID="ad300" runat="server"></uc1:ad300> -->
											<!-- <uc1:articlessub ID="Articlessub1" runat="server"></uc1:articlessub> -->
											<uc1:articlessubdirectorybutton ID="articlessubdirectorybutton" runat="server"></uc1:articlessubdirectorybutton>
											
										</p>
										<footer>
                                             <asp:hyperlink ID="buttonMore"  runat="server" class="button button-icon button-icon-info" > Home</asp:hyperlink>	
											
										</footer>
									</section>

									<section>
										<h3>Related Articles</h3>
										<ul class="style2">
                                            <uc1:articles ID="articles" runat="server"></uc1:articles>
										
										</ul>
									</section>

								</div>
						
						</div>
					</div>
				</div>
			</div>

  			
</body>

</asp:Content>