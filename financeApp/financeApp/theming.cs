using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

public class theme
{
    public string name { get; set; }
    public Color primaryColor { get; set; }
    public Color accentColor { get; set; }
    public Color textColor { get; set; }
    public Color linkColor { get; set; }
    public Color buttonTextColor { get; set; }
    public Color selectionColor { get; set; }
    public Color positiveColor { get; set; }
    public Color negativeColor { get; set; }
    public Color neutralColor { get; set; }
    public readonly toolStripMenuColorTable toolStripColorTable;

    public theme() { }

    public theme(string name, string primaryColor, string accentColor, string textColor, string linkColor,
        string buttonTextColor, string selectionColor, string positiveColor, string negativeColor, string neutralColor)
    {
        this.name = name;
        this.primaryColor = ColorTranslator.FromHtml(primaryColor);
        this.accentColor = ColorTranslator.FromHtml(accentColor);
        this.textColor = ColorTranslator.FromHtml(textColor);
        this.linkColor = ColorTranslator.FromHtml(linkColor);
        this.buttonTextColor = ColorTranslator.FromHtml(buttonTextColor);
        this.selectionColor = ColorTranslator.FromHtml(selectionColor);
        this.positiveColor = ColorTranslator.FromHtml(positiveColor);
        this.negativeColor = ColorTranslator.FromHtml(negativeColor);
        this.neutralColor = ColorTranslator.FromHtml(neutralColor);

        this.toolStripColorTable = new toolStripMenuColorTable(this.accentColor, this.textColor, this.selectionColor);
    }


    public void themeForm(Form formToTheme)
    {
        formToTheme.BackColor = primaryColor;
        formToTheme.ForeColor = textColor;

        foreach(Control control in common.getChildControls(formToTheme))
        {
            themeControl(control);
        }
    }

    private void themeControl(Control controlToTheme)
    {
        switch (controlToTheme.GetType().Name.ToLower())
        {

            case "button":
                themeNeutralButton((Button)controlToTheme);
                break;

            case "label":
                themeLabel((Label)controlToTheme);
                break;

            case "linklabel":
                themeLabel((LinkLabel)controlToTheme);
                break;

            case "listbox":
                themeListBox((ListBox)controlToTheme);
                break;

            case "checkedlistbox":
                themeListBox((CheckedListBox)controlToTheme);
                break;

            case "mdiclient":
                controlToTheme.BackColor = this.primaryColor;
                break; 

            case "menustrip":
                themeMenuStrip((MenuStrip)controlToTheme);
                break;

            case "statusstrip":
                themeStatusStrip((StatusStrip)controlToTheme);
                break;
                
            default:
                break;
        }
    }

    public void themeNeutralButton(Button buttonToTheme)
    {
        buttonToTheme.FlatStyle = FlatStyle.Flat;
        buttonToTheme.FlatAppearance.BorderSize = 1;
        buttonToTheme.BackColor = this.neutralColor;
        buttonToTheme.FlatAppearance.MouseOverBackColor = ControlPaint.Light(this.neutralColor);
        buttonToTheme.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(this.neutralColor);
        buttonToTheme.ForeColor = this.textColor;
        buttonToTheme.Font = new Font(buttonToTheme.Font.FontFamily,buttonToTheme.Font.Size, FontStyle.Bold);
    }

    public void themePositiveButton(Button buttonToTheme)
    {
        buttonToTheme.FlatStyle = FlatStyle.Flat;
        buttonToTheme.FlatAppearance.BorderSize = 1;
        buttonToTheme.BackColor = this.positiveColor;
        buttonToTheme.FlatAppearance.MouseOverBackColor = ControlPaint.Light(this.positiveColor);
        buttonToTheme.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(this.positiveColor);
        buttonToTheme.ForeColor = this.textColor;
        buttonToTheme.Font = new Font(buttonToTheme.Font.FontFamily, buttonToTheme.Font.Size, FontStyle.Bold);
    }

    public void themeNegativeButton(Button buttonToTheme)
    {
        buttonToTheme.FlatStyle = FlatStyle.Flat;
        buttonToTheme.FlatAppearance.BorderSize = 1;
        buttonToTheme.BackColor = this.negativeColor;
        buttonToTheme.FlatAppearance.MouseOverBackColor = ControlPaint.Light(this.negativeColor);
        buttonToTheme.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(this.negativeColor);
        buttonToTheme.ForeColor = this.textColor;
        buttonToTheme.Font = new Font(buttonToTheme.Font.FontFamily, buttonToTheme.Font.Size, FontStyle.Bold);
    }


    private void themeLabel(Label labelToTheme)
    {
        labelToTheme.FlatStyle = FlatStyle.Flat;
        labelToTheme.BackColor = labelToTheme.Parent.BackColor;
        labelToTheme.ForeColor = this.textColor;

        if(labelToTheme.GetType().Name == "LinkLabel")
        {
            ((LinkLabel)labelToTheme).LinkColor = this.linkColor;
            ((LinkLabel)labelToTheme).ActiveLinkColor = this.linkColor;
        }
    }

    private void themeListBox(ListBox listBoxToTheme)
    {
        listBoxToTheme.BackColor = this.accentColor;
        listBoxToTheme.ForeColor = this.textColor;
    }

    public void themeMenuStrip(MenuStrip menuStripToTheme)
    {
        menuStripToTheme.ForeColor = this.textColor;
        menuStripToTheme.Renderer = new ToolStripProfessionalRenderer(this.toolStripColorTable);
        foreach (ToolStripMenuItem menuItem in getMenuItems(menuStripToTheme))
        {
            menuItem.ForeColor = this.textColor;
        }
    }

    private void themeStatusStrip(StatusStrip statusStripToTheme)
    {
        statusStripToTheme.BackColor = this.accentColor;
        statusStripToTheme.ForeColor = this.textColor;
    }


    private List<ToolStripMenuItem> getMenuItems(MenuStrip parentMenu)
    {
        List<ToolStripMenuItem> menuItems = new List<ToolStripMenuItem>();
        Stack<ToolStripMenuItem> stack = new Stack<ToolStripMenuItem>();

        foreach (ToolStripMenuItem menuItem in parentMenu.Items)
        {
            stack.Push(menuItem);
            menuItems.Add(menuItem);
        }

        while (stack.Count > 0)
        {
            foreach (object menuItem in stack.Pop().DropDownItems)
            {
                if (menuItem.GetType().Name == "ToolStripMenuItem")
                {
                    menuItems.Add((ToolStripMenuItem)menuItem);
                    if (((ToolStripMenuItem)menuItem).DropDownItems.Count > 0)
                    {
                        stack.Push((ToolStripMenuItem)menuItem);
                    }
                }
            }
        }
        return menuItems;
    }

    public class toolStripMenuColorTable : ProfessionalColorTable
    {
        private Color primaryColor;
        private Color textColor;
        private Color selectionColor;

        public toolStripMenuColorTable(Color primaryColor, Color textColor, Color selectionColor)
        {
            this.primaryColor = primaryColor;
            this.textColor = textColor;
            this.selectionColor = selectionColor;
        }

        /*override values of the base class*/
        public override Color SeparatorDark
        {
            get
            {
                return this.textColor;
            }
        }

        public override Color SeparatorLight
        {
            get
            {
                return this.textColor;
            }
        }

        public override Color ToolStripDropDownBackground
        {
            get
            {
                return this.primaryColor;
            }
        }

        public override Color ImageMarginGradientBegin
        {
            get
            {
                return this.primaryColor;
            }
        }

        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return this.primaryColor;
            }
        }

        public override Color ImageMarginGradientEnd
        {
            get
            {
                return this.primaryColor;
            }
        }

        public override Color MenuBorder
        {
            get
            {
                return ControlPaint.Light(this.primaryColor);
            }
        }

        public override Color MenuItemBorder
        {
            get
            {
                return ControlPaint.Light(this.primaryColor);
            }
        }

        public override Color MenuItemSelected
        {
            get
            {
                return this.selectionColor;
            }
        }

        public override Color MenuStripGradientBegin
        {
            get
            {
                return this.primaryColor;
            }
        }

        public override Color MenuStripGradientEnd
        {
            get
            {
                return this.primaryColor;
            }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return this.selectionColor;
            }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return this.selectionColor;
            }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return this.primaryColor;
            }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return this.primaryColor;
            }
        }
        
    }


}

