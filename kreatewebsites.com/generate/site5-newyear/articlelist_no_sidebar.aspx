﻿
<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="~/articlelist.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="~/generate/site5/articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="~/generate/site5/articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="~/generate/site5/articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="~/generate/site5/articles-directory.ascx" TagName="articlesdirectory" TagPrefix="uc1" %>
<%@ Register Src="~/generate/site5/articles-directory-limited.ascx" TagName="articlesdirectorylimited" TagPrefix="uc1" %>
<%@ Register Src="~/generate/site5/articles-sub-directory.ascx" TagName="articlesub" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad120.ascx" TagName="ad120" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad160.ascx" TagName="ad160" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_display.ascx" TagName="facebook" TagPrefix="uc1" %>
<%@ Register Src="~/generate/site5/articles-directory-limited-button.ascx" TagName="articlesbutton" TagPrefix="uc1" %>
<%@ Register Src="~/generate/site5/articles-sub-directory-limited-button.ascx" TagName="articlessubdirectorybutton" TagPrefix="uc1" %>
<%@ Register Src="~/generate/site5/articles-list-limited-button.ascx" TagName="articleslistbutton" TagPrefix="uc1" %>
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
						
					</div>
				</div>
			</div>

  			


</asp:Content>