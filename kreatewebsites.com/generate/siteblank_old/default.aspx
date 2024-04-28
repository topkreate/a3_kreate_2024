<%@ Page Language="C#" MasterPageFile="masterpage.Master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Default" CodeFileBaseClass="BasePage" 
     %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
                                        
										<h2>
                                        
                                          <asp:Label ID="HyperLink1" runat="server" Text='<%#Eval("city")%>'  /> 
                                        </h2>
										
										<p>
										
                                            <p> Attractions in <asp:Label ID="Label0" runat="server" Text='<%#Eval("city") %>'/> : <b><asp:Label ID="lbl3" runat="server" Text='<%#Eval("place2") %>'/>  ,
<asp:Label ID="lbl4" runat="server" Text='<%#Eval("place1") %>'/> ,
<asp:Label ID="lbl6" runat="server" Text='<%#Eval("place3") %>'/> </b>...
                              
											
										</p>
									</section>


	
</asp:Content>