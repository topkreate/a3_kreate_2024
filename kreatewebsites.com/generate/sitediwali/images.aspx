
<%@ Page Language="C#" MasterPageFile="diwali.master" AutoEventWireup="true"  codeFile="~/images.aspx.cs" Inherits="Photos"  Title="KreateWebsites"  CodeFileBaseClass="BasePage"  %>


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

<asp:Content ID="Contenthead" ContentPlaceHolderID="head" runat="server"> </asp:Content>
   
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <section class="blog_breadcrumb_area center">
         <div class="background_overlay"></div>
             <div class="container">
                 <div class="breadcrumb_content_two text-center">
              
                  <h1><asp:label runat="server" ID="title"></asp:label></h1>
                 <ol class="list-unstyled">
                     <li><asp:Label ID="metadesc" runat="server" ></asp:Label>.</li>
                 </ol>
             </div>
         </div>
     </section>


<div class="main-wrapper-style2">
                                    <div class="inner">
                                        <section class="5grid-layout box-feature1">
                                            <div class="container">
                                                <div class="row justify-content-center">
                                                    <div class="col-lg-8">
                                                        <div id="projectCarousel" class="carousel slide carousel-container" data-bs-ride="carousel">
                                                        <div class="carousel-inner">                
    <asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="2" RepeatDirection="Horizontal"  >
    <HeaderTemplate>
       
    </HeaderTemplate>

    <ItemTemplate>


                   <div class="carousel-item active">
                        <asp:hyperlink ID="imghyperlink" runat="server" NavigateUrl='<%#   Eval("navigateurl2") %>'>
                                                                  <asp:Image ID="Image1" runat="server"   
                            ImageUrl='<%# Eval("thumbnailurl", "{0}") %>' alt='<%#  Eval("displayname") %>'
                                                            NavigateUrl='<%#  Eval("navigateurl2")  %>'              />
                                                             </asp:hyperlink>


 
                        
                             <blockquote>  <asp:Hyperlink ID="hyperlink2" runat="server"  Text='<%# Eval("displayname")  %>'  NavigateUrl='<%#  Eval("Navigateurl2") %>' />
                    </div>
            
               
            

    </ItemTemplate>

     <FooterTemplate>
       
 </FooterTemplate>
 </asp:Datalist>
    
                                                        <button class="carousel-control-prev" type="button" data-bs-target="#projectCarousel" data-bs-slide="prev">
                                                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                                            <span class="visually-hidden">Previous</span>
                                                        </button>
                                                        <button class="carousel-control-next" type="button" data-bs-target="#projectCarousel" data-bs-slide="next">
                                                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                                            <span class="visually-hidden">Next</span>
                                                        </button>
                                                        </div>
                                                    </div>
                                                </div>
                                                </div>
                                            </div>
                                        </section>
                                    </div>
  </div>


    <section class="elementor-section elementor-top-section elementor-section-boxed elementor-section-height-default">
                            <div class="elementor-container">
                                <div class="elementor-column elementor-col-100">
                                    <div class="elementor-widget-wrap">
                                        <section class="hosting_service_area sec_pad">
                                            <div class="container">
                                                <div class="styled-table hosting_service_item">    
                <h1><asp:label runat="server" ID="Label1"></asp:label></h1>
                <p><asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium"></asp:Label></p>
           

                                                          </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</section>


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

    

</asp:Content>