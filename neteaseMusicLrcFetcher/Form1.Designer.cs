namespace neteaseMusicLrcFetcher
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.songLink = new System.Windows.Forms.TextBox();
            this.songList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lyricDisplay = new System.Windows.Forms.TextBox();
            this.btnFetchLyric = new System.Windows.Forms.Button();
            this.addToList = new System.Windows.Forms.Button();
            this.rightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delAll = new System.Windows.Forms.Button();
            this.pasteAndAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.songName = new System.Windows.Forms.TextBox();
            this.singer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.saveAll = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rightClickMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // songLink
            // 
            this.songLink.Location = new System.Drawing.Point(66, 17);
            this.songLink.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.songLink.Name = "songLink";
            this.songLink.Size = new System.Drawing.Size(520, 23);
            this.songLink.TabIndex = 1;
            this.songLink.Text = "http://music.163.com/song?id=1359613968&userid=529713057";
            // 
            // songList
            // 
            this.songList.FormattingEnabled = true;
            this.songList.ItemHeight = 17;
            this.songList.Location = new System.Drawing.Point(14, 103);
            this.songList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.songList.Name = "songList";
            this.songList.Size = new System.Drawing.Size(240, 531);
            this.songList.TabIndex = 2;
            this.songList.SelectedIndexChanged += new System.EventHandler(this.songList_SelectedIndexChanged);
            this.songList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 4;
            // 
            // lyricDisplay
            // 
            this.lyricDisplay.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lyricDisplay.Location = new System.Drawing.Point(260, 103);
            this.lyricDisplay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lyricDisplay.Multiline = true;
            this.lyricDisplay.Name = "lyricDisplay";
            this.lyricDisplay.ReadOnly = true;
            this.lyricDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.lyricDisplay.Size = new System.Drawing.Size(456, 531);
            this.lyricDisplay.TabIndex = 5;
            this.lyricDisplay.TextChanged += new System.EventHandler(this.lyricDisplay_TextChanged);
            // 
            // btnFetchLyric
            // 
            this.btnFetchLyric.Location = new System.Drawing.Point(113, 645);
            this.btnFetchLyric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFetchLyric.Name = "btnFetchLyric";
            this.btnFetchLyric.Size = new System.Drawing.Size(141, 30);
            this.btnFetchLyric.TabIndex = 6;
            this.btnFetchLyric.UseVisualStyleBackColor = true;
            this.btnFetchLyric.Click += new System.EventHandler(this.button2_Click);
            // 
            // addToList
            // 
            this.addToList.Location = new System.Drawing.Point(14, 55);
            this.addToList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addToList.Name = "addToList";
            this.addToList.Size = new System.Drawing.Size(240, 30);
            this.addToList.TabIndex = 8;
            this.addToList.UseVisualStyleBackColor = true;
            this.addToList.Click += new System.EventHandler(this.button4_Click);
            // 
            // rightClickMenu
            // 
            this.rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.rightClickMenu.Name = "rightClickMenu";
            this.rightClickMenu.Size = new System.Drawing.Size(113, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.deleteToolStripMenuItem.Text = "delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // delAll
            // 
            this.delAll.Location = new System.Drawing.Point(12, 645);
            this.delAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.delAll.Name = "delAll";
            this.delAll.Size = new System.Drawing.Size(95, 30);
            this.delAll.TabIndex = 10;
            this.delAll.UseVisualStyleBackColor = true;
            this.delAll.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pasteAndAdd
            // 
            this.pasteAndAdd.Location = new System.Drawing.Point(597, 15);
            this.pasteAndAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pasteAndAdd.Name = "pasteAndAdd";
            this.pasteAndAdd.Size = new System.Drawing.Size(119, 26);
            this.pasteAndAdd.TabIndex = 11;
            this.pasteAndAdd.UseVisualStyleBackColor = true;
            this.pasteAndAdd.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 12;
            // 
            // songName
            // 
            this.songName.Location = new System.Drawing.Point(312, 59);
            this.songName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.songName.Name = "songName";
            this.songName.ReadOnly = true;
            this.songName.Size = new System.Drawing.Size(174, 23);
            this.songName.TabIndex = 13;
            // 
            // singer
            // 
            this.singer.Location = new System.Drawing.Point(542, 59);
            this.singer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.singer.Name = "singer";
            this.singer.ReadOnly = true;
            this.singer.Size = new System.Drawing.Size(174, 23);
            this.singer.TabIndex = 14;
            this.singer.TextChanged += new System.EventHandler(this.singer_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(498, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 684);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 33);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(599, 641);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 86);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "语言/Lang";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(98, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "中文（简体）";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 49);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(67, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "English";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // saveAll
            // 
            this.saveAll.Location = new System.Drawing.Point(159, 684);
            this.saveAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveAll.Name = "saveAll";
            this.saveAll.Size = new System.Drawing.Size(95, 33);
            this.saveAll.TabIndex = 18;
            this.saveAll.UseVisualStyleBackColor = true;
            this.saveAll.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(260, 663);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(326, 53);
            this.textBox1.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Location = new System.Drawing.Point(260, 641);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 730);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.saveAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.singer);
            this.Controls.Add(this.songName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pasteAndAdd);
            this.Controls.Add(this.delAll);
            this.Controls.Add(this.addToList);
            this.Controls.Add(this.btnFetchLyric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.songList);
            this.Controls.Add(this.songLink);
            this.Controls.Add(this.lyricDisplay);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.rightClickMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox songLink;
        private System.Windows.Forms.ListBox songList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lyricDisplay;
        private System.Windows.Forms.Button btnFetchLyric;
        private System.Windows.Forms.Button addToList;
        private System.Windows.Forms.ContextMenuStrip rightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button delAll;
        private System.Windows.Forms.Button pasteAndAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox songName;
        private System.Windows.Forms.TextBox singer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button saveAll;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
    }
}

