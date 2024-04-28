
<%@ Page Language="C#" MasterPageFile="MasterPage11.master" AutoEventWireup="true" CodeFile="when-is.aspx.cs" Inherits="whenis" 
Title="Sale on Thanks Giving and Black Friday"  CodeFileBaseClass="BasePage"  %>
<%@ Register Src="~/datablock/storelist.ascx" TagName="content" TagPrefix="uc1_content" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div align="left">
<form id="Form1" runat="server">	
								

<a href="http://www.thanks-giving.net/" >Home</a>  <span><asp:Label ID="lbltitle" runat="server"></asp:Label></span>
     
            
			

<h2><asp:hyperlink ID="hyperlink1" runat="server" ></asp:hyperlink></h2>
             


<asp:Repeater ID="RepDetails" runat="server"    >
   
                       <HeaderTemplate>
                     	

                                        
                        </HeaderTemplate>

                       <ItemTemplate>
          <h2> 
          
          <asp:Label ID="lbl1"  runat="server" Text='<%#Eval("event_date" , "{0:dd-MMM-yyyy}"  +" : " +  Eval("festival"))%>'></asp:Label>            

       </h2> 
         
   
          </ItemTemplate>

                    <FooterTemplate>  
                        
                          
                      </FooterTemplate>

                       </asp:Repeater>


      
    <br />

 <br />
		
       <asp:label ID="lblLinks"  runat="server"></asp:label>  &nbsp;&nbsp;
    <asp:hyperlink ID="hyperlink2"  runat="server"></asp:hyperlink>     



     <asp:Repeater ID="RepLinks" runat="server"    >
   
                       <HeaderTemplate>
                     	

                                        
                        </HeaderTemplate>

                       <ItemTemplate>


                      


                         <asp:HyperLink ID="HyperLink1" runat="server" Text='<%#Eval("year") %>'  NavigateUrl='<%# Global.Siteurl + LocalPath.Datefolder + @"\" + DataBinder.Eval(Container.DataItem, "festival") + "/" +  DataBinder.Eval(Container.DataItem, "year") + ".html" %>' >                                         '
                                 </asp:HyperLink>

,

                       </ItemTemplate>

                    <FooterTemplate>  
                        
                          
                      </FooterTemplate>

                       </asp:Repeater>
    													
 </form>
</div>

</asp:Content>