<%@ Control Language="C#" AutoEventWireup="true" CodeFile="searchinternational.ascx.cs" Inherits="Control_Homeright" %>
<div id="cse-search-form" style="width: 100%;">Loading</div>
<script src="//www.google.com/jsapi" type="text/javascript"></script>
<script type="text/javascript"> 
  google.load('search', '1');
  google.setOnLoadCallback(function() {
    var customSearchControl = new google.search.CustomSearchControl('partner-pub-9932751777437258:8401388564');
    customSearchControl.setResultSetSize(google.search.Search.FILTERED_CSE_RESULTSET);
    var options = new google.search.DrawOptions();
    options.enableSearchboxOnly("http://");
    customSearchControl.draw('cse-search-form', options);
  }, true);
</script>
<link rel="stylesheet" href="//www.google.com/cse/style/look/default.css" type="text/css" />
<style type="text/css">
  input.gsc-input {
    border-color: #BCCDF0;
  }
  input.gsc-search-button {
    border-color: #666666;
    background-color: #CECECE;
  }
</style>