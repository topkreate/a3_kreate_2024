<%@ Control Language="C#" AutoEventWireup="true" CodeFile="states.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="86400" VaryByParam="None" %>
		

									
<asp:Repeater ID="RepDetails" runat="server"    >
   
                       

                       <ItemTemplate>
                            
                                                <li>
                                                    <asp:hyperlink ID="hyperlink1" runat="server" Text='<%# Eval("region") %>' Navigateurl='<%# Global.Siteurl + @"state.aspx?state=" + Eval("state") %>' />

                                                    
                                                 </li>
									
									


   
        
   
          </ItemTemplate>

                     

                       </asp:Repeater>
 

  


						
						
					