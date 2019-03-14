namespace wordchain_GUI
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.output_filePath = new System.Windows.Forms.TextBox();
            this.outputFile = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.select_file = new System.Windows.Forms.Button();
            this.input_text = new System.Windows.Forms.RadioButton();
            this.input_file = new System.Windows.Forms.RadioButton();
            this.inputText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.word_mode = new System.Windows.Forms.RadioButton();
            this.char_mode = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.Label();
            this.start_cat = new System.Windows.Forms.Button();
            this.tail_mode = new System.Windows.Forms.CheckBox();
            this.head_mode = new System.Windows.Forms.CheckBox();
            this.tail_alpha = new System.Windows.Forms.ListBox();
            this.head_alpha = new System.Windows.Forms.ListBox();
            this.enableLoop = new System.Windows.Forms.CheckBox();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.output_filePath);
            this.panel3.Controls.Add(this.outputFile);
            this.panel3.Location = new System.Drawing.Point(508, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(184, 100);
            this.panel3.TabIndex = 29;
            // 
            // output_filePath
            // 
            this.output_filePath.Location = new System.Drawing.Point(19, 49);
            this.output_filePath.Name = "output_filePath";
            this.output_filePath.Size = new System.Drawing.Size(144, 25);
            this.output_filePath.TabIndex = 12;
            this.output_filePath.TextChanged += new System.EventHandler(this.output_filePath_TextChanged);
            // 
            // outputFile
            // 
            this.outputFile.AutoSize = true;
            this.outputFile.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.outputFile.Location = new System.Drawing.Point(15, 18);
            this.outputFile.Name = "outputFile";
            this.outputFile.Size = new System.Drawing.Size(164, 23);
            this.outputFile.TabIndex = 11;
            this.outputFile.Text = "结果导出到文件";
            this.outputFile.UseVisualStyleBackColor = true;
            this.outputFile.CheckedChanged += new System.EventHandler(this.outputFile_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.AllowDrop = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.select_file);
            this.panel2.Controls.Add(this.input_text);
            this.panel2.Controls.Add(this.input_file);
            this.panel2.Controls.Add(this.inputText);
            this.panel2.Location = new System.Drawing.Point(59, 230);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 156);
            this.panel2.TabIndex = 28;
            // 
            // select_file
            // 
            this.select_file.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.select_file.Location = new System.Drawing.Point(23, 72);
            this.select_file.Name = "select_file";
            this.select_file.Size = new System.Drawing.Size(160, 31);
            this.select_file.TabIndex = 30;
            this.select_file.Text = "选择单词文件";
            this.select_file.UseVisualStyleBackColor = true;
            this.select_file.Click += new System.EventHandler(this.select_file_Click);
            // 
            // input_text
            // 
            this.input_text.AutoSize = true;
            this.input_text.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.input_text.Location = new System.Drawing.Point(5, 16);
            this.input_text.Name = "input_text";
            this.input_text.Size = new System.Drawing.Size(144, 23);
            this.input_text.TabIndex = 8;
            this.input_text.Text = "直接输入单词";
            this.input_text.UseVisualStyleBackColor = true;
            this.input_text.CheckedChanged += new System.EventHandler(this.input_text_CheckedChanged);
            this.input_text.TextChanged += new System.EventHandler(this.input_text_CheckedChanged);
            // 
            // input_file
            // 
            this.input_file.AutoSize = true;
            this.input_file.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.input_file.Location = new System.Drawing.Point(5, 43);
            this.input_file.Name = "input_file";
            this.input_file.Size = new System.Drawing.Size(144, 23);
            this.input_file.TabIndex = 9;
            this.input_file.Text = "输入文件路径";
            this.input_file.UseVisualStyleBackColor = true;
            this.input_file.CheckedChanged += new System.EventHandler(this.input_file_CheckedChanged);
            this.input_file.TextChanged += new System.EventHandler(this.input_file_CheckedChanged);
            // 
            // inputText
            // 
            this.inputText.AllowDrop = true;
            this.inputText.Location = new System.Drawing.Point(23, 109);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(176, 25);
            this.inputText.TabIndex = 10;
            this.inputText.TextChanged += new System.EventHandler(this.inputText_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.word_mode);
            this.panel1.Controls.Add(this.char_mode);
            this.panel1.Location = new System.Drawing.Point(59, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 86);
            this.panel1.TabIndex = 27;
            // 
            // word_mode
            // 
            this.word_mode.AutoSize = true;
            this.word_mode.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.word_mode.Location = new System.Drawing.Point(19, 13);
            this.word_mode.Name = "word_mode";
            this.word_mode.Size = new System.Drawing.Size(146, 23);
            this.word_mode.TabIndex = 3;
            this.word_mode.Text = "单词最多(-w)";
            this.word_mode.UseVisualStyleBackColor = true;
            this.word_mode.CheckedChanged += new System.EventHandler(this.word_mode_CheckedChanged);
            this.word_mode.TextChanged += new System.EventHandler(this.word_mode_CheckedChanged);
            this.word_mode.Click += new System.EventHandler(this.word_mode_CheckedChanged);
            // 
            // char_mode
            // 
            this.char_mode.AutoSize = true;
            this.char_mode.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.char_mode.Location = new System.Drawing.Point(19, 42);
            this.char_mode.Name = "char_mode";
            this.char_mode.Size = new System.Drawing.Size(146, 23);
            this.char_mode.TabIndex = 4;
            this.char_mode.Text = "字母最多(-a)";
            this.char_mode.UseVisualStyleBackColor = true;
            this.char_mode.CheckedChanged += new System.EventHandler(this.char_mode_CheckedChanged);
            this.char_mode.TextChanged += new System.EventHandler(this.char_mode_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(528, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 26;
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.result.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.result.ForeColor = System.Drawing.Color.Blue;
            this.result.Location = new System.Drawing.Point(508, 226);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(106, 21);
            this.result.TabIndex = 25;
            this.result.Text = "计算结果：";
            this.result.Click += new System.EventHandler(this.result_Click);
            // 
            // start_cat
            // 
            this.start_cat.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.start_cat.ForeColor = System.Drawing.Color.Red;
            this.start_cat.Location = new System.Drawing.Point(508, 159);
            this.start_cat.Name = "start_cat";
            this.start_cat.Size = new System.Drawing.Size(207, 41);
            this.start_cat.TabIndex = 24;
            this.start_cat.Text = "开始计算单词链";
            this.start_cat.UseVisualStyleBackColor = true;
            this.start_cat.Click += new System.EventHandler(this.start_Click);
            // 
            // tail_mode
            // 
            this.tail_mode.AutoSize = true;
            this.tail_mode.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tail_mode.Location = new System.Drawing.Point(330, 230);
            this.tail_mode.Name = "tail_mode";
            this.tail_mode.Size = new System.Drawing.Size(126, 23);
            this.tail_mode.TabIndex = 23;
            this.tail_mode.Text = "指定尾字母";
            this.tail_mode.UseVisualStyleBackColor = true;
            this.tail_mode.CheckedChanged += new System.EventHandler(this.tail_mode_CheckedChanged);
            // 
            // head_mode
            // 
            this.head_mode.AutoSize = true;
            this.head_mode.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.head_mode.Location = new System.Drawing.Point(330, 40);
            this.head_mode.Name = "head_mode";
            this.head_mode.Size = new System.Drawing.Size(126, 23);
            this.head_mode.TabIndex = 22;
            this.head_mode.Text = "指定首字母";
            this.head_mode.UseVisualStyleBackColor = true;
            this.head_mode.CheckedChanged += new System.EventHandler(this.head_mode_CheckedChanged);
            // 
            // tail_alpha
            // 
            this.tail_alpha.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tail_alpha.FormattingEnabled = true;
            this.tail_alpha.ItemHeight = 18;
            this.tail_alpha.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g",
            "h",
            "i",
            "j",
            "k",
            "l",
            "m",
            "n",
            "o",
            "p",
            "q",
            "r",
            "s",
            "t",
            "u",
            "v",
            "w",
            "x",
            "y",
            "z"});
            this.tail_alpha.Location = new System.Drawing.Point(330, 255);
            this.tail_alpha.Name = "tail_alpha";
            this.tail_alpha.Size = new System.Drawing.Size(120, 112);
            this.tail_alpha.TabIndex = 21;
            this.tail_alpha.SelectedIndexChanged += new System.EventHandler(this.tail_SelectedIndexChanged);
            // 
            // head_alpha
            // 
            this.head_alpha.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.head_alpha.FormattingEnabled = true;
            this.head_alpha.ItemHeight = 18;
            this.head_alpha.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g",
            "h",
            "i",
            "j",
            "k",
            "l",
            "m",
            "n",
            "o",
            "p",
            "q",
            "r",
            "s",
            "t",
            "u",
            "v",
            "w",
            "x",
            "y",
            "z"});
            this.head_alpha.Location = new System.Drawing.Point(330, 65);
            this.head_alpha.Name = "head_alpha";
            this.head_alpha.Size = new System.Drawing.Size(120, 112);
            this.head_alpha.TabIndex = 20;
            this.head_alpha.SelectedIndexChanged += new System.EventHandler(this.head_SelectedIndexChanged);
            // 
            // enableLoop
            // 
            this.enableLoop.AutoSize = true;
            this.enableLoop.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.enableLoop.Location = new System.Drawing.Point(59, 40);
            this.enableLoop.Name = "enableLoop";
            this.enableLoop.Size = new System.Drawing.Size(126, 23);
            this.enableLoop.TabIndex = 19;
            this.enableLoop.Text = "允许单词环";
            this.enableLoop.UseVisualStyleBackColor = true;
            this.enableLoop.CheckedChanged += new System.EventHandler(this.enableLoop_CheckedChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.result);
            this.Controls.Add(this.start_cat);
            this.Controls.Add(this.tail_mode);
            this.Controls.Add(this.head_mode);
            this.Controls.Add(this.tail_alpha);
            this.Controls.Add(this.head_alpha);
            this.Controls.Add(this.enableLoop);
            this.Name = "Form1";
            this.Text = "WordChain";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox output_filePath;
        private System.Windows.Forms.CheckBox outputFile;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton input_text;
        private System.Windows.Forms.RadioButton input_file;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton word_mode;
        private System.Windows.Forms.RadioButton char_mode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Button start_cat;
        private System.Windows.Forms.CheckBox tail_mode;
        private System.Windows.Forms.CheckBox head_mode;
        private System.Windows.Forms.ListBox tail_alpha;
        private System.Windows.Forms.ListBox head_alpha;
        private System.Windows.Forms.CheckBox enableLoop;
        private System.Windows.Forms.Button select_file;
    }
}

