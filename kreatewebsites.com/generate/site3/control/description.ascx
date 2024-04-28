 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="description.ascx.cs" Inherits="cities" %>
	<%@ OutputCache Duration="86400" VaryByParam="None" %>
		
<asp:Repeater ID="RepDetails" runat="server"   >

<HeaderTemplate>

    	<div class="4u">
						
						<section>
							

</HeaderTemplate>

<ItemTemplate>


							
								<li>
									
									<h2><asp:HyperLink ID="HyperLink3" runat="server" Text='<%#Eval("title")%>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "city", "http://www.vancouver-bc.biz/city.aspx?name={0}") %>' /> </h2>
									<p>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("description") %>'/>  ,
 
									</p>
								</li>
                                         
                                        


				
									
                                       
								


 



</ItemTemplate>





<FooterTemplate>
    </ul>
					

					</div>
</FooterTemplate>

</asp:Repeater>
             
 
 
 
