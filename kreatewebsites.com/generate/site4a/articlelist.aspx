
<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="~/articlelist.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdirectory" TagPrefix="uc1" %>
<%@ Register Src="articles-directory-limited.ascx" TagName="articlesdirectorylimited" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/actions.ascx" TagName="actions" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad120.ascx" TagName="ad120" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad160.ascx" TagName="ad160" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_display.ascx" TagName="facebook" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


   <!-- Main Wrapper -->
			
		 <div id="main-wrapper">
				<div id="main" class="5grid-layout">
					<div class="row">
						<div class="9u mobileUI-main-content">
							<div class="content content-left">
							
								<!-- Content -->
						
									<article class="is-page-content">
	
										<header>
											
                                             <h3><asp:label runat="server" ID="title"></asp:label></h3>
											
												<span class="byline"> <asp:Label ID="metadesc" runat="server" ></asp:Label></span>	
										</header>

                                            <asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="1" RepeatDirection="Horizontal"  >
<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>


					
	<section>
   <asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium" Text='<%# Eval("text")  %>'></asp:Label>
		</section>
</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Datalist>

								
										<br />
                                         <br /><br />
                            <uc1:facebook ID="facebook" runat="server"></uc1:facebook>	
                            <br />
										
							      
                                   

				<uc1:actions ID="actions" runat="server"></uc1:actions>											
															</article>
								</div>

						</div>
							<div class="3u">
						
							<!-- Sidebar -->
								<div id="sidebar">

									<section>
										<h3>Popular</h3>
									
                                            <uc1:ad300 ID="ad300" runat="server"></uc1:ad300>
								

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

  			


</asp:Content>