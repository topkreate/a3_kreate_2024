
<%@ Page Language="C#" MasterPageFile="MasterPage_realtime.master" AutoEventWireup="true" CodeFile="IFSCCodeCityList.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>

<%@ Register Src="IFSCCode3.ascx" TagName="mobile" TagPrefix="uc1" %>
<%@ Register Src="branches.ascx" TagName="mobilecompany" TagPrefix="uc1" %>
<%@ Register Src="banks.ascx" TagName="mobileos" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           
   



		
		
		<div id="main">
			<div class="5grid-layout">
				<div class="row main-row">
                    <div class="3u">

						<section>
							<h2>Ads</h2>
							<ul class="link-list">
							<uc1:ad300 ID="ad300" runat="server"></uc1:ad300>
							</ul>
						</section>

						<section>
							<h2>Deals</h2>
							<p>
                                <uc1:ad300 ID="ad300b" runat="server"></uc1:ad300></p>
						</section>
					
					</div>

                    <div class="6u mobileUI-main-content">
						
						<section class="middle-content">
                            <asp:Repeater ID="RepDetails" runat="server"    >
   
                      

                       <ItemTemplate>
                             <ul class="small-image-list">
                                                <li>
                                                    
                                                    
                                                    <h4>
                                                       </a>
                            
                             <asp:HyperLink ID="HyperLink9"  runat="server" Text='<%#  Eval("bank") %>' NavigateUrl='<%#  Global.Siteurl + @"IFSCCodeCity.aspx?city=" +   Eval("city") %>' />
                            
                             
                            
                           </h4>
									
								</li>
                                 </ul>	
									


   
        
   
          </ItemTemplate>

                    

                       </asp:Repeater>
 
                             
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