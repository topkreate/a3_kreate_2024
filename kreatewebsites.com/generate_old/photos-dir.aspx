<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="photos-dir.aspx.cs" Inherits="Photos" 
Title="Photos - Sale on Thanks Giving and Black Friday"  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list2.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
		 <div id="main-wrapper">
				<div class="5grid-layout">
                       <!-- Highlight Box -->
                 

                    <!-- Divider -->

						

                    <!-- Features -->
						<div class="row">									
					

															
																<h3><asp:label runat="server" ID="lblTitle"></asp:label></h3>
														
																
													
													


                                         
											
										
										
                                           

							<asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="4" RepeatDirection="Horizontal"  >
<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>


					
                   
<asp:hyperlink ID="imghyperlink" runat="server" NavigateUrl='<%#   DataBinder.Eval(Container.DataItem, "name") + ".html" %>'>
                                                      <asp:Image ID="Image1" runat="server" Height="100px" Width="100px"  
                ImageUrl='<%# Eval("url", "{0}") %>' alt='<%# "image gallery of " + Eval("name") %>'
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

                                                           														

										
		
                            
                            	
									</div>	

          	
                
           

                            <div class="row">
							<div class="12u" align="center">
								<div class="divider divider-top"></div>
                                <uc1:ad728 ID="ad728" runat="server"></uc1:ad728>
							</div>
						</div>

                        <div class="row">
							<div class="12u">
								<div class="highlight-box">
									                               
                                   <h3> Read More Articles : </h3>
									 <uc1:articles ID="articles" runat="server"></uc1:articles>	
								</div>
							</div>
						</div>
            

      	</div>
			</div>														

</asp:Content>