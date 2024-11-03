
<%@ Page Language="C#" MasterPageFile="ace-masterpage.master" AutoEventWireup="true"  codeFile="~/articlelist_2023.aspx.cs" Inherits="Article"  Title="KreateWebsites"  CodeFileBaseClass="BasePage"  %>


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

       <div class="container-xxl py-5">
       <div class="container py-5">
           <div class="row g-5 align-items-center">
               <div class="col-lg-12 wow fadeInUp" data-wow-delay="0.1s">
	
					<asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="1" RepeatDirection="Horizontal"  >
					<HeaderTemplate>
                     

					</HeaderTemplate>
					<ItemTemplate>
					


                                                                        
                                                                                           <p class="mb-5"><asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium" Text='<%# Eval("text")  %>'></asp:Label></p>
                                                                                  
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
                    <img class="img-fluid flex-shrink-0" src="https://storage.googleapis.com/5106_gdrive/www.dataknobs.com/input/content/llm/llm-guardrails/images/Slide400/Slide1.png" style="width: 100%">
                </div>
            </div>
            <div class="testimonial-item p-4 my-5">
                <div class="d-flex align-items-end mb-4">
                    <img class="img-fluid flex-shrink-0" src="https://storage.googleapis.com/5106_gdrive/www.dataknobs.com/input/content/generativeai/10-llms/rag/rag/images/Slide400/Slide1.png" style="width: 100%">
                </div>
            </div>
            <div class="testimonial-item p-4 my-5">
                <div class="d-flex align-items-end mb-4">
                    <img class="img-fluid flex-shrink-0" src="https://storage.googleapis.com/5106_gdrive/www.dataknobs.com/input/content/vector-db/vector-db-101/images/Slide400/Slide1.png"" style="width: 100%">
                </div>
            </div>
            <div class="testimonial-item p-4 my-5">
                <div class="d-flex align-items-end mb-4">
                    <img class="img-fluid flex-shrink-0" src="https://storage.googleapis.com/5106_gdrive/www.dataknobs.com/input/content/generativeai/10-llms/rag/rag/images/Slide400/Slide1.png" style="width: 100%">
                </div>
            </div>
        </div>
    </div>

</asp:Content>