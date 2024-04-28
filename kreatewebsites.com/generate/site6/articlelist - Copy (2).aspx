﻿
<%@ Page Language="C#" MasterPageFile="MasterPage_2023.master" AutoEventWireup="true" CodeFile="~/articlelist_2023.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>
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
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <!-- Main Wrapper -->
			<div id="main-wrapper">
				<div class="5grid-layout">
					<div class="row">
						<div class="8u mobileUI-main-content">

							<!-- Content -->
								<div id="content">
									<article class="last">
										<!--
										<h2><asp:label runat="server" ID="title"></asp:label></h2>
										-->
										
										 <asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="1" RepeatDirection="Horizontal"  >
											<HeaderTemplate>

											</HeaderTemplate>
											<ItemTemplate>
											<asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium" Text='<%# Eval("text")  %>'></asp:Label>
											</ItemTemplate>
										</asp:Datalist>

								
									</article>
								</div>

						</div>					
						<div class="4u">
						
							<!-- Sidebar -->
								<div id="sidebar">
									<!--
									<section>
										<h3>Related Links</h3>
										<p>
                                            <uc1:ad300 ID="ad300" runat="server"></uc1:ad300>
										</p>
										<footer>
                                             <asp:hyperlink ID="buttonMore"  runat="server" class="button button-icon button-icon-info" >             </asp:hyperlink>	
											
										</footer>
									</section>
									-->

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