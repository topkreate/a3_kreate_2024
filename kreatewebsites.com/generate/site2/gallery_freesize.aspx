<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="~/gallery.aspx.cs" Inherits="Photos" 
Title="Photos - Sale on Thanks Giving and Black Friday"  CodeFileBaseClass="BasePage"  %>

<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdir" TagPrefix="uc1" %>
<%@ Register Src="articles-directory-limited.ascx" TagName="articlesd" TagPrefix="uc1" %>
<%@ Register Src="articles-sub-directory.ascx" TagName="articlesub" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad160.ascx" TagName="ad160" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_display.ascx" TagName="facebook" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_comments.ascx" TagName="facebook_comments" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_website_button_count.ascx" TagName="facebook_website_button_count" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
	
      
			
					
											
										
							<div class="6u mobileUI-main-content">

								<!-- Main Content -->
									<section>
										<header>
											
                                             <h2><asp:label runat="server" ID="title"></asp:label></h2>
											
										</header>			
                                           <span> <asp:Label ID="metadesc" runat="server" ></asp:Label></span> 

							<asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="4" RepeatDirection="Horizontal"  >
<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>


					
                   
<asp:hyperlink ID="imghyperlink" runat="server" NavigateUrl='<%#   DataBinder.Eval(Container.DataItem, "navigateurl2")  %>'>
                                                      <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("url", "{0}") %>' alt='<%#  Eval("alt") %>'
                                                NavigateUrl='<%#  Eval("navigateurl2")  %>'              />
                                                 </asp:hyperlink>

                                              
													
				   <blockquote>  <asp:Hyperlink ID="hyperlink1" runat="server"  Text='<%# Eval("displayname")  %>'  NavigateUrl='<%#  DataBinder.Eval(Container.DataItem, "navigateurl2")  %>' /></blockquote>
                    							
		

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


					
                   

												 
               							
		

      <asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium" Text='<%# Eval("text")  %>'></asp:Label>
    <br />


</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Datalist>           
                                        <br />
                                          <h3>Like us on facebook</h3>
                            <uc1:facebook ID="facebook" runat="server"></uc1:facebook>	
                                     
                                        <uc1:facebook_comments ID="facebook_comments" runat="server"></uc1:facebook_comments>	
                                      
                                        <br /> 	
                                                           														
   <section>

                                    <header>
											
                                             <h3>Articles</h3>
											
										</header>
                                     <uc1:articles2 ID="articles2" runat="server"></uc1:articles2>
                                     <uc1:articlesub ID="articlesub" runat="server"></uc1:articlesub>
                                </section>

							</div>
																

</asp:Content>