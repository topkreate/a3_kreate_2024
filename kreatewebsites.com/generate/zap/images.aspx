
<%@ Page Language="C#" MasterPageFile="masterpage.master" AutoEventWireup="true"  codeFile="~/images.aspx.cs" Inherits="Photos"  Title="KreateWebsites"  CodeFileBaseClass="BasePage"  %>


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
<%@ Register Src="gallery-pdm.ascx" TagName="gallery" TagPrefix="uc1" %>

<asp:Content ID="Contenthead" ContentPlaceHolderID="head" runat="server"> </asp:Content>
   
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderArticle" runat="server">

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
                
                  
    <asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="2" RepeatDirection="Horizontal"  >
    <HeaderTemplate>
         <div class="row g-5 align-items-center"> 
    </HeaderTemplate>

    <ItemTemplate>


                    <figure>
                        <asp:hyperlink ID="imghyperlink" runat="server" NavigateUrl='<%#   Eval("navigateurl2") %>'>
                                                                  <asp:Image ID="Image1" runat="server"   
                            ImageUrl='<%# Eval("thumbnailurl", "{0}") %>' alt='<%#  Eval("displayname") %>'
                                                            NavigateUrl='<%#  Eval("navigateurl2")  %>'              />
                                                             </asp:hyperlink>


 
                        <div class="portfolio_text">
                             <blockquote>  <asp:Hyperlink ID="hyperlink2" runat="server"  Text='<%# Eval("displayname")  %>'  NavigateUrl='<%#  Eval("Navigateurl2") %>' />
                        </div>
            
                     </figure>
            

    </ItemTemplate>

     <FooterTemplate>
         </div>
       
 </FooterTemplate>
 </asp:Datalist>
 
  
                 
   


 
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

    <uc1:gallery ID="gallery" runat="server"></uc1:gallery>

</asp:Content>