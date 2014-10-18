namespace Lofinil.GameSDK.Editor.App
{
    partial class ItemControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemControl));
            this.btn_loadItems = new System.Windows.Forms.Button();
            this.btn_removeFx = new System.Windows.Forms.Button();
            this.btn_addFx = new System.Windows.Forms.Button();
            this.btn_deleteGroup = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_addGroup = new System.Windows.Forms.Button();
            this.trv_itemCollection = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btn_loadItems
            // 
            this.btn_loadItems.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_loadItems.Location = new System.Drawing.Point(197, 551);
            this.btn_loadItems.Name = "btn_loadItems";
            this.btn_loadItems.Size = new System.Drawing.Size(41, 23);
            this.btn_loadItems.TabIndex = 21;
            this.btn_loadItems.Text = "载入";
            this.btn_loadItems.UseVisualStyleBackColor = true;
            // 
            // btn_removeFx
            // 
            this.btn_removeFx.Image = ((System.Drawing.Image)(resources.GetObject("btn_removeFx.Image")));
            this.btn_removeFx.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_removeFx.Location = new System.Drawing.Point(168, 549);
            this.btn_removeFx.Name = "btn_removeFx";
            this.btn_removeFx.Size = new System.Drawing.Size(27, 27);
            this.btn_removeFx.TabIndex = 20;
            this.btn_removeFx.UseVisualStyleBackColor = true;
            // 
            // btn_addFx
            // 
            this.btn_addFx.Image = ((System.Drawing.Image)(resources.GetObject("btn_addFx.Image")));
            this.btn_addFx.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_addFx.Location = new System.Drawing.Point(135, 549);
            this.btn_addFx.Name = "btn_addFx";
            this.btn_addFx.Size = new System.Drawing.Size(27, 27);
            this.btn_addFx.TabIndex = 19;
            this.btn_addFx.UseVisualStyleBackColor = true;
            // 
            // btn_deleteGroup
            // 
            this.btn_deleteGroup.Image = ((System.Drawing.Image)(resources.GetObject("btn_deleteGroup.Image")));
            this.btn_deleteGroup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_deleteGroup.Location = new System.Drawing.Point(36, 549);
            this.btn_deleteGroup.Name = "btn_deleteGroup";
            this.btn_deleteGroup.Size = new System.Drawing.Size(27, 27);
            this.btn_deleteGroup.TabIndex = 18;
            this.btn_deleteGroup.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(102, 549);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 27);
            this.button3.TabIndex = 17;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(69, 549);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 27);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_addGroup
            // 
            this.btn_addGroup.Image = ((System.Drawing.Image)(resources.GetObject("btn_addGroup.Image")));
            this.btn_addGroup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_addGroup.Location = new System.Drawing.Point(3, 549);
            this.btn_addGroup.Name = "btn_addGroup";
            this.btn_addGroup.Size = new System.Drawing.Size(27, 27);
            this.btn_addGroup.TabIndex = 15;
            this.btn_addGroup.UseVisualStyleBackColor = true;
            // 
            // trv_itemCollection
            // 
            this.trv_itemCollection.AllowDrop = true;
            this.trv_itemCollection.CheckBoxes = true;
            this.trv_itemCollection.Location = new System.Drawing.Point(3, 3);
            this.trv_itemCollection.Name = "trv_itemCollection";
            this.trv_itemCollection.Size = new System.Drawing.Size(231, 544);
            this.trv_itemCollection.TabIndex = 14;
            // 
            // ItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.btn_loadItems);
            this.Controls.Add(this.btn_removeFx);
            this.Controls.Add(this.btn_addFx);
            this.Controls.Add(this.btn_deleteGroup);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_addGroup);
            this.Controls.Add(this.trv_itemCollection);
            this.Name = "ItemPanel";
            this.Size = new System.Drawing.Size(241, 579);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_loadItems;
        private System.Windows.Forms.Button btn_removeFx;
        private System.Windows.Forms.Button btn_addFx;
        private System.Windows.Forms.Button btn_deleteGroup;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_addGroup;
        private System.Windows.Forms.TreeView trv_itemCollection;

    }
}
