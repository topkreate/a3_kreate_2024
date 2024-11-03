

 <%@ Page Language="C#" MasterPageFile="~/masterpage_blank.Master" AutoEventWireup="true" CodeFile="folder-names-generate.aspx.cs" Inherits="Article" CodeFileBaseClass="BasePage" 

%>


 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Repeater ID="RepLinks" runat="server"    >
<HeaderTemplate>
    <div class="container-xxl py-5">
    <div class="container">
        <div class="text-center wow fadeInUp" data-wow-delay="0.1s">
            <h6 class="section-title bg-white text-center text-primary px-3">Tour blog</h6>
            <h1 class="mb-5">Best Options</h1>
        </div>
    <div class="row g-4">
    
</HeaderTemplate>

<ItemTemplate>


            <div class="col-lg-3 col-sm-6 wow fadeInUp" data-wow-delay="0.1s">
                <div class="service-item rounded pt-3">
                    <div class="p-4">
                        <i class="fa fa-3x fa-globe text-primary mb-4"></i>
					
                            <asp:hyperlink ID="Hyperlink1"  runat="server" Text='<%# Eval("name") %>' NavigateUrl='<%#  Eval("url") %>' >
                                   </asp:hyperlink>
					  
                    </div>
                </div>
            </div>


</ItemTemplate>



<FooterTemplate>
    </div>
  </div>
 </div>


</FooterTemplate>

            </asp:Repeater>
             
    		</asp:Content>
 
 
 
