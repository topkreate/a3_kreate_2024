<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="slide.aspx.cs" Inherits="Photo" 
 CodeFileBaseClass="BasePage"  %>
<%@ Register Src="~/generate/articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="~/generate/articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="~/generate/articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="~/generate/articles-directory.ascx" TagName="articlesdir" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_display.ascx" TagName="facebook" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	<div id="main-wrapper">
				<div class="5grid-layout">

                    <div class="row">
							<div class="12u">
								<div id="banner">
									
                                  <span> <asp:Label ID="metadesc" runat="server" ></asp:Label></span>

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
								</div>
							</div>
						</div>


                <div class="row">
                   
                    
										
               	
                                <asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium"></asp:Label>
                           
                                                              
                                                                  
        
                    
	           	

					</div>
			
                    </div>		

		</asp:Content>







