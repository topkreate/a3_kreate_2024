<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="~/slide.aspx.cs" Inherits="Photo" 
 CodeFileBaseClass="BasePage"  %>


<%@ Register Src="~/appblock_facebook/facebook_display.ascx" TagName="facebook" TagPrefix="uc1" %>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdir" TagPrefix="uc1" %>
<%@ Register Src="articles-directory-limited.ascx" TagName="articlesd" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad160.ascx" TagName="ad160" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	   
			<!-- Main Wrapper -->
			<div id="main-wrapper">
				<div class="5grid-layout">
					<div class="row">
						<div class="12u mobileUI-main-content">

							<!-- Content -->
								<div id="content">
									<article class="last">
										
											
                                             <h2><asp:label runat="server" ID="title"></asp:label></h2>
																	
										
										
                                           
     <asp:image ID="imgMainImage" runat="server"></asp:image>
					
                   
	<div class="caption">
										<span><strong> </strong><asp:Label ID="lblslide" runat="server"></asp:Label></span>
                                         <asp:Hyperlink ID="hyperEmail" runat="server"></asp:Hyperlink>
                                        <div align ="center">
                                        <uc1:facebook ID="facebook" runat="server"></uc1:facebook>  
                                            </div>
                                        <br />
                                        <br />
                                        <asp:HyperLink ID="hypslide" runat="server" CssClass="button"></asp:HyperLink>
										 
									</div>
												 
       
<!--
 <form method="post" action="mailto:someone@example.com">
 Subject: <input type="text" size="10" maxlength="40" name="subject"> 

Message: <textarea rows="5" cols="20" wrap="physical" name="Message">
 </textarea>
 <input type="submit" value="Send">
 </form>
-->

										
															</article>
                                    </div>
                            </div>
                        </div>

                                       <div class="row">
                   
                    
										
               	
                                <asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium"></asp:Label>
                           
                                                              
                                                                  
        
                    
	           	

					</div>
                    <div class="row">
                   
                    
										
               	
                                <uc1:ad728 ID="ad728" runat="server"></uc1:ad728>
                           
                                                              
                                                                  
        
                    
	           	

					</div>
								</div>

						</div>
						
				
			

		</asp:Content>







