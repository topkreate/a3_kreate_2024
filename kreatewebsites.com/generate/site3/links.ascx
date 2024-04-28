<%@ Control Language="C#" AutoEventWireup="true" CodeFile="links.ascx.cs" Inherits="Default" %>
<%@ Register Src="control/mobilecompany3.ascx" TagName="mobilecompany" TagPrefix="uc1" %>
<%@ Register Src="control/mobileos3.ascx" TagName="mobileos" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<div class="4u">
					
						<section>
							<h2><asp:Label runat="server" ID="lblTitle"></asp:Label></h2>
							<div class="5grid">
								<div class="row">
									<div class="6u">
										<ul class="link-list">
											

                     <uc1:mobileos ID="mobileos" runat="server"></uc1:mobileos>	
                      
                 
											
										</ul>
									</div>
									<div class="6u">
										<ul class="link-list">
										
                
											
										</ul>
									</div>
								</div>
							</div>
						</section>

					</div>