
<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="article-slide.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list2.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div id="main-wrapper">
				<div class="5grid-layout">

                    <div class="row">
							<div class="12u">
								<div id="banner">
									
                                  
 <% Response.Write (slidestr); %>

									<div class="caption">
										<span><strong> </strong><asp:Label ID="lblslide" runat="server"></asp:Label></span>
                                        <asp:HyperLink ID="hypslide" runat="server" CssClass="button"></asp:HyperLink>
										
									</div>
								</div>
							</div>
						</div>

              

                    <!-- Divider -->

						

                    <!-- Features -->
						<div class="row">
													
                                                              
                                                                   <asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium"></asp:Label>
        
	            	</div>	

                    <div class="row">
							<div class="12u" align="center">
								<div class="divider divider-top"></div>
                                <uc1:ad728 ID="ad728" runat="server"></uc1:ad728>
                               
							</div>
						</div>

                      <div class="row">
							<div class="12u" align="center">
								<div class="divider divider-top"></div>
                                

                                
							<asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="4" RepeatDirection="Horizontal"  >
<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>


				  <blockquote>  <asp:Hyperlink ID="hyperlink1" runat="server"  Text='<%# Eval("name")  %>'  NavigateUrl='<%#  DataBinder.Eval(Container.DataItem, "name") + ".html" %>' /></blockquote>
													
					
                   
<asp:hyperlink ID="imghyperlink" runat="server" NavigateUrl='<%#   DataBinder.Eval(Container.DataItem, "name") + ".html" %>'>
                                                      <asp:Image ID="Image1" runat="server"  Width="300px"  
                ImageUrl='<%# Eval("url", "{0}") %>' alt='<%# "image gallery of " + Eval("name") %>'
                                                NavigateUrl='<%#  Eval("name") + ".html" %>'              />
                                                 </asp:hyperlink>

                                              
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                							
		

  </div>

</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Datalist>




							</div>
						</div>

                             <!-- Highlight Box -->
                    <div class="row">
							<div class="12u">
								<div class="highlight-box">
									                               
                                   <h3> Read More Articles : </h3>
									 <uc1:articles ID="articles" runat="server"></uc1:articles>	
								</div>
							</div>
						</div>
            
           

                            <div class="row">
							<div class="12u" align="center">
								<div class="divider divider-top"></div>
                              
                                <uc1:ad728 ID="ad1" runat="server"></uc1:ad728>
							</div>
						</div>
      	</div>
			</div>										

</asp:Content>