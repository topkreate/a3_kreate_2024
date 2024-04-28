
<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="~/articles.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list2.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesd" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad120.ascx" TagName="ad120" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_display.ascx" TagName="facebook" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


   
<div id="main">
			<div class="5grid-layout">
				<div class="row main-row">
					<div class="8u">
						
						<section class="left-content">
													<h2> <asp:Label ID="title" runat="server" ></asp:Label></h2>

                            <asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="1" RepeatDirection="Horizontal"  >
<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>


					

   <asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium" Text='<%# Eval("text")  %>'></asp:Label>

</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Datalist>
                                                               <br />
                            <br />
                                                                   <asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium"></asp:Label>
                            <br /><br />
                            <uc1:facebook ID="facebook" runat="server"></uc1:facebook>	
                           
                            <br />
                            <uc1:articles ID="articles" runat="server"></uc1:articles>	
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
											 
                                            
                                            <uc1:ad120 ID="ad120" runat="server"></uc1:ad120>	
										</ul>
									</div>
									<div class="6u">
										<ul class="link-list">
											 <uc1:articleshome ID="articleshome" runat="server"></uc1:articleshome>	
										</ul>
                                        <ul class="link-list">
											 <uc1:articlesd ID="articlesd" runat="server"></uc1:articlesd>	
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