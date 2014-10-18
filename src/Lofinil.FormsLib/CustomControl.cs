using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lofinil.GameSDK.Editor;

namespace Lofinil.GameSDK.Editor.App
{
    // 该控件用于支持ICustomView在Winform下的实现
    public partial class CustomControl : UserControl
    {
        // 简单布局设置
        public DockStyle ControlDock { get; set; }

        public CustomControl()
        {
            InitializeComponent();

            ControlDock = DockStyle.Top;
        }

        public void AddCheckBox(String name, String text, bool initCheck)
        {
            CheckBox cb = new CheckBox();
            cb.AutoSize = true;
            cb.Dock = ControlDock;
            cb.Text = text;
            cb.Checked = initCheck;
            cb.Tag = name;
            Controls.Add(cb);
        }

        public bool GetCheckBoxChecked(String name)
        {
            foreach (Control c in Controls)
            {
                if (c is CheckBox && c.Tag.ToString() == name)
                {
                    return ((CheckBox)c).Checked;
                }
            }
            return false;
        }

        public void AddRadioGroup(String name, String[] radioText, int initCheck)
        {
            int count = radioText.Count();
            RadioButton[] rbs = new RadioButton[count];

            Panel radioPanel = new Panel();
            radioPanel.AutoSize = true;
            radioPanel.Dock = DockStyle.Left;
            radioPanel.Tag = name;

            for (int i = 0; i < count; i++)
            {
                rbs[i] = new RadioButton();
                rbs[i].AutoSize = true;
                rbs[i].Dock = DockStyle.Left;
                rbs[i].Text = radioText[i];
                if (initCheck == i)
                    rbs[i].Checked = true;
                radioPanel.Controls.Add(rbs[i]);
            }

            Controls.Add(radioPanel);
        }

        public int GetRadioGroupChecked(String name)
        {
            foreach (Control p in Controls)
            {
                if (p is Panel && p.Tag.ToString() == name)
                {
                    for (int i = 0; i < p.Controls.Count; i++)
                    {
                        RadioButton r = p.Controls[i] as RadioButton;
                        if (r.Checked)
                            return i;
                    }
                }
            }
            return -1;
        }

        public void AddComboBox(String name, String[] options, int initChoice)
        {
            ComboBox cb = new ComboBox();
            cb.Dock = DockStyle.Left;
            cb.Items.AddRange(options);
            cb.SelectedIndex = initChoice;
            Controls.Add(cb);
        }

        public String GetComboBoxText(String name)
        {
            foreach (Control c in Controls)
            {
                if (c is ComboBox && c.Tag.ToString() == name)
                {
                    return (c as ComboBox).Text;
                }
            }
            return "";
        }

        public void AddButton(String text, Action callBack)
        {
            Button button = new Button();
            button.AutoSize = true;
            button.Dock = DockStyle.Left;
            button.Text = text;
            button.Click += delegate { callBack(); };
            Controls.Add(button);
        }

        public void AddTextBox(String name, String labelText, String text)
        {
            Panel fPnl = new Panel();
            fPnl.Dock = ControlDock;
            //fPnl.AutoSize = true;

            Label label = new Label();
            label.Text = labelText;
            label.Dock = DockStyle.Left;

            TextBox tb = new TextBox();
            tb.Tag = name;
            tb.Text = text;
            tb.Dock = DockStyle.Left;

            fPnl.Controls.Add(tb);
            fPnl.Controls.Add(label);

            Controls.Add(fPnl);
        }

        public String GetTextBoxText(String name)
        {
            return findControl<TextBox>(name, Controls).Text;
        }

        public void AddPathInput(String name, String labelText, String initPath)
        {
            Panel fPnl = new Panel();
           // fPnl.Dock = ControlDock;
            //fPnl.AutoSize = true;

            Label label = new Label();
            label.Text = labelText;
            label.Dock = DockStyle.Left;
            fPnl.Controls.Add(label);

            TextBox tb = new TextBox();
            tb.Text = initPath;
            tb.Tag = name;
            tb.Dock = DockStyle.Left;
            fPnl.Controls.Add(tb);

            Button btn = new Button();
            btn.Text = "...";
            btn.Dock = DockStyle.Left;
            btn.AutoSize = true;
            btn.Click += delegate
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog();
                dlg.SelectedPath = initPath;
                dlg.ShowNewFolderButton = true;
                DialogResult dr = dlg.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tb.Text = dlg.SelectedPath;
                }
            };
            fPnl.Controls.Add(btn);

            Controls.Add(fPnl);
        }

        public String GetPathInput(String name)
        {
            return findControl<TextBox>(name, Controls).Text;
        }

        public void AddFileInput(String name, String labelText, String initFile, String filter)
        {
            FlowLayoutPanel fPnl = new FlowLayoutPanel();
            fPnl.Dock = ControlDock;

            Label label = new Label();
            label.Text = labelText;
            label.Dock = DockStyle.Left;
            fPnl.Controls.Add(label);

            TextBox tb = new TextBox();
            tb.Text = initFile;
            tb.Tag = name;
            tb.Dock = DockStyle.Left;
            fPnl.Controls.Add(tb);

            Button btn = new Button();
            btn.Text = "...";
            btn.Dock = DockStyle.Left;
            btn.Click += delegate
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = initFile;
                dlg.Filter = filter;
                DialogResult dr = dlg.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tb.Text = dlg.FileName;
                }
            };
            fPnl.Controls.Add(btn);

            Controls.Add(fPnl);
        }

        public String GetFileInput(String name)
        {
            return findControl<TextBox>(name, Controls).Text;
        }

        public void Clear()
        {
            // 释放句柄避免内存泄露
            foreach (Control c in Controls)
                c.Dispose();
            Controls.Clear();
        }

        private T findControl<T>(String name, ControlCollection controls) where T:Control
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is T && ctrl.Tag.ToString() == name)
                {
                    return (T)ctrl;
                }
                else if (ctrl.Controls.Count > 0)
                {
                    T findInSub = findControl<T>(name, ctrl.Controls);
                    if (findInSub != default(T))
                        return findInSub;
                }
            }
            return default(T);
        }

        public void AddMultiLineLabel(String text)
        {
            TextBox tb = new TextBox();
            tb.Multiline = true;
            tb.Text = text;
            tb.Dock = ControlDock;
            Controls.Add(tb);
        }
    }

}
