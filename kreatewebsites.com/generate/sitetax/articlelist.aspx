
<%@ Page Language="C#"  AutoEventWireup="true" MasterPageFile="masterpage.master" codeFile="~/articlelist_2023.aspx.cs" Inherits="Article"  Title="KreateWebsites"  CodeFileBaseClass="BasePage"  %>


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
          <span class="display-2 font-weight-bold mb-4"><asp:label runat="server" ID="title"></asp:label></span>
        </p>
          <ul class="list-unstyled mt-5"><p><asp:Label ID="metadesc" runat="server" ></asp:Label></p> </ul>
        <ul class="list-unstyled mt-5">
         				<asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="1" RepeatDirection="Horizontal"  >
				<HeaderTemplate>
     

				</HeaderTemplate>
				<ItemTemplate>
				


                                                        <ul class="list-unstyled mt-5">
                                                                           <p><asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium" Text='<%# Eval("text")  %>'></asp:Label></p>
                                                            </ul>
                                                                  
				</ItemTemplate>
      <FooterTemplate>
         
                      
       

      </FooterTemplate>
        

</asp:Datalist>
        </ul>
      </div>
    </div>
  </div>







</asp:Content>