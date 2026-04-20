using System.Drawing;
using System.Windows.Forms;

namespace ScaleGo
{
  public static class AppTheme
  {
    public static readonly Color BackColor = Color.FromArgb(245, 247, 250);
    public static readonly Color CardColor = Color.White;
    public static readonly Color Primary = Color.FromArgb(37, 99, 235);
    public static readonly Color PrimaryHover = Color.FromArgb(29, 78, 216);
    public static readonly Color Secondary = Color.FromArgb(71, 85, 105);
    public static readonly Color SecondaryHover = Color.FromArgb(51, 65, 85);
    public static readonly Color Success = Color.FromArgb(22, 163, 74);
    public static readonly Color Error = Color.FromArgb(220, 38, 38);
    public static readonly Color Text = Color.FromArgb(31, 41, 55);
    public static readonly Color MutedText = Color.FromArgb(107, 114, 128);
    public static readonly Color Border = Color.FromArgb(203, 213, 225);
    public static readonly Color ReadOnlyBack = Color.FromArgb(239, 246, 255);

    public static readonly Font TitleFont = new Font("Segoe UI", 16F, FontStyle.Bold);
    public static readonly Font DefaultFont = new Font("Segoe UI", 10.5F, FontStyle.Regular);
    public static readonly Font ButtonFont = new Font("Segoe UI", 10F, FontStyle.Bold);
    public static readonly Font WeightFont = new Font("Segoe UI", 18F, FontStyle.Bold);

    public static void StylePrimaryButton(Button btn)
    {
      btn.FlatStyle = FlatStyle.Flat;
      btn.FlatAppearance.BorderSize = 0;
      btn.BackColor = Primary;
      btn.ForeColor = Color.White;
      btn.Font = ButtonFont;
      btn.Cursor = Cursors.Hand;

      btn.MouseEnter += (s, e) => { btn.BackColor = PrimaryHover; };
      btn.MouseLeave += (s, e) => { btn.BackColor = Primary; };
    }

    public static void StyleSecondaryButton(Button btn)
    {
      btn.FlatStyle = FlatStyle.Flat;
      btn.FlatAppearance.BorderSize = 0;
      btn.BackColor = Secondary;
      btn.ForeColor = Color.White;
      btn.Font = ButtonFont;
      btn.Cursor = Cursors.Hand;

      btn.MouseEnter += (s, e) => { btn.BackColor = SecondaryHover; };
      btn.MouseLeave += (s, e) => { btn.BackColor = Secondary; };
    }

    public static void StyleTextBox(TextBox txt, bool isReadOnly = false)
    {
      txt.Font = DefaultFont;
      txt.BorderStyle = BorderStyle.FixedSingle;
      txt.BackColor = isReadOnly ? ReadOnlyBack : Color.White;
      txt.ForeColor = Text;
    }

    public static void ShowStatus(Label lbl, string text, bool isSuccess = false, bool isError = false)
    {
      lbl.Text = text;
      lbl.ForeColor = isError ? Error : isSuccess ? Success : MutedText;
    }

    public static Panel BuildHeader(Control parent, string title)
    {
      var header = new Panel();
      header.Dock = DockStyle.Top;
      header.Height = 60;
      header.BackColor = Primary;

      var lblTitle = new Label();
      lblTitle.AutoSize = true;
      lblTitle.Text = title;
      lblTitle.ForeColor = Color.White;
      lblTitle.Font = TitleFont;
      lblTitle.Location = new Point(18, 14);

      header.Controls.Add(lblTitle);
      parent.Controls.Add(header);
      header.BringToFront();

      return header;
    }
  }
}