
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="footer.ascx.cs" Inherits="Default" %>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-sub-directory.ascx" TagName="articlesub" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdirectory" TagPrefix="uc1" %>
<%@ Register Src="articles-directory-limited.ascx" TagName="articlesdirectorylimited" TagPrefix="uc1" %>

   <div class="container-fluid bg-dark text-light footer pt-5 mt-5 wow fadeIn" data-wow-delay="0.1s">
       <div class="container py-5">
           <div class="row g-5">
               <div class="col-lg-3 col-md-6">
                   <!-- <h4 class="text-white mb-3">Most popular</h4> -->
                   <h4><asp:hyperlink ID="footerhead" class="text-white mb-3" runat="server"></asp:hyperlink></h4>
                   <uc1:articleshome ID="Articleshome3" runat="server"></uc1:articleshome>
               
               </div>
               <div class="col-lg-3 col-md-6">
                   <h4 class="text-white mb-3">Links</h4>
                   <!--
                   <p class="mb-2"><i class="fa fa-map-marker-alt me-3"></i>Select the perfect comforter</p> -->
                    <uc1:articlesub ID="articlessub" runat="server"></uc1:articlesub>
                   <!--
                   <p class="mb-2"><i class="fa fa-phone-alt me-3"></i>www.usacitytrip.com</p>
                   <p class="mb-2"><i class="fa fa-envelope me-3"></i>info@usacitytrip.com</p>
                   -->
                   <div class="d-flex pt-2">
                       <a class="btn btn-outline-light btn-social" href="https://www.twitter.com/usacitytrip/"><i class="fab fa-twitter"></i></a>
                       <a class="btn btn-outline-light btn-social" href="https://www.facebook.com/uscitytrip/"><i class="fab fa-facebook-f"></i></a>
                       <a class="btn btn-outline-light btn-social" href=""><i class="fab fa-youtube"></i></a>
                       <a class="btn btn-outline-light btn-social" href="https://www.linkedin.com/company/dataknobs/"><i class="fab fa-linkedin-in"></i></a>
                       
                   </div>
               </div>
               <div class="col-lg-3 col-md-6">
                   <h4 class="text-white mb-3">Gallery</h4>
                   <div class="row g-2 pt-2">
                       <div class="col-4">
                           <img class="img-fluid bg-light p-1" src="https://storage.googleapis.com/kreatewebsites/site102/img/package-1.jpg" alt="">
                       </div>
                       <div class="col-4">
                           <img class="img-fluid bg-light p-1" src="https://storage.googleapis.com/kreatewebsites/site102/img/package-2.jpg" alt="">
                       </div>
                       <div class="col-4">
                           <img class="img-fluid bg-light p-1" src="https://storage.googleapis.com/kreatewebsites/site102/img/package-3.jpg" alt="">
                       </div>
                       <div class="col-4">
                           <img class="img-fluid bg-light p-1" src="https://storage.googleapis.com/kreatewebsites/site102/img/package-2.jpg" alt="">
                       </div>
                       <div class="col-4">
                           <img class="img-fluid bg-light p-1" src="https://storage.googleapis.com/kreatewebsites/site102/img/package-3.jpg" alt="">
                       </div>
                       <div class="col-4">
                           <img class="img-fluid bg-light p-1" src="https://storage.googleapis.com/kreatewebsites/site102/img/package-1.jpg" alt="">
                       </div>
                   </div>
               </div>
               <div class="col-lg-3 col-md-6">
                   <h4 class="text-white mb-3">Additional Info</h4>
                   <!--
                   <p>Sign up for our newsletter and get inspired for your next trip.</p>
                   <div class="position-relative mx-auto" style="max-width: 400px;">
                       <input class="form-control border-primary w-100 py-3 ps-4 pe-5" type="text" placeholder="Your email">
                       <button type="button" class="btn btn-primary py-2 position-absolute top-0 end-0 mt-2 me-2">SignUp</button>
                   </div>
                   -->
                   
               </div>
           </div>
       </div>
       <div class="container">
           <div class="copyright">
               <div class="row">
                   <div class="col-md-6 text-center text-md-start mb-3 mb-md-0">
                       &copy; <asp:hyperlink ID="footerfooter" class="text-white mb-3" runat="server"></asp:hyperlink>, All Right Reserved
                   </div>
                   <div class="col-md-6 text-center text-md-end">
                       <div class="footer-menu">
                          <uc1:articlesdirectorylimited ID="articlesdirectorylimited" runat="server"></uc1:articlesdirectorylimited>
                       </div>
                   </div>
               </div>
           </div>
       </div>
   </div>




			
								
								
							