using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;
using Gma.System.MouseKeyHook;

//Ryan Harrison 2011
//raharrison.co.uk
//mail@raharrison.co.uk

namespace Auto_Clicker
{
    public partial class MainForm : Form
    {
        #region Global Variables and Properties

        private Thread ClickThread; //Thread to take care of clicking the mouse
                                    //so UI is not made unresponsive

        private Point CurrentPosition { get; set; } //The current position of the mouse cursor
        private IKeyboardMouseEvents m_GlobalHook;//global key handling

        #endregion

        #region Constructor

        /// <summary>
        /// Construct the form object and initialise all form components
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Component Events

        /// <summary>
        /// Start the timer to update the cursor position and clear all items in the list view
        /// when the form loads
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //global key handling
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyDown += GlobalHookKeyPress;

            CurrentPositionTimer.Start();
            PositionsListView.Items.Clear();
            DDLLoad_SaveFiles();

            LoadSave("Default");
        }

        //global key handling
        private void GlobalHookKeyPress(object sender, KeyEventArgs e)
        {
            Console.WriteLine("KeyPress: \t{0}", e.KeyCode);
            if (e.KeyCode == Keys.F1)
            {
                CopyToAddButton_Click(null, null);
            }
            else if (e.KeyCode == Keys.F2)
            {
                AddPositionButton_Click(null, null);
            }
            else if (e.KeyCode == Keys.F3)
            {
                StartClickingButton_Click(null, null);
            }
            else if (e.KeyCode == Keys.F4)
            {
                StopClickingButton_Click(null, null);
            }
        }

        /// <summary>
        /// Set the CurrentPosition property to the current position of the mouse cursor
        /// on screen on each interval of the timer
        /// </summary>
        private void CurrentPositionTimer_Tick(object sender, EventArgs e)
        {
            CurrentPosition = Cursor.Position;
            UpdateCurrentPositionTextBoxes();
        }

        /// <summary>
        /// Copy current position of the cursor to alternate textboxes so they are ready to 
        /// be queued by the user
        /// </summary>
        private void CopyToAddButton_Click(object sender, EventArgs e)
        {
            QueuedXPositionTextBox.Text = CurrentPosition.X.ToString();
            QueuedYPositionTextBox.Text = CurrentPosition.Y.ToString();
        }

        /// <summary>
        /// Add the point held in the queued textboxes to the listview so ready to be executed
        /// </summary>
        private void AddPositionButton_Click(object sender, EventArgs e)
        {
            if (CurrentPositionIsValid(QueuedXPositionTextBox.Text, QueuedYPositionTextBox.Text))
            {
                if (IsValidNumericalInput(SleepTimeTextBox.Text))
                {
                    //Add item holding coordinates, right/left click and sleep time to list view
                    //holding all queued clicks
                    ListViewItem item = new ListViewItem(QueuedXPositionTextBox.Text);
                    item.SubItems.Add(QueuedYPositionTextBox.Text);
                    string clickType = (RightClickCheckBox.Checked) == true ? "R" : "L";

                    int sleepTime = Convert.ToInt32(SleepTimeTextBox.Text);
                    item.SubItems.Add(clickType);
                    item.SubItems.Add(sleepTime.ToString());
                    PositionsListView.Items.Add(item);

                    SaveHelper.SaveEverything("Default", NumRepeatsTextBox, PositionsListView);
                }
                else
                {
                    MessageBox.Show("Sleep time is not a valid positive integer", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Current Coordinates are not valid", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Assign all points in the queue to the ClickHelper and start the thread
        /// </summary>
        private void StartClickingButton_Click(object sender, EventArgs e)
        {
            if (IsValidNumericalInput(NumRepeatsTextBox.Text))
            {
                int iterations = Convert.ToInt32(NumRepeatsTextBox.Text);
                List<Point> points = new List<Point>();
                List<string> clickType = new List<string>();
                List<int> times = new List<int>();

                foreach (ListViewItem item in PositionsListView.Items)
                {
                    //Add data in queued clicks to corresponding List collection
                    int x = Convert.ToInt32(item.Text); //x coordinate
                    int y = Convert.ToInt32(item.SubItems[1].Text); //y coordinate
                    clickType.Add(item.SubItems[2].Text); //click type
                    times.Add(Convert.ToInt32(item.SubItems[3].Text)); //sleep time

                    points.Add(new Point(x, y));
                }
                try
                {
                    //Create a ClickHelper passing Lists of click information
                    ClickThreadHelper helper = new ClickThreadHelper() { Points = points, ClickType = clickType, Iterations = iterations, Times = times, StatusLabel = lblCurrentState };
                    //Create the thread passing the Run method
                    ClickThread = new Thread(new ThreadStart(helper.Run));
                    //Start the thread, thus starting the clicks
                    ClickThread.Start();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
            else
            {
                MessageBox.Show("Number of repeats is not a valid positive integer", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Abort the clicking thread and so stop all simulated clicks
        /// </summary>
        private void StopClickingButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClickThread.IsAlive)
                {
                    ClickThread.Abort(); //Attempt to stop the thread
                    ClickThread.Join(); //Wait for thread to stop
                    MessageBox.Show("Clicking successfully stopped", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ThreadAbortException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Remove all items from the list view holding queued positions
        /// </summary>
        private void RemoveAllMenuItem_Click(object sender, EventArgs e)
        {
            PositionsListView.Items.Clear();
        }

        /// <summary>
        /// Remove only the selected item from the list view holding all queued positions
        /// </summary>
        private void RemoveSelectedMenuItem_Click(object sender, EventArgs e)
        {
            PositionsListView.SelectedItems[0].Remove();
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Update current position textboxes to reflect the current position of the cursor
        /// </summary>
        private void UpdateCurrentPositionTextBoxes()
        {
            CurrentXCoordTextBox.Text = this.CurrentPosition.X.ToString();
            CurrentYCoordTextBox.Text = this.CurrentPosition.Y.ToString();
        }

        /// <summary>
        /// Check whether the input string consists of a valid positive integer
        /// </summary>
        /// <param name="input">The string to check</param>
        /// <returns>True if input is a valid positive integer, otherwise false</returns>
        private bool IsValidNumericalInput(string input)
        {
            int temp = 0;
            return (int.TryParse(input, out temp)) && temp >= 0;
        }

        /// <summary>
        /// Check if the coordinates are valid positive integers and also fit
        /// inside the bounds of the monitor
        /// </summary>
        /// <param name="xCoord">The X coordinate to check</param>
        /// <param name="yCoord">The Y coordinate to check</param>
        /// <returns>True if coordinates are valid, otherwise false</returns>
        private bool CurrentPositionIsValid(string xCoord, string yCoord)
        {
            int x, y, width, height = 0;

            if (int.TryParse(xCoord, out x) && int.TryParse(yCoord, out y))
            {
                width = System.Windows.Forms.SystemInformation.VirtualScreen.Width;
                height = System.Windows.Forms.SystemInformation.VirtualScreen.Height;

                if (x <= width && x >= 0 && y <= height && y >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Thread Helper Class

        internal class ClickThreadHelper
        {
            #region Fields, DLL Imports and Constants

            public List<Point> Points { get; set; } //Hold the list of points in the queue
            public int Iterations { get; set; } //Hold the number of iterations/repeats
            public List<string> ClickType { get; set; } //Is each point right click or left click
            public List<int> Times { get; set; } //Holds sleep times for after each click
            public Label StatusLabel { get; set; }

            //Import unmanaged functions from DLL library
            [DllImport("user32.dll")]
            public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern int SendInput(int nInputs, ref INPUT pInputs, int cbSize);

            /// <summary>
            /// Structure for SendInput function holding relevant mouse coordinates and information
            /// </summary>
            public struct INPUT
            {
                public uint type;
                public MOUSEINPUT mi;

            };

            /// <summary>
            /// Structure for SendInput function holding coordinates of the click and other information
            /// </summary>
            public struct MOUSEINPUT
            {
                public int dx;
                public int dy;
                public int mouseData;
                public int dwFlags;
                public int time;
                public IntPtr dwExtraInfo;
            };

            //Constants for use in SendInput and mouse_event
            public const int INPUT_MOUSE = 0x0000;
            public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
            public const int MOUSEEVENTF_LEFTUP = 0x0004;
            public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
            public const int MOUSEEVENTF_RIGHTUP = 0x0010;
            public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
            public const int MOUSEEVENTF_MIDDLEUP = 0x0040;

            #endregion

            #region Mouse_Event Methods

            /// <summary>
            /// Click the left mouse button at the current cursor position using
            /// the imported mouse_event function
            /// </summary>
            private void ClickLeftMouseButtonMouseEvent()
            {
                //Send a left click down followed by a left click up to simulate a 
                //full left click
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }

            /// <summary>
            /// Click the right mouse button at the current cursor position using
            /// the imported mouse_event function
            /// </summary>
            private void ClickRightMouseButtonMouseEvent()
            {
                //Send a left click down followed by a right click up to simulate a 
                //full right click
                mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            }

            #endregion

            #region SendInput Methods

            /// <summary>
            /// Click the left mouse button at the current cursor position using
            /// the imported SendInput function
            /// </summary>
            public void ClickLeftMouseButtonSendInput()
            {
                //Initialise INPUT object with corresponding values for a left click
                INPUT input = new INPUT();
                input.type = INPUT_MOUSE;
                input.mi.dx = 0;
                input.mi.dy = 0;
                input.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
                input.mi.dwExtraInfo = IntPtr.Zero;
                input.mi.mouseData = 0;
                input.mi.time = 0;

                //Send a left click down followed by a left click up to simulate a 
                //full left click
                SendInput(1, ref input, Marshal.SizeOf(input));
                input.mi.dwFlags = MOUSEEVENTF_LEFTUP;
                SendInput(1, ref input, Marshal.SizeOf(input));

            }

            /// <summary>
            /// Click the left mouse button at the current cursor position using
            /// the imported SendInput function
            /// </summary>
            public void ClickRightMouseButtonSendInput()
            {
                //Initialise INPUT object with corresponding values for a right click
                INPUT input = new INPUT();
                input.type = INPUT_MOUSE;
                input.mi.dx = 0;
                input.mi.dy = 0;
                input.mi.dwFlags = MOUSEEVENTF_RIGHTDOWN;
                input.mi.dwExtraInfo = IntPtr.Zero;
                input.mi.mouseData = 0;
                input.mi.time = 0;

                //Send a right click down followed by a right click up to simulate a 
                //full right click
                SendInput(1, ref input, Marshal.SizeOf(input));
                input.mi.dwFlags = MOUSEEVENTF_RIGHTUP;
                SendInput(1, ref input, Marshal.SizeOf(input));
            }

            #endregion

            #region Methods


            public delegate void SetStateTextConsumer(string text, Color color);
            public void SetStateText(string text, Color color)
            {
                if (StatusLabel.InvokeRequired)
                    StatusLabel.Invoke(new SetStateTextConsumer(SetStateText), new object[] { text, color });
                else
                {
                    StatusLabel.ForeColor = color;
                    StatusLabel.Text = text;
                }
            }

            /// <summary>
            /// Iterate through all queued clicks, for each deciding which mouse button
            /// to press and how long to sleep afterwards
            /// 
            /// This method is assigned to the ClickThread and is the only place where
            /// the mouse buttons are pressed
            /// </summary>
            public void Run()
            {
                try
                {
                    int i = 1;

                    while (i <= Iterations)
                    {
                        SetStateText($@"Running - Iteration {i}/{Iterations}",Color.Green);
                        //Iterate through all queued clicks
                        for (int j = 0; j <= Points.Count - 1; j++)
                        {
                            SetCursorPosition(Points[j]); //Set cursor position before clicking
                            if (ClickType[j].Equals("R"))
                            {
                                ClickRightMouseButtonSendInput();
                            }
                            else
                            {
                                ClickLeftMouseButtonSendInput();
                            }
                            Thread.Sleep(Times[j]);
                        }
                        i++;
                    }
                    SetStateText($@"Competed - {Iterations} Iterations", Color.Blue);
                }
                catch (Exception exc)
                {
                    SetStateText($@"Error - {exc.Message}", Color.Red);
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            /// <summary>
            /// Set the current position of the cursor to the coordinates held in point
            /// </summary>
            /// <param name="point">Coordinates to set the cursor to</param>
            private void SetCursorPosition(Point point)
            {
                Cursor.Position = point;
            }

            #endregion
        }

        #endregion

        private void DDLLoad_SaveFiles()
        {
            List<string> files = new List<string>();

            files.Add("Default");
            files.AddRange(SaveHelper.GetSaveFileList());
            files.Add("--Add New--");

            ddlFileNames.DataSource = files;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string savename = ddlFileNames.SelectedValue.ToString();
            if (savename == "--Add New--")
            {
                //create new
                savename = Microsoft.VisualBasic.Interaction.InputBox("Enter a name", "New Save File");

            }
            SaveHelper.SaveEverything(savename, NumRepeatsTextBox, PositionsListView);
            DDLLoad_SaveFiles();
            ddlFileNames.SelectedItem = savename;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            PositionsListView.Items.Clear();
            string savename = ddlFileNames.SelectedValue.ToString();            
            LoadSave(savename);
        }

        private void LoadSave(string Name)
        {
            SaveValues sv = SaveHelper.LoadEverything(Name);
            if (sv != null)
            {
                NumRepeatsTextBox.Text = sv.NumberToRepeat.ToString();

                foreach (CursorPositionValue pv in sv.CusorPositions)
                {
                    ListViewItem item = new ListViewItem(pv.X.ToString());
                    item.SubItems.Add(pv.Y.ToString());
                    item.SubItems.Add(pv.RightClick == true ? "R" : "L");
                    item.SubItems.Add(pv.Sleep.ToString());
                    PositionsListView.Items.Add(item);
                }
            }
        }

        private void PositionsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = PositionsListView.SelectedItems[0];
                if (item != null)
                {
                    QueuedXPositionTextBox.Text = item.Text;
                    QueuedYPositionTextBox.Text = item.SubItems[1].Text;
                    RightClickCheckBox.Checked = item.SubItems[2].Text == "R" ? true : false;
                    SleepTimeTextBox.Text = item.SubItems[3].Text;
                }
            }
            catch (Exception) { }
        }
        
        private void btnUpdateRow_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = PositionsListView.SelectedItems[0];
                if (item != null)
                {
                    item.Text = QueuedXPositionTextBox.Text;
                    item.SubItems[1].Text = QueuedYPositionTextBox.Text;
                    item.SubItems[2].Text = RightClickCheckBox.Checked == true ? "R" : "L";
                    item.SubItems[3].Text = SleepTimeTextBox.Text;
                }

                SaveHelper.SaveEverything("Default", NumRepeatsTextBox, PositionsListView);
            }
            catch (Exception) { }
        }

        private void NumRepeatsTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveHelper.SaveEverything("Default", NumRepeatsTextBox, PositionsListView);
        }

    }
}
