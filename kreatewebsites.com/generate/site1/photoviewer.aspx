<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="photoviewer.aspx.cs" Inherits="Photo" 
 CodeFileBaseClass="BasePage"  %>


<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	   
<div id="main">
			<div class="5grid-layout">
				<div class="row main-row">
					<div class="8u">
						
						<section class="left-content">
								
					
				
                                             <h2><asp:label runat="server" ID="title"></asp:label></h2>
											
										
										
                                           

                                        <asp:image ID="imgMainImage" runat="server" ></asp:image>

									<p><asp:Label ID="labeltext" runat="server"></asp:Label></p>

                             
										
                       

                          
                            <br /><br />

<!--
 <form method="post" action="mailto:someone@example.com">
 Subject: <input type="text" size="10" maxlength="40" name="subject"> 

Message: <textarea rows="5" cols="20" wrap="physical" name="Message">
 </textarea>
 <input type="submit" value="Send">
 </form>
-->


           
										
                             </section>
					
					</div>
					<div class="4u">

						<section>
							<h2>Advertisement</h2>
							<ul class="small-image-list">
								
                                   <uc1:ad300 ID="ad300" runat="server"></uc1:ad300>	
							</ul>
						</section>
					
						<section>
							<h2>Topics</h2>
							<div class="5grid">
								<div class="row">
									<div class="6u">
										<ul class="link-list">
											
										</ul>
									</div>
									<div class="6u">
										<ul class="link-list">
											
										</ul>
									</div>
								</div>
							</div>
						</section>

					</div>
				</div>
			</div>
		</div>

		</asp:Content>







