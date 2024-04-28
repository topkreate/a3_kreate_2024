 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="places-list.ascx.cs" Inherits="mycontrol" %>
	<%@ OutputCache Duration="86400" VaryByParam="None" %>
		
<asp:Repeater ID="RepDetails" runat="server"   >

<HeaderTemplate>
       
									
</HeaderTemplate>

<ItemTemplate>



								
										
										<ul class="check-list">
											<li><asp:hyperlink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "biz_name", "http://www.ItalyCityTour.net/?name={0}") %>' >
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("biz_name") %>'/> 
</asp:Hyperlink>
                                                
                                                </li>
										
										</ul>
							

						

 



</ItemTemplate>





<FooterTemplate>

    <footer class="controls">
								<a href="#" class="button">Continue Reading</a>
							</footer>
    	
    
    	</div>
    
</FooterTemplate>

</asp:Repeater>
             
 
 
 
