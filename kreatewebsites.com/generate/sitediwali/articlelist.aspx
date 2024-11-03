
<%@ Page Language="C#" MasterPageFile="diwali.master" AutoEventWireup="true"  codeFile="~/articlelist_2023.aspx.cs" Inherits="Article"  Title="KreateWebsites"  CodeFileBaseClass="BasePage"  %>


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
   
 
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                                                    </section>
                                                </div>
                                            </div>
                                        </div>
                                    </section>
                
    

</asp:Content>