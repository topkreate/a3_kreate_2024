<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="Copy of generate_page.aspx.cs" Inherits="Generate" CodeFileBaseClass="BasePage" 


 %>
 <html lang="en">

 <form runat="server">


     <br />
    
  Input Path : <asp:textbox ID="textbox_inputpath" runat="server"></asp:textbox> <br />
  Output Path = <asp:textbox ID="textbox_outputpath" runat="server"></asp:textbox> 
     <br />
     <br />
       Original string : <asp:textbox ID="textboxOrg" runat="server"></asp:textbox> ,   Replace with = <asp:textbox ID="textboxRep" runat="server"></asp:textbox> 


     <asp:button ID="button1" runat="server" text="Generate" OnClick="button1_Click" />

     
     <br />
     <asp:label ID= "result" runat="server" ></asp:label>

	</form>

        </html>

