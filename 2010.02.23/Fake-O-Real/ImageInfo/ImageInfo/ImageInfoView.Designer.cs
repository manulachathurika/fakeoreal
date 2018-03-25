
//----------------------------------------------------------------------------------------
// patterns & practices - Smart Client Software Factory - Guidance Package
//
// This file was generated by the "Add View" recipe.
//
// For more information see: 
// ms-help://MS.VSCC.v90/MS.VSIPCC.v90/ms.practices.scsf.2008apr/SCSF/html/02-09-010-ModelViewPresenter_MVP.htm
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

namespace FakeOReal.ImageInfo
{
    partial class ImageInfoView
    {
        /// <summary>
        /// The presenter used by this view.
        /// </summary>
        private FakeOReal.ImageInfo.ImageInfoViewPresenter _presenter = null;

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
            if (disposing)
            {
                if (_presenter != null)
                    _presenter.Dispose();

                if (components != null)
                    components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listExif = new System.Windows.Forms.ListView();
            this.columnId = new System.Windows.Forms.ColumnHeader();
            this.columnField = new System.Windows.Forms.ColumnHeader();
            this.columnDesc = new System.Windows.Forms.ColumnHeader();
            this.columnValue = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listExif
            // 
            this.listExif.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnId,
            this.columnField,
            this.columnDesc,
            this.columnValue});
            this.listExif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listExif.FullRowSelect = true;
            this.listExif.Location = new System.Drawing.Point(0, 0);
            this.listExif.Name = "listExif";
            this.listExif.Size = new System.Drawing.Size(788, 428);
            this.listExif.TabIndex = 3;
            this.listExif.UseCompatibleStateImageBehavior = false;
            this.listExif.View = System.Windows.Forms.View.Details;
            // 
            // columnId
            // 
            this.columnId.Text = "ID";
            this.columnId.Width = 68;
            // 
            // columnField
            // 
            this.columnField.Text = "Exif Field Name";
            this.columnField.Width = 126;
            // 
            // columnDesc
            // 
            this.columnDesc.Text = "Description";
            this.columnDesc.Width = 140;
            // 
            // columnValue
            // 
            this.columnValue.Text = "Value";
            this.columnValue.Width = 300;
            // 
            // ImageInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listExif);
            this.Name = "ImageInfoView";
            this.Size = new System.Drawing.Size(788, 428);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listExif;
        private System.Windows.Forms.ColumnHeader columnId;
        private System.Windows.Forms.ColumnHeader columnField;
        private System.Windows.Forms.ColumnHeader columnDesc;
        private System.Windows.Forms.ColumnHeader columnValue;

    }
}

