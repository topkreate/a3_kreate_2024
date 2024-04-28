<%@ Control Language="C#" AutoEventWireup="true" CodeFile="featured-list.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="86400" VaryByParam="None" %>
		
<asp:Repeater ID="RepDetails" runat="server"  DataSourceID="SqlDataSource2"   >
   
                       <HeaderTemplate>
                           <section>
									<h3>Featured</h3>
									<ul class="link-list">
                        </HeaderTemplate>

                       <ItemTemplate>
      <li>
          <asp:HyperLink ID="HyperLink1"  runat="server" Text='<%# "Happy " + Eval("title") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "hyperlink", "{0}") %>' />
   </li>
          </ItemTemplate>

                       <FooterTemplate>
 </ul>
                           </section>
                      </FooterTemplate>

                       </asp:Repeater>
 

     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:films %>"
            SelectCommand="featured_search" SelectCommandType="StoredProcedure">
              <SelectParameters>  
                                <asp:QueryStringParameter Name="category" QueryStringField="category" Type="string"  defaultvalue="festival" />     
                                 <asp:QueryStringParameter Name="category2" QueryStringField="category2" Type="string"  defaultvalue="everything" /> 
                                 <asp:QueryStringParameter Name="country" QueryStringField="country" Type="string"  defaultvalue="India" /> 
                                                                      
								<asp:QueryStringParameter Name="n" QueryStringField="n" Type="string" defaultvalue="3" />
                                <asp:QueryStringParameter Name="sortorder" QueryStringField="sortorder" Type="string" defaultvalue="1" />
                  	<asp:QueryStringParameter Name="direction" QueryStringField="direction" Type="string" defaultvalue="1" />
                                <asp:QueryStringParameter Name="spin" QueryStringField="spin" Type="string" defaultvalue="1" />
               </SelectParameters>
        </asp:SqlDataSource>


						
						
					