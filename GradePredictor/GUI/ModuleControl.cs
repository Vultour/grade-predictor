using System.Drawing;
using System.Windows.Forms;

using GradePredictor.CourseCore;
using GradePredictor.CourseUtil;


/// <copyright file="ModuleControl.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.GUI
{
    public partial class ModuleControl : UserControl
    {
        private Module module;

        public Module Module { get { return this.module; } }
        public string Title { set { this.lblModuleName.Text = value; } }
        public string Code
        {
            set
            {
                this.lblModuleCode.Text = "[" + value.ToUpper() + "]";
                this.resetCreditLabelPosition();
            }
        }
        public int Credits
        {
            set
            {
                this.lblModuleCredits.ForeColor = ((value > 0) ? (Color.Black) : (Color.Red));
                this.lblModuleCredits.Text = ((value > 0) ? (value.ToString()) : ("No credits"));
                this.resetCreditLabelPosition();
            }
        }
        public double Result
        {
            set
            {
                if ((value >= 0) && (value <= 100))
                {
                    this.lblResultPercentage.Text = value.ToString("f1") + "%";
                    if (value >= 40)
                    {
                        this.lblResultText.ForeColor = CourseColor.GetColor(value);
                        this.lblResultText.Text = "PASS";
                    }
                    else if (value >= 30)
                    {
                        this.lblResultText.ForeColor = CourseColor.Retake;
                        this.lblResultText.Text = "REF";
                    }
                    else
                    {
                        this.lblResultText.ForeColor = CourseColor.Fail;
                        this.lblResultText.Text = "FAIL";
                    }
                }
                else
                {
                    this.lblResultPercentage.Text = "N/A";
                    this.lblResultText.ForeColor = CourseColor.Unknown;
                    this.lblResultText.Text = "N/A";
                }
            }
        }

        public ModuleControl(Module m)
        {
            InitializeComponent();

            this.module = m;
            this.module.Change += this.moduleChangedHandler;

            this.Title = m.Title;
            this.Code = m.Code;
            this.Credits = m.Credits;
            this.Result = m.Result;
        }


        private void resetCreditLabelPosition()
        {
            this.lblModuleCredits.Location = new Point(
                (this.lblModuleCode.Location.X + this.lblModuleCode.Width),
                this.lblModuleCredits.Location.Y
            );
        }


        public void hookFaceClick(System.EventHandler handler)
        {
            this.Click += handler;
            this.lblModuleName.Click += handler;
            this.lblModuleCode.Click += handler;
            this.lblResultPercentage.Click += handler;
            this.lblResultText.Click += handler;
        }

        public void hookRemoveClick(System.EventHandler handler)
        {
            this.btnRemove.Click += handler;
        }


        public void moduleChangedHandler(CourseObjectBase sender, bool triggerRecalc)
        {
            if (!(sender is Module)) { throw new InvalidCourseObjectException(); }
            Module m = (Module)sender;
            this.Invoke((MethodInvoker)delegate
            {
                this.Title = m.Title;
                this.Code = m.Code;
                this.Result = m.Result;
                this.Credits = m.Credits;
            });
        }
    }
}
