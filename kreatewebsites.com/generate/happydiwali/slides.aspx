
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

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server"> </asp:Content>
   
 
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderArticle" runat="server">

<div class="container-xxl py-5">
    <div class="container py-5">
        <div class="row g-5 align-items-center">
            <div class="col-lg-12 wow fadeInUp" data-wow-delay="0.1s">
                <h1 class="mb-5"><asp:label runat="server" ID="title"></asp:label></h1>
                <p class="mb-5"><asp:Label ID="metadesc" runat="server" ></asp:Label></p>
            </div>
        </div>
    </div>
</div>


<div class="container-fluid p-0 pb-5">
    <div class="owl-carousel header-carousel position-relative mb-5">
        <div class="owl-carousel-item position-relative">
<asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="4" RepeatDirection="Horizontal"  >
    <HeaderTemplate>
    </HeaderTemplate>

    <ItemTemplate>


            <asp:hyperlink ID="imghyperlink" runat="server" NavigateUrl='<%#   Eval("navigateurl2") %>'>
                                                      <asp:Image ID="Image1" runat="server"   class="img-fluid"
                ImageUrl='<%# Eval("thumbnailurl", "{0}") %>' alt='<%#  Eval("alt") %>'
                                                NavigateUrl='<%#  Eval("navigateurl2")  %>'              />
                                                 </asp:hyperlink>
            
    

    </ItemTemplate>

     <FooterTemplate>
 </FooterTemplate>
 </asp:Datalist>
          </div>
        
    </div>
</div>


  <div class="container-xxl py-5">
    <div class="container py-5">
        <div class="row g-5 align-items-center">
            <div class="col-lg-12 wow fadeInUp" data-wow-delay="0.1s">
                <h1 class="mb-5"><asp:label runat="server" ID="Label1"></asp:label></h1>
                <p class="mb-5"><asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium"></asp:Label></p>
            </div>
        </div>
    </div>
</div>



     <div class="container-xxl py-5">
 <div class="container py-5">
     <div class="row g-5 align-items-center">
         <div class="col-lg-12 wow fadeInUp" data-wow-delay="0.1s">
	
		<asp:Datalist ID="RepComments" runat="server"  RepeatColumns="1" RepeatDirection="Horizontal"  >
		<HeaderTemplate>
               

		</HeaderTemplate>
		<ItemTemplate>
		


                                                                  
                                                                                     <p class="mb-5"><asp:Label ID="label2" runat="server"  ForeColor="Black" Font-Size="Medium" Text='<%# Eval("text")  %>'></asp:Label></p>
                                                                            
		</ItemTemplate>
                <FooterTemplate>
                   
                                
 

                </FooterTemplate>
                  

	</asp:Datalist>

                              </div>
                           </div>
                   </div>
               </div>

    <div class="container py-5">
        <div class="text-center">
            <h1 class="mb-0">Our Gallery</h1>
        </div>
        <div class="owl-carousel testimonial-carousel wow fadeInUp" data-wow-delay="0.1s">
            <div class="testimonial-item p-4 my-5">
                <div class="d-flex align-items-end mb-4">
                    <img class="img-fluid flex-shrink-0" src="https://acespireconsulting.com/static/acespire/images/slide-2.jpg" style="width: 100%">
                </div>
            </div>
            <div class="testimonial-item p-4 my-5">
                <div class="d-flex align-items-end mb-4">
                    <img class="img-fluid flex-shrink-0" src="https://acespireconsulting.com/static/acespire/images/slide-3.jpg" style="width: 100%">
                </div>
            </div>
            <div class="testimonial-item p-4 my-5">
                <div class="d-flex align-items-end mb-4">
                    <img class="img-fluid flex-shrink-0" src="https://acespireconsulting.com/static/acespire/images/slide-1.jpg" style="width: 100%">
                </div>
            </div>
            <div class="testimonial-item p-4 my-5">
                <div class="d-flex align-items-end mb-4">
                    <img class="img-fluid flex-shrink-0" src="https://acespireconsulting.com/static/acespire/images/service.jpg" style="width: 100%">
                </div>
            </div>
        </div>
    </div>

</asp:Content>