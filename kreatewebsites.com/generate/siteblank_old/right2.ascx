<%@ Control Language="C#" AutoEventWireup="true" CodeFile="right2.ascx.cs" Inherits="Kerala_right" %>
 <%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
 <%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<div id="sidebar">
			
		<div id="onecol">
			
<div id="tabbed-area">
			
    <ul class="clearfix" id="tab_controls">
		<li class="first active"><a href="#"><span>TV</span></a></li>
		<li class="second"><a href="#"><span>Phones</span></a></li>
		<li class="last"><a href="#"><span>Pcs</span></a></li>
	</ul>
	<!--#include virtual="~/appblock/ad300.htm" -->
		
</div> <!-- end #tabbed-area -->


		<div id="recent-posts-6" class="widget widget_recent_entries">
        		<h4 class="widgettitle"><span>Things to Buy</span></h4><div class="widgetcontent">		<ul>
      <uc1:articles ID="articles" runat="server"></uc1:articles>	

				</ul>
		</div><!-- end .widget-content --></div> <!-- end .widget -->
		
		
        
      	<div id="Div1" class="widget widget_recent_entries">
			<h4 class="widgettitle"><span>Thanks Giving Sale</span></h4><div class="widgetcontent">		<ul>

     <uc1:articleshome ID="articleshome" runat="server"></uc1:articleshome>	
    	</ul>
</div><!-- end .widget-content --></div> <!-- end .widget -->	

<div id="firstcol">
			<div id="archives-3" class="widget widget_archive"><h4 class="widgettitle"><span>Most Buy</span></h4><div class="widgetcontent">		<ul>

<li><a href="http://www.thanks-giving.net/TV/">LCD TV</a></li>
<li><a href="http://www.thanks-giving.net/XBOX/" >XBOX</a></li>
<li><a href="http://www.thanks-giving.net/Phones/" >Phones</a></li>
<li><a href="http://www.thanks-giving.net/Tablets/" >Tablets</a></li>
<li><a href="http://www.thanks-giving.net/Slates/" >Slates</a></li>

<li><a href="http://www.thanks-giving.net/PC/" >Touch PCs</a></li>
<li><a href="http://www.thanks-giving.net/Domains/" >Domains</a></li>
<li><a href="http://www.thanks-giving.net/Websites/" >Websites</a></li>
<li><a href="http://www.thanks-giving.net/Hosting/" >Hosting</a></li>
<li><a href="http://www.thanks-giving.net/SEO/">SEO Package</a></li>
<li><a href="http://www.thanks-giving.net/Links/" >Links</a></li>
<li><a href="http://www.thanks-giving.net/Websites/Buy.html" ">Buy webistes</a></li>



    	</ul>
</div><!-- end .widget-content --></div> <!-- end .widget -->		<!-- end .widget --> <!-- end .widget -->		</div> <!-- end #firstcol -->
		
		<div id="secondcol">
			<div id="linkcat-2" class="widget widget_links"><h4 class="widgettitle"><span>Advertisement</span></h4>
            <div class="widgetcontent">
<!--#include virtual="~/appblock/ad160.htm" -->

</div><!-- end .widget-content --></div> <!-- end .widget -->
	<!-- end .widget --> <!-- end .widget -->		
		
		
		
</div>


		</div>

    </div>