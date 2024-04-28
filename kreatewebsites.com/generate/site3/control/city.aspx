<%@ Page Language="C#" MasterPageFile="masterpage.Master" AutoEventWireup="true" CodeFile="city.aspx.cs" Inherits="Default" CodeFileBaseClass="BasePage" 
 %>
<%@    OutputCache Duration="86400" VaryByParam="*"  %>
<%@ Register Src="~/control/sidebar.ascx" TagName="right" TagPrefix="uc1" %>
<%@ Register Src="~/control/footer.ascx" TagName="foot" TagPrefix="uc1_foot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
		<!-- Main -->

			<div id="main-wrapper" class="subpage">
				<div class="5grid-layout">
                    <div class="row">
							<div class="12u">
								<div id="banner">
									
                                  
 <% Response.Write (slidestr); %>

									<div class="caption">
										<span><strong> <asp:Label ID="Label1" runat="server"> </asp:Label> </strong></span>
                                       
										
									</div>
								</div>
							</div>
						</div>
					<div class="row">
						<div class="6u">
					
							<!-- Content -->

								<article class="first">
								
									<h2><asp:Label ID="labeltitle" runat="server"></asp:Label></h2>

									<!--#include virtual="~/App_Code/uiblock/repeater-cities-1c.htm" -->

								</article>							

						</div>
						  <uc1:right ID="right" runat="server"></uc1:right>
					</div>
				</div>
			</div>
    <uc1_foot:foot ID="foot" runat="server"></uc1_foot:foot>
		</asp:Content>