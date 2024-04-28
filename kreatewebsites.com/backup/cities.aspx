<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="cities.aspx.cs" Inherits="Default" CodeFileBaseClass="BasePage" 
     %>
<%@ Register Src="~/generate/articles-directory.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<%@ Register Src="~/generate/footer.ascx" TagName="footer" TagPrefix="uc1" %>
<%@ Register Src="~/Controlslide2/best.ascx" TagName="best" TagPrefix="uc1" %>
<html>
	<head runat="server">
		<title></title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8" />
		<meta name="description" content="" />
		<meta name="keywords" content="" />
		<link href="http://fonts.googleapis.com/css?family=Open+Sans+Condensed:300,300italic,700" rel="stylesheet" />
		<noscript><link rel="stylesheet" href="https://pictures.kreatewebsites.com/site1/css/5grid/core.css" /><link rel="stylesheet" href="https://pictures.kreatewebsites.com/site1/css/5grid/core-desktop.css" /><link rel="stylesheet" href="https://pictures.kreatewebsites.com/site1/css/5grid/core-1200px.css" /><link rel="stylesheet" href="https://pictures.kreatewebsites.com/site1/css/5grid/core-noscript.css" /><link rel="stylesheet" href="css/style.css" /><link rel="stylesheet" href="https://pictures.kreatewebsites.com/site1/css/style-desktop.css" /></noscript>
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
								<h1 >
                                    
                                    <asp:Hyperlink ID="topheader" class="mobileUI-site-name" runat="server"> </asp:Hyperlink>
								</h1>
							</div>
							<nav class="mobileUI-site-nav" id="site-nav">
								<ul>

								
                               <li>   <a href="https://www.kreatewebsites.com/cities.aspx">Top Cities</a> </li> 
                                 <li>    <a href="https://www.kreatewebsites.com/cities.aspx">Regions</a> </li> 

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

							<uc1:best ID="best" runat="server"></uc1:best>


                                   	<h4 class="title"> <asp:Label ID="lblTitle"  runat="server"></asp:Label></h4>


					<div class="row">
					
					
							<!-- Content -->

						
														
					
		
			
	
    
<asp:DataList ID="RepDetails" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"    >

<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>

    <div class="3u" style="WIDTH: 300px">
								<section>

<h2>
     <asp:HyperLink ID="HyperLink1" runat="server" Text='<%#Eval("city")%>'                                          
                                      NavigateUrl='<%# Eval("cityurl")     %>' >
                                           </asp:HyperLink>
      
      
</h2>
<p>
         
    <asp:HyperLink ID="HyperLink4" runat="server" Text='<%#Eval("region")%>'                                          
                                      NavigateUrl='<%# Eval( "stateurl")                                      %>' >
                                           </asp:HyperLink>
 
 </p>





      
	</section>
</div>
</ItemTemplate>

<FooterTemplate>



</FooterTemplate>

</asp:DataList>
						
	</div>	

					<!-- Features -->
                    	
			</div>
                </div>
		<!-- Footer -->

					

	</body>
</html>