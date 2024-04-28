
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="masterpage.ascx.cs" Inherits="mastercontrol" %>
	


<%@ Register Src="~/control/places-list.ascx" TagName="middle" TagPrefix="uc1" %>
<%@ Register Src="~/control/restaurants-list.ascx" TagName="right" TagPrefix="uc1" %>
<%@ OutputCache Duration="86400" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	<head id="head1" runat="server">
		<title>Cheap Websites</title>
		 
		<meta http-equiv="content-type" content="text/html; charset=utf-8" />
		<noscript><link rel="stylesheet" href="http://www.yellp.mobi/site2/css/5grid/core.css" /><link rel="stylesheet" href="http://www.yellp.mobi/site2/css/5grid/core-desktop.css" /><link rel="stylesheet" href="http://www.yellp.mobi/site2/css/5grid/core-1200px.css" /><link rel="stylesheet" href="http://www.yellp.mobi/site2/css/5grid/core-noscript.css" /><link rel="stylesheet" href="http://www.yellp.mobi/site2/css/style.css" /><link rel="stylesheet" href="http://www.yellp.mobi/site2/css/style-desktop.css" /></noscript>
		<script src="http://www.yellp.mobi/site2/css/5grid/jquery.js"></script>
		<script src="http://www.yellp.mobi/site2/css/5grid/init.js?use=mobile,desktop,1000px&amp;mobileUI=1&amp;mobileUI.theme=none&amp;mobileUI.titleBarHeight=55&amp;mobileUI.openerWidth=75&amp;mobileUI.openerText=&lt;"></script>
		<!--[if lte IE 9]><link rel="stylesheet" href="http://www.yellp.mobi/site2/css/style-ie9.css" /><![endif]-->
	</head>
	<body>

		<!-- Header -->
			<div id="header-wrapper">
				
                <header id="header" class="5grid-layout">
					<div class="row">
						<div class="12u">
						
							<!-- Logo -->
								<h1><a href="http://www.vancouver-bc.biz/" class="mobileUI-site-name">Websites for Mobiles</a></h1>
							
							<!-- Nav -->
								<nav class="mobileUI-site-nav">
									<a href="http://www.vancouver-bc.biz/">Homepage</a>
									<a href="http://www.vancouver-bc.biz/webdesign.php">Web Design</a>
									<a href="http://www.vancouver-bc.biz/prices.php">Price</a>
									<a href="http://www.vancouver-bc.biz/portfolio.php">Our Portfolio</a>
									<a href="http://www.vancouver-bc.biz/aboutus.php">About us</a>
								</nav>

						</div>
					</div>
				</header>
				
			

		<div id="banner">
					<div class="5grid-layout">
						<div class="row">
							<div class="6u">
							
								<!-- Banner Copy -->
									<p><asp:Label ID="Labeltitle" runat="server"> </asp:Label></p>
									<a href="http://www.vancouver-bc.biz/price.php" class="button-big">See Price!</a>

							</div>
							<div class="6u">
								
								<!-- Banner Image -->
									<a href="#" class="bordered-feature-image"> <% Response.Write (slidestr); %></a>
							
							</div>
						</div>
					</div>
				</div>
		</div>
		<!-- Features -->
			<div id="features-wrapper">
				<div id="features">
					<div class="5grid-layout">
						<div class="row">
							<!--#include virtual="~/App_Code/uiblock/repeater-cities-2-1.htm" -->
						</div>
					</div>
				</div>
			</div>

		<!-- Content -->
			<div id="content-wrapper">
				<div id="content">
					<div class="5grid-layout">
						<div class="row">
							<div class="4u">

								<!-- Box #1 -->
									<section>
										<header>
											<h2>What to see</h2>
											<h3>Web Developers</h3>
										</header>
										<a href="#" class="feature-image"><img src="http://www.yellp.mobi/site2/images/pic05.jpg" alt="" /></a>
										<p>
											Team of web designers, developers, content writer. 
											Dedicate to serve customer needs 
											Committed to excel and provide best services.
										</p>
									</section>

							</div>
							
                               <uc1:middle ID="middle" runat="server"></uc1:middle>
							<div class="4u">
								
								<!-- Box #3 -->
									
                                <uc1:right ID="right" runat="server"></uc1:right>
							</div>
						</div>
					</div>
				</div>
			</div>

		<!-- #include virtual= "~/footer.htm" --> 
		

		<!-- Copyright -->
		<!-- #include virtual= "~/copyright.htm" --> 
		
	</body>
</html>