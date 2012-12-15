﻿namespace SpreadSharp

open Microsoft.Office.Interop.Excel

module XApp =

    /// <summary>Returns the stack collection used to hold the COM objects created by the application.
    /// This is the mechanism used to abstract away proper COM cleanup.</summary>
    /// <returns>The stack collection.</returns>
    let comStack = COM.comStack

    /// <summary>Closes Excel and releases the created COM objects.</summary>
    /// <param name="appClass">The Excel ApplicationClass.</param>
    let quit (appClass : ApplicationClass) =
        appClass.Quit ()
        Utilities.releaseComObjects ()
        Utilities.collectGarbage ()

    /// <summary>Starts Excel in hidden or visible mode.</summary>
    /// <param name="visible">The visiblity setting.</param>
    /// <returns>The created Excel ApplicationClass instance.</returns>
    let start visible =
        let appClass = ApplicationClass(Visible = visible)
        COM.pushComObj appClass