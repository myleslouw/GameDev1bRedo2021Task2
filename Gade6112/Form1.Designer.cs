namespace Gade6112
{
    partial class Form1
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
            this.lbl_GameScreen = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.lb_UpdateScreen = new System.Windows.Forms.ListBox();
            this.btn_Up = new System.Windows.Forms.Button();
            this.btn_Right = new System.Windows.Forms.Button();
            this.btn_Down = new System.Windows.Forms.Button();
            this.btn_left = new System.Windows.Forms.Button();
            this.btn_Attack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_PlayerStats = new System.Windows.Forms.Label();
            this.rtb_HitAlert = new System.Windows.Forms.RichTextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_EnemiesList = new System.Windows.Forms.Label();
            this.btn_shopItem1 = new System.Windows.Forms.Button();
            this.btn_shopItem2 = new System.Windows.Forms.Button();
            this.btn_shopItem3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_GameScreen
            // 
            this.lbl_GameScreen.AutoSize = true;
            this.lbl_GameScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GameScreen.Location = new System.Drawing.Point(25, 26);
            this.lbl_GameScreen.Name = "lbl_GameScreen";
            this.lbl_GameScreen.Size = new System.Drawing.Size(0, 20);
            this.lbl_GameScreen.TabIndex = 0;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(972, 507);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 1;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // lb_UpdateScreen
            // 
            this.lb_UpdateScreen.FormattingEnabled = true;
            this.lb_UpdateScreen.Location = new System.Drawing.Point(713, 406);
            this.lb_UpdateScreen.Name = "lb_UpdateScreen";
            this.lb_UpdateScreen.Size = new System.Drawing.Size(334, 95);
            this.lb_UpdateScreen.TabIndex = 14;
            // 
            // btn_Up
            // 
            this.btn_Up.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Up.Location = new System.Drawing.Point(909, 139);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(55, 37);
            this.btn_Up.TabIndex = 15;
            this.btn_Up.Text = "^";
            this.btn_Up.UseVisualStyleBackColor = true;
            this.btn_Up.Click += new System.EventHandler(this.btn_Up_Click);
            // 
            // btn_Right
            // 
            this.btn_Right.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Right.Location = new System.Drawing.Point(979, 173);
            this.btn_Right.Name = "btn_Right";
            this.btn_Right.Size = new System.Drawing.Size(55, 37);
            this.btn_Right.TabIndex = 16;
            this.btn_Right.Text = ">";
            this.btn_Right.UseVisualStyleBackColor = true;
            this.btn_Right.Click += new System.EventHandler(this.btn_Right_Click);
            // 
            // btn_Down
            // 
            this.btn_Down.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Down.Location = new System.Drawing.Point(909, 211);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(55, 37);
            this.btn_Down.TabIndex = 17;
            this.btn_Down.Text = "v";
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // btn_left
            // 
            this.btn_left.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_left.Location = new System.Drawing.Point(837, 173);
            this.btn_left.Name = "btn_left";
            this.btn_left.Size = new System.Drawing.Size(55, 37);
            this.btn_left.TabIndex = 18;
            this.btn_left.Text = "<";
            this.btn_left.UseVisualStyleBackColor = true;
            this.btn_left.Click += new System.EventHandler(this.btn_left_Click);
            // 
            // btn_Attack
            // 
            this.btn_Attack.Location = new System.Drawing.Point(898, 182);
            this.btn_Attack.Name = "btn_Attack";
            this.btn_Attack.Size = new System.Drawing.Size(75, 23);
            this.btn_Attack.TabIndex = 19;
            this.btn_Attack.Text = "Attack!";
            this.btn_Attack.UseVisualStyleBackColor = true;
            this.btn_Attack.Click += new System.EventHandler(this.btn_Attack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(713, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Hero Vision:";
            // 
            // lbl_PlayerStats
            // 
            this.lbl_PlayerStats.AutoSize = true;
            this.lbl_PlayerStats.Location = new System.Drawing.Point(710, 259);
            this.lbl_PlayerStats.Name = "lbl_PlayerStats";
            this.lbl_PlayerStats.Size = new System.Drawing.Size(66, 13);
            this.lbl_PlayerStats.TabIndex = 22;
            this.lbl_PlayerStats.Text = "Player Stats:";
            // 
            // rtb_HitAlert
            // 
            this.rtb_HitAlert.Location = new System.Drawing.Point(713, 508);
            this.rtb_HitAlert.Name = "rtb_HitAlert";
            this.rtb_HitAlert.Size = new System.Drawing.Size(158, 22);
            this.rtb_HitAlert.TabIndex = 23;
            this.rtb_HitAlert.Text = "";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(889, 352);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 24;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(978, 352);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(75, 23);
            this.btn_Load.TabIndex = 25;
            this.btn_Load.Text = "Load";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(434, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Enemies on Map:";
            // 
            // lbl_EnemiesList
            // 
            this.lbl_EnemiesList.AutoSize = true;
            this.lbl_EnemiesList.Location = new System.Drawing.Point(434, 415);
            this.lbl_EnemiesList.Name = "lbl_EnemiesList";
            this.lbl_EnemiesList.Size = new System.Drawing.Size(86, 13);
            this.lbl_EnemiesList.TabIndex = 29;
            this.lbl_EnemiesList.Text = "*List of Enemies*";
            // 
            // btn_shopItem1
            // 
            this.btn_shopItem1.Location = new System.Drawing.Point(437, 173);
            this.btn_shopItem1.Name = "btn_shopItem1";
            this.btn_shopItem1.Size = new System.Drawing.Size(160, 23);
            this.btn_shopItem1.TabIndex = 30;
            this.btn_shopItem1.Text = "shopItem1";
            this.btn_shopItem1.UseVisualStyleBackColor = true;
            this.btn_shopItem1.Click += new System.EventHandler(this.btn_shopItem1_Click);
            // 
            // btn_shopItem2
            // 
            this.btn_shopItem2.Location = new System.Drawing.Point(437, 211);
            this.btn_shopItem2.Name = "btn_shopItem2";
            this.btn_shopItem2.Size = new System.Drawing.Size(160, 23);
            this.btn_shopItem2.TabIndex = 31;
            this.btn_shopItem2.Text = "shopItem2";
            this.btn_shopItem2.UseVisualStyleBackColor = true;
            this.btn_shopItem2.Click += new System.EventHandler(this.btn_shopItem2_Click);
            // 
            // btn_shopItem3
            // 
            this.btn_shopItem3.Location = new System.Drawing.Point(437, 249);
            this.btn_shopItem3.Name = "btn_shopItem3";
            this.btn_shopItem3.Size = new System.Drawing.Size(160, 23);
            this.btn_shopItem3.TabIndex = 32;
            this.btn_shopItem3.Text = "shopItem3";
            this.btn_shopItem3.UseVisualStyleBackColor = true;
            this.btn_shopItem3.Click += new System.EventHandler(this.btn_shopItem3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(434, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "Shop Items:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 605);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_shopItem3);
            this.Controls.Add(this.btn_shopItem2);
            this.Controls.Add(this.btn_shopItem1);
            this.Controls.Add(this.lbl_EnemiesList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.rtb_HitAlert);
            this.Controls.Add(this.lbl_PlayerStats);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Attack);
            this.Controls.Add(this.btn_left);
            this.Controls.Add(this.btn_Down);
            this.Controls.Add(this.btn_Right);
            this.Controls.Add(this.btn_Up);
            this.Controls.Add(this.lb_UpdateScreen);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.lbl_GameScreen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_GameScreen;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.ListBox lb_UpdateScreen;
        private System.Windows.Forms.Button btn_Up;
        private System.Windows.Forms.Button btn_Right;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Button btn_left;
        private System.Windows.Forms.Button btn_Attack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_PlayerStats;
        private System.Windows.Forms.RichTextBox rtb_HitAlert;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_EnemiesList;
        private System.Windows.Forms.Button btn_shopItem1;
        private System.Windows.Forms.Button btn_shopItem2;
        private System.Windows.Forms.Button btn_shopItem3;
        private System.Windows.Forms.Label label3;
    }
}

