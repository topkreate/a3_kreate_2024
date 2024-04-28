<%@ Control Language="C#" AutoEventWireup="true" CodeFile="list-places.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="10" VaryByParam="*" %>
		
<asp:Repeater ID="RepDetails" runat="server"     >
   
                       <HeaderTemplate>
                           
                        </HeaderTemplate>

                       <ItemTemplate>
      <li>
            <asp:label ID="HyperLink1"  runat="server" Text='<%#  Eval("biz_name") %>'  />
         
   </li>
          </ItemTemplate>

                       <FooterTemplate>
 
                      </FooterTemplate>

                       </asp:Repeater>
 

  


						
						
					