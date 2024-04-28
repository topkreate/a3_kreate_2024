<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MobileCompany3.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="86400" VaryByParam="None" %>
		

									
<asp:Repeater ID="RepDetails" runat="server"    >
   
                       

                       <ItemTemplate>
                            
                                                <li>
                                                    <asp:hyperlink ID="hyperlink1" runat="server" Text='<%# Eval("company") %>' Navigateurl='<%# Global.Siteurl + @"Mobiles.aspx?company=" + Eval("company") %>' />

                                                    
                                                 </li>
									
									


   
        
   
          </ItemTemplate>

                     

                       </asp:Repeater>
 

  


						
						
					