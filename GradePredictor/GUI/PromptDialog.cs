using System;
using System.ComponentModel;
using System.Windows.Forms;


/// <copyright file="PromptDialog.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.GUI
{
    public partial class PromptDialog<T> : Form
    {
        public PromptDialog()
        {
            InitializeComponent();
        }

        public PromptDialog<T> SetCaption(string c)
        {
            this.Text = c;
            return this;
        }

        public PromptDialog<T> SetText(string c)
        {
            this.label1.Text = c;
            return this;
        }


        public T Prompt()
        {
            return this.Prompt((x) => true);
        }

        /// <summary>
        /// Prompts the user for a value, validating its type against the generic and the supplied validator function.
        /// </summary>
        /// <param name="validator">Function taking an argument of type T, returning bool.</param>
        /// <returns></returns>
        public T Prompt(Func<T, bool> validator)
        {
            while (true)
            {
                this.ShowDialog();

                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter.IsValid(this.tbInput.Text))
                {
                    try
                    {
                        T value = (T)converter.ConvertFrom(this.tbInput.Text);
                        if (validator(value)) {
                            return value;
                        }
                    }
                    catch (Exception) { }
                }

                MessageBox.Show("The input is invalid", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
