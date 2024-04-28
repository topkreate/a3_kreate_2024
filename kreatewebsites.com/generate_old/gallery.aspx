<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="gallery.aspx.cs" Inherits="Photos" 
Title="Photos - Sale on Thanks Giving and Black Friday"  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
			<div id="main-wrapper" class="subpage">
				<div class="5grid-layout">
					<div class="row">
						<div class="9u">
					
							<!-- Content -->

								<article class="first">
														
					

															
																<h3><asp:label runat="server" ID="lblTitle"></asp:label></h3>
														
																
													
													


                                         
											
										
										
                                           

							<asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="6" RepeatDirection="Horizontal"  >
<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>


					
                   
<asp:hyperlink ID="imghyperlink" runat="server" NavigateUrl='<%#   DataBinder.Eval(Container.DataItem, "url")  %>'>
                                                      <asp:Image ID="Image1" runat="server" Height="100px" Width="100px"  
                ImageUrl='<%# Eval("url", "{0}") %>' alt='<%# "image gallery of " + Eval("name") %>'
                                                NavigateUrl='<%#  Eval("url")  %>'              />
                                                 </asp:hyperlink>

                                                <blockquote>  <asp:Hyperlink ID="hyperlink1" runat="server"  Text='<%# Eval("name")  %>'  NavigateUrl='<%#  DataBinder.Eval(Container.DataItem, "url")  %>' /></blockquote>
													
				
                    							
		

  </div>

</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Datalist>
										
									<asp:Label ID="labeltext" runat="server"></asp:Label>	

                                                           														

										
		</article>							

						</div>
                            
                  <div class="3u">
						
							<!-- Sidebar -->
							
								<section>
									<h3>Ads and Deals</h3>
									<ul class="link-list">
									 <uc1:ad300 ID="ad300" runat="server"></uc1:ad300>
									</ul>
								</section>

								<section class="last">
									<h3>Topics</h3>
								
									<ul class="link-list">
											 <uc1:articles ID="articles" runat="server"></uc1:articles>	
									</ul>
								</section>
						
						</div>
					</div>
				</div>
			</div>
          	
																

</asp:Content>