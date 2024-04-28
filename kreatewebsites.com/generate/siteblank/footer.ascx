 
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="footer.ascx.cs" Inherits="Default" %>

<div id="footer-wrapper">
				<footer class="5grid-layout" id="site-footer">
					<div class="row">
						<div class="3u">
							<section class="first">
								<h2><asp:hyperlink ID="footerhead" runat="server"></asp:hyperlink></h2>
								<ul class="link-list">
										
									
									
                                    <asp:datalist ID="RepLinks" runat="server"    >
<HeaderTemplate>

    
</HeaderTemplate>

<ItemTemplate>


												
		<li>								
		<asp:hyperlink ID="title"  runat="server" Text='<%# Eval("name") %>' NavigateUrl='<%#  Eval("url") %>' >
            
            </asp:hyperlink>
            </li>	


</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:datalist>
                                    

                   </ul>
							</section>
						</div>

                        <div class="3u">
							<section >
								<h2>Set 2</h2>
								<ul class="link-list">
										
									
									
                                    <asp:datalist ID="RepLinks2" runat="server"    >
<HeaderTemplate>

    
</HeaderTemplate>

<ItemTemplate>


												
		<li>								
		<asp:hyperlink ID="title"  runat="server" Text='<%# Eval("name") %>' NavigateUrl='<%#  Eval("url") %>' >
            
            </asp:hyperlink>
            </li>	


</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:datalist>
                                    

                   </ul>
							</section>
						</div>
                        <div class="3u">
							<section >
								<h2>Set 3</h2>
								<ul class="link-list">
										
									
									
                                    <asp:datalist ID="RepLinks3" runat="server"    >
<HeaderTemplate>

    
</HeaderTemplate>

<ItemTemplate>


												
		<li>								
		<asp:hyperlink ID="title"  runat="server" Text='<%# Eval("name") %>' NavigateUrl='<%#  Eval("url") %>' >
            
            </asp:hyperlink>
            </li>	


</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:datalist>
                                    

                   </ul>
							</section>
						</div>

                        <div class="3u">
							<section class="last" >
								<h2>Set 4</h2>
								<ul class="link-list">
										
									
									
                                    <asp:datalist ID="RepLinks4" runat="server"    >
<HeaderTemplate>

    
</HeaderTemplate>

<ItemTemplate>


												
		<li>								
		<asp:hyperlink ID="title"  runat="server" Text='<%# Eval("name") %>' NavigateUrl='<%#  Eval("url") %>' >
            
            </asp:hyperlink>
            </li>	


</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:datalist>
                                    

                   </ul>
							</section>
						</div>
                        	</div>
					<div class="row">
						<div class="12u">
							<div class="divider"></div>
						</div>
					</div>
					<div class="row">
						<div class="12u">
							<div id="copyright">
								&copy; Copyright.  Design: <asp:HyperLink ID="cright" runat="server" ></asp:HyperLink> | <asp:HyperLink ID="sitemap" runat="server" ></asp:HyperLink>  | <asp:HyperLink ID="privacypolicy" runat="server" > | <asp:hyperlink ID="footerfooter" runat="server"> </asp:hyperlink></asp:HyperLink> 
							</div>
						</div>
					</div>
				</footer>