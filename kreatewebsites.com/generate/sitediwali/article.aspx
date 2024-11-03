
<%@ Page Language="C#" MasterPageFile="diwali.master" AutoEventWireup="true" CodeFile="~/article.aspx.cs" Inherits="Article" CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="../site5/articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdirectory" TagPrefix="uc1" %>
<%@ Register Src="../site5/articles-directory-limited.ascx" TagName="articlesdirectorylimited" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad120.ascx" TagName="ad120" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad160.ascx" TagName="ad160" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_display.ascx" TagName="facebook" TagPrefix="uc1" %>
<%@ Register Src="../site5/articles-directory-limited-button.ascx" TagName="articlesbutton" TagPrefix="uc1" %>
<%@ Register Src="../site5/articles-sub-directory-limited-button.ascx" TagName="articlessubdirectorybutton" TagPrefix="uc1" %>
<%@ Register Src="../site5/articles-list-limited-button.ascx" TagName="articleslistbutton" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<body>
		

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
	
							
											
         <section class="elementor-section elementor-top-section elementor-section-boxed elementor-section-height-default">
                                     <div class="elementor-container">
                                         <div class="elementor-column elementor-col-100">
                                             <div class="elementor-widget-wrap">
                                                 <section class="hosting_service_area sec_pad">
                                                     <div class="container">
                                                         <div class="styled-table hosting_service_item">                                        
								
										
                                            <asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium"></asp:Label>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</section>
  			
</body>

</asp:Content>