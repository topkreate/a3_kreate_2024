<%@ Control Language="C#" AutoEventWireup="true" CodeFile="best.ascx.cs" Inherits="Control_Homeright" %>
	
<asp:Repeater ID="RepeaterSlide"  runat="server"  >

                       <HeaderTemplate>

                          
                        </HeaderTemplate>

                       <ItemTemplate>
	
							 <div class="12u">
								<div id="banner">
                                    <div class="row">
									<a href="#"><img src='<%#Eval("imageurl")%>' alt='<%#Eval("text")%>' /></a>
									<div class="caption">
										<span><asp:Label ID="lbl4" runat="server" Text='<%# Eval("Text")  %>'/></span>
										<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("link") %>' class="button">Australia Cities</asp:HyperLink> 
                                
                                         <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="https://www.kreatewebsites.com/tourist-attractions.aspx" class="button">Tourist Attractions</asp:HyperLink>   
									</div>
                               </div>
							</div>
						</div>
								

  
                       

                             </ItemTemplate>

                       <FooterTemplate>
     
 
                      </FooterTemplate>

                       </asp:Repeater>
  
	
		