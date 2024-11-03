 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="articles-directory-limited-slider.ascx.cs" Inherits="Default" %>

 

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
					
			<asp:hyperlink ID="title" class="btn btn-link"  runat="server" Text='<%# "<em><b>" + Eval("name") + "</b></em>" %>' NavigateUrl='<%#  Eval("url") %>' >  	 </asp:hyperlink>
            
           
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
             
 
 
 
