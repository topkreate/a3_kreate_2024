<%@ Page Language="C#" MasterPageFile="masterpage.Master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Default" CodeFileBaseClass="BasePage" 
     %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


		
		<!-- Main -->

			<div id="main-wrapper">
				<div class="5grid-layout">
					
					<!-- Banner -->

						<div class="row">
							<div class="12u">
								<div id="banner">
									
                                  
 <% Response.Write (slidestr); %>

									<div class="caption">
										<span><strong> <asp:Label ID="Labeltitle" runat="server"> </asp:Label> </strong></span>
                                        <asp:HyperLink ID="HyperLink1" runat="server" class="button"  /> 
										
									</div>
								</div>
							</div>
						</div>

					<!-- Features -->

						<div class="row">

           
								<!--#include virtual="repeater-cities-1a.htm" -->
                          
						</div>

					<!-- Divider -->

						<div class="row">
							<div class="12u">
								<div class="divider divider-top"></div>
							</div>
						</div>

					<!-- Highlight Box -->

						<div class="row">
							<div class="12u">
								<div class="highlight-box">
									<p><asp:Label ID="labelHeader" runat="server"></asp:Label></p><br />
                                    <p><asp:Label ID="labelPlaces" runat="server"></asp:Label></p><br />
                                    <asp:HyperLink ID="HyperLinkMore" runat="server" class="button"  /> 
                                    
									
								</div>
							</div>
						</div>

					<!-- Divider -->

						<div class="row">
							<div class="12u">
								<div class="divider divider-bottom"></div>
							</div>
						</div>

					<!-- Thumbnails -->

						<div class="row">
							<div class="12u">
								<section class="thumbnails first last">
									<div class="5grid">
										<div class="row">
                                            <div align ="center">
											<!--#include virtual="~/appblock/inc/ad728.ad" -->
                                                </div>
										</div>
										<div class="row">
											<div class="12u">
												<div class="divider"></div>
											</div>
										</div>
										<div class="row">
                                            <div align="center">
											<!--#include virtual="~/appblock/inc/ad728.ad" -->
                                                </div>
										</div>
									</div>
								</section>
							</div>
						</div>

					<!-- Divider -->

						<div class="row">
							<div class="12u">
								<div class="divider divider-top"></div>
							</div>
						</div>
						
					<!-- CTA Box -->

						<div class="row">
							<div class="12u">
								<div class="cta-box">
                                    <span><asp:Label ID="Label11" runat="server"> </asp:Label> </span>
                                    
                                      <asp:HyperLink ID="HyperLink11" runat="server" class="button"  /> 
									
								</div>
							</div>
						</div>

				</div>
			</div>

	
</asp:Content>