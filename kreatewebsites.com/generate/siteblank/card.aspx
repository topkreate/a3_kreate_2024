<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="card.aspx.cs" Inherits="Photo" 
 CodeFileBaseClass="BasePage"  %>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdir" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_comments.ascx" TagName="facebookcomments" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_display.ascx" TagName="facebook" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	   
<div id="main">
			<div class="5grid-layout">
				<div class="row main-row">
				
								
					
				
                                             <h2><asp:label runat="server" ID="lblTitle"></asp:label></h2>
											
										
										
                                           

                                        <asp:image ID="imgMainImage" runat="server" ></asp:image>

								
                            <br /><br />

                       <uc1:ad728 ID="ad728" runat="server"></uc1:ad728>	 
                    	<p><asp:Label ID="labeltext" runat="server"></asp:Label></p>
						
                    <h2>			
                          <asp:Hyperlink ID="hyperEmail" runat="server"></asp:Hyperlink>
                        </h2>	

                    <br />
                            <uc1:facebook ID="facebook" runat="server"></uc1:facebook>
                    <br />
                      <uc1:facebookcomments ID="facebookcomments" runat="server"></uc1:facebookcomments>	
<!--
 <form method="post" action="mailto:someone@example.com">
 Subject: <input type="text" size="10" maxlength="40" name="subject"> 

Message: <textarea rows="5" cols="20" wrap="physical" name="Message">
 </textarea>
 <input type="submit" value="Send">
 </form>
-->


                                 See more cards :
            <uc1:articles2 ID="articles2" runat="server"></uc1:articles2>	
										
              
               
                
					
				</div>
			</div>
		</div>

		</asp:Content>







