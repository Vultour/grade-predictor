namespace GradePredictor.GUI
{
    partial class MainWindowView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpStart = new System.Windows.Forms.TabPage();
            this.btnStartLoadAuto = new System.Windows.Forms.Button();
            this.btnStartNew = new System.Windows.Forms.Button();
            this.btnStartLoad = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpOne = new System.Windows.Forms.TabPage();
            this.btnAddOne = new System.Windows.Forms.Button();
            this.lblHelpOne = new System.Windows.Forms.Label();
            this.tpTwo = new System.Windows.Forms.TabPage();
            this.btnAddTwo = new System.Windows.Forms.Button();
            this.lblHelpTwo = new System.Windows.Forms.Label();
            this.tpThree = new System.Windows.Forms.TabPage();
            this.btnAddThree = new System.Windows.Forms.Button();
            this.lblHelpThree = new System.Windows.Forms.Label();
            this.tpSummary = new System.Windows.Forms.TabPage();
            this.lblYearThree = new System.Windows.Forms.Label();
            this.lblYearTwo = new System.Windows.Forms.Label();
            this.lblYearOne = new System.Windows.Forms.Label();
            this.lblHelpYearThree = new System.Windows.Forms.Label();
            this.lblHelpYearTwo = new System.Windows.Forms.Label();
            this.lblHelpYearOne = new System.Windows.Forms.Label();
            this.separator4 = new System.Windows.Forms.Label();
            this.separator3 = new System.Windows.Forms.Label();
            this.separator2 = new System.Windows.Forms.Label();
            this.lblHelpDegree = new System.Windows.Forms.Label();
            this.separator1 = new System.Windows.Forms.Label();
            this.lblDegree = new System.Windows.Forms.Label();
            this.rbOne = new System.Windows.Forms.RadioButton();
            this.rbTwo = new System.Windows.Forms.RadioButton();
            this.rbThree = new System.Windows.Forms.RadioButton();
            this.rbSummary = new System.Windows.Forms.RadioButton();
            this.mainStatus = new System.Windows.Forms.StatusStrip();
            this.lblMessages = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbEditTitle = new System.Windows.Forms.PictureBox();
            this.btnRestart = new System.Windows.Forms.Button();
            this.tcMain.SuspendLayout();
            this.tpStart.SuspendLayout();
            this.tpOne.SuspendLayout();
            this.tpTwo.SuspendLayout();
            this.tpThree.SuspendLayout();
            this.tpSummary.SuspendLayout();
            this.mainStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tcMain.Controls.Add(this.tpStart);
            this.tcMain.Controls.Add(this.tpOne);
            this.tcMain.Controls.Add(this.tpTwo);
            this.tcMain.Controls.Add(this.tpThree);
            this.tcMain.Controls.Add(this.tpSummary);
            this.tcMain.ItemSize = new System.Drawing.Size(0, 1);
            this.tcMain.Location = new System.Drawing.Point(146, 59);
            this.tcMain.Multiline = true;
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(484, 298);
            this.tcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcMain.TabIndex = 0;
            // 
            // tpStart
            // 
            this.tpStart.Controls.Add(this.btnStartLoadAuto);
            this.tpStart.Controls.Add(this.btnStartNew);
            this.tpStart.Controls.Add(this.btnStartLoad);
            this.tpStart.Controls.Add(this.label2);
            this.tpStart.Controls.Add(this.label1);
            this.tpStart.Location = new System.Drawing.Point(4, 5);
            this.tpStart.Name = "tpStart";
            this.tpStart.Size = new System.Drawing.Size(476, 289);
            this.tpStart.TabIndex = 4;
            this.tpStart.Text = "Start";
            this.tpStart.UseVisualStyleBackColor = true;
            // 
            // btnStartLoadAuto
            // 
            this.btnStartLoadAuto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartLoadAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartLoadAuto.Location = new System.Drawing.Point(69, 167);
            this.btnStartLoadAuto.Name = "btnStartLoadAuto";
            this.btnStartLoadAuto.Size = new System.Drawing.Size(110, 43);
            this.btnStartLoadAuto.TabIndex = 4;
            this.btnStartLoadAuto.Text = "Load last";
            this.btnStartLoadAuto.UseVisualStyleBackColor = true;
            // 
            // btnStartNew
            // 
            this.btnStartNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartNew.Location = new System.Drawing.Point(301, 167);
            this.btnStartNew.Name = "btnStartNew";
            this.btnStartNew.Size = new System.Drawing.Size(110, 43);
            this.btnStartNew.TabIndex = 3;
            this.btnStartNew.Text = "New";
            this.btnStartNew.UseVisualStyleBackColor = true;
            // 
            // btnStartLoad
            // 
            this.btnStartLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartLoad.Location = new System.Drawing.Point(185, 167);
            this.btnStartLoad.Name = "btnStartLoad";
            this.btnStartLoad.Size = new System.Drawing.Size(110, 43);
            this.btnStartLoad.TabIndex = 2;
            this.btnStartLoad.Text = "Load file";
            this.btnStartLoad.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome, choose one of the options below to start!";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grade Predictor";
            // 
            // tpOne
            // 
            this.tpOne.AutoScroll = true;
            this.tpOne.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.tpOne.Controls.Add(this.btnAddOne);
            this.tpOne.Controls.Add(this.lblHelpOne);
            this.tpOne.Location = new System.Drawing.Point(4, 5);
            this.tpOne.Name = "tpOne";
            this.tpOne.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tpOne.Size = new System.Drawing.Size(476, 289);
            this.tpOne.TabIndex = 0;
            this.tpOne.Text = "Year 1";
            this.tpOne.UseVisualStyleBackColor = true;
            // 
            // btnAddOne
            // 
            this.btnAddOne.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddOne.Image = global::GradePredictor.Properties.Resources.IconPlusMedium;
            this.btnAddOne.Location = new System.Drawing.Point(221, 147);
            this.btnAddOne.Name = "btnAddOne";
            this.btnAddOne.Size = new System.Drawing.Size(36, 36);
            this.btnAddOne.TabIndex = 1;
            this.btnAddOne.TabStop = false;
            this.btnAddOne.UseVisualStyleBackColor = true;
            // 
            // lblHelpOne
            // 
            this.lblHelpOne.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHelpOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelpOne.Location = new System.Drawing.Point(69, 92);
            this.lblHelpOne.Name = "lblHelpOne";
            this.lblHelpOne.Size = new System.Drawing.Size(340, 52);
            this.lblHelpOne.TabIndex = 0;
            this.lblHelpOne.Text = "There are no modules in this year yet. Add one by clicking on the button below:";
            this.lblHelpOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpTwo
            // 
            this.tpTwo.AutoScroll = true;
            this.tpTwo.Controls.Add(this.btnAddTwo);
            this.tpTwo.Controls.Add(this.lblHelpTwo);
            this.tpTwo.Location = new System.Drawing.Point(4, 5);
            this.tpTwo.Name = "tpTwo";
            this.tpTwo.Size = new System.Drawing.Size(476, 289);
            this.tpTwo.TabIndex = 1;
            this.tpTwo.Text = "Year 2";
            this.tpTwo.UseVisualStyleBackColor = true;
            // 
            // btnAddTwo
            // 
            this.btnAddTwo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddTwo.Image = global::GradePredictor.Properties.Resources.IconPlusMedium;
            this.btnAddTwo.Location = new System.Drawing.Point(221, 147);
            this.btnAddTwo.Name = "btnAddTwo";
            this.btnAddTwo.Size = new System.Drawing.Size(36, 36);
            this.btnAddTwo.TabIndex = 1;
            this.btnAddTwo.TabStop = false;
            this.btnAddTwo.UseVisualStyleBackColor = true;
            // 
            // lblHelpTwo
            // 
            this.lblHelpTwo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHelpTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelpTwo.Location = new System.Drawing.Point(69, 92);
            this.lblHelpTwo.Name = "lblHelpTwo";
            this.lblHelpTwo.Size = new System.Drawing.Size(340, 52);
            this.lblHelpTwo.TabIndex = 0;
            this.lblHelpTwo.Text = "There are no modules in this year yet. Add one by clicking on the button below:";
            this.lblHelpTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpThree
            // 
            this.tpThree.AutoScroll = true;
            this.tpThree.BackColor = System.Drawing.SystemColors.Control;
            this.tpThree.Controls.Add(this.btnAddThree);
            this.tpThree.Controls.Add(this.lblHelpThree);
            this.tpThree.Location = new System.Drawing.Point(4, 5);
            this.tpThree.Name = "tpThree";
            this.tpThree.Size = new System.Drawing.Size(476, 289);
            this.tpThree.TabIndex = 2;
            this.tpThree.Text = "Year 3";
            // 
            // btnAddThree
            // 
            this.btnAddThree.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddThree.Image = global::GradePredictor.Properties.Resources.IconPlusMedium;
            this.btnAddThree.Location = new System.Drawing.Point(221, 147);
            this.btnAddThree.Name = "btnAddThree";
            this.btnAddThree.Size = new System.Drawing.Size(36, 36);
            this.btnAddThree.TabIndex = 1;
            this.btnAddThree.TabStop = false;
            this.btnAddThree.UseVisualStyleBackColor = true;
            // 
            // lblHelpThree
            // 
            this.lblHelpThree.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHelpThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelpThree.Location = new System.Drawing.Point(69, 92);
            this.lblHelpThree.Name = "lblHelpThree";
            this.lblHelpThree.Size = new System.Drawing.Size(340, 52);
            this.lblHelpThree.TabIndex = 0;
            this.lblHelpThree.Text = "There are no modules in this year yet. Add one by clicking on the button below:";
            this.lblHelpThree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpSummary
            // 
            this.tpSummary.Controls.Add(this.lblYearThree);
            this.tpSummary.Controls.Add(this.lblYearTwo);
            this.tpSummary.Controls.Add(this.lblYearOne);
            this.tpSummary.Controls.Add(this.lblHelpYearThree);
            this.tpSummary.Controls.Add(this.lblHelpYearTwo);
            this.tpSummary.Controls.Add(this.lblHelpYearOne);
            this.tpSummary.Controls.Add(this.separator4);
            this.tpSummary.Controls.Add(this.separator3);
            this.tpSummary.Controls.Add(this.separator2);
            this.tpSummary.Controls.Add(this.lblHelpDegree);
            this.tpSummary.Controls.Add(this.separator1);
            this.tpSummary.Controls.Add(this.lblDegree);
            this.tpSummary.Location = new System.Drawing.Point(4, 5);
            this.tpSummary.Name = "tpSummary";
            this.tpSummary.Size = new System.Drawing.Size(476, 289);
            this.tpSummary.TabIndex = 3;
            this.tpSummary.Text = "Summary";
            this.tpSummary.UseVisualStyleBackColor = true;
            // 
            // lblYearThree
            // 
            this.lblYearThree.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblYearThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblYearThree.Location = new System.Drawing.Point(172, 167);
            this.lblYearThree.Name = "lblYearThree";
            this.lblYearThree.Size = new System.Drawing.Size(122, 28);
            this.lblYearThree.TabIndex = 11;
            this.lblYearThree.Text = "100%";
            this.lblYearThree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblYearTwo
            // 
            this.lblYearTwo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblYearTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblYearTwo.Location = new System.Drawing.Point(288, 103);
            this.lblYearTwo.Name = "lblYearTwo";
            this.lblYearTwo.Size = new System.Drawing.Size(122, 28);
            this.lblYearTwo.TabIndex = 10;
            this.lblYearTwo.Text = "100%";
            this.lblYearTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblYearOne
            // 
            this.lblYearOne.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblYearOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblYearOne.Location = new System.Drawing.Point(53, 103);
            this.lblYearOne.Name = "lblYearOne";
            this.lblYearOne.Size = new System.Drawing.Size(125, 28);
            this.lblYearOne.TabIndex = 9;
            this.lblYearOne.Text = "100%";
            this.lblYearOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHelpYearThree
            // 
            this.lblHelpYearThree.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHelpYearThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHelpYearThree.Location = new System.Drawing.Point(169, 197);
            this.lblHelpYearThree.Name = "lblHelpYearThree";
            this.lblHelpYearThree.Size = new System.Drawing.Size(125, 20);
            this.lblHelpYearThree.TabIndex = 8;
            this.lblHelpYearThree.Text = "Year 3";
            this.lblHelpYearThree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHelpYearTwo
            // 
            this.lblHelpYearTwo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHelpYearTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHelpYearTwo.Location = new System.Drawing.Point(288, 133);
            this.lblHelpYearTwo.Name = "lblHelpYearTwo";
            this.lblHelpYearTwo.Size = new System.Drawing.Size(122, 20);
            this.lblHelpYearTwo.TabIndex = 7;
            this.lblHelpYearTwo.Text = "Year 2";
            this.lblHelpYearTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHelpYearOne
            // 
            this.lblHelpYearOne.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHelpYearOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHelpYearOne.Location = new System.Drawing.Point(50, 133);
            this.lblHelpYearOne.Name = "lblHelpYearOne";
            this.lblHelpYearOne.Size = new System.Drawing.Size(128, 20);
            this.lblHelpYearOne.TabIndex = 6;
            this.lblHelpYearOne.Text = "Year 1";
            this.lblHelpYearOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // separator4
            // 
            this.separator4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.separator4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.separator4.Location = new System.Drawing.Point(172, 195);
            this.separator4.Name = "separator4";
            this.separator4.Size = new System.Drawing.Size(122, 2);
            this.separator4.TabIndex = 5;
            // 
            // separator3
            // 
            this.separator3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.separator3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.separator3.Location = new System.Drawing.Point(288, 131);
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(122, 2);
            this.separator3.TabIndex = 4;
            // 
            // separator2
            // 
            this.separator2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.separator2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.separator2.Location = new System.Drawing.Point(53, 131);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(125, 2);
            this.separator2.TabIndex = 3;
            // 
            // lblHelpDegree
            // 
            this.lblHelpDegree.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHelpDegree.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHelpDegree.Location = new System.Drawing.Point(33, 50);
            this.lblHelpDegree.Name = "lblHelpDegree";
            this.lblHelpDegree.Size = new System.Drawing.Size(397, 19);
            this.lblHelpDegree.TabIndex = 2;
            this.lblHelpDegree.Text = "Degree";
            this.lblHelpDegree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // separator1
            // 
            this.separator1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.separator1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.separator1.Location = new System.Drawing.Point(33, 48);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(398, 2);
            this.separator1.TabIndex = 1;
            // 
            // lblDegree
            // 
            this.lblDegree.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDegree.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDegree.Location = new System.Drawing.Point(33, 9);
            this.lblDegree.Name = "lblDegree";
            this.lblDegree.Size = new System.Drawing.Size(397, 39);
            this.lblDegree.TabIndex = 0;
            this.lblDegree.Text = "UPPER SECOND (100%)";
            this.lblDegree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbOne
            // 
            this.rbOne.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbOne.AutoSize = true;
            this.rbOne.Checked = true;
            this.rbOne.Enabled = false;
            this.rbOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOne.Location = new System.Drawing.Point(12, 17);
            this.rbOne.Name = "rbOne";
            this.rbOne.Size = new System.Drawing.Size(136, 36);
            this.rbOne.TabIndex = 1;
            this.rbOne.TabStop = true;
            this.rbOne.Text = "Year 1      >";
            this.rbOne.UseVisualStyleBackColor = true;
            this.rbOne.CheckedChanged += new System.EventHandler(this.mainTabSelectionChanged);
            // 
            // rbTwo
            // 
            this.rbTwo.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbTwo.AutoSize = true;
            this.rbTwo.Enabled = false;
            this.rbTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTwo.Location = new System.Drawing.Point(12, 64);
            this.rbTwo.Name = "rbTwo";
            this.rbTwo.Size = new System.Drawing.Size(136, 36);
            this.rbTwo.TabIndex = 2;
            this.rbTwo.Text = "Year 2      >";
            this.rbTwo.UseVisualStyleBackColor = true;
            this.rbTwo.CheckedChanged += new System.EventHandler(this.mainTabSelectionChanged);
            // 
            // rbThree
            // 
            this.rbThree.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbThree.AutoSize = true;
            this.rbThree.Enabled = false;
            this.rbThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbThree.Location = new System.Drawing.Point(12, 111);
            this.rbThree.Name = "rbThree";
            this.rbThree.Size = new System.Drawing.Size(136, 36);
            this.rbThree.TabIndex = 3;
            this.rbThree.Text = "Year 3      >";
            this.rbThree.UseVisualStyleBackColor = true;
            this.rbThree.CheckedChanged += new System.EventHandler(this.mainTabSelectionChanged);
            // 
            // rbSummary
            // 
            this.rbSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbSummary.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbSummary.AutoSize = true;
            this.rbSummary.Enabled = false;
            this.rbSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSummary.Location = new System.Drawing.Point(12, 317);
            this.rbSummary.Name = "rbSummary";
            this.rbSummary.Size = new System.Drawing.Size(136, 36);
            this.rbSummary.TabIndex = 4;
            this.rbSummary.Text = "Summary >";
            this.rbSummary.UseVisualStyleBackColor = true;
            this.rbSummary.CheckedChanged += new System.EventHandler(this.mainTabSelectionChanged);
            // 
            // mainStatus
            // 
            this.mainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMessages});
            this.mainStatus.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mainStatus.Location = new System.Drawing.Point(0, 358);
            this.mainStatus.Name = "mainStatus";
            this.mainStatus.Size = new System.Drawing.Size(642, 24);
            this.mainStatus.TabIndex = 6;
            this.mainStatus.Text = "Status";
            // 
            // lblMessages
            // 
            this.lblMessages.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblMessages.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblMessages.IsLink = true;
            this.lblMessages.Name = "lblMessages";
            this.lblMessages.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMessages.Size = new System.Drawing.Size(84, 19);
            this.lblMessages.Text = "Messages: 0";
            this.lblMessages.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::GradePredictor.Properties.Resources.IconSaveMedium;
            this.btnSave.Location = new System.Drawing.Point(590, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 36);
            this.btnSave.TabIndex = 7;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Image = global::GradePredictor.Properties.Resources.IconLoadMedium;
            this.btnLoad.Location = new System.Drawing.Point(548, 17);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(36, 36);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.Location = new System.Drawing.Point(210, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(235, 36);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Course Name";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbEditTitle
            // 
            this.pbEditTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbEditTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbEditTitle.Image = global::GradePredictor.Properties.Resources.IconPencilMedium;
            this.pbEditTitle.Location = new System.Drawing.Point(451, 17);
            this.pbEditTitle.Name = "pbEditTitle";
            this.pbEditTitle.Size = new System.Drawing.Size(36, 36);
            this.pbEditTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbEditTitle.TabIndex = 10;
            this.pbEditTitle.TabStop = false;
            this.pbEditTitle.Click += new System.EventHandler(this.pbEditTitle_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestart.Image = global::GradePredictor.Properties.Resources.IconRestartMedium;
            this.btnRestart.Location = new System.Drawing.Point(506, 17);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(36, 36);
            this.btnRestart.TabIndex = 11;
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // MainWindowView
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(642, 382);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.pbEditTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.mainStatus);
            this.Controls.Add(this.rbSummary);
            this.Controls.Add(this.rbThree);
            this.Controls.Add(this.rbTwo);
            this.Controls.Add(this.rbOne);
            this.Controls.Add(this.tcMain);
            this.MinimumSize = new System.Drawing.Size(650, 400);
            this.Name = "MainWindowView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grade Predictor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DecodeIngressByteStream);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainWindowView_DragEnter);
            this.tcMain.ResumeLayout(false);
            this.tpStart.ResumeLayout(false);
            this.tpStart.PerformLayout();
            this.tpOne.ResumeLayout(false);
            this.tpTwo.ResumeLayout(false);
            this.tpThree.ResumeLayout(false);
            this.tpSummary.ResumeLayout(false);
            this.mainStatus.ResumeLayout(false);
            this.mainStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpOne;
        private System.Windows.Forms.TabPage tpTwo;
        private System.Windows.Forms.RadioButton rbOne;
        private System.Windows.Forms.RadioButton rbTwo;
        private System.Windows.Forms.RadioButton rbThree;
        private System.Windows.Forms.RadioButton rbSummary;
        private System.Windows.Forms.TabPage tpThree;
        private System.Windows.Forms.TabPage tpSummary;
        private System.Windows.Forms.TabPage tpStart;
        private System.Windows.Forms.Button btnStartNew;
        private System.Windows.Forms.Button btnStartLoad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartLoadAuto;
        private System.Windows.Forms.StatusStrip mainStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblHelpOne;
        private System.Windows.Forms.Button btnAddOne;
        private System.Windows.Forms.Button btnAddTwo;
        private System.Windows.Forms.Label lblHelpTwo;
        private System.Windows.Forms.Button btnAddThree;
        private System.Windows.Forms.Label lblHelpThree;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHelpDegree;
        private System.Windows.Forms.Label separator1;
        private System.Windows.Forms.Label lblDegree;
        private System.Windows.Forms.Label lblHelpYearThree;
        private System.Windows.Forms.Label lblHelpYearTwo;
        private System.Windows.Forms.Label lblHelpYearOne;
        private System.Windows.Forms.Label separator4;
        private System.Windows.Forms.Label separator3;
        private System.Windows.Forms.Label separator2;
        private System.Windows.Forms.Label lblYearThree;
        private System.Windows.Forms.Label lblYearTwo;
        private System.Windows.Forms.Label lblYearOne;
        private System.Windows.Forms.PictureBox pbEditTitle;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.ToolStripStatusLabel lblMessages;
    }
}

