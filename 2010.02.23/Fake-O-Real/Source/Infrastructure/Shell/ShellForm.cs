//----------------------------------------------------------------------------------------
// patterns & practices - Smart Client Software Factory - Guidance Package
//
// This file was generated by this guidance package as part of the solution template
//
// The FormShell class represent the main form of your application.
// 
// For more information see: 
// ms-help://MS.VSCC.v90/MS.VSIPCC.v90/ms.practices.scsf.2008apr/SCSF/html/03-01-010-How_to_Create_Smart_Client_Solutions.htm
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

using System.Windows.Forms;
using FakeOReal.Infrastructure.Interface.Constants;

namespace FakeOReal.Infrastructure.Shell
{
    /// <summary>
    /// Main application shell view.
    /// </summary>
    public partial class ShellForm : Form
    {
        /// <summary>
        /// Default class initializer.
        /// </summary>
        public ShellForm()
        {
            InitializeComponent();

            _layoutWorkspace.Name = WorkspaceNames.LayoutWorkspace;
        }

    }
}
