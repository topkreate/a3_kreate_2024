
<%@ Page Language="C#" MasterPageFile="MasterPage_realtime.master" AutoEventWireup="true" CodeFile="Place.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>

<%@ Register Src="cities.ascx" TagName="cities" TagPrefix="uc1" %>
<%@ Register Src="states.ascx" TagName="states" TagPrefix="uc1" %>
<%@ Register Src="countries.ascx" TagName="countries" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           
   



		
		
		<div id="main">
			<div class="5grid-layout">
				<div class="row main-row">
                    <div class="3u">

						<section>
							<h2>Cities to see</h2>
							<ul class="link-list">
							<uc1:cities ID="cities" runat="server"></uc1:cities>
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
                             <uc1:states ID="states" runat="server"></uc1:states>
                      </section>
					
					</div>

                    <div class="3u">

						<section>


					                    
                		<h2>Countries to see</h2>
							<ul class="small-image-list">
								<uc1:countries ID="countries" runat="server"></uc1:countries>
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