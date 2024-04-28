using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Text.RegularExpressions;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    private string _keywords;
    private string _description;
    // Constructor
    // Add an event handler to Init event for the control
    // so we can execute code when a server control (page)
    // that inherits from this base class is initialized.
    public BasePage()
    {
        Init += new EventHandler(BasePage_Init);
    }
    // Whenever a page that uses this base class is initialized
    // add meta keywords and descriptions if available
    void BasePage_Init(object sender, EventArgs e)
    {

        if (!String.IsNullOrEmpty(Meta_Keywords))
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "keywords";
            tag.Content = Meta_Keywords;
            Header.Controls.Add(tag);
        }

        if (!String.IsNullOrEmpty(Meta_Description))
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "description";
            tag.Content = Meta_Description;
            Header.Controls.Add(tag);
        }
    }

    /// <summary>
    /// Gets or sets the Meta Keywords tag for the page
    /// </summary>
    public string Meta_Keywords
    {
        get
        {
            return _keywords;
        }
        set
        {
            // strip out any excessive white-space, newlines and linefeeds
            _keywords = Regex.Replace(value, "\\s+", " ");
        }
    }

    /// <summary>
    /// Gets or sets the Meta Description tag for the page
    /// </summary>
    public string Meta_Description
    {
        get
        {
            return _description;
        }
        set
        {
            // strip out any excessive white-space, newlines and linefeeds
            _description = Regex.Replace(value, "\\s+", " ");
        }
    }

}
