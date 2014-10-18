using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LofiEngine.Inputs;

namespace LofiEditor.Editors
{
    public partial class ConfigControlForm : Form
    {
        KeyMap KeyMap;

        public ConfigControlForm()
        {
            InitializeComponent();
        }
        public ConfigControlForm(KeyMap keyMap) : this()
        {
            KeyMap = keyMap;
        }

        private void ConfigControlForm_Load(object sender, EventArgs e)
        {
            lsb_gameKeys.Items.Clear();
            foreach (GameKey gameKey in KeyMap.GameKeys)
            {
                lsb_gameKeys.Items.Add(gameKey.Name);
            }
        }

        private void lsb_gameKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsb_gameKeys.SelectedItem != null)
            {
                tb_key.Text = KeyMap.GetKey(lsb_gameKeys.SelectedItem.ToString()).ToString();
            }
        }   

        private void tb_key_KeyUp(object sender, KeyEventArgs e)
        {
            if (lsb_gameKeys.SelectedItem != null)
            {
                String gameKeyName = lsb_gameKeys.SelectedItem.ToString();
                KeyMap.MapKey(gameKeyName, (Microsoft.Xna.Framework.Input.Keys)e.KeyCode);
                tb_key.Text = e.KeyCode.ToString();
            }
        }

        private void btn_clearKey_Click(object sender, EventArgs e)
        {
            if (lsb_gameKeys.SelectedItem != null)
            {
                String gameKeyName = KeyMap.GetKey(lsb_gameKeys.SelectedItem.ToString()).ToString();
                KeyMap.ClearMap(gameKeyName);
            }
        }

        private void btn_clearAll_Click(object sender, EventArgs e)
        {
            KeyMap.ClearAllMap();
        }

    }
}
