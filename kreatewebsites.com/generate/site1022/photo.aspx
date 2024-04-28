<%@ Page Language="C#" MasterPageFile="MasterPage2023.master" AutoEventWireup="true" CodeFile="~/photo.aspx.cs" Inherits="Photo" 
 CodeFileBaseClass="BasePage"  %>


<%@ Register Src="~/appblock_facebook/facebook_display.ascx" TagName="facebook" TagPrefix="uc1" %>
<%@ Register Src="articles-list.ascx" TagName="articles" TagPrefix="uc1" %>
<%@ Register Src="articles-list2.ascx" TagName="articles2" TagPrefix="uc1" %>
<%@ Register Src="articles-list-home.ascx" TagName="articleshome" TagPrefix="uc1" %>
<%@ Register Src="articles-directory.ascx" TagName="articlesdir" TagPrefix="uc1" %>
<%@ Register Src="articles-directory-limited.ascx" TagName="articlesd" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad300.ascx" TagName="ad300" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad160.ascx" TagName="ad160" TagPrefix="uc1" %>
<%@ Register Src="~/appblock/ad728.ascx" TagName="ad728" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	   
	
											
                                             <h2><asp:label runat="server" ID="title"></asp:label></h2>
																	
										
										 <span> <asp:Label ID="metadesc" runat="server" ></asp:Label></span>
                                           <br />

                    <span class="image image-full">      <asp:image ID="imgMainImage" runat="server" ></asp:image> </span>

									<p><asp:Label ID="labeltext" runat="server"></asp:Label></p>
										
                          <asp:Hyperlink ID="hyperEmail" runat="server"></asp:Hyperlink>

                            <uc1:facebook ID="facebook" runat="server"></uc1:facebook>
                            <br /><br />
                                        <asp:Datalist ID="RepComments" runat="server"  RepeatColumns="1" RepeatDirection="Horizontal"  >
<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>


					
                   

												 
               							
		

      <asp:Label ID="label2" runat="server"  ForeColor="Black" Font-Size="Medium" Text='<%# Eval("text")  %>'></asp:Label>
    <br />


</ItemTemplate>



<FooterTemplate>

    
 

</FooterTemplate>

            </asp:Datalist>    
<!--
 <form method="post" action="mailto:someone@example.com">
 Subject: <input type="text" size="10" maxlength="40" name="subject"> 

Message: <textarea rows="5" cols="20" wrap="physical" name="Message">
 </textarea>
 <input type="submit" value="Send">
 </form>
-->


								<asp:Label ID="label1" runat="server"></asp:Label>	

                <uc1:articles2 ID="articles2" runat="server"></uc1:articles2>	                                           														
       


		</asp:Content>







