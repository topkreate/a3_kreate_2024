 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="footer.ascx.cs" Inherits="Default" %>
<%@ Register Src="ver-navigation.ascx" TagName="vernav" TagPrefix="uc1" %>
<%@ Register Src="footer-new.ascx" TagName="fnew" TagPrefix="uc1" %>
<%@ Register Src="../site1/articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="../site1/articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="../site1/articles-sub-directory.ascx" TagName="articlesub" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdirectory" TagPrefix="uc1" %>

<footer>
  <div
    class="jumbotron jumbotron-fluid"
    id="contact"
    style="background-image: url('https://storage.googleapis.com/layout.kreatewebsites.com/atlas/img/contact-bk.jpg');"
  >
    <div class="container my-5">
      <div class="row justify-content-between">
        <div class="col-md-4 text-white">
          <h2 class="font-weight-bold"><asp:hyperlink ID="footerhead" runat="server"></asp:hyperlink></h2>
          <ul class="list-unstyled">
           <uc1:articles ID="footer" runat="server"></uc1:articles>
          </ul>
        </div>
        <div class="col-md-4 text-white">
          <h2 class="font-weight-bold">Main</h2>
          <ul class="list-unstyled">
           <uc1:articleshome ID="Articles1" runat="server"></uc1:articleshome>
          </ul>
        </div>
        <div class="col-md-4">
          <div class="row justify-content-between">
            <div class="col-md-6 text-white">
              <h2 class="font-weight-bold">Details</h2>
              <ul class="list-unstyled">
               <uc1:articlesub ID="Articles2" runat="server"></uc1:articlesub>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div class="jumbotron jumbotron-fluid" id="copyright">
    <div class="container">
      <div class="row justify-content-between">
        <div
          class="col-md-6 text-white align-self-center text-center text-md-left my-2"
        >
          <asp:HyperLink class="border-bottom" ID="cright" runat="server" ></asp:HyperLink> |   | <asp:HyperLink ID="privacypolicy" runat="server" > | <asp:hyperlink ID="footerfooter" runat="server"> </asp:hyperlink></asp:HyperLink> 

              <!--/*** This template is free as long as you keep the footer author’s credit link/attribution link/backlink. If you'd like to use the template without the footer author’s credit link/attribution link/backlink, you can purchase the Credit Removal License from "https://www.kreatewebsites.com/credit-removal". Thank you for your support. ***/-->
  Designed By <a class="border-bottom" href="https://www.kreatewebsites.com">Kreate Websites</a> | <asp:HyperLink ID="HyperLink1" runat="server" ></asp:HyperLink>
        </div>
      </div>
    </div>
  </div>
</footer>





			
								
								
							