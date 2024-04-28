<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cities.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="86400" VaryByParam="None" %>
		

									
<asp:Repeater ID="RepDetails" runat="server"    >
   
                       

                       <ItemTemplate>
                            
                                                <li>
                                                    <asp:hyperlink ID="hyperlink1" runat="server" Text='<%# Eval("city") %>' Navigateurl='<%# Global.Siteurl + @"city.aspx?city=" + Eval("city") %>' />

                                                    
                                                 </li>
									
									


   
        
   
          </ItemTemplate>

                     

                       </asp:Repeater>
 

  


						
						
					