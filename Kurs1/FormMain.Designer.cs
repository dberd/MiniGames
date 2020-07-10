namespace Kurs1
{
  partial class FormMain
  {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.DurakButton = new System.Windows.Forms.Button();
      this.KozelButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.label1.Dock = System.Windows.Forms.DockStyle.Top;
      this.label1.Font = new System.Drawing.Font("Tw Cen MT Condensed", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(1115, 119);
      this.label1.TabIndex = 0;
      this.label1.Text = "Помощник для игры в карты";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.BackColor = System.Drawing.SystemColors.ButtonShadow;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(1, 119);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(1114, 63);
      this.label2.TabIndex = 1;
      this.label2.Text = "Выберите игру";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // DurakButton
      // 
      this.DurakButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.DurakButton.Location = new System.Drawing.Point(172, 289);
      this.DurakButton.Name = "DurakButton";
      this.DurakButton.Size = new System.Drawing.Size(194, 148);
      this.DurakButton.TabIndex = 2;
      this.DurakButton.Text = "Дурак";
      this.DurakButton.UseVisualStyleBackColor = true;
      this.DurakButton.Click += new System.EventHandler(this.DurakButton_Click);
      // 
      // KozelButton
      // 
      this.KozelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.KozelButton.Location = new System.Drawing.Point(740, 289);
      this.KozelButton.Name = "KozelButton";
      this.KozelButton.Size = new System.Drawing.Size(194, 148);
      this.KozelButton.TabIndex = 3;
      this.KozelButton.Text = "Козёл";
      this.KozelButton.UseVisualStyleBackColor = true;
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1115, 540);
      this.Controls.Add(this.KozelButton);
      this.Controls.Add(this.DurakButton);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Помощник в картах";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button DurakButton;
    private System.Windows.Forms.Button KozelButton;
  }
}


