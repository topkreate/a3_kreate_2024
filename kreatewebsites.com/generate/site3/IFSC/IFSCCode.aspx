
<%@ Page Language="C#" MasterPageFile="MasterPage_realtime.master" AutoEventWireup="true" CodeFile="IFSCCode.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>

<%@ Register Src="IFSCCode3.ascx" TagName="mobile" TagPrefix="uc1" %>
<%@ Register Src="branches.ascx" TagName="branches" TagPrefix="uc1" %>
<%@ Register Src="banks.ascx" TagName="banks" TagPrefix="uc1" %>
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
                                <uc1:banks ID="ad300b" runat="server"></uc1:banks></p>
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
                             <asp:HyperLink ID="HyperLink1"  runat="server" Text='<%#  Eval("bank") %>'  />
                              Branch Name : <asp:HyperLink ID="HyperLink2"  runat="server" Text='<%#  Eval("branch_name") %>' /> <br />
                           IFSC Code : <asp:HyperLink ID="HyperLink3"  runat="server" Text='<%#  Eval("IFSCCode") %>'  />  <br />
                              MICR Code : <asp:HyperLink ID="HyperLink7"  runat="server" Text='<%#  Eval("MICRCode") %>'  />   <br />
                              Address :  <asp:HyperLink ID="HyperLink4"  runat="server" Text='<%#  Eval("Address") %>'  /> <br />
                              City :  <asp:HyperLink ID="HyperLink9"  runat="server" Text='<%#  Eval("City") %>'  />
                             District :  <asp:HyperLink ID="HyperLink11"  runat="server" Text='<%#  Eval("District") %>'  />
                             State :  <asp:HyperLink ID="HyperLink12"  runat="server" Text='<%#  Eval("State") %>'  />
                             
                            
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
                                <uc1:ad300 ID="ad1" runat="server"></uc1:ad300>
								
						</section>
					
						<section>
							<h2>more deals</h2>
							<ul class="link-list">
								 <uc1:branches ID="branchess" runat="server"></uc1:branches>
							</ul>
							</ul>
						</section>

					</div>
				</div>
			</div>
		</div>



                                      
					
		 </asp:Content>