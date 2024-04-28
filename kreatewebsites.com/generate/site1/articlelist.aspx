
<%@ Page Language="C#" MasterPageFile="MasterPage2023.master" AutoEventWireup="true" CodeFile="~/articlelist.aspx.cs" Inherits="Article" 
  CodeFileBaseClass="BasePage"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   


   

													<h2> <asp:Label ID="title" runat="server" ></asp:Label></h2>

    					 <span> <asp:Label ID="metadesc" runat="server" ></asp:Label></span>				
                        <br />     
                                                              
                                                                <asp:Datalist ID="RepDetails" runat="server"  RepeatColumns="1" RepeatDirection="Horizontal"  >
<HeaderTemplate>


</HeaderTemplate>

<ItemTemplate>


					

   <asp:Label ID="labeltext" runat="server"  ForeColor="Black" Font-Size="Medium" Text='<%# Eval("text")  %>'></asp:Label>

</ItemTemplate>



<FooterTemplate>



</FooterTemplate>

            </asp:Datalist>
     
	

</asp:Content>