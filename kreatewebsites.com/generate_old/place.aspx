
      
<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="place.aspx.cs" Inherits="Default" 
Title="City guide"  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
			<div id="main-wrapper" class="subpage">
				<div class="5grid-layout">
					<div class="row">
						<div class="9u">
					
							<!-- Content -->

								<article class="first">
														          
                 <asp:Label ID="lblArea"  runat="server"></asp:Label></h4>
			
	
    
<asp:Repeater ID="RepDetails" runat="server"     >

<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>

<div class="entry clearfix">
<h2 class="title">
     <asp:HyperLink ID="HyperLink1" runat="server" Text='<%#Eval("biz_name")%>'                                          
                                      NavigateUrl='<%# Eval("placeurl")     %>' >
                                           </asp:HyperLink>
      
      
</h2>

<div class="entry-content clearfix">
<p><asp:Label ID="lbl3" runat="server" Text='<%#Eval("biz_info") %>'/>  

</p>


</div>
<div class="post-meta clearfix">
<p class="meta-info">
  <b><asp:Label ID="lb31" runat="server" Text='<%#Eval("cat_sub") %>'/> </b>
  <b><asp:Label ID="lb32" runat="server" Text='<%#Eval("category") %>'/> </b>
 
 
 </p>

<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "biz_name", "https://www.kreatewebsites.com/attraction-details.aspx?name={0}") %>' class="readmore"><span>See More pictures</span></asp:HyperLink> 

      
	</div>
</div>
</ItemTemplate>

<FooterTemplate>



</FooterTemplate>

</asp:Repeater>
						
					     

<asp:Repeater ID="RepPictures" runat="server"     >

<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>

<div class="entry clearfix">
<h2 class="title">
     <asp:HyperLink ID="HyperLink1" runat="server" Text='<%#Eval("biz_name")%>'                                          
                                      NavigateUrl='<%# Eval("url") 
                                         
                                      %>' >
                                           </asp:HyperLink>
      
      
</h2>
    <asp:Image ID="lmage1" runat="server"  class="thumb alignleft" ImageUrl='<%# Eval("imageurl") %>' alt='<%#Eval("web_meta_desc") %>'/>


         

 
<div class="entry-content clearfix">
<p><asp:Label ID="lbl3" runat="server" Text='<%#Eval("web_meta_desc") %>'/>  

</p>


</div>
<div class="post-meta clearfix">
<p class="meta-info">
  <b><asp:Label ID="lb31" runat="server" Text='<%#Eval("category") %>'/> </b>

 
 
 </p>

<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# Eval("url") %>' class="readmore"><span>See</span></asp:HyperLink> 

      
	</div>
</div>
</ItemTemplate>

<FooterTemplate>



</FooterTemplate>

</asp:Repeater>

    
   	
    
   		</article>							

						</div>
                            
                  <div class="3u">
						
							<!-- Sidebar -->
							
								<section>
									<h3>Ads and Deals</h3>
									<ul class="link-list">
									 <uc1:ad300 ID="ad300" runat="server"></uc1:ad300>
									</ul>
								</section>

								<section class="last">
									<h3>Topics</h3>
								
									<ul class="link-list">
											 <uc1:articles ID="articles" runat="server"></uc1:articles>	
									</ul>
								</section>
						
						</div>
					</div>
				</div>
			</div>
          	
																

</asp:Content>