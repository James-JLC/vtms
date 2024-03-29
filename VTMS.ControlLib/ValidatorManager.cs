﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
namespace VTMS.ControlLib
{
    public class ValidatorManager : System.ComponentModel.Component
    {
        public static bool ValidateControls(Form form)
        {
            bool test = form.ValidateChildren(ValidationConstraints.Enabled & ValidationConstraints.TabStop & ValidationConstraints.Selectable);
            foreach (Control control in form.Controls)
            {
                if (control.GetType() == typeof(TextBoxExt))
                {
                    TextBoxExt textBox = control as TextBoxExt;
                    if (!textBox.Invalid())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //private static Hashtable validateControl = new Hashtable();

        //public static void registControl(string controlName, ErrorProvider errorProvider)
        //{
        //    if (validateControl[controlName] == null)
        //        validateControl.Add(controlName, errorProvider);
        //}
        //public static void degistControls()
        //{
        //    foreach(DictionaryEntry de in validateControl)
        //    {
        //        ErrorProvider errorProvider = (ErrorProvider)de.Value;
        //        errorProvider.Clear();
        //        validateControl.Remove(errorProvider);
        //    }
        //}
        //public static void degistControl(string controlName)
        //{
        //    ErrorProvider errorProvider = (ErrorProvider)validateControl[controlName];
        //    if (errorProvider == null)
        //        return;
        //    errorProvider.Clear();
        //    validateControl.Remove(controlName);
        //}
        //public static Hashtable ValidateControl
        //{
        //    get
        //    {
        //        return validateControl;
        //    }
        //}
    }
}
