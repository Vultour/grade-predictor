using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;


/// <copyright file="ControlExtensions.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.Util
{
    public static class ControlExtensions
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern string SendMessage(IntPtr hWnd, int msg, Int32 wParam, Int32 lParam);
        public const int WM_SETREDRAW = 0x000B;

        public static void Center(this Control c, Control parent, int offsetX, int offsetY){
            c.Location = new Point(
                (parent.Width / 2) - (c.Width / 2) + offsetX,
                (parent.Height / 2) + (c.Height / 2) + offsetY
            );
        }

        public static void Center(this Control c) { c.Center(c.Parent, 0, 0); }
        public static void Center(this Control c, Control parent) { c.Center(parent, 0, 0); }
        public static void Center(this Control c, int offsetX, int offsetY) { c.Center(c.Parent, offsetX, offsetY); }

        public static void SuspendRedraw(this Control c) { SendMessage(c.Handle, ControlExtensions.WM_SETREDRAW, 0, 0); }

        public static void ResumeRedraw(this Control c) {
            SendMessage(c.Handle, ControlExtensions.WM_SETREDRAW, 1, 0);
            c.Refresh();
        }

        public static void PerformWhileSuspended(this Control c, Action a)
        {
            SendMessage(c.Handle, ControlExtensions.WM_SETREDRAW, 0, 0);
            a();
            SendMessage(c.Handle, ControlExtensions.WM_SETREDRAW, 1, 0);
            c.Refresh();
        }
    }
}
