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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.simTimer = new System.Windows.Forms.Timer(this.components);
            this.tabCircuit = new System.Windows.Forms.TabPage();
            this.btnACMode = new System.Windows.Forms.Button();
            this.btnDCMode = new System.Windows.Forms.Button();
            this.lblComponentValue = new System.Windows.Forms.Label();
            this.compTrack = new System.Windows.Forms.TrackBar();
            this.btnSimulate = new System.Windows.Forms.Button();
            this.chtVt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chtIV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.picBin = new System.Windows.Forms.PictureBox();
            this.tlsComponents = new System.Windows.Forms.ToolStrip();
            this.btnBattery = new System.Windows.Forms.ToolStripButton();
            this.btnCell = new System.Windows.Forms.ToolStripButton();
            this.btnResistor = new System.Windows.Forms.ToolStripButton();
            this.btnLamp = new System.Windows.Forms.ToolStripButton();
            this.btnDiode = new System.Windows.Forms.ToolStripButton();
            this.tlsMeasures = new System.Windows.Forms.ToolStrip();
            this.btnAmmeter = new System.Windows.Forms.ToolStripButton();
            this.btnVoltmeter = new System.Windows.Forms.ToolStripButton();
            this.tlsMaterials = new System.Windows.Forms.ToolStrip();
            this.btnWire = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.componentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.measuresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabSimulation = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pctSimple = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabCircuit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtVt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBin)).BeginInit();
            this.tlsComponents.SuspendLayout();
            this.tlsMeasures.SuspendLayout();
            this.tlsMaterials.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabSimulation.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctSimple)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCircuit
            // 
            this.tabCircuit.Controls.Add(this.btnACMode);
            this.tabCircuit.Controls.Add(this.btnDCMode);
            this.tabCircuit.Controls.Add(this.lblComponentValue);
            this.tabCircuit.Controls.Add(this.compTrack);
            this.tabCircuit.Controls.Add(this.btnSimulate);
            this.tabCircuit.Controls.Add(this.chtVt);
            this.tabCircuit.Controls.Add(this.chtIV);
            this.tabCircuit.Controls.Add(this.picBin);
            this.tabCircuit.Controls.Add(this.tlsComponents);
            this.tabCircuit.Controls.Add(this.tlsMaterials);
            this.tabCircuit.Controls.Add(this.tlsMeasures);
            this.tabCircuit.Controls.Add(this.pictureBox1);
            this.tabCircuit.Location = new System.Drawing.Point(4, 25);
            this.tabCircuit.Name = "tabCircuit";
            this.tabCircuit.Padding = new System.Windows.Forms.Padding(3);
            this.tabCircuit.Size = new System.Drawing.Size(1160, 643);
            this.tabCircuit.TabIndex = 0;
            this.tabCircuit.Text = "Default";
            this.tabCircuit.UseVisualStyleBackColor = true;
            // 
            // btnACMode
            // 
            this.btnACMode.Location = new System.Drawing.Point(1028, 400);
            this.btnACMode.Name = "btnACMode";
            this.btnACMode.Size = new System.Drawing.Size(97, 72);
            this.btnACMode.TabIndex = 14;
            this.btnACMode.Text = "Alternating Current";
            this.btnACMode.UseVisualStyleBackColor = true;
            // 
            // btnDCMode
            // 
            this.btnDCMode.Location = new System.Drawing.Point(925, 400);
            this.btnDCMode.Name = "btnDCMode";
            this.btnDCMode.Size = new System.Drawing.Size(97, 72);
            this.btnDCMode.TabIndex = 13;
            this.btnDCMode.Text = "Direct  Current";
            this.btnDCMode.UseVisualStyleBackColor = true;
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
            this.btnSimulate.Location = new System.Drawing.Point(925, 478);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(200, 72);
            this.btnSimulate.TabIndex = 8;
            this.btnSimulate.Text = "Simulate";
            this.btnSimulate.UseVisualStyleBackColor = true;
            this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click_1);
            // 
            // chtVt
            // 
            chartArea9.Name = "ChartArea1";
            this.chtVt.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            this.chtVt.Legends.Add(legend9);
            this.chtVt.Location = new System.Drawing.Point(857, 209);
            this.chtVt.Name = "chtVt";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            this.chtVt.Series.Add(series9);
            this.chtVt.Size = new System.Drawing.Size(297, 169);
            this.chtVt.TabIndex = 7;
            this.chtVt.Text = "V-t graph";
            this.chtVt.Click += new System.EventHandler(this.chtVt_Click);
            // 
            // chtIV
            // 
            chartArea10.Name = "ChartArea1";
            this.chtIV.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.chtIV.Legends.Add(legend10);
            this.chtIV.Location = new System.Drawing.Point(855, 34);
            this.chtIV.Name = "chtIV";
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "Series1";
            this.chtIV.Series.Add(series10);
            this.chtIV.Size = new System.Drawing.Size(297, 169);
            this.chtIV.TabIndex = 6;
            this.chtIV.Text = "I-V graph";
            this.chtIV.Click += new System.EventHandler(this.chtIV_Click);
            // 
            // picBin
            // 
            this.picBin.BackColor = System.Drawing.Color.DimGray;
            this.picBin.Image = global::WindowsFormsApp1.Properties.Resources.trash1;
            this.picBin.Location = new System.Drawing.Point(1063, 572);
            this.picBin.Name = "picBin";
            this.picBin.Size = new System.Drawing.Size(91, 91);
            this.picBin.TabIndex = 5;
            this.picBin.TabStop = false;
            this.picBin.Click += new System.EventHandler(this.picBin_Click);
            this.picBin.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox2_DragDrop);
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
            this.tlsComponents.Location = new System.Drawing.Point(3, 31);
            this.tlsComponents.Name = "tlsComponents";
            this.tlsComponents.Size = new System.Drawing.Size(1154, 27);
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
            this.btnBattery.Size = new System.Drawing.Size(29, 24);
            this.btnBattery.Text = "Battery";
            this.btnBattery.Click += new System.EventHandler(this.btnBattery_Click);
            // 
            // btnCell
            // 
            this.btnCell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCell.Image = ((System.Drawing.Image)(resources.GetObject("btnCell.Image")));
            this.btnCell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCell.Name = "btnCell";
            this.btnCell.Size = new System.Drawing.Size(29, 24);
            this.btnCell.Text = "Cell";
            this.btnCell.Click += new System.EventHandler(this.btnCell_Click);
            // 
            // btnResistor
            // 
            this.btnResistor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnResistor.Image = ((System.Drawing.Image)(resources.GetObject("btnResistor.Image")));
            this.btnResistor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResistor.Name = "btnResistor";
            this.btnResistor.Size = new System.Drawing.Size(29, 24);
            this.btnResistor.Text = "Resistor";
            this.btnResistor.Click += new System.EventHandler(this.btnResistor_Click);
            // 
            // btnLamp
            // 
            this.btnLamp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLamp.Image = ((System.Drawing.Image)(resources.GetObject("btnLamp.Image")));
            this.btnLamp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLamp.Name = "btnLamp";
            this.btnLamp.Size = new System.Drawing.Size(29, 24);
            this.btnLamp.Text = "Lamp";
            this.btnLamp.Click += new System.EventHandler(this.btnLamp_Click);
            // 
            // btnDiode
            // 
            this.btnDiode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDiode.Image = ((System.Drawing.Image)(resources.GetObject("btnDiode.Image")));
            this.btnDiode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDiode.Name = "btnDiode";
            this.btnDiode.Size = new System.Drawing.Size(29, 24);
            this.btnDiode.Text = "Diode";
            this.btnDiode.Click += new System.EventHandler(this.btnDiode_Click);
            // 
            // tlsMeasures
            // 
            this.tlsMeasures.BackColor = System.Drawing.Color.DimGray;
            this.tlsMeasures.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tlsMeasures.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAmmeter,
            this.btnVoltmeter});
            this.tlsMeasures.Location = new System.Drawing.Point(3, 31);
            this.tlsMeasures.Name = "tlsMeasures";
            this.tlsMeasures.Size = new System.Drawing.Size(1154, 27);
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
            this.btnAmmeter.Size = new System.Drawing.Size(29, 24);
            this.btnAmmeter.Text = "Ammeter";
            this.btnAmmeter.Click += new System.EventHandler(this.btnAmmeter_Click);
            // 
            // btnVoltmeter
            // 
            this.btnVoltmeter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnVoltmeter.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltmeter.Image")));
            this.btnVoltmeter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVoltmeter.Name = "btnVoltmeter";
            this.btnVoltmeter.Size = new System.Drawing.Size(29, 24);
            this.btnVoltmeter.Text = "Voltmeter";
            this.btnVoltmeter.Click += new System.EventHandler(this.btnVoltmeter_Click);
            // 
            // tlsMaterials
            // 
            this.tlsMaterials.BackColor = System.Drawing.Color.DimGray;
            this.tlsMaterials.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tlsMaterials.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnWire});
            this.tlsMaterials.Location = new System.Drawing.Point(3, 3);
            this.tlsMaterials.Name = "tlsMaterials";
            this.tlsMaterials.Size = new System.Drawing.Size(1154, 27);
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
            // tabSimulation
            // 
            this.tabSimulation.Controls.Add(this.tabCircuit);
            this.tabSimulation.Controls.Add(this.tabPage1);
            this.tabSimulation.Controls.Add(this.tabPage2);
            this.tabSimulation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSimulation.Location = new System.Drawing.Point(0, 28);
            this.tabSimulation.Name = "tabSimulation";
            this.tabSimulation.SelectedIndex = 0;
            this.tabSimulation.Size = new System.Drawing.Size(1168, 672);
            this.tabSimulation.TabIndex = 3;
            this.tabSimulation.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pctSimple);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1160, 643);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Simple";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pctSimple
            // 
            this.pctSimple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctSimple.Location = new System.Drawing.Point(3, 3);
            this.pctSimple.Name = "pctSimple";
            this.pctSimple.Size = new System.Drawing.Size(1154, 637);
            this.pctSimple.TabIndex = 0;
            this.pctSimple.TabStop = false;
            this.pctSimple.Click += new System.EventHandler(this.pctSimple_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 700);
            this.Controls.Add(this.tabSimulation);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Physics Engine";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.tabCircuit.ResumeLayout(false);
            this.tabCircuit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtVt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBin)).EndInit();
            this.tlsComponents.ResumeLayout(false);
            this.tlsComponents.PerformLayout();
            this.tlsMeasures.ResumeLayout(false);
            this.tlsMeasures.PerformLayout();
            this.tlsMaterials.ResumeLayout(false);
            this.tlsMaterials.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabSimulation.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctSimple)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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

        private void shapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Timer simTimer;
        private System.ComponentModel.IContainer components;
        private TabPage tabCircuit;
        private Button btnACMode;
        private Button btnDCMode;
        private Label lblComponentValue;
        private TrackBar compTrack;
        private Button btnSimulate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtVt;
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem componentsToolStripMenuItem;
        private ToolStripMenuItem materialsToolStripMenuItem;
        private ToolStripMenuItem measuresToolStripMenuItem;
        private PictureBox pictureBox1;
        private TabControl tabSimulation;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private PictureBox pctSimple;
        private PictureBox pictureBox2;
    }
}

