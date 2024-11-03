
<%@ Page Language="C#" MasterPageFile="masterpage.master" AutoEventWireup="true"  codeFile="~/photos-dir.aspx.cs" Inherits="Photos"  Title="KreateWebsites"  CodeFileBaseClass="BasePage"  %>


<%@ Register Src="../site1/articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="../site1/articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="../site1/articles-sub-directory.ascx" TagName="articlesub" TagPrefix="uc1" %>
<%@ Register Src="../site1/articles-directory.ascx" TagName="articlesdirectory" TagPrefix="uc1" %>
<%@ Register Src="../site1/articles-directory-limited.ascx" TagName="articlesdirectorylimited" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad160.ascx" TagName="ad160" TagPrefix="uc1" %>

<%@ Register Src="../site1/footer.ascx" TagName="footer" TagPrefix="uc1" %>

<%@ Register Src="header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../site1/header2.ascx" TagName="header2" TagPrefix="uc1" %>
<%@ Register Src="footer.ascx" TagName="footer2" TagPrefix="uc1" %>
<%@ Register Src="gallery.ascx" TagName="gallery" TagPrefix="uc1" %>
<%@ Register Src="pictures.ascx" TagName="pictures" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server"> </asp:Content>
   
 
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderArticle" runat="server">

  <div class="container my-5 py-2">
  <h2 class="text-center font-weight-bold my-5">
    <span class="display-2 font-weight-bold mb-4"><asp:label runat="server" ID="title"></asp:label></span>
  </h2>
        
      
      <ul class="list-unstyled mt-5"><p><asp:Label ID="metadesc" runat="server" ></asp:Label></p> </ul>
      

 <div class="row">
    <div
      data-aos="fade-up"
      data-aos-delay="200"
      data-aos-duration="1000"
      data-aos-once="true"
      class="col-md-4 text-center"
    >

                              
<asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="1" RepeatDirection="Horizontal"  >
    <HeaderTemplate>
    </HeaderTemplate>

    <ItemTemplate>


            <asp:hyperlink ID="imghyperlink" runat="server" NavigateUrl='<%#   Eval("navigateurl2") %>'>
                                                      <asp:Image ID="Image1" runat="server"  
                ImageUrl='<%# Eval("thumbnailurl", "{0}") %>' alt='<%#  Eval("alt") %>'
                                                NavigateUrl='<%#  Eval("navigateurl2")  %>'              />
                                                 </asp:hyperlink>
            
    
        <h4>  <asp:Hyperlink ID="hyperlink1" runat="server"  Text='<%# Eval("displayname")  %>'  NavigateUrl='<%#  Eval("Navigateurl") %>' /></h4>

    </ItemTemplate>

     <FooterTemplate>
 </FooterTemplate>
 </asp:Datalist>
   
  
</div>


   <div class="container my-5 py-2" id="price-table">
  <div class="row">
    <div
      data-aos="fade-right"
      data-aos-delay="200"
      data-aos-duration="1000"
      data-aos-once="true"
      class="col-md-12 text-center py-4 mt-5"
    >
     
        <ul class="list-unstyled mt-5"><p><asp:Label ID="labeltext" runat="server" ></asp:Label></p> </ul>
     
    </div>
  </div>
</div>


  <div class="container my-5 py-2" id="price-table">
    <div class="row">
      <div
        data-aos="fade-right"
        data-aos-delay="200"
        data-aos-duration="1000"
        data-aos-once="true"
        class="col-md-12 text-center py-4 mt-5"
      >
        <p class="font-weight-bold">
          <span class="display-2 font-weight-bold mb-4"><asp:label runat="server" ID="Label1"></asp:label></span>
        </p>
          <ul class="list-unstyled mt-5"><p><asp:Label ID="Label3" runat="server" ></asp:Label></p> </ul>
        <ul class="list-unstyled mt-5">
	
		<asp:Datalist ID="RepComments" runat="server"  RepeatColumns="1" RepeatDirection="Horizontal"  >
		<HeaderTemplate>
               

		</HeaderTemplate>
		<ItemTemplate>
		


                                                                  
                                                                                     <p class="mb-5"><asp:Label ID="label2" runat="server"  ForeColor="Black" Font-Size="Medium" Text='<%# Eval("text")  %>'></asp:Label></p>
                                                                            
		</ItemTemplate>
                <FooterTemplate>
                   
                                
 

                </FooterTemplate>
                  

	</asp:Datalist>

            </ul>
    </div>
  </div>
</div>


    <!-- <uc1:pictures ID="pictures" runat="server"></uc1:pictures> -->
    <!-- <uc1:gallery ID="gallery" runat="server"></uc1:gallery> -->

</asp:Content>