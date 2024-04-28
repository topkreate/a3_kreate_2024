<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="slide.aspx.cs" Inherits="Photo" 
 CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdir" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	<div id="main-wrapper">
				<div class="5grid-layout">

                    <div class="row">
							<div class="12u">
								<div id="banner">
									
                                  

                                       <asp:image ID="imgMainImage" runat="server" width="1200"></asp:image>

									<div class="caption">
										<span><strong> </strong><asp:Label ID="lblslide" runat="server"></asp:Label></span>
                                        <asp:HyperLink ID="hypslide" runat="server" CssClass="button"></asp:HyperLink>
										
									</div>
								</div>
							</div>
						</div>


                    <div class="row">
													
                                                              
                                                                   <asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium"></asp:Label>
        
	            	</div>	

					</div>
			</div>		

		</asp:Content>







