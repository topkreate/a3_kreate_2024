<%@ Control Language="C#" AutoEventWireup="true" CodeFile="featured2.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="86400" VaryByParam="None" %>
		
  <section>
									<h3>Upcoming Festivals</h3>
									
<asp:Repeater ID="RepDetails" runat="server"     >
   
                       <HeaderTemplate>
                         
                        </HeaderTemplate>

                       <ItemTemplate>
      <li>
          <asp:HyperLink ID="HyperLink1"  runat="server" Text='<%# "Wishing " + Eval("title") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "hyperlink", "{0}") %>' />
   </li>
          </ItemTemplate>

                       <FooterTemplate>

                      </FooterTemplate>

                       </asp:Repeater>

                                         
                           </section>
 

  


						
						
					