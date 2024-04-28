<%@ Page Language="C#" Debug="true"  MasterPageFile="masterpage.Master" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="About" CodeFileBaseClass="BasePage" 
 %>
<%@ Register Src="~/control/sidebar.ascx" TagName="sidebar" TagPrefix="uc1" %>

<%@ Register Src="~/control/links.ascx" TagName="links" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
 </asp:Content>

<%@ OutputCache Duration="86400" VaryByParam="*" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
		
		<!-- Main Wrapper -->
			<div id="main-wrapper">
				<div class="5grid-layout">
					<div class="row">
						<div class="4u">
						
							<!-- Sidebar -->
								<uc1:sidebar ID="sidebar" runat="server"></uc1:sidebar>
						
						</div>
						<div class="8u mobileUI-main-content">
                             
							<!-- Content -->
								<div id="content">
									<article class="last">

										   <!-- #include virtual= "~/App_Code/uiblock/topic.inc" --> 
										
										<uc1:links ID="links" runat="server"></uc1:links>
										

									</article>
								</div>

						</div>
					</div>
				</div>
			</div>

		</asp:Content>