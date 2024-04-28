<%@ Page Language="C#" MasterPageFile="masterpage.Master" AutoEventWireup="true" CodeFile="city.aspx.cs" Inherits="Default" CodeFileBaseClass="BasePage" 
 %>

<%@ Register Src="sidebar.ascx" TagName="right" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
		<!-- Main -->

			<div id="main-wrapper" class="subpage">
				<div class="5grid-layout">
                    <div class="row">
							<div class="12u">
								<div id="banner">
									
                                  
 <% Response.Write (slidestr); %>

									<div class="caption">
										<span><strong> <asp:Label ID="Label1" runat="server"> </asp:Label> </strong></span>
                                       
										
									</div>
								</div>
							</div>
						</div>
					<div class="row">
						<div class="6u">
					
							<!-- Content -->

								<article class="first">
								
									<h1><asp:Label ID="labeltitle" runat="server"></asp:Label></h1>
                                   

									<asp:Repeater ID="RepDetails" runat="server"   >

<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>



                                        
										<h2>
                                        
                                          <asp:label ID="HyperLink1" runat="server" Text='<%#Eval("biz_name")%>'  /> 
                           
     </h2>
										
										
								


</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

</asp:Repeater>
             

								</article>							

						</div>
						  <uc1:right ID="right" runat="server"></uc1:right>
					</div>
				</div>
			</div>
 
		</asp:Content>