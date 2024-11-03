
<%@ Page Language="C#" MasterPageFile="MasterPage2024.master" AutoEventWireup="true" CodeFile="~/articlelist_2023.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="1022-articles-list.ascx" TagName="articles1022" TagPrefix="uc1" %>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="1022-articles-list-home.ascx" TagName="articleshome1022" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdirectory" TagPrefix="uc1" %>
<%@ Register Src="articles-directory-limited.ascx" TagName="articlesdirectorylimited" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad120.ascx" TagName="ad120" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad160.ascx" TagName="ad160" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_display.ascx" TagName="facebook" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


	   <h1 class="display-1"><asp:label runat="server" ID="title"></asp:label></h1>
                    <h4 class="mb-4"><asp:label ID="metadesc" runat="server" ></asp:label></h4>
	
					
		
    <br />  					
							
										
										 <asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="1" RepeatDirection="Horizontal"  >
											<HeaderTemplate>

											</HeaderTemplate>
											<ItemTemplate>
											<asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium" Text='<%# Eval("text")  %>'></asp:Label>
											</ItemTemplate>
										</asp:Datalist>

								


<uc1:articles1022 ID="Articleslist1" runat="server"></uc1:articles1022>

<uc1:articleshome1022 ID="Articleslisthome1" runat="server"></uc1:articleshome1022>




	<!-- 
	<p>Article List 2</p>
<uc1:articles2 ID="Articleslist3" runat="server"></uc1:articles2>

		<p>Article List Directory </p>
<uc1:articlesdirectory ID="Articleslist2" runat="server"></uc1:articlesdirectory>
	<p>Article List Directory Limited</p>
<uc1:articlesdirectorylimited ID="Articleslistdirectory1" runat="server"></uc1:articlesdirectorylimited>

		-->




</asp:Content>