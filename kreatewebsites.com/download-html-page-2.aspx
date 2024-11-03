<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="download-html-page-2.aspx.cs" Inherits="Generate"  


 %>
 <html lang="en">

 <form runat="server">


     <br />
    
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Input Path : <asp:textbox ID="textbox_inputpath" runat="server" width="530"></asp:textbox> <br /><br />
  &nbsp;&nbsp;&nbsp;&nbsp;Output Path: <asp:textbox ID="textbox_outputpath" runat="server" width="530"></asp:textbox> 
     <br />
    
     <br />
     <br />
     <asp:button ID="button1" runat="server" text="Download on local drive" OnClick="button1_Click" width ="200" align="center" height="50"/>

     
     <br />
     <asp:label ID= "result" runat="server" ></asp:label>

	</form>

        </html>

