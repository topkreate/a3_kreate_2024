<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sidebar.ascx.cs" Inherits="sidebar" %>
					
	<%@ Register Src="featured.ascx" TagName="featured" TagPrefix="ucl" %>
	<%@ Register Src="list-places.ascx" TagName="places" TagPrefix="ucl" %>
	<%@ Register Src="list-cities.ascx" TagName="cities" TagPrefix="ucl" %>
	<%@ Register Src="list-category.ascx" TagName="category" TagPrefix="ucl" %>
	<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="ucl" %>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="ucl" %>
						<div class="3u">
						
							<!-- Sidebar 1 -->
							
								<section>
									<h3>Best Places</h3>
									<ul class="link-list">
										
                                    <ucl:places ID="places" runat="server"/>
									</ul>
								</section>

								<section>
									<h3>Ads</h3>
									<p>
                                        <!--#include virtual="~/appblock/ad250.htm" -->
																	
									</p>
                                    <h3>Best cities</h3>
									<ul class="link-list">
                                       
                                        <ucl:cities ID="cities" runat="server"/>
										
									</ul>
                                     <h3>What to see</h3>
                                    <ul class="link-list">
                                       
                                        <ucl:category ID="category" runat="server"/>
										
									</ul>
								</section>
						
						</div>
						<div class="3u">
						
							<!-- Sidebar 2 -->
							
								<section>
									<h3>Ads</h3>
									<p>
										<!--#include virtual="~/appblock/ad250.htm" -->						
									</p>
                                    <h3>Main Topic</h3>
									<ul class="link-list">

										<ucl:articleshome ID="articleshome" runat="server"/>
									
									</ul>
								</section>

								<section class="last">
									<h3>Related Topics</h3>
									<ul class="link-list">
										<ucl:articles ID="articles" runat="server"/>
									</ul>
								</section>
                            <ucl:featured ID="featured" runat="server"/>
                              
						
						</div>
					