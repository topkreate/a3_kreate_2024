<%@ Control Language="C#" AutoEventWireup="true" CodeFile="links.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="86400" VaryByParam="None" %>
		

									
<asp:Repeater ID="RepDetails" runat="server"    >
   
                       <HeaderTemplate>
                     
                           <h2>Best Tours</h2>
							<div class="5grid">
								<div class="row">
									<div class="6u">
										<ul class="link-list">

										<header>
											<h2><asp:Label ID="labelCategory" runat="server"></asp:Label></h2>
                                          


											<h4><asp:Label ID="labelSubCategory" runat="server"></asp:Label></h4>
                                            
										</header>
                        </HeaderTemplate>

                       <ItemTemplate>
                            
                                                <li>
                                                    
                                                     <asp:HyperLink ID="HyperLink1"  runat="server" Text='<%#  Eval("title") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "hyperlink", "{0}") %>' />
                                                    </li>
                                                    
                                        
									
									


   
        
   
          </ItemTemplate>

                       <FooterTemplate>
                                       </ul>
									</div>
								</div>
							</div>
						</section>
                           
                      </FooterTemplate>

                       </asp:Repeater>
 

  


						
						
					