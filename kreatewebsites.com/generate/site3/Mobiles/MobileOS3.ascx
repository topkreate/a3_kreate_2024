<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MobileOS3.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="86400" VaryByParam="None" %>
		

									
<asp:Repeater ID="RepDetails" runat="server"    >
   
                       

                       <ItemTemplate>
                            
                                                <li>
                                                    <asp:hyperlink ID="hyperlink1" runat="server" Text='<%# Eval("os") %>' Navigateurl='<%# Global.Siteurl + @"Mobiles.aspx?os=" + Eval("os") %>' />

                                                    
                                                 </li>
									
									


   
        
   
          </ItemTemplate>

                     

                       </asp:Repeater>
 

  


						
						
					