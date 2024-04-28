
<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="article.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list2.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


   
<div id="main">
			<div class="5grid-layout">
				<div class="row main-row">
					<div class="8u">
						
						<section class="left-content">
													
                                                              
                                                                   <asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium"></asp:Label>
                            <br /><br />
                            <uc1:articles ID="articles" runat="server"></uc1:articles>	
        	</section>
					
					</div>
					<div class="4u">

						<section>
							<h2>Advertisement</h2>
							<ul class="small-image-list">
								<!--#include virtual="~/appblock/ad300.htm"-->
							</ul>
						</section>
					
						<section>
							<h2>Topics</h2>
							<div class="5grid">
								<div class="row">
									<div class="6u">
										<ul class="link-list">
											 
                                            <!--#include virtual="~/appblock/ad120.htm"-->
										</ul>
									</div>
									<div class="6u">
										<ul class="link-list">
											 <uc1:articleshome ID="articleshome" runat="server"></uc1:articleshome>	
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