<%@ Control Language="C#" AutoEventWireup="true" CodeFile="countries.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="86400" VaryByParam="None" %>
		

									
<asp:Repeater ID="RepDetails" runat="server"    >
   
                       

                       <ItemTemplate>
                            
                                                <li>
                                                    <asp:hyperlink ID="hyperlink1" runat="server" Text='<%# Eval("country") %>' Navigateurl='<%# Global.Siteurl + @"country.aspx?country=" + Eval("country") %>' />

                                                    
                                                 </li>
									
									


   
        
   
          </ItemTemplate>

                     

                       </asp:Repeater>
 

  


						
						
					