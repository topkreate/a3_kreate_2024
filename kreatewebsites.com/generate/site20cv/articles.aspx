
<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="~/articles.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list2.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesd" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad120.ascx" TagName="ad120" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_display.ascx" TagName="facebook" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


   
	<div id="hd">
			<div class="yui-gc">
				<div class="yui-u first">
					<h1> <asp:Label ID="title" runat="server" ></asp:Label></h1>
					<h2>Software Developer, Architect </h2>
				</div>

				<div class="yui-u">
					<div class="contact-info">
						<h3><a id="pdf" href="#">Download PDF</a></h3>
						<h3><a href="mailto:name@yourdomain.com">name@hotmail.com</a></h3>
						<h3>(XXX) - XXX-XXXX</h3>
					</div><!--// .contact-info -->
				</div>
			</div><!--// .yui-gc -->
		</div><!--// hd -->

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
                            <br />
                                                                   <asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium"></asp:Label>
                            <br /><br />
                            <uc1:facebook ID="facebook" runat="server"></uc1:facebook>	
                           
                            <br />
                            <uc1:articles ID="articles" runat="server"></uc1:articles>	
        	
			
</asp:Content>