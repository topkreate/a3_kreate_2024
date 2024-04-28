 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="restaurants-list.ascx.cs" Inherits="mycontrol" %>
	<%@ OutputCache Duration="86400" VaryByParam="None" %>
		
<asp:Repeater ID="RepDetails" runat="server"   >

<HeaderTemplate>
        <div class="4u">
            <!-- Box #2 -->
									<section>
										<header>
											<h2>Restaurants</h2>
											<h3>Famous places to eat</h3>
                                            </header>
</HeaderTemplate>

<ItemTemplate>


                    <ul class="quote-list">
								<li>
												
												<p><asp:hyperlink ID="HyperLink1" runat="server" Text='<%#Eval("biz_name") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "biz_name", "http://www.ItalyCityTour.net/?name={0}") %>' >
                                                </asp:Hyperlink> </p>
												<span><asp:hyperlink ID="HyperLink2" runat="server" Text='<%#Eval("e_city") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "e_City", "http://www.ItalyCityTour.net/?name={0}") %>' >
                                                </asp:Hyperlink></span>
											</li>
                        </ul>
										
										

                                                
                                          
						

 



</ItemTemplate>





<FooterTemplate>

    		</section>
    <!--#include virtual="~/App_Code/appblock/ad300.htm" -->
    	</div>
      
</FooterTemplate>

</asp:Repeater>
             
 
 
 
