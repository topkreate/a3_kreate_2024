<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="~/gallery.aspx.cs" Inherits="Photos" 
Title="Photos - Sale on Thanks Giving and Black Friday"  CodeFileBaseClass="BasePage"  %>

<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdir" TagPrefix="uc1" %>
<%@ Register Src="articles-directory-limited.ascx" TagName="articlesd" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/actions.ascx" TagName="actions" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad160.ascx" TagName="ad160" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_activity_feed.ascx" TagName="facebookactivity" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_comments.ascx" TagName="facebookcomments" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_embedded_posts.ascx" TagName="facebookembeddedposts" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_recommended_feed.ascx" TagName="facebook_recommended_feed" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
	 <header id="header">
				<div class="logo">
					<div>
						<h1><asp:label runat="server" ID="Label3"></asp:label></h1>
					</div>
			</header>
			
									
									<!-- Nav -->
										<nav id="nav" class="mobileUI-site-nav">
											<ul>
								
                    <uc1:articlesd ID="articlesdir" runat="server"></uc1:articlesd>
                                               
											</ul>
										</nav>
	   
				<div id="main-wrapper">
				<div id="main" class="5grid-layout">
					<div class="row">
						<div class="9u mobileUI-main-content">
                            <div class="content content-left">
							<!-- Content -->
								
									<article class="is-page-content">
											<span> <asp:Label ID="metadesc" runat="server" ></asp:Label></span>	
                                            <h3><asp:label runat="server" ID="title"></asp:label></h3>

							<asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="3" RepeatDirection="Horizontal"  >
<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>


					
                   
<asp:hyperlink ID="imghyperlink" runat="server" NavigateUrl='<%#   DataBinder.Eval(Container.DataItem, "navigateurl2")  %>'>
                                                      <asp:Image ID="Image1" runat="server"   
                ImageUrl='<%# Eval("url", "{0}") %>' alt='<%#  Eval("alt") %>'
                                                NavigateUrl='<%#  Eval("navigateurl")  %>'              />
                                                 </asp:hyperlink>

                                              
				 <blockquote>  <asp:Hyperlink ID="hyperlink1" runat="server"  Text='<%# Eval("displayname")  %>'   /></blockquote>									
				
                    							
		

  </div>

</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Datalist>
										
									<asp:Label ID="labeltext" runat="server"></asp:Label>	
    <br />
        <asp:Datalist ID="RepComments" runat="server"  RepeatColumns="1" RepeatDirection="Horizontal"  >
<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>


					
                   

												 
               							
		

      <asp:Label ID="label1" runat="server"  ForeColor="Black" Font-Size="Medium" Text='<%# Eval("text")  %>'></asp:Label>
    <br />


</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Datalist>           
                                        <br />
                                        <br /> 	
                                                           														
     <uc1:facebookactivity ID="facebookactivity" runat="server"></uc1:facebookactivity>	
								
                                <uc1:facebookcomments ID="facebookcomments" runat="server"></uc1:facebookcomments>			

     <uc1:articles2 ID="articles2" runat="server"></uc1:articles2>	
						
		<asp:Label ID="label2" runat="server"></asp:Label>	

                                                           														
 
                                        <br /><br />

			<uc1:actions ID="actions" runat="server"></uc1:actions>												
															</article>
								

								
								
							</div>
						</div>
                                 
						<div class="3u">
						
							
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