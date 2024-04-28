<%@ Control Language="C#" AutoEventWireup="true" CodeFile="featured-search.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="86400" VaryByParam="None" %>
		
  <section>
									<h3>Upcoming Festivals</h3>
									<ul class="link-list">
<asp:Repeater ID="RepDetails" runat="server"     >
   
                       <HeaderTemplate>
                         
                        </HeaderTemplate>

                       <ItemTemplate>
                           <p></p>
      <li>
          <asp:HyperLink ID="HyperLink1"  runat="server" Text='<%# "Wishing " + Eval("title") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "hyperlink", "{0}") %>' />
   </li>
          </ItemTemplate>

                       <FooterTemplate>

                      </FooterTemplate>

                       </asp:Repeater>

                                         </ul>
                           </section>
 

  


						
						
					