using System;
using System.Windows.Forms;

using GradePredictor.CourseCore;
using GradePredictor.CourseUtil;
using GradePredictor.Util;


/// <copyright file="SingleModuleController.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.GUI
{
    class SingleModuleController
    {
        private Form parent;
        private SingleModuleView view;
        private SingleAssessmentController assessmentWindow;
        private Module module;

        public Module Module
        {
            get { return this.module; }
            set {
                if (this.module != null) { this.module.Change -= this.moduleChangedHandler; }
                this.module = value;
                this.module.Change += this.moduleChangedHandler;
            }
        }


        public SingleModuleController(Form parent)
        {
            this.parent = parent;
            this.view = new SingleModuleView(this.addAssessmentHandler);
            this.assessmentWindow = new SingleAssessmentController();
            this.module = null;

            this.view.ModuleDataUpdated += this.moduleDataUpdatedHandler;
        }


        public void addAssessmentHandler(object sender, EventArgs e)
        {
            this.module.AddAssessment();
            this.view.Invoke((MethodInvoker)delegate
            {
                this.view.createAssessment(this.openAssessmentHandler, this.removeAssessmentHandler, this.module.Assessments[this.module.Assessments.Count - 1]);
            });
        }


        public void populate()
        {
            this.view.Invoke((MethodInvoker)delegate
            {
                this.view.BeginLoading();
                this.view.reset();
                this.view.ModuleName = this.module.Title;
                this.view.ModuleCode = this.module.Code;
                this.view.ModuleCredits = this.module.Credits;
                this.view.ModuleResult = this.module.Result;
            });

            ConcurrentWorkQueue.Enqueue(() =>
            {
                foreach (var assessment in this.module.Assessments)
                {
                    this.view.Invoke((MethodInvoker)delegate
                    {
                        Application.DoEvents();
                        this.view.createAssessment(this.openAssessmentHandler, this.removeAssessmentHandler, assessment);
                    });
                }

                this.view.Invoke((MethodInvoker)delegate { this.view.EndLoading(); });
            });
        }

        public void show()
        {
            this.view.ShowDialog();
        }

        public void populateAndShow()
        {
            // HACK: Terrible? way to create handle on UI thread while not blocking the caller.
            // Invoke() doesn't work without calling ShowDialog(), but ShowDialog() blocks the caller.
            this.parent.BeginInvoke((MethodInvoker)delegate { this.show(); });
            this.parent.BeginInvoke((MethodInvoker)delegate { this.populate(); });
        }


        public void openAssessmentHandler(object sender, EventArgs e)
        {
            AssessmentControl a;
            if (sender is AssessmentControl){
                a = (AssessmentControl)sender;
            } else if (((Control)sender).Parent is AssessmentControl){
                a = (AssessmentControl)((Control)sender).Parent;
            } else{
                a = (AssessmentControl)((Control)sender).Parent.Parent;
            }
            this.assessmentWindow.Assessment = a.Assessment;
            this.assessmentWindow.populateAndShow();
        }

        public void removeAssessmentHandler(object sender, EventArgs e)
        {
            this.module.RemoveAssessment(((AssessmentControl)((Button)sender).Parent).Assessment);
            this.view.Invoke((MethodInvoker)delegate { this.view.removeAssessment((AssessmentControl)((Button)sender).Parent); });
        }

        public void moduleChangedHandler(CourseObjectBase sender, bool triggerRecalc)
        {
            if (!(sender is Module)) { throw new InvalidCourseObjectException(); }
            Module m = (Module)sender;
            this.view.Invoke((MethodInvoker)delegate
            {
                this.view.ModuleName = m.Title;
                this.view.ModuleCode = m.Code;
                this.view.ModuleCredits = m.Credits;
                this.view.ModuleResult = m.Result;
            });
        }

        public void moduleDataUpdatedHandler()
        {
            this.module.EditModule(
                this.view.ModuleName,
                this.view.ModuleCode,
                this.view.ModuleCredits
            );
        }
    }
}
