﻿ 
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



                        	</div>
					<div class="row">
						<div class="12u">
							<div class="divider"></div>
						</div>
					</div>
					<div class="row">
						<div class="12u">
							<div id="copyright">
								&copy; Copyright. All rights reserved. |  <asp:hyperlink ID="footerfooter" runat="server"> </asp:hyperlink>
							</div>
						</div>
					</div>
				</footer>