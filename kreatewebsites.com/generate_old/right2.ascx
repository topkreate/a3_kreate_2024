<%@ Control Language="C#" AutoEventWireup="true" CodeFile="right2.ascx.cs" Inherits="Kerala_right" %>
 <%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
 <%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad160.ascx" TagName="ad160" TagPrefix="uc1" %>
<div id="sidebar">
			
		<div id="onecol">
			
<div id="tabbed-area">
			
	<ul class="clearfix" id="tab_controls">
		<li class="first active"><a href="#"><span>Europe</span></a></li>
		<li class="second"><a href="#"><span>America</span></a></li>
		<li class="last"><a href="#"><span>Asia</span></a></li>
	</ul>
	
	<div id="all_tabs" class="clearfix">
		<div style="display: block;" class="widget popular">
			<ul>
										
<li class="clearfix">
			<a href="https://www.kreatewebsites.com/Switzerland/">
			<img src="https://www.kreatewebsites.com/Photos/Geneva-Switzerland.jpg" alt="Places to see in Geneva Switzerland" width="74" height="74"/>		</a>
		<span class="right">
		<a href="#">
			<span class="title">Geneva, Zurich has most places to see in Switzerland</span>
		</a>
		<span class="postinfo"></span>
	</span>
</li>											
<li class="clearfix">
			<a href="https://www.kreatewebsites.com/Italy/">
			<img src="https://www.kreatewebsites.com/Photos/Rome-City.jpg" alt="Places to see in Rome Italy"  width="74" height="74"/>		</a>
		<span class="right">
		<a href="https://www.kreatewebsites.com/Italy/">
			<span class="title">Rome is best destination in Italy</span>
		</a>
		<span class="postinfo"></span>
	</span>
</li>											
<li class="clearfix">
			<a href="https://www.kreatewebsites.com/France/">
			<img src="https://www.kreatewebsites.com/Photos/Paris-France.jpg" alt="Places to see in Paris France"   width="74" height="74"/>		</a>
		<span class="right">
		<a href="https://www.kreatewebsites.com/France/">
			<span class="title">France - Eiffel towers, Museums, Euro Disney </span>
		</a>
		<span class="postinfo"></span>
	</span>
</li>								</ul>
		</div> <!-- end .widget -->
		
		<div style="display: none;" class="widget popular">
			<ul>
																							
<li class="clearfix">
			<a href="https://www.kreatewebsites.com/Hawaii/">
			<img src="https://www.kreatewebsites.com/pictures/74/Hawaii.jpg" alt="What to see in Hawaii" title="Alleppey Tour"  width="74" height="74"/>		</a>
		<span class="right">
		<a href="Kerala-Destinations/Alleppey.aspx">
			<span class="title">Hawaii</span>
		</a>
		<span class="postinfo">Avatar movie was shot in Hawaii</span>
	</span>
</li>																														
<li class="clearfix">
			<a href="https://www.kreatewebsites.com/Florida/">
			<img src="https://www.indiacitytrip.com/pictures/74/Florida.jpg" alt="Places to see in Florida" title="Calicut Tour" width="74" height="74"/>		</a>
		<span class="right">
		<a href="https://www.kreatewebsites.com/Florida/">
			<span class="title">Florida</span>
		</a>
		<span class="postinfo">Beaches, Theme parks, perfect weather make Florida best state to see. </span>
	</span>
</li>																														
<li class="clearfix">
<a href="https://www.kreatewebsites.com/Montana/">
<img src="https://www.indiacitytrip.com/pictures/74/Montana.jpg" alt="Cochin Tour" title="Cochin Tour"  width="74" height="74"/>		</a>
<span class="right">
<a href="https://www.indiacitytrip.com/Kerala-Destinations/Cochin.aspx">
<span class="title">Montana</span></a>
<span class="postinfo">Best Ski, road journeys in USA</span>
</span>
</li>



</ul>
		</div> <!-- end .widget -->
		
		<div style="display: none;" class="widget popular">
			<ul>
										
<li class="clearfix">
			<a href="https://www.kreatewebsites.com/China/best-places-in-china.aspx">
			<img src="https://www.kreatewebsites.com/Photos/china-wall.jpg" alt="Wall of China is most visited place" width="74" height="74"/>		</a>
		<span class="right">
		<a href="https://www.kreatewebsites.com/China/best-places-in-china.aspx">
			<span class="title">Here are 50 best places in China</span>
		</a>
		<span class="postinfo"></span>
	</span>
</li>											
<li class="clearfix">
			<a href="https://www.kreatewebsites.com/India/">
			<img src="https://www.kreatewebsites.com/Photos/Taj-mahal-wonders-of-the-world.jpg" alt="Tajmahal places to see in India" width="74" height="74"/>		</a>
		<span class="right">
		<a href="https://www.kreatewebsites.com/India/">
			<span class="title">Tajmahal, Best forts and historical attractions in India</span>
		</a>
		<span class="postinfo"></span>
	</span>
</li>											
<li class="clearfix">
			<a href="https://www.kreatewebsites.com/Singapore/best-places-in-singapore.aspx">
			<img src="https://www.kreatewebsites.com/Photos/singaporeflyer-singapur.jpg" alt="Places to see in Singapore" width="74" height="74"/>		</a>
		<span class="right">
		<a href="https://www.kreatewebsites.com/Singapore/best-places-in-singapore.aspx">
			<span class="title">Best of Singapore</span>
		</a>
		<span class="postinfo"></span>
	</span>
</li>								</ul>
		</div> <!-- end .widget -->
	</div> <!-- end #all-tabs -->
		
</div> <!-- end #tabbed-area -->


		<div id="recent-posts-6" class="widget widget_recent_entries">
        		<h4 class="widgettitle"><span>Local Places to see</span></h4><div class="widgetcontent">		<ul>
      <uc1:articles ID="articles" runat="server"></uc1:articles>	

				</ul>
		</div><!-- end .widget-content --></div> <!-- end .widget -->
		
		
        
      	<div id="Div1" class="widget widget_recent_entries">
			<h4 class="widgettitle"><span>International Places</span></h4><div class="widgetcontent">		<ul>

     <uc1:articleshome ID="articleshome" runat="server"></uc1:articleshome>	
    	</ul>
</div><!-- end .widget-content --></div> <!-- end .widget -->	

<div id="firstcol">
			<div id="archives-3" class="widget widget_archive"><h4 class="widgettitle"><span>Favorite Tourist Places</span></h4><div class="widgetcontent">
                <!--#include virtual="~/appblock/ad160.htm" -->
                
                		
</div><!-- end .widget-content --></div> <!-- end .widget -->		<!-- end .widget --> <!-- end .widget -->		</div> <!-- end #firstcol -->
		
		<div id="secondcol">
			<div id="linkcat-2" class="widget widget_links"><h4 class="widgettitle"><span>Advertisement</span></h4>
            <div class="widgetcontent">
<ul>

<li><a href="https://www.kreatewebsites.com/Hawaii/">Hawaii</a></li>
<li><a href="https://www.kreatewebsites.com/Florida/" >Florida</a></li>
<li><a href="https://www.kreatewebsites.com/Dubai/" >Dubai</a></li>
<li><a href="https://www.kreatewebsites.com/Singapore/" >Singapore</a></li>
<li><a href="https://www.kreatewebsites.com/Thailand/" >Thailand</a></li>
<li><a href="https://www.kreatewebsites.com/Canada/British Columbia/" >British Columbia</a></li>
<li><a href="https://www.kreatewebsites.com/cook-islands/" >Cook Islands</a></li>
<li><a href="https://www.kreatewebsites.com/Italy/" >Italy</a></li>
<li><a href="https://www.kreatewebsites.com/Switzerland/" >Switzerland</a></li>
<li><a href="https://www.kreatewebsites.com/France/" >France</a></li>
<li><a href="https://www.kreatewebsites.com/Seychelles/">Seychelles</a></li>
<li><a href="https://www.kreatewebsites.com/Spain/" >Spain</a></li>
<li><a href="https://www.kreatewebsites.com/Montana/" ">Montana</a></li>

<li><a href="https://www.kreatewebsites.com/Washington/" ">Washington</a></li>

    	</ul>

</div><!-- end .widget-content --></div> <!-- end .widget -->
	<!-- end .widget --> <!-- end .widget -->		
		
		
		
</div>


		</div>

    </div>