<%@ Control Language="C#" AutoEventWireup="true" CodeFile="list-cities.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="86400" VaryByParam="*" %>
		
<asp:Repeater ID="RepDetails" runat="server"     >
   
                       <HeaderTemplate>
                           
                        </HeaderTemplate>

                       <ItemTemplate>
      <li>
          <asp:label ID="HyperLink1"  runat="server" Text='<%#  Eval("city")  %>'    />
   </li>
          </ItemTemplate>

                       <FooterTemplate>
 
                      </FooterTemplate>

                       </asp:Repeater>
 

  


						
						
					