using System.Windows.Forms;

using GradePredictor.Util;


/// <copyright file="CoursePredictorApplication.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor
{
    public delegate void VoidDelegate();
    public delegate void IntegerDelegate(int i);
    public delegate void IntegerBooleanDelegate(int i, bool b);
    class CoursePredictorApplication : ApplicationContext
    {
        private GradePredictor.GUI.MainWindowController mainWindow;
        public CoursePredictorApplication()
        {
            // Initialize concurrent job queue
            ConcurrentWorkQueue.Initialize();

            // Start the application
            this.mainWindow = new GradePredictor.GUI.MainWindowController();
            this.MainForm = this.mainWindow.View;
            this.MainForm.Show();
        }
    }
}
