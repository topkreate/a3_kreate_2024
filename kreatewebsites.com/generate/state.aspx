<%@ Page Language="C#" MasterPageFile="masterpage.Master" AutoEventWireup="true" CodeFile="state.aspx.cs" Inherits="Default" CodeFileBaseClass="BasePage" 
     %>
<%@    OutputCache Duration="86400" VaryByParam="*"  %>
<%@ Register Src="~/control/footer.ascx" TagName="foot" TagPrefix="uc1_foot" %>
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
										<span><strong> </strong><% Response.Write(Page.Title); %></span>
										<a href="#" class="button">Find Out More!</a>
									</div>
								</div>
							</div>
						</div>

					<!-- Features -->

						<div class="row">

           
								<!--#include virtual="~/App_Code/uiblock/repeater-cities-1a.htm" -->
                          
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
                                    <p><asp:Label ID="labelPlaces" runat="server"></asp:Label></p> <br />
                                   
                                     <asp:HyperLink ID="HyperLink3" runat="server" class="button"  /> 
									
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
											<!--#include virtual="~/App_Code/appblock/ad728.htm" -->
                                                </div>
										</div>
										<div class="row">
											<div class="12u">
												<div class="divider"></div>
											</div>
										</div>
										<div class="row">
                                            <div align="center">
											<!--#include virtual="~/App_Code/appblock/ad728.htm" -->
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

		<!-- Footer -->
    <uc1_foot:foot ID="foot" runat="server"></uc1_foot:foot>

</asp:Content>