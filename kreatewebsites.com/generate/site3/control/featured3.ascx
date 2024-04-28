<%@ Control Language="C#" AutoEventWireup="true" CodeFile="featured3.ascx.cs" Inherits="featured" %>
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
                                                    <asp:Image ID="lmage1" runat="server" Height="74px" Width="74px"  alt="" class="left" ImageUrl='<%# "http://pictures.italycitytour.net/pictures/74/" + Eval("imageurl", "{0}") %>' />

                                                    
                                                    <h4>
                                                       </a>
                             <asp:HyperLink ID="HyperLink1"  runat="server" Text='<%#  Eval("title") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "hyperlink", "{0}") %>' />
                           </h4>
										<p><asp:Label ID="lbl1" runat="server" Text='<%#Eval("description") %>'/></p>
									
									


   
        
   
          </ItemTemplate>

                       <FooterTemplate>
</section>
                           
							</div>
                           
                      </FooterTemplate>

                       </asp:Repeater>
 

  


						
						
					