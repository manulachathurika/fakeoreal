//----------------------------------------------------------------------------------------
// patterns & practices - Smart Client Software Factory - Guidance Package
//
// This file was generated by the "Add Business Module" recipe.
//
// This class contains placeholder methods for the common module initialization 
// tasks, such as adding services, or user-interface element
//
// For more information see: 
// ms-help://MS.VSCC.v90/MS.VSIPCC.v90/ms.practices.scsf.2008apr/SCSF/html/02-08-060-Add_Business_Module_Next_Steps.htm
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using FakeOReal.Infrastructure.Interface;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Commands;
using FakeOReal.ImageAnalysis.Interface.Constants;
using FakeOReal.ImageAnalysis.Interface;
using Microsoft.Practices.CompositeUI.EventBroker;
using System.Drawing;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV;
using AForge.Imaging.Filters;
using AForge.Imaging;

namespace FakeOReal.ImageAnalysis
{
    public class ModuleController : WorkItemController
    {
        private static System.Drawing.Image image;
        private static string path;      
        private static GetParam pa;
        private static ImageAView mov;
        public override void Run()
        {
            AddServices();
            ExtendMenu();
            ExtendToolStrip();
            AddViews();
        }

        private void AddServices()
        {
            //TODO: add services provided by the Module. See: Add or AddNew method in 
            //		WorkItem.Services collection or see ms-help://MS.VSCC.v90/MS.VSIPCC.v90/ms.practices.2005Nov.cab/CAB/html/03-020-Adding%20Services.htm
        }

        private void ExtendMenu()
        {
            //TODO: add menu items here, normally by calling the "Add" method on
            //		on the WorkItem.UIExtensionSites collection. For an example 
            //		See: ms-help://MS.VSCC.v90/MS.VSIPCC.v90/ms.practices.scsf.2008apr/SCSF/html/02-04-340-Showing_UIElements.htm
            UIExtensionSite MainMenuSite =
         this.WorkItem.UIExtensionSites[UIExtensionSiteNames.MainMenu];
            ToolStripMenuItem TopTi = new ToolStripMenuItem("Analysis");
            ToolStripMenuItem ti1 = new ToolStripMenuItem("Edge Detection");            
            ToolStripMenuItem ti2 = new ToolStripMenuItem("Histogram");
            ToolStripMenuItem ti3 = new ToolStripMenuItem("Fourier Transformation");
            
            ToolStripMenuItem ti1_1 = new ToolStripMenuItem("Canny");
            ToolStripMenuItem ti1_2 = new ToolStripMenuItem("Sobel");
            ToolStripMenuItem ti1_3 = new ToolStripMenuItem("Difference");
            ToolStripMenuItem ti1_4 = new ToolStripMenuItem("Homogenity");
            ToolStripMenuItem ti1_5 = new ToolStripMenuItem("Edges");
           
            ti1.DropDownItems.Add(ti1_1);
            ti1.DropDownItems.Add(ti1_2);
            ti1.DropDownItems.Add(ti1_3);
            ti1.DropDownItems.Add(ti1_4);
            ti1.DropDownItems.Add(ti1_5);

            TopTi.DropDownItems.Add(ti1);
            TopTi.DropDownItems.Add(ti2);
            TopTi.DropDownItems.Add(ti3);            

            MainMenuSite.Add(TopTi);
            this.WorkItem.Commands[CommandNames.edge_canny].
        AddInvoker(ti1_1, "Click");
            this.WorkItem.Commands[CommandNames.edge_sobel].
        AddInvoker(ti1_2, "Click");
            this.WorkItem.Commands[CommandNames.edge_difference].
        AddInvoker(ti1_3, "Click");
            this.WorkItem.Commands[CommandNames.edge_homogenity].
        AddInvoker(ti1_4, "Click");
            this.WorkItem.Commands[CommandNames.edges].
        AddInvoker(ti1_5, "Click");
            this.WorkItem.Commands[CommandNames.histogram].
        AddInvoker(ti2, "Click");
            this.WorkItem.Commands[CommandNames.fourier].
        AddInvoker(ti3, "Click");           
        }

        private void ExtendToolStrip()
        {
            //TODO: add new items to the ToolStrip in the Shell. See the UIExtensionSites collection in the WorkItem. 
            //		See: ms-help://MS.VSCC.v90/MS.VSIPCC.v90/ms.practices.scsf.2008apr/SCSF/html/02-04-340-Showing_UIElements.htm
        }

        private void AddViews()
        {
            //TODO: create the Module views, add them to the WorkItem and show them in 
            //		a Workspace. See: ms-help://MS.VSCC.v90/MS.VSIPCC.v90/ms.practices.scsf.2008apr/SCSF/html/03-01-040-How_to_Add_a_View_with_a_Presenter.htm

            // To create and add a view you can customize the following sentence
            // SampleView view = ShowViewInWorkspace<SampleView>(WorkspaceNames.SampleWorkspace);
                  
           // ImageView view = ShowViewInWorkspace<ImageView>(WorkspaceNames.TabWorkspace);

        }

        [CommandHandler(CommandNames.edge_canny)]
        public void CannyClickHandler(object sender, EventArgs e)
        {
            if(image!=null){              
                pa = new GetParam(this);               
                pa.trackBar1.Minimum = 10;
                pa.trackBar1.Maximum = 30;
                pa.trackBar1.TickFrequency = 2;
                pa.trackBar2.Minimum = 0;
                pa.trackBar2.Maximum = 255;
                pa.trackBar2.TickFrequency = 20;
                pa.trackBar3.Minimum = 0;
                pa.trackBar3.Maximum = 255;
                pa.trackBar3.TickFrequency = 20;               
                pa.Show();                 
            }
        }

        [CommandHandler(CommandNames.edge_sobel)]
        public void SobelClickHandler(object sender, EventArgs e)
        {
            if (image != null)
            {
                Bitmap imx = new Bitmap(path);
                imx = Grayscale.CommonAlgorithms.Y.Apply(imx);
                SobelEdgeDetector gb = new SobelEdgeDetector();
                imx = gb.Apply(imx);
                if (mov != null) { 
                    this.WorkItem.Workspaces[WorkspaceNames.TabWorkspace].Close(mov);
                }
                mov = this.WorkItem.SmartParts.AddNew<ImageAView>();
                mov.panAndZoomPictureBox1.Image = imx;
                SmartPartInfo spi =
                     new SmartPartInfo("Sobel", "MyOwnDescription");
                this.WorkItem.Workspaces[WorkspaceNames.TabWorkspace].Show(mov, spi);
            }
        }

        [CommandHandler(CommandNames.edge_homogenity)]
        public void HomogenityClickHandler(object sender, EventArgs e)
        {
            if (image != null)
            {
                Bitmap imx = new Bitmap(path);
                imx = Grayscale.CommonAlgorithms.Y.Apply(imx);
                HomogenityEdgeDetector gb = new HomogenityEdgeDetector();
                imx = gb.Apply(imx);
                if (mov != null)
                {
                    this.WorkItem.Workspaces[WorkspaceNames.TabWorkspace].Close(mov);
                }
                mov = this.WorkItem.SmartParts.AddNew<ImageAView>();
                mov.panAndZoomPictureBox1.Image = imx;
                SmartPartInfo spi =
                     new SmartPartInfo("Homogenity", "MyOwnDescription");
                this.WorkItem.Workspaces[WorkspaceNames.TabWorkspace].Show(mov, spi);
            }
        }

        [CommandHandler(CommandNames.edge_difference)]
        public void DifferenceClickHandler(object sender, EventArgs e)
        {
            if (image != null)
            {
                Bitmap imx = new Bitmap(path);               
                imx = Grayscale.CommonAlgorithms.Y.Apply(imx);
                DifferenceEdgeDetector gb = new DifferenceEdgeDetector();
                imx = gb.Apply(imx);
                if (mov != null)
                {
                    this.WorkItem.Workspaces[WorkspaceNames.TabWorkspace].Close(mov);
                }
                mov = this.WorkItem.SmartParts.AddNew<ImageAView>();
                mov.panAndZoomPictureBox1.Image = imx;
                SmartPartInfo spi =
                     new SmartPartInfo("Difference", "MyOwnDescription");
                this.WorkItem.Workspaces[WorkspaceNames.TabWorkspace].Show(mov, spi);
            }
        }

        [CommandHandler(CommandNames.edges)]
        public void EdgesClickHandler(object sender, EventArgs e)
        {
            if (image != null)
            {
                Bitmap imx = new Bitmap(path);
                Edges gb = new Edges();
                imx = gb.Apply(imx);
                if (mov != null)
                {
                    this.WorkItem.Workspaces[WorkspaceNames.TabWorkspace].Close(mov);
                }
                mov = this.WorkItem.SmartParts.AddNew<ImageAView>();
                mov.panAndZoomPictureBox1.Image = imx;
                SmartPartInfo spi =
                     new SmartPartInfo("Edges", "MyOwnDescription");
                this.WorkItem.Workspaces[WorkspaceNames.TabWorkspace].Show(mov, spi);
            }
        }

        [CommandHandler(CommandNames.histogram)]
        public void HistogramClickHandler(object sender, EventArgs e)
        {
            if (image != null)
            {               
                HistogramWindow hw = new HistogramWindow(path);
                hw.Show();
            }
        }

        [CommandHandler(CommandNames.fourier)]
        public void FourierClickHandler(object sender, EventArgs e)
        {
            if (image != null)
            {
                try
                {
                    Bitmap imx = new Bitmap(path);
                    // create complex image
                    ComplexImage complexImage = ComplexImage.FromBitmap(imx);
                    // do forward Fourier transformation
                    complexImage.ForwardFourierTransform();
                    mov = this.WorkItem.SmartParts.AddNew<ImageAView>();
                    // get complex image as bitmap   
                    mov.panAndZoomPictureBox1.Image = complexImage.ToBitmap();
                    SmartPartInfo spi =
                         new SmartPartInfo("Fourier", "MyOwnDescription");
                    this.WorkItem.Workspaces[WorkspaceNames.TabWorkspace].Show(mov, spi);
                }
                catch {
                   MessageBox.Show("Height and width of images should be power of 2.");
                }
            }
        }       

        [EventSubscription(EventTopicNames.LoadImage, ThreadOption.UserInterface)]
        public void OnLoadImage(object sender, OnImageLoad eventArgs)
        {//TODO: Add your code here
            image = eventArgs.img;
            path = eventArgs.file;
        }

        public void doCanny(int low, int high, int sigma)
        {
            Bitmap imx = new Bitmap(path);            
                imx = Grayscale.CommonAlgorithms.Y.Apply(imx);
                CannyEdgeDetector gb = new CannyEdgeDetector(((byte)low), ((byte)high), (sigma / 10));
                imx = gb.Apply(imx);
                if (mov != null)
                {
                    this.WorkItem.Workspaces[WorkspaceNames.TabWorkspace].Close(mov);
                }
                mov = this.WorkItem.SmartParts.AddNew<ImageAView>();
                mov.panAndZoomPictureBox1.Image = imx;
                SmartPartInfo spi =
                     new SmartPartInfo("Canny", "MyOwnDescription");
                this.WorkItem.Workspaces[WorkspaceNames.TabWorkspace].Show(mov, spi);           
        }

    }
}