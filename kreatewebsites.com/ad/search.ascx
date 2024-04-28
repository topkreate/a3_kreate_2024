<%@ Control Language="C#" AutoEventWireup="true" CodeFile="search.ascx.cs" Inherits="Control_Homeright" %>
<form action="Result.aspx" id="cse-search-box">
  <div>
    <input type="hidden" name="cx" value="partner-pub-9932751777437258:6387415076" />
    <input type="hidden" name="cof" value="FORID:10" />
    <input type="hidden" name="ie" value="UTF-8" />
    <input type="text" name="q" size="25" />
    <input type="submit" name="sa" value="Search" />
  </div>
</form>
<script type="text/javascript" src="http://www.google.com/jsapi"></script>
<script type="text/javascript">    google.load("elements", "1", { packages: "transliteration" });</script>
<script type="text/javascript" src="http://www.google.com/cse/t13n?form=cse-search-box&t13n_langs=en"></script>

<script type="text/javascript" src="http://www.google.com/coop/cse/brand?form=cse-search-box&amp;lang=en"></script>

   <!-- End popular query -->	