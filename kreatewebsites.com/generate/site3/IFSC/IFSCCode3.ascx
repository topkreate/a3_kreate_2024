<%@ Control Language="C#" AutoEventWireup="true" CodeFile="IFSCCode3.ascx.cs" Inherits="featured" %>
	<%@ OutputCache Duration="86400" VaryByParam="*" %>
		

									
<asp:Repeater ID="RepDetails" runat="server"    >
   
                      

                       <ItemTemplate>
                             <ul class="small-image-list">
                                                <li>
                                                    
                                                    
                                                    <h4>
                                                       </a>
                             <asp:HyperLink ID="HyperLink1"  runat="server" Text='<%#  Eval("bank") %>'  />
                              Branch Name : <asp:HyperLink ID="HyperLink2"  runat="server" Text='<%#  Eval("branch_name") %>' /> <br />
                           IFSC Code : <asp:HyperLink ID="HyperLink3"  runat="server" Text='<%#  Eval("IFSCCode") %>'  />  <br />
                              MICR Code : <asp:HyperLink ID="HyperLink7"  runat="server" Text='<%#  Eval("MICRCode") %>'  />   <br />
                              Address :  <asp:HyperLink ID="HyperLink4"  runat="server" Text='<%#  Eval("Address") %>'  /> <br />
                              City :  <asp:HyperLink ID="HyperLink9"  runat="server" Text='<%#  Eval("City") %>'  />
                             District :  <asp:HyperLink ID="HyperLink11"  runat="server" Text='<%#  Eval("District") %>'  />
                             State :  <asp:HyperLink ID="HyperLink12"  runat="server" Text='<%#  Eval("State") %>'  />
                             
                            
                           </h4>
									
								</li>
                                 </ul>	
									


   
        
   
          </ItemTemplate>

                    

                       </asp:Repeater>
 

  


						
						
					