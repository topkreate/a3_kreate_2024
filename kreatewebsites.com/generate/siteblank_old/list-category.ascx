<%@ Control Language="C#" AutoEventWireup="true" CodeFile="list-category.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="10" VaryByParam="*" %>
		
<asp:Repeater ID="RepDetails" runat="server"     >
   
                       <HeaderTemplate>
                           
                        </HeaderTemplate>

                       <ItemTemplate>
      <li>
            <asp:label ID="HyperLink1"  runat="server" Text='<%#  Eval("cat_sub") %>'  />
         
   </li>
          </ItemTemplate>

                       <FooterTemplate>
 
                      </FooterTemplate>

                       </asp:Repeater>
 

  


						
						
					