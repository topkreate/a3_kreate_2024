<%@ Page Language="C#" MasterPageFile="masterpage.Master" AutoEventWireup="true" CodeFile="attractions.aspx.cs" Inherits="Default" CodeFileBaseClass="BasePage" 
 %>
<%@    OutputCache Duration="86400" VaryByParam="*"  %>
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
						<div class="3u">
						
							<!-- Sidebar 1 -->
							
								<section>
									<h3>Big cities</h3>
									<ul class="link-list">
										
                                     <li><a href="http://www.uscitytrip.net/city.aspx?name=Mumbai">Mumbai</a>
									<li><a href="http://www.uscitytrip.net/city.aspx?name=Delhi">Delhi</a>
									<li><a href="http://www.uscitytrip.net/city.aspx?name=Chennai">Chennai</a>
									<li><a href="http://www.uscitytrip.net/city.aspx?name=Kolkara">Kolkata</a>
									<li><a href="http://www.uscitytrip.net/city.aspx?name=Bangalore">Bangalore</a>
									</ul>
								</section>

								<section>
									<h3>Ads</h3>
									<p>
                                        <!--#include virtual="~/App_Code/appblock/ad250.htm" -->
																	
									</p>
                                    <h3>Monuments</h3>
									<ul class="link-list">
                                        <li><a href="http://www.uscitytrip.net/city.aspx?name=Jaipur">Jaipur</a>
									<li><a href="http://www.uscitytrip.net/city.aspx?name=Jodhpur">Jodhpur</a>
	                                 <li><a href="http://www.uscitytrip.net/city.aspx?name=Udaipur">Udaipur</a>
									<li><a href="http://www.uscitytrip.net/city.aspx?name=Agra">Agra</a>
                                    <li><a href="http://www.uscitytrip.net/city.aspx?name=Agra">Mysore</a>
										
									</ul>
								</section>
						
						</div>
						<div class="3u">
						
							<!-- Sidebar 2 -->
							
								<section>
									<h3>Ads</h3>
									<p>
										<!--#include virtual="~/App_Code/appblock/ad250.htm" -->						
									</p>
                                    <h3>Hill Stations</h3>
									<ul class="link-list">

										<li><a href="http://www.uscitytrip.net/city.aspx?name=Shimla">Shimla</a>
									<li><a href="http://www.uscitytrip.net/city.aspx?name=Manali">Manali</a>
	                                 <li><a href="http://www.uscitytrip.net/city.aspx?name=Ooty">Ooty</a>
									<li><a href="http://www.uscitytrip.net/city.aspx?name=Munnar">Munnar</a>
                                    <li><a href="http://www.uscitytrip.net/city.aspx?name=Darjeeling">Darjeeling</a>
									</ul>
								</section>

								<section class="last">
									<h3>Pilgrimage</h3>
									<ul class="link-list">
										<li><a href="http://www.uscitytrip.net/city.aspx?name=Tirupati">Tirupati</a>
									<li><a href="http://www.uscitytrip.net/city.aspx?name=Shirdi">Shirdi</a>
	                                 <li><a href="http://www.uscitytrip.net/city.aspx?name=Vaishnodevi">Vaishnodevi</a>
									<li><a href="http://www.uscitytrip.net/city.aspx?name=Ajmer">Ajmer</a>
                                    <li><a href="http://www.uscitytrip.net/city.aspx?name=Haridwar">Haridwar</a>
									</ul>
								</section>
						
						</div>
					</div>
				</div>
			</div>
    <uc1_foot:foot ID="foot" runat="server"></uc1_foot:foot>
		</asp:Content>