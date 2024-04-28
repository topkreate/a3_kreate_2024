<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="~/gallery.aspx.cs" Inherits="Photos" 
Title="Photos - Sale on Thanks Giving and Black Friday"  CodeFileBaseClass="BasePage"  %>

<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdir" TagPrefix="uc1" %>
<%@ Register Src="articles-directory-limited.ascx" TagName="articlesd" TagPrefix="uc1" %>
<%@ Register Src="articles-sub-directory.ascx" TagName="articlesub" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
	
   
<div id="main">
			<div class="5grid-layout">
				<div class="row main-row">
					<div class="8u">
						
						<section class="left-content">							
					
					

															
																<h3><asp:label runat="server" ID="title"></asp:label></h3>
														
																
													
													


                                         
											
										
										
                                           

							<asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="3" RepeatDirection="Horizontal"  >
<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>


					
                   
<asp:hyperlink ID="imghyperlink" runat="server" NavigateUrl='<%#   DataBinder.Eval(Container.DataItem, "navigateurl2")  %>'>
                                                      <asp:Image ID="Image1" runat="server"   
                ImageUrl='<%# Eval("url", "{0}") %>' alt='<%#  Eval("alt") %>'
                                                NavigateUrl='<%#  Eval("linkurl")  %>'              />
                                                 </asp:hyperlink>

                                            
				 <blockquote>  <asp:Hyperlink ID="hyperlink1" runat="server"  Text='<%# Eval("displayname")  %>'   /></blockquote>
                    							
		

  </div>

</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Datalist>
										
									<asp:Label ID="labeltext" runat="server"></asp:Label>	

                            <br />
                              <asp:Datalist ID="RepComments" runat="server"  RepeatColumns="1" RepeatDirection="Horizontal"  >
<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>


					
                   

												 
               							
		

      <asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium" Text='<%# Eval("text")  %>'></asp:Label>
    <br />


</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Datalist>           
                                        <br />
                                        <br /> 	
                                      <uc1:articlesub ID="articlesub" runat="server"></uc1:articlesub>	              														

		 	</section>
					
					</div>
					<div class="4u">

						<section>
							<h2>Advertisement</h2>
							<ul class="small-image-list">
								
                                <uc1:ad300 ID="ad300" runat="server"></uc1:ad300>	
							</ul>
						</section>
					
						<section>
							<h2>Articles</h2>
							<div class="5grid">
								<div class="row">
									<div class="6u">
										<ul class="link-list">
											 <uc1:articles ID="articles" runat="server"></uc1:articles>	
										</ul>
									</div>
									<div class="6u">
										<ul class="link-list">
											 <uc1:articleshome ID="articleshome" runat="server"></uc1:articleshome>	
                                            <uc1:articlesd ID="articlesd" runat="server"></uc1:articlesd>
                                             <uc1:articlesub ID="articlesub1" runat="server"></uc1:articlesub>
                                            	
										</ul>
									</div>
								</div>
							</div>
						</section>

					</div>
				</div>
			</div>
		</div>
                
																

</asp:Content>