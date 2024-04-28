
<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="~/articlelist.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdirectory" TagPrefix="uc1" %>
<%@ Register Src="articles-directory-limited.ascx" TagName="articlesdirectorylimited" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad120.ascx" TagName="ad120" TagPrefix="uc1" %>
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
                                        <h3>Like us on facebook</h3>
                            <uc1:facebook ID="facebook" runat="server"></uc1:facebook>	
                                        <br /> Facebook comments<br />
                                        <uc1:facebook_comments ID="facebook_comments" runat="server"></uc1:facebook_comments>	
                                    
                                       
                            <br />
										
										
									</section>
                                <section>

                                    <header>
											
                                             <h3>Articles in</h3>
											
										</header>
                                   
                                      <uc1:articles2 ID="articles2" runat="server"></uc1:articles2>
                                  
                                </section>


                                
							</div>
							
  			


</asp:Content>