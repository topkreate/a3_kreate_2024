
<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list2.ascx" TagName="articles" TagPrefix="uc1" %>
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
													
                              <div class="3u">
								<section class="first">
									<h2>Engage Users</h2>
									<p><strong>Beautiful sites</strong> engage user.  User consume more content, do more transaction and spend more time on website. </p>
								</section>							
							</div>
							<div class="3u">
								<section>
									<h2>Fast</h2>
									<p>These sites are not only pretty looking but perform very fast. Design is simple and only load require objects thus increasing page speed.</p>
								</section>							
							</div>
							<div class="3u">
								<section>
									<h2>Windows Android</h2>
									<p><strong>HTML5</strong> based web portals works well on any operating system - Windows, Android, MAC. Users using any operating sytem will see greate sites. </p>
								</section>							
							</div>
							<div class="3u">
								<section class="last">
									<h2>Form Factor</h2>
									<p>The theme and css used here adjust automatically to device size. Whether you are using large LCD, standard laptop monitor, 9 inch tablel or smart phone - site will look greate! </p>
                                    			      </section>							
							</div>                                
                                                                
        
		             </div>	

                    <div class="row">
							<div class="12u" align="center">
								<div class="divider divider-top"></div>
                                <!--#include virtual="~/appblock/ad728.htm" -->
							</div>
						</div>

                      

                             <!-- Highlight Box -->
                    
            
           

                            <div class="row">
							<div class="12u" align="center">
								<div class="divider divider-top"></div>
                                <!--#include virtual="~/appblock/ad728.htm" -->
							</div>
						</div>
      	</div>
			</div>										

</asp:Content>