
<%@ Page Language="C#" MasterPageFile="MasterPage_header2023.master" AutoEventWireup="true" CodeFile="~/articlelist2023-title2.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-sub-directory.ascx" TagName="articlesub" TagPrefix="uc1" %>
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
<%@ Register Src="articles-list-button-side.ascx" TagName="articleslistbuttonside" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


   <!-- Main Wrapper -->
			
		<header id="header">
				<div class="logo">
					<div>
						<h1><asp:label runat="server" ID="title"></asp:label></h1>
						<span class="byline"><asp:label runat="server" ID="Label1"></asp:label></span>
					</div>
			</header>
			
									
									<!-- Nav -->
										<nav id="nav" class="mobileUI-site-nav">
											<ul>
								
                 <uc1:articlesdirectory ID="articlesdir" runat="server"></uc1:articlesdirectory> 
				<!--	<uc1:articlesdirectorylimited ID="articlesdirectorylimited" runat="server"></uc1:articlesdirectorylimited> -->
                                               
											</ul>
										</nav>
	   
				<div id="main-wrapper">
				<div id="main" class="5grid-layout">
					<div class="row">
						<div class="9u mobileUI-main-content">
                            <div class="content content-left">
							<!-- Content -->
								
									<article class="is-page-content">
	
							
											
                                             <h3><asp:label runat="server" ID="title2"></asp:label></h3>
											
									<span> <asp:Label ID="metadesc" runat="server" ></asp:Label></span>	
										
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

														<uc1:articlesbutton ID="articlesbutton" runat="server"></uc1:articlesbutton>	
 
<uc1:articleslistbutton ID="articleslistbutton" runat="server"></uc1:articleslistbutton>	
										
										
															</article>
								</div>

						</div>
							<div class="3u">
						
							<!-- Sidebar -->
								<div id="sidebar">

									<section>
										<h3>Links</h3>
										<!-- 
										<p>  
											
											<uc1:articlesub ID="articlessub" runat="server"></uc1:articlesub>	
										</p>
											-->
											<footer>
												 <!-- <asp:hyperlink ID="buttonMore"  runat="server" class="button button-icon button-icon-info" >             </asp:hyperlink>	-->
												<uc1:articlessubdirectorybutton ID="articleslistbutton1" runat="server"></uc1:articlessubdirectorybutton>	
											</footer>

									</section>

									<section>
										<!-- <h3>Related Articles</h3> -->
										<ul class="style2">
                                            
										<uc1:articles ID="articles" runat="server"></uc1:articles>
										</ul>
									</section>

								</div>
						
						</div>
					</div>
				</div>
			</div>

  			


</asp:Content>