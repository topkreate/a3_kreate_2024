<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="photo.aspx.cs" Inherits="Photo" 
 CodeFileBaseClass="BasePage"  %>

<%@ Register Src="articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdir" TagPrefix="uc1" %>
<%@ Register Src="~/appblock_facebook/facebook_display.ascx" TagName="facebook" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	   
<div align="left">
<form id="Form1" runat="server">
								
					
				
                                             <h2><asp:label runat="server" ID="lblTitle"></asp:label></h2>
											
										
										
                                           

                                        <asp:image ID="imgMainImage" runat="server" ></asp:image>

									<p><asp:Label ID="labeltext" runat="server"></asp:Label></p>
										
                          <asp:Hyperlink ID="hyperEmail" runat="server"></asp:Hyperlink>

                            <uc1:facebook ID="facebook" runat="server"></uc1:facebook>
                            <br /><br />

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
										
                </form>
</div>


		</asp:Content>







