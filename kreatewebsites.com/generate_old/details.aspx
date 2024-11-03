<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="details.aspx.cs" Inherits="Default" CodeFileBaseClass="BasePage" 
     %>
<%@ Register Src="articles-directory.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<%@ Register Src="footer.ascx" TagName="footer" TagPrefix="uc1" %>
<html lang="en">
	<head runat="server">
		<title></title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8" />
		<meta name="description" content="" />
		<meta name="keywords" content="" />
		<link href="http://fonts.googleapis.com/css?family=Open+Sans+Condensed:300,300italic,700" rel="stylesheet" />
		<noscript><link rel="stylesheet" href="css/5grid/core.css" /><link rel="stylesheet" href="https://pictures.kreatewebsites.com/site1/css/5grid/core-desktop.css" /><link rel="stylesheet" href="https://pictures.kreatewebsites.com/site1/css/5grid/core-1200px.css" /><link rel="stylesheet" href="https://pictures.kreatewebsites.com/site1/css/5grid/core-noscript.css" /><link rel="stylesheet" href="css/style.css" /><link rel="stylesheet" href="https://pictures.kreatewebsites.com/site1/css/style-desktop.css" /></noscript>
		<script src="https://pictures.kreatewebsites.com/site1/css/5grid/jquery.js"></script>
		<script src="https://pictures.kreatewebsites.com/site1/css/5grid/init.js?use=mobile,desktop,1000px&amp;mobileUI=1&amp;mobileUI.theme=none&amp;mobileUI.titleBarHeight=60&amp;mobileUI.openerWidth=52"></script>
		<!--[if IE 9]><link rel="stylesheet" href="https://pictures.kreatewebsites.com/site1/css/style-ie9.css" /><![endif]-->
	</head>
	<body>

		<!-- Header -->

			<div id="header-wrapper">
				<header class="5grid-layout" id="site-header">
					<div class="row">
						<div class="12u">
							<div id="logo">
								
                                    <h3>
                                    <asp:Hyperlink ID="topheader" class="mobileUI-site-name" runat="server"> </asp:Hyperlink>
								</h3>
							</div>
							<nav class="mobileUI-site-nav" id="site-nav">
								<ul>
								<uc1:articles ID="articles" runat="server"></uc1:articles>	
								</ul>
							</nav>
						</div>
					</div>
				</header>
			</div>

		<!-- Main -->

			<div id="main-wrapper">
				<div class="5grid-layout">
					
					<!-- Banner -->

						<div class="row">
							<div class="12u">
								<div id="banner">
									
                                                                    
                                        <asp:image ID="imgMainImage" runat="server" ></asp:image>
									<div class="caption">
										<span><strong>Hill Station - </strong></span>
                                        	<a href="https://www.kreatewebsites.com/address/" class="button">Find Parlor</a>
										<a href="https://www.kreatewebsites.com/tutorial/" class="button"> Beauty Tutorial</a>
									
									</div>
								</div>
							</div>
						</div>

					<!-- Features -->
                    	<div class="row" align="center">
                         
                    <uc1:ad728 ID="ad728" runat="server"></uc1:ad728>
	
                            </div>

						<div class="row">
                            <h1><asp:Label ID="lblTitle" runat="server"></asp:Label></h1>
                              </div>
             



						


					<!-- Highlight Box -->

                          

						<div class="row">
							<div class="12u">
								<div class="highlight-box">
									
                                    <h3> <asp:Label ID="heading3" runat="server"></asp:Label></h3>
                                    
									<span><asp:Label ID="lblDescription" runat="server"></asp:Label>

                                        <h2><asp:Label ID="heading2" runat="server"></asp:Label></h2>
                                        </span>
								</div>
							</div>
						</div>

					<!-- Divider -->
                      <div class="row" align="center">
                               
                    <uc1:ad728 ID="ad1" runat="server"></uc1:ad728>
                                   
                            </div>
						<div class="row">
							<div class="12u">
								<div class="divider divider-bottom"></div>
							</div>
						</div>

					<!-- Thumbnails -->

						

				</div>
			</div>

		<!-- Footer -->

					<uc1:footer ID="footer" runat="server"></uc1:footer>	

	</body>
</html>