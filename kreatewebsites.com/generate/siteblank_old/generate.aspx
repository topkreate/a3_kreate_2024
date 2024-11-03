<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="generate.aspx.cs" Inherits="Default" CodeFileBaseClass="BasePage" 


 %>
 <html lang="en">

 <form runat="server">


			<h2>New Input Path</h2>
    <asp:textbox ID="inputbox" runat="server"></asp:textbox>

    <h2>Output path</h2>


     <asp:textbox ID="outbox" runat="server"></asp:textbox>

  <asp:Button id="b1" Text="Submit" OnClick="submit" runat="server" />
      

	</form>

        </html>