<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Copy of Mobile3.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="86400" VaryByParam="None" %>
		

									
<asp:Repeater ID="RepDetails" runat="server"    >
   
                       <HeaderTemplate>
                     

                                        <div class="4u">

								<!-- Box #1 -->
									<section>
										<header>
											<h2><asp:Label ID="labelCategory" runat="server"></asp:Label></h2>
                                          


											<h4><asp:Label ID="labelSubCategory" runat="server"></asp:Label></h4>
                                            
										</header>
                        </HeaderTemplate>

                       <ItemTemplate>
                             <ul class="small-image-list">
                                                <li>
                                                    <asp:Image ID="lmage1" runat="server" Height="74px" Width="74px"  alt="" class="left" ImageUrl='<%# Global.Siteurl + @"/" + Eval("imageurl") %>' />

                                                    
                                                    <h4>
                                                       </a>
                             <asp:HyperLink ID="HyperLink1"  runat="server" Text='<%#  Eval("model") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "model", "{0}") %>' />
                           </h4>
									
									
									


   
        
   
          </ItemTemplate>

                       <FooterTemplate>
</section>
                           
							</div>
                           
                      </FooterTemplate>

                       </asp:Repeater>
 

  


						
						
					