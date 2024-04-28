
<%@ Page Language="C#" MasterPageFile="MasterPage-6-1.master" AutoEventWireup="true" CodeFile="~/article.aspx.cs" Inherits="Article" 
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

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
   
 </asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


						<header class="major">		
											
                                             <h2><asp:label runat="server" ID="title"></asp:label></h2>
											
									 <span class="byline"> <asp:Label ID="metadesc" runat="server" ></asp:Label></span>
						</header>										
                                            <asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium"></asp:Label>
	
                            <uc1:facebook ID="facebook" runat="server"></uc1:facebook>	
                            <br />
										
							           <uc1:ad728 ID="ad728" runat="server"></uc1:ad728>
                                        <br /><br />
	<!--
				 <asp:hyperlink ID="buttonmain"  runat="server" class="button" >             </asp:hyperlink>
                                                            <asp:hyperlink ID="buttonall"  runat="server" class="button button-alt" >             </asp:hyperlink>												
	-->

</asp:Content>