<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="slides.aspx.cs" Inherits="Photos" 
Title="Photos - Sale on Thanks Giving and Black Friday"  CodeFileBaseClass="BasePage"  %>

<%@ Register Src="~/generate/site3/articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="~/generate/site3/articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="~/generate/site3/articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="~/generate/site3/articles-directory.ascx" TagName="articlesdir" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
	
   
				
				<div align="left">
<form id="Form1" runat="server">		

															
																<h3><asp:label runat="server" ID="lblTitle"></asp:label></h3>
														
																
													
													


                                         
											
										
										
                                           

							<asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="4" RepeatDirection="Horizontal"  >
<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>


					
                   
<asp:hyperlink ID="imghyperlink" runat="server" NavigateUrl='<%#   DataBinder.Eval(Container.DataItem, "name") + ".html" %>'>
                                                      <asp:Image ID="Image1" runat="server" Height="100px" Width="100px"  
                ImageUrl='<%# Eval("thumbnailurl", "{0}") %>' alt='<%# "image gallery of " + Eval("name") %>'
                                                NavigateUrl='<%#  Eval("name") + ".html" %>'              />
                                                 </asp:hyperlink>

                                                <blockquote>  <asp:Hyperlink ID="hyperlink1" runat="server"  Text='<%# Eval("name")  %>'  NavigateUrl='<%#  DataBinder.Eval(Container.DataItem, "name") + ".html" %>' /></blockquote>
													
				
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                							
		

  </div>

</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Datalist>
										
									<asp:Label ID="labeltext" runat="server"></asp:Label>	

                                                           														

										
	   </form>
                     <uc1:articles2 ID="articles2" runat="server"></uc1:articles2>	
</div>
                         												

</asp:Content>