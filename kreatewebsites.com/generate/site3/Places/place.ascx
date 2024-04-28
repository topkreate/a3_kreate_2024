<%@ Control Language="C#" AutoEventWireup="true" CodeFile="place.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="86400" VaryByParam="*" %>
		

									
<asp:Repeater ID="RepDetails" runat="server"    >
   
                      

                       <ItemTemplate>
                             <ul class="small-image-list">
                                                <li>
                                                    <asp:Image ID="lmage1" runat="server"   alt='<%#  Eval("biz_name") %>' class="left" ImageUrl='<%# Global.photopath + @"/" + Eval("imageurl") %>' />

                                                    
                                                    <h4>
                                                       </a>
                             <asp:HyperLink ID="HyperLink1"  runat="server" Text='<%#  Eval("biz_name") %>' NavigateUrl='<%# Global.Siteurl + @"/" + DataBinder.Eval(Container.DataItem, "biz_name", "{0}") %>' />
                              Info : <asp:HyperLink ID="HyperLink4"  runat="server" Text='<%#  Eval("biz_info") %>' /> <br />
                                                         City : <asp:HyperLink ID="HyperLink2"  runat="server" Text='<%#  Eval("city") %>' /> <br />
                             State : <asp:HyperLink ID="HyperLink3"  runat="server" Text='<%#  Eval("state") %>'  />  <br />
                              Country : <asp:HyperLink ID="HyperLink7"  runat="server" Text='<%#  Eval("os") %>'  /> , <asp:HyperLink ID="HyperLink6"  runat="server" Text='<%#  Eval("country") %>'  />  <br />
                            
                           </h4>
									
								</li>
                                 </ul>	
									


   
        
   
          </ItemTemplate>

                    

                       </asp:Repeater>
 

  


						
						
					