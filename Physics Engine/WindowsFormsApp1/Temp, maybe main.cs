using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static WindowsFormsApp1.Form1;


namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {

        // Tracks the components
        private BaseElecPiece editingComponent = null;
        private bool muteTrack = false;
        private List<BaseElecPiece> myCircuitList = new List<BaseElecPiece>();
        private BaseElecPiece selectedComp = null;
        private bool isDragging = false;
        private int lastMouseX;
        private int lastMouseY;
        private int mouseX;
        
        private List<BaseElecPiece> activeCircuitList = new List<BaseElecPiece>();
        private Point startDrag;

        // Track what the user wants to draw
        private string selectedWireHandle = "";
        public Form1()
        {
            InitializeComponent();

            //Defining Pens
            Pen redPen = new Pen(Color.Red);
            Pen blackPen = new Pen(Color.Black);
            // Interface
            pictureBox1.Paint += PictureBox1_Paint;
            pctSimple.Paint += pctSimple_Paint;
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            //Lock the PictureBox behavior so interface stays in place and doesn't resize with the form
            //Main problem maker
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pctSimple.Dock = DockStyle.Fill;
            pctSimple.SizeMode = PictureBoxSizeMode.Normal;

            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer,
            true);


            SetupCharts();


            compTrack.Parent = pictureBox1;
            compTrack.Parent = pctSimple;
            lblComponentValue.Parent = pictureBox1;
            lblComponentValue.Parent = pctSimple;
            compTrack.SmallChange = 1;
            compTrack.LargeChange = 10;
            compTrack.TickFrequency = 50;
            compTrack.Visible = false;
            lblComponentValue.Visible = false;

            // Both events are wired and controls are on top
            compTrack.Scroll -= ComponentTrackBar_Scroll;
            compTrack.Scroll += ComponentTrackBar_Scroll;
            compTrack.ValueChanged -= ComponentTrackBar_Scroll;
            compTrack.ValueChanged += ComponentTrackBar_Scroll;

            compTrack.BringToFront();
            lblComponentValue.BringToFront();
        }

        private void SetupCharts()
        {
            // I-V chart
            if (chtIV.ChartAreas.Count == 0) chtIV.ChartAreas.Add("CA");
            var caIV = chtIV.ChartAreas[0];
            caIV.AxisX.Title = "Voltage (V)";
            caIV.AxisY.Title = "Current (A)";
            caIV.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            caIV.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chtIV.Series.Clear();
            var sIV = chtIV.Series.Add("I-V");
            sIV.ChartType = SeriesChartType.Line;
            sIV.BorderWidth = 2;
        }

        public abstract class BaseElecPiece
        {
            public string Name { get; set; }
            public double Voltage { get; set; }
            public double Current { get; set; }
            public double Resistance { get; set; }

            // Top left is the start position
            public Point StartPoint { get; set; }
            public Point EndPoint { get; set; }

            
            public abstract void Draw(Graphics g);

            public int X { get; set; }
            public int Y { get; set; }

            public bool ContainsPoint(int mouseX, int mouseY)
            {
                return mouseX >= X && mouseX <= X + 80 && mouseY >= Y && mouseY <= Y + 80;
            }

            // The anchor points are used for snapping wires to the left and right sides of components
            public Point LeftAnchor => new Point(this.X + 0, this.Y + 50);

            public Point RightAnchor => new Point(this.X + 75, this.Y + 50);

            public virtual bool IsHit(Point clickLocation, float tolerance)
            {
                return ContainsPoint(clickLocation.X, clickLocation.Y);
            }
        }


        private void btnWireTool_Click(object sender, EventArgs e)
        {
            
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            // Enable smooth line drawing
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Loop through list and render each custom drawing
            foreach (var component in activeCircuitList)
            {
                component.Draw(e.Graphics);
            }
        }
        private void toolStripButton_Click(object sender, EventArgs e)
        {
            // Uncheck all other buttons in the toolstrip so only one is active
            foreach (var item in tlsMaterials.Items)
            {
                if (item is ToolStripButton btn && btn != sender)
                {
                    btn.Checked = false;
                }
            }

        }
        // Important variables that track how to wire works
        private string shapeToDraw = "";
        private int shapeX = 50;
        private int shapeY = 50;
        private int shapeWidth = 100;
        private int shapeHeight = 100;
        private string titleText;
        private string defaultText;
        private string promptText;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // Set the shape's position to the mouse click location
            shapeX = e.X - shapeWidth / 2;
            shapeY = e.Y - shapeHeight / 2;
            this.Invalidate();
        }


        private void measuresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            tlsMeasures.Visible = !tlsMeasures.Visible;
            tlsComponents.Visible = false;
            tlsMaterials.Visible = false;
        }
        private void componentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            tlsComponents.Visible = !tlsComponents.Visible;
            tlsMaterials.Visible = false;
            tlsMeasures.Visible = false;
        }

        private void materialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            tlsMaterials.Visible = !tlsMaterials.Visible;
            tlsComponents.Visible = false;
            tlsMeasures.Visible = false;
        }
        private void tlsMaterials_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            pictureBox1.BackColor = Color.White;
            pctSimple.BackColor = Color.White;
            RefreshCanvas();

        }

        private void btnBattery_Click(object sender, EventArgs e)
        {
            
            myCircuitList.Add(new Battery { X = 150, Y = 50 });
            RefreshCanvas();

        }

        private void btnCell_Click(object sender, EventArgs e)
        {
            
            myCircuitList.Add(new Cell { X = 50, Y = 50 });
            RefreshCanvas();
        }

        private void btnAmmeter_Click(object sender, EventArgs e)
        {
            
            myCircuitList.Add(new Ammeter { X = 50, Y = 50 });
            RefreshCanvas();
        }

        private void btnVoltmeter_Click(object sender, EventArgs e)
        {
            
            myCircuitList.Add(new Voltmeter { X = 50, Y = 50 });
            RefreshCanvas();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // It will check if the user clicked on a component and if so, 
            // it will set that component as the selectedComp and start dragging it.
            Debug.WriteLine($"MouseDown at {e.Location}. selectedComp BEFORE search = {selectedComp?.GetType().Name ?? "(null)"}");
            if (e.Button != MouseButtons.Left) return;

            // hide by default
            compTrack?.Hide();
            lblComponentValue?.Hide();
            // Reset selected wire handle
            for (int i = myCircuitList.Count - 1; i >= 0; i--)
            {
                // Check if the mouse click is within the component's hit area 
                var comp = myCircuitList[i];
                if (comp.IsHit(new Point(e.X, e.Y), 8f))
                {
                    selectedComp = comp;
                    Debug.WriteLine($">> Selected: {selectedComp.GetType().Name} | R: {selectedComp.Resistance}Ω, V: {selectedComp.Voltage}V");
                    isDragging = true;
                    lastMouseX = e.X;
                    lastMouseY = e.Y;

                    if (comp is Wire wire)
                    {
                        Point clickPosition = new Point(e.X, e.Y);
                        selectedWireHandle = wire.GetSelectedHandle(clickPosition);
                    }
                    else
                    {
                        selectedWireHandle = "";
                    }

                    SyncTrackbar();
                    break;
                }
            }
        }

        private void pctSimple_MouseDown(object sender, MouseEventArgs e)
        {
            // It will check if the user clicked on a component and if so, 
            // it will set that component as the selectedComp and start dragging it.
            Debug.WriteLine($"MouseDown at {e.Location}. selectedComp BEFORE search = {selectedComp?.GetType().Name ?? "(null)"}");
            if (e.Button != MouseButtons.Left) return;

            // hide by default
            compTrack?.Hide();
            lblComponentValue?.Hide();
            // Reset selected wire handle
            for (int i = myCircuitList.Count - 1; i >= 0; i--)
            {
                // Check if the mouse click is within the component's hit area 
                var comp = myCircuitList[i];
                if (comp.IsHit(new Point(e.X, e.Y), 8f))
                {
                    selectedComp = comp;
                    Debug.WriteLine($">> Selected: {selectedComp.GetType().Name} | R: {selectedComp.Resistance}Ω, V: {selectedComp.Voltage}V");
                    isDragging = true;
                    lastMouseX = e.X;
                    lastMouseY = e.Y;

                    if (comp is Wire wire)
                    {
                        Point clickPosition = new Point(e.X, e.Y);
                        selectedWireHandle = wire.GetSelectedHandle(clickPosition);
                    }
                    else
                    {
                        selectedWireHandle = "";
                    }

                    SyncTrackbar();
                    break;
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
            bool overBin = false;
            if (isDragging && picBin != null)
            {
                var binScreen = picBin.PointToScreen(Point.Empty);
                var binInCanvas = pictureBox1.PointToClient(binScreen);
                var binRect = new Rectangle(binInCanvas, picBin.Size);

                
                if (binRect.Contains(e.Location)) overBin = true;
                picBin.BackColor = overBin ? Color.LightCoral : SystemColors.Control;
            }

            // If dragging a component, update its position based on mouse movement
            if (isDragging && selectedComp != null)
            {
                int moveX = e.X - lastMouseX;
                int moveY = e.Y - lastMouseY;
                
                if (selectedComp is Wire wire)
                {
                    // If dragging a wire, moves the appropriate endpoint or the whole wire
                    if (selectedWireHandle == "StartPoint")
                    {
                        var start = wire.StartPoint;
                        start.Offset(moveX, moveY);
                        wire.StartPoint = start;
                        // If attached, detach while dragging a handle so it can be moved freely
                        wire.connectedStartComp = null;
                        wire.connectedStartAnch = "";
                    }
                    else if (selectedWireHandle == "EndPoint")
                    {
                        wire.EndPoint = new Point(wire.EndPoint.X + moveX, wire.EndPoint.Y + moveY);
                        wire.connectedEndComp = null;
                        wire.connectedEndAnch = "";
                    }
                    else
                    {
                        var start = wire.StartPoint;
                        start.Offset(moveX, moveY);
                        wire.StartPoint = start;
                        var end = wire.StartPoint;
                        end.Offset(moveX, moveY);
                        wire.StartPoint = start;
                        // detach both ends while moving whole wire
                        wire.connectedStartComp = null;
                        wire.connectedStartAnch = "";
                        wire.connectedEndComp = null;
                        wire.connectedEndAnch = "";
                    }
                }
                else
                {
                    selectedComp.X += moveX;
                    selectedComp.Y += moveY;
                }

                lastMouseX = e.X;
                lastMouseY = e.Y;

                RefreshCanvas();
            }

            // Updates when there is mouse movement
            if (isDragging && selectedComp != null && compTrack != null && compTrack.Visible)
            {
                // The trackbar is repositioned to be above the selected component
                compTrack.Location = new Point(selectedComp.X, Math.Max(0, selectedComp.Y - 36));
                lblComponentValue.Location = new Point(compTrack.Location.X, Math.Max(0, compTrack.Location.Y - 20));
            }
        }

        private void pctSimple_MouseMove(object sender, MouseEventArgs e)
        {

            bool overBin = false;
            if (isDragging && pictureBox3 != null)
            {
                var binScreen = pictureBox3.PointToScreen(Point.Empty);
                var binInCanvas = pctSimple.PointToClient(binScreen);
                var binRect = new Rectangle(binInCanvas, pictureBox3.Size);


                if (binRect.Contains(e.Location)) overBin = true;
                pictureBox3.BackColor = overBin ? Color.LightCoral : SystemColors.Control;
            }

            // If dragging a component, update its position based on mouse movement
            if (isDragging && selectedComp != null)
            {
                int moveX = e.X - lastMouseX;
                int moveY = e.Y - lastMouseY;

                if (selectedComp is Wire wire)
                {
                    // If dragging a wire, moves the appropriate endpoint or the whole wire
                    if (selectedWireHandle == "StartPoint")
                    {
                        var start = wire.StartPoint;
                        start.Offset(moveX, moveY);
                        wire.StartPoint = start;
                        // If attached, detach while dragging a handle so it can be moved freely
                        wire.connectedStartComp = null;
                        wire.connectedStartAnch = "";
                    }
                    else if (selectedWireHandle == "EndPoint")
                    {
                        wire.EndPoint = new Point(wire.EndPoint.X + moveX, wire.EndPoint.Y + moveY);
                        wire.connectedEndComp = null;
                        wire.connectedEndAnch = "";
                    }
                    else
                    {
                        var start = wire.StartPoint;
                        start.Offset(moveX, moveY);
                        wire.StartPoint = start;
                        var end = wire.StartPoint;
                        end.Offset(moveX, moveY);
                        wire.StartPoint = start;
                        // detach both ends while moving whole wire
                        wire.connectedStartComp = null;
                        wire.connectedStartAnch = "";
                        wire.connectedEndComp = null;
                        wire.connectedEndAnch = "";
                    }
                }
                else
                {
                    selectedComp.X += moveX;
                    selectedComp.Y += moveY;
                }

                lastMouseX = e.X;
                lastMouseY = e.Y;

                RefreshCanvas();
            }

            // Updates when there is mouse movement
            if (isDragging && selectedComp != null && compTrack != null && compTrack.Visible)
            {
                // The trackbar is repositioned to be above the selected component
                compTrack.Location = new Point(selectedComp.X, Math.Max(0, selectedComp.Y - 36));
                lblComponentValue.Location = new Point(compTrack.Location.X, Math.Max(0, compTrack.Location.Y - 20));
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Debug.WriteLine($"MouseUp at {e.Location}. selectedComp at MouseUp = {selectedComp?.GetType().Name ?? "(null)"}");
            
            if (picBin != null) picBin.BackColor = SystemColors.Control;

            // If a component was being dragged, check if it intersects the bin for deletion
            if (selectedComp != null)
            {
                
                Rectangle binRect = Rectangle.Empty;
                if (picBin != null)
                {
                    Point binTopLeft = new Point(0, 0);
                    Point binScreenPos = picBin.PointToScreen(binTopLeft);
                    var binInCanvas = pictureBox1.PointToClient(binScreenPos);
                    int x = binInCanvas.X;
                    int y = binInCanvas.Y;
                    binRect = new Rectangle(x, y, picBin.Width, picBin.Height);
                }

                // If the dropped component intersects the bin, its deleted and connected wires
                if (picBin != null)
                {
                    // Get the bounds of the selected component including wires
                    Rectangle compRect = getCompBound(selectedComp);
                    if (compRect.Right > binRect.Left &&
                        compRect.Left < binRect.Right &&
                        compRect.Bottom > binRect.Top &&
                        compRect.Top < binRect.Bottom)
                    {

                        // Removes any wires attached to this component first
                        var connectedWires = myCircuitList
                        .OfType<Wire>()
                        .Where(w => w.connectedStartComp == selectedComp || w.connectedEndComp == selectedComp)
                        .ToList();

                        foreach (var w in connectedWires)
                        {
                            myCircuitList.Remove(w);
                        }

                        // Now removes the component itself
                        myCircuitList.Remove(selectedComp);

                        // Clears selection and redraws
                        selectedComp = null;
                        selectedWireHandle = "";
                        isDragging = false;
                        RefreshCanvas();
                        return;
                    }
                }

                // Existing wire-snapping logic 
                if (selectedComp is Wire wire)
                {
                    int snapDist = 20;
                    double startDist = double.MaxValue;
                    double endDist = double.MaxValue;
                    BaseElecPiece startComp = null;
                    BaseElecPiece bestEndComp = null;
                    Point startAnch = Point.Empty;
                    Point endAnch = Point.Empty;
                    string startAnchName = "";
                    string endAnchName = "";
                    // Loop through all components to find the closest anchors for snapping
                    foreach (BaseElecPiece staticComp in myCircuitList)
                    {
                        if (staticComp == wire) continue;

                        var left = staticComp.LeftAnchor;
                        var right = staticComp.RightAnchor;

                        var distStartLeft = GetDistance(wire.StartPoint, left);
                        var distStartRight = GetDistance(wire.StartPoint, right);
                        var distEndLeft = GetDistance(wire.EndPoint, left);
                        var distEndRight = GetDistance(wire.EndPoint, right);

                        if (distStartLeft < startDist) { startDist = distStartLeft; startComp = staticComp; startAnch = left; startAnchName = "Left"; }
                        if (distStartRight < startDist) { startDist = distStartRight; startComp = staticComp; startAnch = right; startAnchName = "Right"; }

                        if (distEndLeft < endDist) { endDist = distEndLeft; bestEndComp = staticComp; endAnch = left; endAnchName = "Left"; }
                        if (distEndRight < endDist) { endDist = distEndRight; bestEndComp = staticComp; endAnch = right; endAnchName = "Right"; }
                    }
                    // Snap to the closest anchor if within snap distance for start point
                    if (startComp != null && startDist <= snapDist)
                    {
                        wire.connectedStartComp = startComp;
                        wire.connectedStartAnch = startAnchName;
                        wire.StartPoint = startAnch;
                    }
                    else
                    {
                        wire.connectedStartComp = null;
                        wire.connectedStartAnch = "";
                    }
                    // Snap to the closest anchor if within snap distance for end point
                    if (bestEndComp != null && endDist <= snapDist)
                    {
                        wire.connectedEndComp = bestEndComp;
                        wire.connectedEndAnch = endAnchName;
                        wire.EndPoint = endAnch;
                    }
                    else
                    {
                        wire.connectedEndComp = null;
                        wire.connectedEndAnch = "";
                    }

                    // Finishes the snapping and clears selection
                    selectedComp = null;
                    selectedWireHandle = "";
                    isDragging = false;
                    RefreshCanvas();
                    return;
                }

                // Existing snapping for rectangular components
                int snapDistanceRect = 35;
                foreach (BaseElecPiece staticComp in myCircuitList)
                {
                    // Skip snapping to itself
                    if (staticComp == selectedComp) continue;
                    // Calculates distance from selected component's left anchor to static component's right anchor
                    double distLeftToRight = Math.Sqrt(
                        Math.Pow(selectedComp.LeftAnchor.X - staticComp.RightAnchor.X, 2) +
                        Math.Pow(selectedComp.LeftAnchor.Y - staticComp.RightAnchor.Y, 2)
                    );
                    // If within snapping distance, snap the selected component to the right of the static component
                    if (distLeftToRight < snapDistanceRect)
                    {
                        selectedComp.X = staticComp.RightAnchor.X;
                        selectedComp.Y = staticComp.RightAnchor.Y - 50;
                        break;
                    }
                    // Calculates distance from selected component's right anchor to static component's left anchor
                    double distRightToLeft = Math.Sqrt(
                        Math.Pow(selectedComp.RightAnchor.X - staticComp.LeftAnchor.X, 2) +
                        Math.Pow(selectedComp.RightAnchor.Y - staticComp.LeftAnchor.Y, 2)
                    );
                    // If within snapping distance, snap the selected component to the left of the static component
                    if (distRightToLeft < snapDistanceRect)
                    {
                        selectedComp.X = staticComp.LeftAnchor.X - 75;
                        selectedComp.Y = staticComp.LeftAnchor.Y - 50;
                        break;
                    }
                }

                
                selectedComp = null;
                pictureBox1.Invalidate();
                isDragging = false;
            }
        }

        private void pctSimple_MouseUp(object sender, MouseEventArgs e)
        {
            Debug.WriteLine($"MouseUp at {e.Location}. selectedComp at MouseUp = {selectedComp?.GetType().Name ?? "(null)"}");

            if (pictureBox3 != null) pictureBox3.BackColor = SystemColors.Control;

            // If a component was being dragged, check if it intersects the bin for deletion
            if (selectedComp != null)
            {

                Rectangle binRect = Rectangle.Empty;
                if (pictureBox3 != null)
                {
                    Point binTopLeft = new Point(0, 0);
                    Point binScreenPos = pictureBox3.PointToScreen(binTopLeft);
                    var binInCanvas = pctSimple.PointToClient(binScreenPos);
                    int x = binInCanvas.X;
                    int y = binInCanvas.Y;
                    binRect = new Rectangle(x, y, pictureBox3.Width, pictureBox3.Height);
                }

                // If the dropped component intersects the bin, its deleted and connected wires
                if (pictureBox3 != null)
                {
                    // Get the bounds of the selected component including wires
                    Rectangle compRect = getCompBound(selectedComp);
                    if (compRect.Right > binRect.Left &&
                        compRect.Left < binRect.Right &&
                        compRect.Bottom > binRect.Top &&
                        compRect.Top < binRect.Bottom)
                    {

                        // Removes any wires attached to this component first
                        var connectedWires = myCircuitList
                        .OfType<Wire>()
                        .Where(w => w.connectedStartComp == selectedComp || w.connectedEndComp == selectedComp)
                        .ToList();

                        foreach (var w in connectedWires)
                        {
                            myCircuitList.Remove(w);
                        }

                        // Now removes the component itself
                        myCircuitList.Remove(selectedComp);

                        // Clears selection and redraws
                        selectedComp = null;
                        selectedWireHandle = "";
                        isDragging = false;
                        RefreshCanvas();
                        return;
                    }
                }

                // Existing wire-snapping logic 
                if (selectedComp is Wire wire)
                {
                    int snapDist = 20;
                    double startDist = double.MaxValue;
                    double endDist = double.MaxValue;
                    BaseElecPiece startComp = null;
                    BaseElecPiece bestEndComp = null;
                    Point startAnch = Point.Empty;
                    Point endAnch = Point.Empty;
                    string startAnchName = "";
                    string endAnchName = "";
                    // Loop through all components to find the closest anchors for snapping
                    foreach (BaseElecPiece staticComp in myCircuitList)
                    {
                        if (staticComp == wire) continue;

                        var left = staticComp.LeftAnchor;
                        var right = staticComp.RightAnchor;

                        var distStartLeft = GetDistance(wire.StartPoint, left);
                        var distStartRight = GetDistance(wire.StartPoint, right);
                        var distEndLeft = GetDistance(wire.EndPoint, left);
                        var distEndRight = GetDistance(wire.EndPoint, right);

                        if (distStartLeft < startDist) { startDist = distStartLeft; startComp = staticComp; startAnch = left; startAnchName = "Left"; }
                        if (distStartRight < startDist) { startDist = distStartRight; startComp = staticComp; startAnch = right; startAnchName = "Right"; }

                        if (distEndLeft < endDist) { endDist = distEndLeft; bestEndComp = staticComp; endAnch = left; endAnchName = "Left"; }
                        if (distEndRight < endDist) { endDist = distEndRight; bestEndComp = staticComp; endAnch = right; endAnchName = "Right"; }
                    }
                    // Snap to the closest anchor if within snap distance for start point
                    if (startComp != null && startDist <= snapDist)
                    {
                        wire.connectedStartComp = startComp;
                        wire.connectedStartAnch = startAnchName;
                        wire.StartPoint = startAnch;
                    }
                    else
                    {
                        wire.connectedStartComp = null;
                        wire.connectedStartAnch = "";
                    }
                    // Snap to the closest anchor if within snap distance for end point
                    if (bestEndComp != null && endDist <= snapDist)
                    {
                        wire.connectedEndComp = bestEndComp;
                        wire.connectedEndAnch = endAnchName;
                        wire.EndPoint = endAnch;
                    }
                    else
                    {
                        wire.connectedEndComp = null;
                        wire.connectedEndAnch = "";
                    }

                    // Finishes the snapping and clears selection
                    selectedComp = null;
                    selectedWireHandle = "";
                    isDragging = false;
                    RefreshCanvas();
                    return;
                }

                // Existing snapping for rectangular components
                int snapDistanceRect = 35;
                foreach (BaseElecPiece staticComp in myCircuitList)
                {
                    // Skip snapping to itself
                    if (staticComp == selectedComp) continue;
                    // Calculates distance from selected component's left anchor to static component's right anchor
                    double distLeftToRight = Math.Sqrt(
                        Math.Pow(selectedComp.LeftAnchor.X - staticComp.RightAnchor.X, 2) +
                        Math.Pow(selectedComp.LeftAnchor.Y - staticComp.RightAnchor.Y, 2)
                    );
                    // If within snapping distance, snap the selected component to the right of the static component
                    if (distLeftToRight < snapDistanceRect)
                    {
                        selectedComp.X = staticComp.RightAnchor.X;
                        selectedComp.Y = staticComp.RightAnchor.Y - 50;
                        break;
                    }
                    // Calculates distance from selected component's right anchor to static component's left anchor
                    double distRightToLeft = Math.Sqrt(
                        Math.Pow(selectedComp.RightAnchor.X - staticComp.LeftAnchor.X, 2) +
                        Math.Pow(selectedComp.RightAnchor.Y - staticComp.LeftAnchor.Y, 2)
                    );
                    // If within snapping distance, snap the selected component to the left of the static component
                    if (distRightToLeft < snapDistanceRect)
                    {
                        selectedComp.X = staticComp.LeftAnchor.X - 75;
                        selectedComp.Y = staticComp.LeftAnchor.Y - 50;
                        break;
                    }
                }


                selectedComp = null;
                pctSimple.Invalidate();
                isDragging = false;
            }
        }
        private double GetDistance(Point p1, Point p2)
        {
            
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
        // Snaps the moving component to the nearest anchor of other components if within snap distance
        private void SnapComponents(dynamic movingCell, IEnumerable<dynamic> allComponents)
        {
            int snapDist = 20;
            // Loop through all components to find the closest anchors for snapping
            foreach (var standCell in allComponents)
            {
                if (standCell == movingCell) continue;

                // Check if the moving cell's left anchor is close to the static cell's right anchor
                if (GetDistance(movingCell.LeftAnchor, standCell.RightAnchor) < snapDist)
                {
                    movingCell.X = standCell.RightAnchor.X;
                    movingCell.Y = standCell.RightAnchor.Y - 50;
                    return;
                }
                // Same but for right
                if (GetDistance(movingCell.RightAnchor, standCell.LeftAnchor) < snapDist)
                {
                    movingCell.X = standCell.LeftAnchor.X - 75;
                    movingCell.Y = standCell.LeftAnchor.Y - 50;
                    return;
                }
            }
        }
             
        private const int resizing = 0x0046;
        private const int calcSize = 0x0083;
        private bool lockLayoutFrames = false;
        protected override void WndProc(ref Message m)
        {
            if (lockLayoutFrames && (m.Msg == resizing || m.Msg == calcSize))
            {
                return; 
            }
            base.WndProc(ref m);
        }
        private void RefreshCanvas()
        {
            if (pictureBox1.Width <= 0 || pictureBox1.Height <= 0) return;
            Bitmap bmp = new Bitmap(pictureBox1.ClientRectangle.Width, pictureBox1.ClientRectangle.Height);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                // Each component executes its custom design sequence
                foreach (var component in myCircuitList)
                {
                    component.Draw(graphics);
                }
            }
            // Dispose of the previous image to free resources and avoid memory leaks
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = bmp;

            if (pctSimple.Width <= 0 || pctSimple.Height <= 0) return;
            Bitmap bmp2 = new Bitmap(pctSimple.ClientRectangle.Width, pctSimple.ClientRectangle.Height);
            using (Graphics graphics = Graphics.FromImage(bmp2))
            {
                foreach (var component in myCircuitList)
                {
                    component.Draw(graphics);
                }
            }
            pctSimple.Image?.Dispose();
            pctSimple.Image = bmp2;
        }
        // This is the Paint event handler for pictureBox1, which is the main canvas where components are drawn.
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (Form1.BaseElecPiece comp in myCircuitList)
            {
                comp.Draw(e.Graphics);
            }
        }
        private void pctSimple_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (Form1.BaseElecPiece comp in myCircuitList)
            {
                comp.Draw(e.Graphics);
            }
        }
        private void btnDiode_Click(object sender, EventArgs e)
        {
            
            myCircuitList.Add(new Diode { X = 50, Y = 50 });
            RefreshCanvas();
        }

        private void btnResistor_Click(object sender, EventArgs e)
        {
            
            myCircuitList.Add(new Resistor { X = 50, Y = 50 });
            RefreshCanvas();

        }

        private void btnLamp_Click(object sender, EventArgs e)
        {
            
            myCircuitList.Add(new Lamp { X = 50, Y = 50 });
            RefreshCanvas();
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            this.ActiveControl = null;
        }
        
        private void btnWire_Click(object sender, EventArgs e)
        {
            
            this.ActiveControl = null;
            myCircuitList.Add(new Wire
            {
                StartPoint = new Point(50, 50),
                EndPoint = new Point(150, 50)
            });
            RefreshCanvas();
        }

        private void pctSimple_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox2_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        private void picBin_Click(object sender, EventArgs e)
        {
            
        }
        
        private Rectangle getCompBound(BaseElecPiece comp)
        {
            if (comp == null) return Rectangle.Empty;

            // If it's a wire, uses rendered endpoints
            if (comp is Wire w)
            {

                Point s = (w.connectedStartComp != null)
                    ? (w.connectedStartAnch == "Left" ? w.connectedStartComp.LeftAnchor : w.connectedStartComp.RightAnchor)
                    : w.StartPoint;
                Point e = (w.connectedEndComp != null)
                    ? (w.connectedEndAnch == "Left" ? w.connectedEndComp.LeftAnchor : w.connectedEndComp.RightAnchor)
                    : w.EndPoint;
                // Adds padding to ensure the wire's handle radius is included in the bounding box
                int pad = w.handleRad + 6;
                int left = Math.Min(s.X, e.X) - pad;
                int top = Math.Min(s.Y, e.Y) - pad;
                int width = Math.Abs(s.X - e.X) + pad * 2;
                int height = Math.Abs(s.Y - e.Y) + pad * 2;
                return new Rectangle(left, top, Math.Max(1, width), Math.Max(1, height));
            }

            
            const int compWidth = 80;
            const int compHeight = 80;
            return new Rectangle(comp.X, comp.Y, compWidth, compHeight);
        }

        // Dont work so no V-t graph
        private CancellationTokenSource simCts;
        private double simTime = 0.0;
        private readonly double simDt = 0.02; // seconds
        private double amplitude = 5.0;
        private double frequency = 1.0;
        private int vtMaxPoints = 800;
        private BaseElecPiece selectedForIV = null;

        //Starts the graphs
        private void StartSimulation()
        {
            if (simCts != null) return;
            simCts = new CancellationTokenSource();
            simTime = 0.0;
            
        }

        // Stops the simulation loop and cancels any ongoing tasks
        private void StopSimulation()
        {
            if (simCts == null) return;
            simCts.Cancel();
            simCts = null;
        }

        
        private double ComputeCircuitCurrent(double additionalOscillatorVoltage = 0.0)
        {
            
            double Vsum = additionalOscillatorVoltage;
            foreach (var comp in myCircuitList)
            {
                if (comp is Battery || comp is Cell)
                    Vsum += comp.Voltage;
            }

             
            double Rtotal = 0.0;
            foreach (var comp in myCircuitList)
            {
                Rtotal += CircuitSimulator.GetEffectiveResistance(comp, Vsum);
            }

            if (Rtotal <= 0.0) return 0.0;
            return Vsum / Rtotal;
        }
        // The main simulation loop that runs by updating the circuit state and charts at each time step.
        private async Task RunSimulationLoop(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    // compute step 
                    double osc = amplitude * Math.Sin(2.0 * Math.PI * frequency * simTime);

                    BaseElecPiece analysedSeed = selectedForIV;

                    if (analysedSeed == null)
                    {
                        analysedSeed = myCircuitList.OfType<Battery>().FirstOrDefault();
                    }

                    if (analysedSeed == null)
                    {
                        analysedSeed = myCircuitList.FirstOrDefault();
                    }

                    List<BaseElecPiece> compProcess;

                    if (analysedSeed != null)
                    {
                        compProcess = GetConnectedComp(analysedSeed);
                    }
                    else
                    {
                        compProcess = myCircuitList.ToList();
                    }

                    if (compProcess == null || compProcess.Count == 0)
                    {
                        
                    }
                    else
                    {
                        
                        double current = CircuitSimulator.ComputeCircuitCurrent(compProcess, osc);

                        
                        double totalVoltage = compProcess.Sum(c => c.Voltage) + osc;

                        
                        foreach (var c in compProcess)
                        {
                            if (c is Ammeter am)
                            {
                                am.MeasuredCurrent = current;
                            }
                            else if (c is Voltmeter vm)
                            {
                                
                                vm.MeasuredVoltage = totalVoltage;
                            }
                        }

                        // ensures UI updates the drawn meters 
                        if (pictureBox1 != null && !pictureBox1.IsDisposed)
                        {
                            
                            if (pictureBox1.InvokeRequired)
                            {
                                pictureBox1.BeginInvoke(new Action(() => RefreshCanvas()));
                            }
                        }
                        else
                        {
                            RefreshCanvas();
                        }

                        if (pctSimple != null && !pctSimple.IsDisposed)
                        {

                            if (pctSimple.InvokeRequired)
                            {
                                pctSimple.BeginInvoke(new Action(() => RefreshCanvas()));
                            }
                        }
                        else
                        {
                            RefreshCanvas();
                        }

                        double plotVolt = totalVoltage;
                        if (selectedForIV != null)
                        {
                            double Rcomp = CircuitSimulator.GetEffectiveResistance(selectedForIV, totalVoltage);
                            plotVolt = current * Rcomp;
                        }

                        
                    }

                    simTime += simDt;
                    // delay is in milliseconds
                    int delay = (int)(simDt * 1000);
                    await Task.Delay(delay, token);
                }
            }
            
            catch (TaskCanceledException) { }
            catch (ObjectDisposedException) { }
        }

        
        private void SimulateOnce()
        {
           
            BaseElecPiece analisedSeed = selectedForIV ?? myCircuitList.FirstOrDefault();

            analisedSeed = selectedForIV
                ?? myCircuitList.OfType<Battery>().FirstOrDefault()
                ?? myCircuitList.OfType<Cell>().FirstOrDefault()
                ?? myCircuitList.OfType<Form1.BaseElecPiece>().FirstOrDefault();

            
            if (analisedSeed == null)
            {
                MessageBox.Show("No components placed.", "SimulateOnce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            var compProcess = GetConnectedComp(analisedSeed);
            Debug.WriteLine($"SimulateOnce: analisedSeed={analisedSeed.GetType().Name}, connectedCount={compProcess.Count}");

            if (compProcess.Count == 0)
            {
                MessageBox.Show("Connected set is empty.", "SimulateOnce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // The current in this connected loop is computed using the CircuitSimulator.cs file
            double osc = 0.0;
            double current = CircuitSimulator.ComputeCircuitCurrent(compProcess, osc);

            double totalVoltage = compProcess.Sum(c => c.Voltage) + osc;

            // Populate meter readings
            foreach (var c in compProcess)
            {
                if (c is Ammeter am) am.MeasuredCurrent = current;
                if (c is Voltmeter vm) vm.MeasuredVoltage = totalVoltage;
            }

            // Update visuals so meters show readings
            RefreshCanvas();

            
            double plotVolt = totalVoltage;
            if (selectedForIV != null && compProcess.Contains(selectedForIV))
            {
                double Rcomp = CircuitSimulator.GetEffectiveResistance(selectedForIV, totalVoltage);
                plotVolt = current * Rcomp;
            }

            
            

            if (selectedForIV != null)
            {
                PlotIV(selectedForIV, 20.0, 200);
                chtIV.ChartAreas[0].RecalculateAxesScale();
                chtIV.Invalidate();
            }
            else
            {
                
                if (chtIV.Series.Count == 0) chtIV.Series.Add("I-V");
                var sIV = chtIV.Series[0];
                sIV.Points.AddXY(totalVoltage, current);
                chtIV.ChartAreas[0].RecalculateAxesScale();
                chtIV.Invalidate();
            }

            // Debug popup
            Debug.WriteLine($"SimulateOnce result: I={current}, V_total={totalVoltage}, V_plot={plotVolt}");
            MessageBox.Show($"I={current:F6} A\nV_total={totalVoltage:F3} V\nV_plot={plotVolt:F3} V\nconnectedCount={compProcess.Count}",
                "SimulateOnce", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        public class Cell : Form1.BaseElecPiece
        {
            
            public Cell()
            {
                Resistance = 0.0;   
                Voltage = 5.0;      
            }

            
            public override void Draw(Graphics g)
            {
                using (Pen blackPen = new Pen(Color.Black, 3))
                {
                    g.DrawLine(blackPen, X + 0, Y + 50, X + 25, Y + 50);
                    g.DrawLine(blackPen, X + 25, Y + 25, X + 25, Y + 75);
                    g.DrawLine(blackPen, X + 50, Y + 40, X + 50, Y + 60);
                    g.DrawLine(blackPen, X + 50, Y + 50, X + 75, Y + 50);
                }
            }
            // Returns the left and right anchor points for connecting wires to the cell.
            public new Point LeftAnchor => new Point(this.X + 0, this.Y + 50);
            public new Point RightAnchor => new Point(this.X + 75, this.Y + 50);

        }

        public class Battery : Form1.BaseElecPiece
        {
            
            public double MinVoltage { get; } = 0.0;
            public double MaxVoltage { get; } = 250.0;

            public Battery()
            {
                Resistance = 0.0; 
                Voltage = 10.0;   
            }

            
            public void SetVoltage(double v)
            {
                Voltage = Math.Max(MinVoltage, Math.Min(MaxVoltage, v));
            }
            
            public override void Draw(Graphics g)
            {
                using (Pen blackPen = new Pen(Color.Black, 3))
                {
                    g.DrawLine(blackPen, X + 0, Y + 50, X + 20, Y + 50);
                    g.DrawLine(blackPen, X + 20, Y + 25, X + 20, Y + 75);
                    g.DrawLine(blackPen, X + 35, Y + 40, X + 35, Y + 60);
                    g.DrawLine(blackPen, X + 50, Y + 25, X + 50, Y + 75);
                    g.DrawLine(blackPen, X + 65, Y + 40, X + 65, Y + 60);
                    g.DrawLine(blackPen, X + 65, Y + 50, X + 85, Y + 50);
                }
            }
        }

        public class Diode : Form1.BaseElecPiece
        {
            
            public double ForwardResistance { get; set; } = 7.0;
            public double ReverseResistance { get; set; } = 50.0;
            public Diode() { }

            
            public override void Draw(Graphics g)
            {

                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen blackPen = new Pen(Color.Black, 3))
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    g.DrawEllipse(blackPen, X + 13, Y + 25, 50, 50);
                    Point[] triangle = new Point[]
                     {
                new Point( X + 28,  Y + 35), // Top back corner
                new Point( X + 28,  Y + 65), // Bottom back corner
                new Point( X + 50,  Y + 50)  // Arrow tip
                     };

                    g.FillPolygon(brush, triangle);
                    g.DrawLine(blackPen, X + 50, Y + 35, X + 50, Y + 65);
                    g.DrawLine(blackPen, X + 0, Y + 50, X + 75, Y + 50);
                }
            }

            public double EffectiveResistanceForVoltage(double appliedVoltage)
            {
                return appliedVoltage >= 0 ? ForwardResistance : ReverseResistance;
            }
        }
        
        public class Resistor : Form1.BaseElecPiece
        {
            
            public Resistor()
            {
                Resistance = 100.0; 
            }
            public override void Draw(Graphics g)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen blackPen = new Pen(Color.Black, 3))
                {
                    g.DrawLine(blackPen, X + 20, Y + 70, X + 70, Y + 70);
                    g.DrawLine(blackPen, X + 20, Y + 30, X + 70, Y + 30);
                    g.DrawLine(blackPen, X + 20, Y + 70, X + 20, Y + 30);
                    g.DrawLine(blackPen, X + 70, Y + 30, X + 70, Y + 70);
                    g.DrawLine(blackPen, X + 0, Y + 50, X + 20, Y + 50);
                    g.DrawLine(blackPen, X + 70, Y + 50, X + 90, Y + 50);
                }
            }

        }
       
        public class Lamp : Form1.BaseElecPiece
        {
            
            public Lamp() { }

            public override void Draw(Graphics g)
            {

                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen blackPen = new Pen(Color.Black, 3))
                {
                    g.DrawLine(blackPen, X + 0, Y + 50, X + 15, Y + 50);
                    g.DrawLine(blackPen, X + 60, Y + 50, X + 75, Y + 50);

                    g.DrawEllipse(blackPen, X + 13, Y + 25, 50, 50);

                    g.DrawLine(blackPen, X + 27, Y + 39, X + 49, Y + 61);
                    g.DrawLine(blackPen, X + 27, Y + 61, X + 49, Y + 39);
                }
            }
        }

        public class Ammeter : Form1.BaseElecPiece
        {
            public double MeasuredCurrent { get; set; }

            public Ammeter()
            {
                Resistance = 0.0;
                Voltage = 0.0;
                MeasuredCurrent = 0.0;
            }

            public override void Draw(Graphics g)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen blackPen = new Pen(Color.Black, 3))
                using (Brush textBrush = new SolidBrush(Color.Black))
                using (Brush backBrush = new SolidBrush(Color.FromArgb(200, Color.White)))
                {
                    g.DrawLine(blackPen, X + 0, Y + 50, X + 15, Y + 50);
                    g.DrawLine(blackPen, X + 60, Y + 50, X + 75, Y + 50);

                    g.DrawEllipse(blackPen, X + 13, Y + 25, 50, 50);

                    g.DrawLine(blackPen, X + 38, Y + 35, X + 31, Y + 57);
                    g.DrawLine(blackPen, X + 38, Y + 35, X + 45, Y + 57);
                    g.DrawLine(blackPen, X + 34, Y + 48, X + 42, Y + 48);

                    string ammeterText = $"{MeasuredCurrent:F3} A";

                    using (Font displayFont = new Font("Segoe UI", 9, FontStyle.Bold))
                    {
                        SizeF textSize = g.MeasureString(ammeterText, displayFont);

                        float textX = X + 38 - (textSize.Width / 2);
                        float textY = Y + 62;

                        var labelA = new RectangleF(textX - 4, textY - 2, textSize.Width + 8, textSize.Height + 4);

                        g.FillRectangle(backBrush, labelA);
                        g.DrawRectangle(Pens.Gray, (int)labelA.X, (int)labelA.Y, (int)labelA.Width, (int)labelA.Height);
                        g.DrawString(ammeterText, displayFont, textBrush, textX, textY);
                    }
                }
            }
        }
        public class Voltmeter : Form1.BaseElecPiece
        {
            public double MeasuredVoltage { get; set; }

            public Voltmeter()
            {
                Resistance = 1e9; 
                Voltage = 0.0;
                MeasuredVoltage = 0.0;
            }

            public override void Draw(Graphics g)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen blackPen = new Pen(Color.Black, 3))
                using (Brush textBrush = new SolidBrush(Color.Black))
                using (Brush backBrush = new SolidBrush(Color.FromArgb(200, Color.White)))
                {
                    g.DrawLine(blackPen, X + 0, Y + 50, X + 15, Y + 50);
                    g.DrawLine(blackPen, X + 60, Y + 50, X + 75, Y + 50);

                    g.DrawEllipse(blackPen, X + 13, Y + 25, 50, 50);

                    g.DrawLine(blackPen, X + 30, Y + 37, X + 38, Y + 59);
                    g.DrawLine(blackPen, X + 38, Y + 59, X + 46, Y + 37);

                    string voltText = $"{MeasuredVoltage:F2} V";

                    using (Font labelFont = new Font("Segoe UI", 9, FontStyle.Bold))
                    {
                        SizeF labelSize = g.MeasureString(voltText, labelFont);

                        float displayX = X + 38 - (labelSize.Width / 2);
                        float displayY = Y + 62;

                        var textFrame = new RectangleF(displayX - 4, displayY - 2, labelSize.Width + 8, labelSize.Height + 4);

                        g.FillRectangle(backBrush, textFrame);
                        g.DrawRectangle(Pens.Gray, (int)textFrame.X, (int)textFrame.Y, (int)textFrame.Width, (int)textFrame.Height);
                        g.DrawString(voltText, labelFont, textBrush, displayX, displayY);
                    }
                }
            }
        }
        public class Wire : Form1.BaseElecPiece
        {
            public int handleRad { get; set; } = 8;
            public Wire() { Resistance = 0.0; Voltage = 0.0; }

            public Form1.BaseElecPiece connectedStartComp { get; set; }
            public Form1.BaseElecPiece connectedEndComp { get; set; }
            public string connectedStartAnch { get; set; } = ""; 
            public string connectedEndAnch { get; set; } = "";

            private Point EffectiveStart
            {
                get
                {
                    if (connectedStartComp != null)
                    {
                        return connectedStartAnch == "Left" ? connectedStartComp.LeftAnchor : connectedStartComp.RightAnchor;
                    }
                    return StartPoint;
                }
            }

            private Point EffectiveEnd
            {
                get
                {
                    if (connectedEndComp != null)
                    {
                        return connectedEndAnch == "Left" ? connectedEndComp.LeftAnchor : connectedEndComp.RightAnchor;
                    }
                    return EndPoint;
                }
            }

            public override void Draw(Graphics g)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Point s = EffectiveStart;
                Point e = EffectiveEnd;

                using (Pen blackPen = new Pen(Color.Black, 2))
                {
                    blackPen.StartCap = LineCap.Round;
                    blackPen.EndCap = LineCap.Round;
                    g.DrawLine(blackPen, s, e);
                }

                // Visualize hit area, semi-transparent grey
                int visRad = handleRad + 4;
                using (Brush hitBrush = new SolidBrush(Color.FromArgb(140, Color.LightGray)))
                using (Pen hitOutline = new Pen(Color.Gray, 1))
                {
                    g.FillEllipse(hitBrush, s.X - visRad, s.Y - visRad, visRad * 2, visRad * 2);
                    g.DrawEllipse(hitOutline, s.X - visRad, s.Y - visRad, visRad * 2, visRad * 2);

                    g.FillEllipse(hitBrush, e.X - visRad, e.Y - visRad, visRad * 2, visRad * 2);
                    g.DrawEllipse(hitOutline, e.X - visRad, e.Y - visRad, visRad * 2, visRad * 2);
                }

                // Draw red handles
                g.FillEllipse(Brushes.Red, s.X - handleRad, s.Y - handleRad, handleRad * 2, handleRad * 2);
                g.FillEllipse(Brushes.Red, e.X - handleRad, e.Y - handleRad, handleRad * 2, handleRad * 2);
            }

            public override bool IsHit(Point clickLocation, float tolerance)
            {
                Point s = EffectiveStart;
                Point e = EffectiveEnd;

                if (s == e) return IsNearPoint(clickLocation, s, (int)tolerance);

                float num = Math.Abs((e.Y - s.Y) * clickLocation.X - (e.X - s.X) * clickLocation.Y + e.X * s.Y - e.Y * s.X);
                float den = (float)Math.Sqrt(Math.Pow(e.Y - s.Y, 2) + Math.Pow(e.X - s.X, 2));
                if (den == 0) return false;

                float distance = num / den;

                bool withinBounds = clickLocation.X >= Math.Min(s.X, e.X) - tolerance &&
                                    clickLocation.X <= Math.Max(s.X, e.X) + tolerance &&
                                    clickLocation.Y >= Math.Min(s.Y, e.Y) - tolerance &&
                                    clickLocation.Y <= Math.Max(s.Y, e.Y) + tolerance;

                return distance <= tolerance && withinBounds;
            }

            public string GetSelectedHandle(Point clickLocation)
            {
                Point s = EffectiveStart;
                Point e = EffectiveEnd;
                    
                if (IsNearPoint(clickLocation, s, handleRad + 4)) return "StartPoint";
                if (IsNearPoint(clickLocation, e, handleRad + 4)) return "EndPoint";
                if (IsHit(clickLocation, 5)) return "body";
                return "";
            }

            private bool IsNearPoint(Point p1, Point p2, int tolerance)
            {
                int dx = p1.X - p2.X;
                int dy = p1.Y - p2.Y;
                return (dx * dx + dy * dy) <= (tolerance * tolerance);
            }
        }

        private void chtIV_Click(object sender, EventArgs e)
        {

        }

        private void chtVt_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BaseElecPiece clicked = null;
            for (int i = myCircuitList.Count - 1; i >= 0; i--)
            {
                var comp = myCircuitList[i];
                if (comp.IsHit(new Point(e.X, e.Y), 8f) || comp.ContainsPoint(e.X, e.Y))
                {
                    clicked = comp;
                    break;
                }
            }

            if (clicked != null)
            {
                selectedForIV = clicked;
                PlotIV(selectedForIV, 20.0, 400);
            }
        }

        // Plot I-V for a single component using CircuitSimulator.GetEffectiveResistance
        private void PlotIV(BaseElecPiece comp, double vMax = 20.0, int steps = 200)
        {
            if (comp == null || chtIV == null) return;

            
            if (chtIV.Series.Count == 0) chtIV.Series.Add("I-V");
            var series = chtIV.Series[0];
            series.Points.Clear();

            double step = (2.0 * vMax) / steps;
            for (int i = 0; i <= steps; i++)
            {
                double v = -vMax + i * step;

                
                double R = CircuitSimulator.GetEffectiveResistance(comp, v);

                
                double I = (R <= 0.0) ? 0.0 : v / R;

                series.Points.AddXY(v, I);
            }

            chtIV.Invalidate();
        }

        // V-t chart so dont work
        
        private List<BaseElecPiece> GetConnectedComp(BaseElecPiece analisedSeed)
        {
            if (analisedSeed == null) return new List<BaseElecPiece>();

            var visited = new HashSet<BaseElecPiece>();
            var q = new Queue<BaseElecPiece>();
            visited.Add(analisedSeed);
            q.Enqueue(analisedSeed);

            while (q.Count > 0)
            {
                var cur = q.Dequeue();

                // Find wires that attach to this component
                foreach (var wire in myCircuitList.OfType<Wire>())
                {
                    if (wire.connectedStartComp != cur && wire.connectedEndComp != cur)
                        continue;

                    BaseElecPiece oppositeComp = (wire.connectedStartComp == cur)
                        ? wire.connectedEndComp
                        : wire.connectedStartComp;

                    if (!visited.Contains(wire))
                    {
                        visited.Add(wire);
                        q.Enqueue(wire);
                    }

                    if (oppositeComp != null && !visited.Contains(oppositeComp))
                    {
                        visited.Add(oppositeComp);
                        q.Enqueue(oppositeComp);
                    }
                }

                
                if (cur is Wire wireCur)
                {
                    var endpoints = new[] { wireCur.connectedStartComp, wireCur.connectedEndComp };

                    foreach (var comp in endpoints)
                    {
                        if (comp != null && !visited.Contains(comp))
                        {
                            visited.Add(comp);
                            q.Enqueue(comp);
                        }
                    }
                }
            }

            return visited.ToList();
        }
        private void DumpCircuitState()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Total components: {myCircuitList.Count}");
            int i = 0;
            foreach (var c in myCircuitList)
            {
                string type = c.GetType().Name;
                if (c is Wire w)
                {
                    string startComponent = w.connectedStartComp != null ? w.connectedStartComp.GetType().Name : "None";
                    string endComponent = w.connectedEndComp != null ? w.connectedEndComp.GetType().Name : "None";

                    string logLine = $"{i}: Wire From {w.StartPoint} to {w.EndPoint} | Links: {startComponent} -> {endComponent}";
                    sb.AppendLine(logLine);
                    i++;
                }
                else
                {
                    string componentDetails = $"Type: {type} | Position: ({c.X}, {c.Y}) | V = {c.Voltage}V, R = {c.Resistance}Ω";
                    sb.AppendLine($"[{i}] {componentDetails}");
                    i++;
                }
            }

            Debug.WriteLine(sb.ToString());
            MessageBox.Show(sb.ToString(), "Circuit State", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSimulate_Click_1(object sender, EventArgs e)
        {
            DumpCircuitState();

            SimulateOnce();
        }

        private string FormatResistance(double ohms)
        {
            if (ohms >= 1_000_000) return $"{ohms / 1_000_000.0:F2} MΩ";
            if (ohms >= 1_000) return $"{ohms / 1_000.0:F2} kΩ";
            return $"{ohms:F0} Ω";
        }
        
        private string FormatVoltage(double v)
        {
            return $"{v:F2} V";
        }

        private void SyncTrackbar()
        {
            if (selectedComp == null || compTrack == null || lblComponentValue == null)
            {
                editingComponent = null;
                muteTrack = false;
                compTrack?.Hide();
                lblComponentValue?.Hide();
                muteTrack = false;
                return;
            }

            // Show UI and remember which component it is editing
            editingComponent = selectedComp;
            compTrack.Show();
            lblComponentValue.Show();

            compTrack.Location = new Point(Math.Max(0, selectedComp.X), Math.Max(0, selectedComp.Y - 40));
            lblComponentValue.Location = new Point(compTrack.Location.X, Math.Max(0, compTrack.Location.Y - 20));

            compTrack.BringToFront();
            lblComponentValue.BringToFront();

            muteTrack = true;
            if (editingComponent is Resistor r)
            {
                compTrack.Minimum = 0;
                compTrack.Maximum = 500; 
                compTrack.Value = Math.Min(compTrack.Maximum, Math.Max(compTrack.Minimum, (int)Math.Round(r.Resistance)));
                lblComponentValue.Text = $"R = {r.Resistance:F0} Ω";
            }
            else if (editingComponent is Battery b)
            {
                compTrack.Minimum = (int)Math.Floor(b.MinVoltage);
                compTrack.Maximum = (int)Math.Ceiling(b.MaxVoltage);
                compTrack.Value = Math.Min(compTrack.Maximum, Math.Max(compTrack.Minimum, (int)Math.Round(b.Voltage)));
                lblComponentValue.Text = $"V = {b.Voltage:F1} V";
            }
            else if (editingComponent is Cell c)
            {
                compTrack.Minimum = 0;
                compTrack.Maximum = 20;
                compTrack.Value = Math.Min(compTrack.Maximum, Math.Max(compTrack.Minimum, (int)Math.Round(c.Voltage)));
                lblComponentValue.Text = $"V = {c.Voltage:F1} V";
            }
            else
            {
                editingComponent = null;
                compTrack.Hide();
                lblComponentValue.Hide();
            }

            muteTrack = false;
        }

        
        private void ComponentTrackBar_Scroll(object sender, EventArgs e)
        {
            if (muteTrack) return; 

            
            var target = editingComponent ?? selectedComp;
            if (target == null)
            {
                Debug.WriteLine($"TrackBar change but no editing component (value={compTrack.Value})");
                return;
            }

            int v = compTrack.Value;
            
            if (target is Resistor r)
            {
                r.Resistance = v;
                lblComponentValue.Text = $"R = {r.Resistance:F0} Ω";
            }
            else if (target is Battery b)
            {
                b.SetVoltage(v);
                lblComponentValue.Text = $"V = {b.Voltage:F1} V";
            }
            else if (target is Cell c)
            {
                c.Voltage = v;
                lblComponentValue.Text = $"V = {c.Voltage:F1} V";
            }

            // keep UI on top
            compTrack.BringToFront();
            lblComponentValue.BringToFront();

            Debug.WriteLine($"TrackBar -> editing={target.GetType().Name}, value={v}, model R={target.Resistance}, V={target.Voltage}");
            RefreshCanvas();
        }

        
    }
}