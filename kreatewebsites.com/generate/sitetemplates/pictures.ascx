 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pictures.ascx.cs" Inherits="Default" %>

<div class="container py-5">
    <div class="text-center">
        <h1 class="mb-0">Our Gallery</h1>
    </div>
    
     


        <asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="1" RepeatDirection="Horizontal"  >
        <HeaderTemplate>
            
        </HeaderTemplate>

        <ItemTemplate>
            <div class="owl-carousel testimonial-carousel wow fadeInUp" data-wow-delay="0.1s">
            <div class="testimonial-item p-4 my-5">
                <div class="d-flex align-items-end mb-4">
                   
                    
                    <asp:hyperlink ID="imghyperlink" runat="server" NavigateUrl='<%#   Eval("navigateurl2") %>'>
                                                              <asp:Image ID="Image1" runat="server"  
                        ImageUrl='<%# Eval("thumbnailurl", "{0}") %>' alt='<%#  Eval("alt") %>' class="img-fluid flex-shrink-0"  style="width: 100%"
                                                        NavigateUrl='<%#  Eval("navigateurl2")    %>'              />
                                                         </asp:hyperlink>
                </div>
            </div>
        </div>
        </ItemTemplate>

        <FooterTemplate>
            
           </FooterTemplate>
 </asp:Datalist>



   
</div>




			
								
								
							