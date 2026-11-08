using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer CircuitComponent = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (CircuitComponent != null))
            {
                CircuitComponent.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.simTimer = new System.Windows.Forms.Timer(this.components);
            this.tabCircuit = new System.Windows.Forms.TabPage();
            this.lblComponentValue = new System.Windows.Forms.Label();
            this.compTrack = new System.Windows.Forms.TrackBar();
            this.btnSimulate = new System.Windows.Forms.Button();
            this.chtIV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.picBin = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tlsComponents = new System.Windows.Forms.ToolStrip();
            this.btnBattery = new System.Windows.Forms.ToolStripButton();
            this.btnCell = new System.Windows.Forms.ToolStripButton();
            this.btnResistor = new System.Windows.Forms.ToolStripButton();
            this.btnLamp = new System.Windows.Forms.ToolStripButton();
            this.btnDiode = new System.Windows.Forms.ToolStripButton();
            this.tlsMaterials = new System.Windows.Forms.ToolStrip();
            this.btnWire = new System.Windows.Forms.ToolStripButton();
            this.tlsMeasures = new System.Windows.Forms.ToolStrip();
            this.btnAmmeter = new System.Windows.Forms.ToolStripButton();
            this.btnVoltmeter = new System.Windows.Forms.ToolStripButton();
            this.tabSimulation = new System.Windows.Forms.TabControl();
            this.tabSimple = new System.Windows.Forms.TabPage();
            this.pctSimple = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.componentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.measuresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabCircuit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tlsComponents.SuspendLayout();
            this.tlsMaterials.SuspendLayout();
            this.tlsMeasures.SuspendLayout();
            this.tabSimulation.SuspendLayout();
            this.tabSimple.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctSimple)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // simTimer
            // 
            this.simTimer.Tick += new System.EventHandler(this.Form1_Load);
            // 
            // tabCircuit
            // 
            this.tabCircuit.Controls.Add(this.lblComponentValue);
            this.tabCircuit.Controls.Add(this.compTrack);
            this.tabCircuit.Controls.Add(this.btnSimulate);
            this.tabCircuit.Controls.Add(this.chtIV);
            this.tabCircuit.Controls.Add(this.picBin);
            this.tabCircuit.Controls.Add(this.pictureBox1);
            this.tabCircuit.Location = new System.Drawing.Point(4, 25);
            this.tabCircuit.Name = "tabCircuit";
            this.tabCircuit.Padding = new System.Windows.Forms.Padding(3);
            this.tabCircuit.Size = new System.Drawing.Size(1160, 643);
            this.tabCircuit.TabIndex = 0;
            this.tabCircuit.Text = "Default";
            this.tabCircuit.UseVisualStyleBackColor = true;
            // 
            // lblComponentValue
            // 
            this.lblComponentValue.AutoSize = true;
            this.lblComponentValue.Location = new System.Drawing.Point(544, 553);
            this.lblComponentValue.Name = "lblComponentValue";
            this.lblComponentValue.Size = new System.Drawing.Size(126, 16);
            this.lblComponentValue.TabIndex = 12;
            this.lblComponentValue.Text = "Resistance/Voltage";
            this.lblComponentValue.Visible = false;
            // 
            // compTrack
            // 
            this.compTrack.Location = new System.Drawing.Point(521, 572);
            this.compTrack.Name = "compTrack";
            this.compTrack.Size = new System.Drawing.Size(184, 56);
            this.compTrack.TabIndex = 11;
            this.compTrack.Visible = false;
            // 
            // btnSimulate
            // 
            this.btnSimulate.Location = new System.Drawing.Point(927, 466);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(200, 72);
            this.btnSimulate.TabIndex = 8;
            this.btnSimulate.Text = "Simulate";
            this.btnSimulate.UseVisualStyleBackColor = true;
            this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click_1);
            // 
            // chtIV
            // 
            chartArea2.Name = "ChartArea1";
            this.chtIV.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chtIV.Legends.Add(legend2);
            this.chtIV.Location = new System.Drawing.Point(855, 34);
            this.chtIV.Name = "chtIV";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chtIV.Series.Add(series2);
            this.chtIV.Size = new System.Drawing.Size(297, 169);
            this.chtIV.TabIndex = 6;
            this.chtIV.Text = "I-V graph";
            this.chtIV.Click += new System.EventHandler(this.chtIV_Click);
            // 
            // picBin
            // 
            this.picBin.BackColor = System.Drawing.Color.DimGray;
            this.picBin.Image = global::WindowsFormsApp1.Properties.Resources.trash1;
            this.picBin.Location = new System.Drawing.Point(1061, 544);
            this.picBin.Name = "picBin";
            this.picBin.Size = new System.Drawing.Size(91, 91);
            this.picBin.TabIndex = 5;
            this.picBin.TabStop = false;
            this.picBin.Click += new System.EventHandler(this.picBin_Click);
            this.picBin.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox2_DragDrop);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1154, 637);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // tlsComponents
            // 
            this.tlsComponents.BackColor = System.Drawing.Color.DimGray;
            this.tlsComponents.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tlsComponents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBattery,
            this.btnCell,
            this.btnResistor,
            this.btnLamp,
            this.btnDiode});
            this.tlsComponents.Location = new System.Drawing.Point(0, 0);
            this.tlsComponents.Name = "tlsComponents";
            this.tlsComponents.Size = new System.Drawing.Size(1168, 31);
            this.tlsComponents.TabIndex = 3;
            this.tlsComponents.Text = "toolStrip3";
            this.tlsComponents.Visible = false;
            // 
            // btnBattery
            // 
            this.btnBattery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBattery.Image = ((System.Drawing.Image)(resources.GetObject("btnBattery.Image")));
            this.btnBattery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBattery.Name = "btnBattery";
            this.btnBattery.Size = new System.Drawing.Size(29, 28);
            this.btnBattery.Text = "Battery";
            this.btnBattery.Click += new System.EventHandler(this.btnBattery_Click);
            // 
            // btnCell
            // 
            this.btnCell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCell.Image = ((System.Drawing.Image)(resources.GetObject("btnCell.Image")));
            this.btnCell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCell.Name = "btnCell";
            this.btnCell.Size = new System.Drawing.Size(29, 28);
            this.btnCell.Text = "Cell";
            this.btnCell.Click += new System.EventHandler(this.btnCell_Click);
            // 
            // btnResistor
            // 
            this.btnResistor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnResistor.Image = ((System.Drawing.Image)(resources.GetObject("btnResistor.Image")));
            this.btnResistor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResistor.Name = "btnResistor";
            this.btnResistor.Size = new System.Drawing.Size(29, 28);
            this.btnResistor.Text = "Resistor";
            this.btnResistor.Click += new System.EventHandler(this.btnResistor_Click);
            // 
            // btnLamp
            // 
            this.btnLamp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLamp.Image = ((System.Drawing.Image)(resources.GetObject("btnLamp.Image")));
            this.btnLamp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLamp.Name = "btnLamp";
            this.btnLamp.Size = new System.Drawing.Size(29, 28);
            this.btnLamp.Text = "Lamp";
            this.btnLamp.Click += new System.EventHandler(this.btnLamp_Click);
            // 
            // btnDiode
            // 
            this.btnDiode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDiode.Image = ((System.Drawing.Image)(resources.GetObject("btnDiode.Image")));
            this.btnDiode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDiode.Name = "btnDiode";
            this.btnDiode.Size = new System.Drawing.Size(29, 28);
            this.btnDiode.Text = "Diode";
            this.btnDiode.Click += new System.EventHandler(this.btnDiode_Click);
            // 
            // tlsMaterials
            // 
            this.tlsMaterials.BackColor = System.Drawing.Color.DimGray;
            this.tlsMaterials.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tlsMaterials.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnWire});
            this.tlsMaterials.Location = new System.Drawing.Point(0, 0);
            this.tlsMaterials.Name = "tlsMaterials";
            this.tlsMaterials.Size = new System.Drawing.Size(1168, 31);
            this.tlsMaterials.TabIndex = 1;
            this.tlsMaterials.Text = "toolStrip1";
            this.tlsMaterials.Visible = false;
            this.tlsMaterials.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tlsMaterials_ItemClicked);
            // 
            // btnWire
            // 
            this.btnWire.AutoSize = false;
            this.btnWire.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnWire.Image = ((System.Drawing.Image)(resources.GetObject("btnWire.Image")));
            this.btnWire.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWire.Name = "btnWire";
            this.btnWire.Size = new System.Drawing.Size(29, 24);
            this.btnWire.Text = "Wire";
            this.btnWire.Click += new System.EventHandler(this.btnWire_Click);
            // 
            // tlsMeasures
            // 
            this.tlsMeasures.BackColor = System.Drawing.Color.DimGray;
            this.tlsMeasures.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tlsMeasures.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAmmeter,
            this.btnVoltmeter});
            this.tlsMeasures.Location = new System.Drawing.Point(0, 0);
            this.tlsMeasures.Name = "tlsMeasures";
            this.tlsMeasures.Size = new System.Drawing.Size(1168, 31);
            this.tlsMeasures.TabIndex = 2;
            this.tlsMeasures.Text = "toolStrip2";
            this.tlsMeasures.Visible = false;
            // 
            // btnAmmeter
            // 
            this.btnAmmeter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAmmeter.Image = ((System.Drawing.Image)(resources.GetObject("btnAmmeter.Image")));
            this.btnAmmeter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAmmeter.Name = "btnAmmeter";
            this.btnAmmeter.Size = new System.Drawing.Size(29, 28);
            this.btnAmmeter.Text = "Ammeter";
            this.btnAmmeter.Click += new System.EventHandler(this.btnAmmeter_Click);
            // 
            // btnVoltmeter
            // 
            this.btnVoltmeter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnVoltmeter.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltmeter.Image")));
            this.btnVoltmeter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVoltmeter.Name = "btnVoltmeter";
            this.btnVoltmeter.Size = new System.Drawing.Size(29, 28);
            this.btnVoltmeter.Text = "Voltmeter";
            this.btnVoltmeter.Click += new System.EventHandler(this.btnVoltmeter_Click);
            // 
            // tabSimulation
            // 
            this.tabSimulation.Controls.Add(this.tabCircuit);
            this.tabSimulation.Controls.Add(this.tabSimple);
            this.tabSimulation.Controls.Add(this.tabPage2);
            this.tabSimulation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSimulation.Location = new System.Drawing.Point(0, 28);
            this.tabSimulation.Name = "tabSimulation";
            this.tabSimulation.SelectedIndex = 0;
            this.tabSimulation.Size = new System.Drawing.Size(1168, 672);
            this.tabSimulation.TabIndex = 3;
            // 
            // tabSimple
            // 
            this.tabSimple.Controls.Add(this.pictureBox3);
            this.tabSimple.Controls.Add(this.pctSimple);
            this.tabSimple.Location = new System.Drawing.Point(4, 25);
            this.tabSimple.Name = "tabSimple";
            this.tabSimple.Padding = new System.Windows.Forms.Padding(3);
            this.tabSimple.Size = new System.Drawing.Size(1160, 643);
            this.tabSimple.TabIndex = 1;
            this.tabSimple.Text = "Simple";
            this.tabSimple.UseVisualStyleBackColor = true;
            // 
            // pctSimple
            // 
            this.pctSimple.BackColor = System.Drawing.Color.White;
            this.pctSimple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctSimple.Location = new System.Drawing.Point(3, 3);
            this.pctSimple.Name = "pctSimple";
            this.pctSimple.Size = new System.Drawing.Size(1154, 637);
            this.pctSimple.TabIndex = 0;
            this.pctSimple.TabStop = false;
            this.pctSimple.Click += new System.EventHandler(this.pctSimple_Click);
            this.pctSimple.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctSimple_MouseDown);
            this.pctSimple.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctSimple_MouseMove);
            this.pctSimple.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pctSimple_MouseUp);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1160, 643);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Advanced";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1154, 637);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // componentsToolStripMenuItem
            // 
            this.componentsToolStripMenuItem.Name = "componentsToolStripMenuItem";
            this.componentsToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.componentsToolStripMenuItem.Text = "Components";
            this.componentsToolStripMenuItem.Click += new System.EventHandler(this.componentsToolStripMenuItem_Click);
            // 
            // materialsToolStripMenuItem
            // 
            this.materialsToolStripMenuItem.Name = "materialsToolStripMenuItem";
            this.materialsToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.materialsToolStripMenuItem.Text = "Wires";
            this.materialsToolStripMenuItem.Click += new System.EventHandler(this.materialsToolStripMenuItem_Click);
            // 
            // measuresToolStripMenuItem
            // 
            this.measuresToolStripMenuItem.Name = "measuresToolStripMenuItem";
            this.measuresToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.measuresToolStripMenuItem.Text = "Measures";
            this.measuresToolStripMenuItem.Click += new System.EventHandler(this.measuresToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Cyan;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.componentsToolStripMenuItem,
            this.materialsToolStripMenuItem,
            this.measuresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1168, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox3.Image = global::WindowsFormsApp1.Properties.Resources.trash1;
            this.pictureBox3.Location = new System.Drawing.Point(1061, 544);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(91, 91);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 700);
            this.Controls.Add(this.tabSimulation);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tlsComponents);
            this.Controls.Add(this.tlsMaterials);
            this.Controls.Add(this.tlsMeasures);
            this.Name = "Form1";
            this.Text = "Physics Engine";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.tabCircuit.ResumeLayout(false);
            this.tabCircuit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tlsComponents.ResumeLayout(false);
            this.tlsComponents.PerformLayout();
            this.tlsMaterials.ResumeLayout(false);
            this.tlsMaterials.PerformLayout();
            this.tlsMeasures.ResumeLayout(false);
            this.tlsMeasures.PerformLayout();
            this.tabSimulation.ResumeLayout(false);
            this.tabSimple.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctSimple)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void resistorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupCharts();        // ensure charts configured
                                  // StartSimulation();  // optional, don't start automatic sim while debugging one-shot
                                  // call one-shot test:
            
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Timer simTimer;
        private System.ComponentModel.IContainer components;
        private TabPage tabCircuit;
        private Label lblComponentValue;
        private TrackBar compTrack;
        private Button btnSimulate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtIV;
        private PictureBox picBin;
        private ToolStrip tlsComponents;
        private ToolStripButton btnBattery;
        private ToolStripButton btnCell;
        private ToolStripButton btnResistor;
        private ToolStripButton btnLamp;
        private ToolStripButton btnDiode;
        private ToolStrip tlsMeasures;
        private ToolStripButton btnAmmeter;
        private ToolStripButton btnVoltmeter;
        private ToolStrip tlsMaterials;
        private ToolStripButton btnWire;
        private PictureBox pictureBox1;
        private TabControl tabSimulation;
        private TabPage tabSimple;
        private TabPage tabPage2;
        private PictureBox pctSimple;
        private PictureBox pictureBox2;
        private ToolStripMenuItem componentsToolStripMenuItem;
        private ToolStripMenuItem materialsToolStripMenuItem;
        private ToolStripMenuItem measuresToolStripMenuItem;
        private MenuStrip menuStrip1;
        private PictureBox pictureBox3;
    }
}

