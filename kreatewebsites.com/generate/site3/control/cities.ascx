 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cities.ascx.cs" Inherits="cities" %>
	<%@ OutputCache Duration="86400" VaryByParam="None" %>
		
<asp:Repeater ID="RepDetails" runat="server"   >

<HeaderTemplate>

    	<div class="6u">
					
						<section>
							<h2>Best Cities</h2>
							<p> </p>
							<ul class="big-image-list">

</HeaderTemplate>

<ItemTemplate>


							
								<li>
									
                                    <asp:Image ID="lmage1" runat="server" Height="100px" Width="150px" class="left" alt="" ImageUrl='<%# "http://pictures.italycitytour.net/150/" + Eval("imageurl", "{0}") %>' />
									<h3><asp:HyperLink ID="HyperLink3" runat="server" Text='<%#Eval("city")%>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "city", "http://www.italycitytour.net/{0}/") %>' /> </h3>
									<p>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("place2") %>'/>  ,
<asp:Label ID="Label2" runat="server" Text='<%#Eval("place1") %>'/> ,
<asp:Label ID="Label3" runat="server" Text='<%#Eval("place3") %>'/> 
									</p>
								</li>
                                         
                                        


				
									
                                       
								


 



</ItemTemplate>





<FooterTemplate>
    </ul>
					

					</div>
</FooterTemplate>

</asp:Repeater>
             
 
 
 
