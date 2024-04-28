


<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Best.aspx.cs" Inherits="Default" 
Title="City guide"  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="~/generate/articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<%@ Register Src="~/Controlslide2/best.ascx" TagName="best" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
			<div id="main-wrapper" >
				<div class="5grid-layout">


                    <!-- Banner -->

					<uc1:best ID="best" runat="server"></uc1:best>

					<!-- Features -->


                    	<h1 class="title"> <asp:Label ID="lblTitle"  runat="server"></asp:Label></h1>


					<div class="row">
					
					
							<!-- Content -->

						
														
					
		
			
	
    
<asp:DataList ID="RepDetails" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"    >

<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>

    <div class="3u" style="WIDTH: 300px">
								<section>

<h2>
     <asp:HyperLink ID="HyperLink1" runat="server" Text='<%#Eval("biz_name")%>'                                          
                                      NavigateUrl='<%# Eval("placeurl")     %>' >
                                           </asp:HyperLink>
      
      
</h2>
<p>
         <asp:HyperLink ID="HyperLink2" runat="server" Text='<%#Eval("city")%>'                                          
                                      NavigateUrl='<%# Eval( "cityurl")                                      %>' >
                                           </asp:HyperLink>

    <asp:HyperLink ID="HyperLink4" runat="server" Text='<%#Eval("statename")%>'                                          
                                      NavigateUrl='<%# Eval( "stateurl")                                      %>' >
                                           </asp:HyperLink>
    <asp:HyperLink ID="HyperLink5" runat="server" Text='<%#Eval("country")%>'                                          
                                      NavigateUrl='<%# Eval( "countryurl")                                      %>' >
                                           </asp:HyperLink>
 </p>

<p><asp:Label ID="lbl3" runat="server" Text='<%#Eval("biz_info") %>'/>  

</p>




<p>
  <b><asp:Label ID="lb31" runat="server" Text='<%#Eval("cat_sub") %>'/> </b>
  <b><asp:Label ID="lb32" runat="server" Text='<%#Eval("category") %>'/> </b>
 
 
 </p>

<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# Eval("placeurl") %>' class="readmore" Text='<%# Eval("biz_name")%>' ></asp:HyperLink> 

      
	</section>
</div>
</ItemTemplate>

<FooterTemplate>



</FooterTemplate>

</asp:DataList>
						
	</div>				     
<div class="row">
							<div class="12u">
								<div class="divider divider-top"></div>
							</div>
						</div>
    
   	
          	
																

</asp:Content>