<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="~/images.aspx.cs" Inherits="Photos" 
Title="Photos - Sale on Thanks Giving and Black Friday"  CodeFileBaseClass="BasePage"  %>




<%@ Register Src="~/appblock_facebook/facebook_display.ascx" TagName="facebook" TagPrefix="uc1" %>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdir" TagPrefix="uc1" %>
<%@ Register Src="articles-directory-limited.ascx" TagName="articlesd" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad160.ascx" TagName="ad160" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_activity_feed.ascx" TagName="facebookactivity" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_comments.ascx" TagName="facebookcomments" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_embedded_posts.ascx" TagName="facebookembeddedposts" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_recommended_feed.ascx" TagName="facebook_recommended_feed" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
 		<div class="6u mobileUI-main-content">

								<!-- Main Content -->
									<section>
										<header>
											
                                             <h2><asp:label runat="server" ID="title"></asp:label></h2>
											
										</header>												
										
										


                                         
											
										
										
                                           

							<asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="4" RepeatDirection="Horizontal"  >
<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>


					
                   
<asp:hyperlink ID="imghyperlink" runat="server" NavigateUrl='<%#   Eval("navigateurl") %>'>
                                                      <asp:Image ID="Image1" runat="server"   
                ImageUrl='<%# Eval("thumbnailurl", "{0}") %>' alt='<%#  Eval("displayname") %>'
                                                NavigateUrl='<%#  Eval("navigateurl")  %>'              />
                                                 </asp:hyperlink>

                                                <blockquote>  <asp:Hyperlink ID="hyperlink1" runat="server"  Text='<%# Eval("displayname")  %>'  NavigateUrl='<%#  Eval("Navigateurl") %>' /></blockquote>
												 
				
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                							
		

  </div>

</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Datalist>
										
									<asp:Label ID="labeltext" runat="server"></asp:Label>	

                                                           														
                            <br />
                            <br />
                             <uc1:facebookactivity ID="facebookactivity" runat="server"></uc1:facebookactivity>	
								
                                <uc1:facebookcomments ID="facebookcomments" runat="server"></uc1:facebookcomments>			
<!--
                            <uc1:facebookembeddedposts ID="facebookembeddedposts" runat="server"></uc1:facebookembeddedposts>		
                              <uc1:facebook_recommended_feed ID="facebook_recommended_feed" runat="server"></uc1:facebook_recommended_feed>		
                            -->
    
						
		<asp:Label ID="label1" runat="server"></asp:Label>	

                       <br />
                                            <asp:Datalist ID="RepComments" runat="server"  RepeatColumns="1" RepeatDirection="Horizontal"  >
<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>


					
                   

												 
               							
		

      <asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium" Text='<%# Eval("text")  %>'></asp:Label>
    <br />


</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Datalist>           
                                        <br />
                                        <br /> 	                                    														
  <uc1:articles2 ID="articles2" runat="server"></uc1:articles2>	

							</div>


</asp:Content>