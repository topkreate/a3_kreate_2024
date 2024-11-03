 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="footer.ascx.cs" Inherits="Default" %>
<%@ Register Src="ver-navigation.ascx" TagName="vernav" TagPrefix="uc1" %>
<%@ Register Src="footer-new.ascx" TagName="fnew" TagPrefix="uc1" %>

<div class="container-fluid bg-dark text-light footer pt-5 wow fadeIn" data-wow-delay="0.1s" style="margin-top: 6rem;">
    <div class="container py-5">
        <div class="row g-5">
            <div class="col-lg-3 col-md-6">
                <h4 class="text-light mb-4">Address</h4>
                <p class="mb-2"><i class="fa fa-map-marker-alt me-3"></i>USA</p>
                <p class="mb-2"><i class="fa fa-phone-alt me-3"></i>Phone</p>
                <p class="mb-2"><i class="fa fa-envelope me-3"></i>Email Address</p>
                <div class="d-flex pt-2">
                    <a class="btn btn-outline-light btn-social" href=""><i class="fab fa-twitter"></i></a>
                    <a class="btn btn-outline-light btn-social" href=""><i class="fab fa-facebook-f"></i></a>
                    <a class="btn btn-outline-light btn-social" href=""><i class="fab fa-youtube"></i></a>
                    <a class="btn btn-outline-light btn-social" href=""><i class="fab fa-linkedin-in"></i></a>
                </div>
            </div>
            <div class="col-lg-3 col-md-6">
                <h4 class="text-light mb-4"><asp:hyperlink ID="footerhead" runat="server"></asp:hyperlink></h4>
                <a class="btn btn-link" href="">Home</a>
                <a class="btn btn-link" href="">Services</a>
                <a class="btn btn-link" href="">About</a>
                <a class="btn btn-link" href="">Career</a>
            </div>
            <div class="col-lg-3 col-md-6">
                <h4 class="text-light mb-4">Services</h4>
                <uc1:vernav ID="vernav" runat="server"></uc1:vernav>
            </div>
            <div class="col-lg-3 col-md-3">
                <h4 class="text-light mb-4">Additional Links</h4>
                <a class="btn btn-link" href="">Home</a>
                <a class="btn btn-link" href="">Services</a>
                <uc1:fnew ID="fnew" runat="server"></uc1:fnew>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="copyright">
            <div class="row">
                <div class="col-md-6 text-center text-md-start mb-3 mb-md-0">
                    &copy;  All Right Reserved.
					 <asp:HyperLink class="border-bottom" ID="cright" runat="server" ></asp:HyperLink> |   | <asp:HyperLink ID="privacypolicy" runat="server" > | <asp:hyperlink ID="footerfooter" runat="server"> </asp:hyperlink></asp:HyperLink> 
			</div>

                </div>
                <div class="col-md-6 text-center text-md-end">
                    <!--/*** This template is free as long as you keep the footer author’s credit link/attribution link/backlink. If you'd like to use the template without the footer author’s credit link/attribution link/backlink, you can purchase the Credit Removal License from "https://www.kreatewebsites.com/credit-removal". Thank you for your support. ***/-->
                    Designed By <a class="border-bottom" href="https://www.kreatewebsites.com">Kreate Websites</a> | <asp:HyperLink ID="sitemap" runat="server" ></asp:HyperLink>
                </div>
            </div>
        </div>
 </div>




			
								
								
							