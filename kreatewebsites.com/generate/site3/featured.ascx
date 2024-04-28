<%@ Control Language="C#" AutoEventWireup="true" CodeFile="featured.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="86400" VaryByParam="None" %>
		
<asp:Repeater ID="RepDetails" runat="server"     >
   
                       <HeaderTemplate>
                           <section>
									<h3>Featured Festivals</h3>
									<ul class="link-list">
                        </HeaderTemplate>

                       <ItemTemplate>
      <li>
          <asp:HyperLink ID="HyperLink1"  runat="server" Text='<%# "Wishing " + Eval("title") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "hyperlink", "{0}") %>' />
   </li>
          </ItemTemplate>

                       <FooterTemplate>
 </ul>
                           </section>
                      </FooterTemplate>

                       </asp:Repeater>
 

  


						
						
					