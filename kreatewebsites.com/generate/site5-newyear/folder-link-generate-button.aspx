﻿ 

<%@ Page Language="C#" MasterPageFile="~/generate/site5/masterpage_blank.Master" AutoEventWireup="true" CodeFile="folder-link-generate-button.aspx.cs" Inherits="Article" CodeFileBaseClass="BasePage" 

%>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 

    <asp:Repeater ID="RepLinks" runat="server"    >
<HeaderTemplate>

    
</HeaderTemplate>

<ItemTemplate>


												
									
		<asp:hyperlink ID="buttonmain"  runat="server" Text='<%# Eval("name") %>' NavigateUrl='<%#  Eval("url") %>' >
            
            </asp:hyperlink>
      
    	 
                                               		


</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Repeater>

    
		</asp:Content>
             
 
 
 
