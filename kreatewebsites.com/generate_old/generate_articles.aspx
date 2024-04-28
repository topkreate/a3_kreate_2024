<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="generate_articles.aspx.cs" Inherits="Generate" CodeFileBaseClass="BasePage" 


 %>
 <html>

 <form runat="server">


  Site Path :    <asp:textbox ID="textbox_sitepath" runat="server"></asp:textbox> <br />
  Computer Path : <asp:textbox ID="textbox_computerpath" runat="server"></asp:textbox>  <br />
  SiteFolder = <asp:textbox ID="textbox_sitefolder" runat="server"></asp:textbox> <br />
    
  Input Path : <asp:textbox ID="textbox_inputpath" runat="server"></asp:textbox> <br />
  Output Path = <asp:textbox ID="textbox_outputpath" runat="server"></asp:textbox> <br />


          Photopath = <asp:textbox ID="textbox_Photopath" runat="server"></asp:textbox> 
     Overwrite = <asp:textbox ID="check_overwrite" runat="server"></asp:textbox> 

     <asp:button ID="button1" runat="server" text="Generate" />

     
     <br />
     <asp:label ID= "result" runat="server" ></asp:label>

	</form>

        </html>

