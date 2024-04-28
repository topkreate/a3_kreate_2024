
<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="~/articlelist.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdirectory" TagPrefix="uc1" %>
<%@ Register Src="articles-directory-limited.ascx" TagName="articlesdirectorylimited" TagPrefix="uc1" %>
<%@ Register Src="articles-sub-directory.ascx" TagName="articlesub" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad120.ascx" TagName="ad120" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad160.ascx" TagName="ad160" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_display.ascx" TagName="facebook" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<body class="right-sidebar">

		<!-- Header Wrapper -->
		<div id="header-wrapper">
			<div class="5grid-layout">
				<div class="row">
					<div class="12u">
						
						<!-- Header -->
							<header id="header">
								
								<!-- Logo -->
									<div id="logo">
																				 <h1><asp:label runat="server" ID="title"></asp:label></h1>
										<span>Menu</span>
									</div>
									
								<!-- Nav -->
									<nav id="nav" class="mobileUI-site-nav">
										<ul>											 <uc1:articles ID="articles1" runat="server"></uc1:articles>
										</ul>
									</nav>
								
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
	
							
											
                                            
											
									
										
                                            <asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="1" RepeatDirection="Horizontal"  >
<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>


					

   <asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium" Text='<%# Eval("text")  %>'></asp:Label>

</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Datalist>

								
										<br />
                                         <br /><br />
                            <uc1:facebook ID="facebook" runat="server"></uc1:facebook>	
                            <br />
										
							           <uc1:ad728 ID="ad728" runat="server"></uc1:ad728>
                                        <br /><br />

				 <asp:hyperlink ID="buttonmain"  runat="server" class="button" >  Read More           </asp:hyperlink>
                                                            <asp:hyperlink ID="buttonall"  runat="server" class="button button-alt" >Find out more             </asp:hyperlink>												
															</article>
								</div>

						</div>
						<div class="4u">
						
							<!-- Sidebar -->
								<div id="sidebar">


									<section>
										<h3>Right Articles</h3>
										<ul class="style2">
                                            <uc1:articles ID="articles" runat="server"></uc1:articles>
										
										</ul>
                                         <ul class="style2">
                                            <uc1:articlesub ID="articlesub" runat="server"></uc1:articlesub>
										
										</ul>
									</section>

								</div>
						
						</div>
					</div>
				</div>
			</div>

  			


</asp:Content>