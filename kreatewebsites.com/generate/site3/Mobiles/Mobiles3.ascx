<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Mobiles3.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="86400" VaryByParam="*" %>
		

									
<asp:Repeater ID="RepDetails" runat="server"    >
   
                      

                       <ItemTemplate>
                             <ul class="small-image-list">
                                                <li>
                                                    <asp:Image ID="lmage1" runat="server" Height="74px" Width="74px"  alt="" class="left" ImageUrl='<%# Global.Siteurl + @"/" + Eval("imageurl") %>' />

                                                    
                                                    <h4>
                                                       </a>
                             <asp:HyperLink ID="HyperLink1"  runat="server" Text='<%#  Eval("model") %>' NavigateUrl='<%# Global.Siteurl + @"Mobile.aspx?n=1&model=" + DataBinder.Eval(Container.DataItem, "model", "{0}") %>' />
                           </h4>
									
								</li>
                                 </ul>	
									


   
        
   
          </ItemTemplate>

                    

                       </asp:Repeater>
 

  


						
						
					