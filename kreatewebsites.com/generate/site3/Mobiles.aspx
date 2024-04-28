
<%@ Page Language="C#" MasterPageFile="MasterPage_realtime.master" AutoEventWireup="true" CodeFile="Mobiles.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>

<%@ Register Src="control/mobiles3.ascx" TagName="mobile" TagPrefix="uc1" %>
<%@ Register Src="header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="footer.ascx" TagName="footer" TagPrefix="uc1" %>
<%@ Register Src="control/mobilecompany3.ascx" TagName="mobilecompany" TagPrefix="uc1" %>
<%@ Register Src="control/mobileos3.ascx" TagName="mobileos" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           
   



		
		
		<div id="main">
			<div class="5grid-layout">
				<div class="row main-row">
                    <div class="3u">

						<section>
							<h2>Mobile Companies</h2>
							<ul class="link-list">
							<uc1:mobilecompany ID="mobile1" runat="server"></uc1:mobilecompany>
							</ul>
						</section>

						<section>
							<h2>Deals</h2>
							<p>
                                <uc1:ad300 ID="ad300" runat="server"></uc1:ad300></p>
						</section>
					
					</div>

                    <div class="6u mobileUI-main-content">
						
						<section class="middle-content">
                             <uc1:mobile ID="mobiles" runat="server"></uc1:mobile>
                      </section>
					
					</div>

                    <div class="3u">

						<section>


					                    
                		<h2>Operating System</h2>
							<ul class="small-image-list">
								<uc1:mobileos ID="mobileos" runat="server"></uc1:mobileos>
							</ul>
						</section>
					
						<section>
							<h2>more deals</h2>
							<ul class="link-list">
								 <uc1:ad300 ID="ad1" runat="server"></uc1:ad300>
							</ul>
						</section>

					</div>
				</div>
			</div>
		</div>



                                      
					
		 </asp:Content>