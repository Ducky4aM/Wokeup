namespace Wokeup
{
    partial class AddFavoriteListFOrm
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
            btnAddFavoriteList = new Button();
            lblAddFavoriteNameText = new Label();
            txbAddFavoriteList = new TextBox();
            btnCancelAddFavoriteList = new Button();
            lblAddFavoriteListText = new Label();
            SuspendLayout();
            // 
            // btnAddFavoriteList
            // 
            btnAddFavoriteList.Location = new Point(27, 131);
            btnAddFavoriteList.Name = "btnAddFavoriteList";
            btnAddFavoriteList.Size = new Size(92, 36);
            btnAddFavoriteList.TabIndex = 0;
            btnAddFavoriteList.Text = "Add";
            btnAddFavoriteList.UseVisualStyleBackColor = true;
            btnAddFavoriteList.Click += btnAddFavoriteList_Click;
            // 
            // lblAddFavoriteNameText
            // 
            lblAddFavoriteNameText.AutoSize = true;
            lblAddFavoriteNameText.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblAddFavoriteNameText.Location = new Point(20, 71);
            lblAddFavoriteNameText.Name = "lblAddFavoriteNameText";
            lblAddFavoriteNameText.Size = new Size(81, 20);
            lblAddFavoriteNameText.TabIndex = 1;
            lblAddFavoriteNameText.Text = "List name:";
            // 
            // txbAddFavoriteList
            // 
            txbAddFavoriteList.Location = new Point(107, 68);
            txbAddFavoriteList.Name = "txbAddFavoriteList";
            txbAddFavoriteList.Size = new Size(203, 23);
            txbAddFavoriteList.TabIndex = 2;
            // 
            // btnCancelAddFavoriteList
            // 
            btnCancelAddFavoriteList.Location = new Point(125, 131);
            btnCancelAddFavoriteList.Name = "btnCancelAddFavoriteList";
            btnCancelAddFavoriteList.Size = new Size(92, 36);
            btnCancelAddFavoriteList.TabIndex = 0;
            btnCancelAddFavoriteList.Text = "Cancel";
            btnCancelAddFavoriteList.UseVisualStyleBackColor = true;
            btnCancelAddFavoriteList.Click += btnCancelAddFavoriteList_Click;
            // 
            // lblAddFavoriteListText
            // 
            lblAddFavoriteListText.AutoSize = true;
            lblAddFavoriteListText.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblAddFavoriteListText.Location = new Point(52, 9);
            lblAddFavoriteListText.Name = "lblAddFavoriteListText";
            lblAddFavoriteListText.Size = new Size(224, 25);
            lblAddFavoriteListText.TabIndex = 1;
            lblAddFavoriteListText.Text = "Adding new favorite list";
            // 
            // AddFavoriteListFOrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 179);
            Controls.Add(txbAddFavoriteList);
            Controls.Add(lblAddFavoriteListText);
            Controls.Add(lblAddFavoriteNameText);
            Controls.Add(btnCancelAddFavoriteList);
            Controls.Add(btnAddFavoriteList);
            Name = "AddFavoriteListFOrm";
            Text = "AddFavoriteListForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddFavoriteList;
        private Label lblAddFavoriteNameText;
        private TextBox txbAddFavoriteList;
        private Button btnCancelAddFavoriteList;
        private Label lblAddFavoriteListText;
    }
}