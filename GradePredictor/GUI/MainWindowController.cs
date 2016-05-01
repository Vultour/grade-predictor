using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using GradePredictor.CourseCore;
using GradePredictor.CourseUtil;
using GradePredictor.Util;


/// <copyright file="MainWindowController.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.GUI
{
    class MainWindowController
    {
        private MainWindowView view;
        private WarningsView warningsWindow;
        private SingleModuleController moduleWindow;
        private Course course;

        private int selectedYear;

        public MainWindowView View
        {
            get { return this.view; }
        }

        public MainWindowController()
        {
            this.view = new MainWindowView(
                this.StartNewHandler,
                this.StartLoadAutoHandler,
                this.LoadCourseHandler,
                this.AddModuleHandler,
                this.SaveCourseHandler,
                this.ShowMessagesHandler,
                this.FileDroppedHandler
            );
            this.view.FormClosing += this.ApplicationClosingHandler;
            this.moduleWindow = new SingleModuleController(this.view);
            this.warningsWindow = new WarningsView();

            this.view.YearChanged += this.YearChangedHandler;
            this.view.CourseDataUpdated += this.CourseEditedHandler;
        }


        private void registerCourse(Course course)
        {
            if (course != null)
            {
                this.view.Invoke((MethodInvoker)delegate {
                    this.view.reset();
                    this.view.startNew();
                });

                this.view.Invoke((MethodInvoker)delegate { this.warningsWindow.BeginLoading(); });

                if (this.course != null) { this.course.Detach(); }
                this.course = course;
                this.course.Change += this.CourseChangedHandler;
                this.course.WarningEmitted += this.WarningsChangedHandler;
                this.course.TriggerCalculation();

                ConcurrentWorkQueue.Enqueue(() => this.view.Invoke((MethodInvoker)delegate { this.warningsWindow.EndLoading(); }));

                this.view.Invoke((MethodInvoker)delegate { this.view.BeginLoading(); });
                foreach (Year y in this.course.Years)
                {
                    foreach (Module m in y.Modules)
                    {
                        this.view.Invoke((MethodInvoker)delegate
                        {
                            this.view.createModule(y.Number, this.OpenModuleHandler, this.RemoveModuleHandler, m);
                            Application.DoEvents();
                        });
                    }
                }
                this.view.Invoke((MethodInvoker)delegate
                {
                    this.view.SelectYearOne();
                    this.view.ResetModuleControlPositions(1);
                    this.view.SelectYearTwo();
                    this.view.ResetModuleControlPositions(2);
                    this.view.SelectYearThree();
                    this.view.ResetModuleControlPositions(3);
                    this.view.SelectYearOne();
                    this.view.EndLoading();
                });
            }
        }


        public void CourseEditedHandler()
        {
            this.course.Title = this.view.Title;
        }

        public void StartNewHandler(object sender, EventArgs e)
        {
            // Reset Course instance
            // (re) Initialize main form
            ConcurrentWorkQueue.Enqueue(() => this.registerCourse(new Course()));
        }

        public void StartLoadAutoHandler(object sender, EventArgs e)
        {
            // Load Course from autosave
            if (System.IO.File.Exists(Properties.Resources.SAVE_FILE_PATH))
            {
                ConcurrentWorkQueue.Enqueue(() =>
                {
                    try
                    {
                        Course c = new CourseXMLBackend(null).SetPath(Properties.Resources.SAVE_FILE_PATH).Load();
                        this.registerCourse(c);
                        return;
                    }
                    catch (InvalidCourseXMLException)
                    {
                        MessageBox.Show("Unable to load course, the file might be corrupted.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
            else
            {
                MessageBox.Show("No autosave file present.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void AddModuleHandler(object sender, EventArgs e)
        {
            this.course.Years[this.selectedYear - 1].CreateModule();
            this.view.Invoke((MethodInvoker)delegate
            {
                this.view.createModule(this.OpenModuleHandler, this.RemoveModuleHandler, this.course.Years[this.selectedYear - 1].Modules[this.course.Years[this.selectedYear - 1].Modules.Count - 1]);
            });
        }

        public void RemoveModuleHandler(object sender, EventArgs e)
        {
            ModuleControl control = (ModuleControl)((Button)sender).Parent;
            this.course.Years[this.selectedYear - 1].RemoveModule(control.Module);
            this.view.Invoke((MethodInvoker)delegate { this.view.removeModule(control); });
        }

        public void OpenModuleHandler(object sender, EventArgs e)
        {
            ModuleControl m = null;
            if (sender is ModuleControl)
            {
                m = (ModuleControl)sender;
            }
            else
            {
                m = (ModuleControl)((Control)sender).Parent;
            }
            this.moduleWindow.Module = m.Module;
            this.moduleWindow.populateAndShow();
        }

        public void SaveCourseHandler(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.InitialDirectory = Environment.CurrentDirectory;
            file.CheckPathExists = true;
            file.ValidateNames = true;
            file.Filter = "Course files (*.course)|*.course";
            file.FileOk += (s, ee) =>
            {
                ConcurrentWorkQueue.Enqueue(() => { new CourseXMLBackend(this.course.DeepClone()).SetPath(file.FileName).Save(); });
            };
            file.ShowDialog();
        }

        public void LoadCourseHandler(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Environment.CurrentDirectory;
            file.CheckFileExists = true;
            file.CheckPathExists = true;
            file.Multiselect = false;
            file.ValidateNames = true;
            file.Filter = "Course files (*.course)|*.course";
            file.FileOk += (s, ee) =>
            {
                try
                {
                    ConcurrentWorkQueue.Enqueue(() => {
                        Course c = new CourseXMLBackend(null).SetPath(file.FileName).Load();
                        this.registerCourse(c);
                    });
                } catch (InvalidCourseXMLException)
                {
                    MessageBox.Show("Error loading course, the file might be corrupted.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            file.ShowDialog();
        }

        public void FileDroppedHandler(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            IEnumerable<string> selection = files.Where((string s) => s.Contains(".course"));
            string x;
            if (selection.Count() > 0)
            {
                x = selection.First();
                ConcurrentWorkQueue.Enqueue(() =>
                {
                    try
                    {
                        Course c = new CourseXMLBackend(null).SetPath(x).Load();
                        this.registerCourse(c);
                    }
                    catch (InvalidCourseXMLException)
                    {
                        MessageBox.Show("Error loading course, the file might be corrupted.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
        }

        public void ShowMessagesHandler(object sender, EventArgs e) { this.warningsWindow.Show(); }

        public void YearChangedHandler(int index)
        {
            this.selectedYear = index;
        }

        public void CourseChangedHandler(object Sender, bool triggerRecalc)
        {
            this.view.Invoke((MethodInvoker)delegate
            {
                this.view.editCourseValues(
                    this.course.Title,
                    this.course.Years[0].Result,
                    this.course.Years[1].Result,
                    this.course.Years[2].Result,
                    this.course.Result
                );
            });
        }

        public void WarningsChangedHandler()
        {
            List<CourseWarning> wrn = this.course.Warnings;
            this.view.Invoke((MethodInvoker)delegate { this.view.Warnings = wrn.Count; });
            this.warningsWindow.Invoke((MethodInvoker)delegate
            {
                this.warningsWindow.Clear();
                wrn.ForEach((CourseWarning w) => { this.warningsWindow.AddWarning(w); });
            });
        }

        public void ApplicationClosingHandler(object sender, FormClosingEventArgs e)
        {
            // Save on exit
            new CourseXMLBackend(this.course).SetPath(Properties.Resources.SAVE_FILE_PATH).Save();
        }
    }
}
