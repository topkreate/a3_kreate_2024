
<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="~/articlelist.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list2.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesd" TagPrefix="uc1" %>
<%@ Register Src="articles-sub-directory.ascx" TagName="articlessub" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad120.ascx" TagName="ad120" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_display.ascx" TagName="facebook" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	
	

                       <asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="1" RepeatDirection="Horizontal"  >
<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>


     <asp:Label ID="label1" runat="server"  ForeColor="Black" Font-Size="Medium" Text='<%# Eval("text")  %>'></asp:Label>


	</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Datalist>
                            <br />
    	<asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium"></asp:Label>
    <br />
                            <uc1:facebook ID="facebook" runat="server"></uc1:facebook>	
                            <br />
                            <br />
     <uc1:ad728 ID="ad728" runat="server"></uc1:ad728>
                            <br />
                            <uc1:articles ID="articles" runat="server"></uc1:articles>	

	

</asp:Content>