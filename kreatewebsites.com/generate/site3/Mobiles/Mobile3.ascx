<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Mobile3.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="86400" VaryByParam="*" %>
		

									
<asp:Repeater ID="RepDetails" runat="server"    >
   
                      

                       <ItemTemplate>
                             <ul class="small-image-list">
                                                <li>
                                                    <asp:Image ID="lmage1" runat="server"   alt='<%#  Eval("model") %>' class="left" ImageUrl='<%# Global.photopath + @"/" + Eval("imageurl") %>' />

                                                    
                                                    <h4>
                                                       </a>
                             <asp:HyperLink ID="HyperLink1"  runat="server" Text='<%#  Eval("model") %>' NavigateUrl='<%# Global.Siteurl + @"/" + DataBinder.Eval(Container.DataItem, "model", "{0}") %>' />
                              Company : <asp:HyperLink ID="HyperLink2"  runat="server" Text='<%#  Eval("company") %>' /> <br />
                             Battery power : <asp:HyperLink ID="HyperLink3"  runat="server" Text='<%#  Eval("battery") %>'  />  <br />
                              Operating System : <asp:HyperLink ID="HyperLink7"  runat="server" Text='<%#  Eval("os") %>'  /> , <asp:HyperLink ID="HyperLink6"  runat="server" Text='<%#  Eval("osversion") %>'  />  <br />
                              Size :  <asp:HyperLink ID="HyperLink4"  runat="server" Text='<%#  Eval("height") %>'  /> * <asp:HyperLink ID="HyperLink5"  runat="server" Text='<%#  Eval("width") %>'  /> * * <asp:HyperLink ID="HyperLink8"  runat="server" Text='<%#  Eval("thickness") %>'  /> <br />
                              Storage :  <asp:HyperLink ID="HyperLink9"  runat="server" Text='<%#  Eval("storage") %>'  />
                             Camera :  <asp:HyperLink ID="HyperLink11"  runat="server" Text='<%#  Eval("camera") %>'  />
                             Processor :  <asp:HyperLink ID="HyperLink12"  runat="server" Text='<%#  Eval("processor") %>'  />
                             Cellular Company :  <asp:HyperLink ID="HyperLink10"  runat="server" Text='<%#  Eval("network_company") %>'  />
                             Memory :  <asp:HyperLink ID="HyperLink13"  runat="server" Text='<%#  Eval("ram") %>'  />
                             Expandable memory :  <asp:HyperLink ID="HyperLink14"  runat="server" Text='<%#  Eval("expandable_memory") %>'  />
                           </h4>
									
								</li>
                                 </ul>	
									


   
        
   
          </ItemTemplate>

                    

                       </asp:Repeater>
 

  


						
						
					