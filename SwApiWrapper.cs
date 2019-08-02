﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.IO.MemoryMappedFiles;
using System.Drawing;

using SolidWorks.Interop.swconst;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swdocumentmgr;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace SwApiWrapper
{

    public class SwApiWrapper
    {
        private SldWorks swApp;
        private ModelDoc2 swMainModel;
        private DrawingDoc swDrawDoc;

        private SwModelWrapper swModelWrap;
        public SwModelWrapper MainModel
        {
            get
            {
                return swModelWrap;
            }
        }

        public SwApiWrapper()
        {
            string attachMessage = SwAttach();
            if (attachMessage != null)
                throw new Exception(attachMessage);
            string loadMessage = LoadActiveModel();
            if (loadMessage != null)
                throw new Exception(loadMessage);
        }

        private string SwAttach()
        {

            string strMessage;
            //bool blnStatus = true;

            //Check for the status of existing solidworks apps
            if (System.Diagnostics.Process.GetProcessesByName("sldworks").Length < 1)
            {
                strMessage = "Solidworks instance not detected.";
                //blnStatus = false;
            }
            else if (System.Diagnostics.Process.GetProcessesByName("sldworks").Length > 1)
            {
                strMessage = "Multiple instances of Solidworks detected.";
                //blnStatus = false;
            }
            else
            {
                strMessage = null;
                //swApp = System.Diagnostics.Process.GetProcessesByName("SldWorks.Application");
                swApp = (SldWorks)System.Runtime.InteropServices.Marshal.GetActiveObject("SldWorks.Application");
                //swApp = (SolidWorks.Interop.sldworks.Application)
            }

            SwDMClassFactory swClassFact;
            swClassFact = new SwDMClassFactory();

            return strMessage;

        }

        private string LoadActiveModel()
        {
            /// <summary>Load active model
            /// <list type="bullet">
            ///   <listheader>
            ///     <description>Set model properties</description>
            ///   </listheader>
            ///   <item>Model file name with path</item>
            ///   <item>Model file name</item>
            ///   <item>Referenced configuration</item>
            /// </list>
            /// <returns>Error message string</returns>
            /// </summary>

            ModelDoc2 swDoc;
            SolidWorks.Interop.sldworks.View swDrawView;
            swDocumentTypes_e swDocType;

            string strModelFile;
            string strModelName;
            string strConfigName = null;

            int intErrors = 0;
            int intWarnings = 0;

            // get the active document
            swDoc = (ModelDoc2)this.swApp.ActiveDoc;
            if (swDoc == null)
            {
                return "Could not acquire an active document";
            }

            // Check for the correct doc type
            strModelFile = swDoc.GetPathName();
            strModelName = strModelFile.Substring(strModelFile.LastIndexOf("\\") + 1, strModelFile.Length - strModelFile.LastIndexOf("\\") - 1);
            swDocType = (swDocumentTypes_e)swDoc.GetType();

            // get model document from drawing document
            if (swDocType == swDocumentTypes_e.swDocDRAWING)
            {

                swDrawDoc = (DrawingDoc)swDoc;
                swDrawView = (SolidWorks.Interop.sldworks.View)swDrawDoc.GetFirstView();
                swDrawView = (SolidWorks.Interop.sldworks.View)swDrawView.GetNextView();

                strModelFile = swDrawView.GetReferencedModelName();
                strConfigName = swDrawView.ReferencedConfiguration;
                strModelName = strModelFile.Substring(strModelFile.LastIndexOf("\\") + 1, strModelFile.Length - strModelFile.LastIndexOf("\\") - 1);
                swDocType = (swDocumentTypes_e)GetTypeFromString(strModelFile);

                if (swDocType != swDocumentTypes_e.swDocASSEMBLY & swDocType != swDocumentTypes_e.swDocPART)
                {
                    return "error getting file type from drawing view's referenced model";
                }

                // Try to load the model file
                try
                {
                    swMainModel = swApp.OpenDoc6(strModelFile, (int)swDocType, (int)swOpenDocOptions_e.swOpenDocOptions_LoadModel, strConfigName, ref intErrors, ref intWarnings);
                    swMainModel = swApp.ActivateDoc3(strModelFile, true, (int)swRebuildOnActivation_e.swDontRebuildActiveDoc, intErrors);
                }
                catch (Exception e)
                {
                    return e.Message;
                }

            }
            else
            {
                swMainModel = swDoc;
            }

            swModelWrap = new SwModelWrapper(swApp, swDocType, swMainModel, strConfigName: null);

            return null;

        }

        private SwDmDocumentType GetTypeFromString(string ModelPathName)
        {

            // ModelPathName = fully qualified name of file
            SwDmDocumentType nDocType = 0;

            // Determine type of SOLIDWORKS file based on file extension
            if (ModelPathName.ToLower().EndsWith("sldprt"))
            {
                nDocType = SwDmDocumentType.swDmDocumentPart;
            }
            else if (ModelPathName.ToLower().EndsWith("sldasm"))
            {
                nDocType = SwDmDocumentType.swDmDocumentAssembly;
            }
            else if (ModelPathName.ToLower().EndsWith("slddrw"))
            {
                nDocType = SwDmDocumentType.swDmDocumentDrawing;
            }
            else
            {
                // Not a SOLIDWORKS file
                nDocType = SwDmDocumentType.swDmDocumentUnknown;
            }

            return nDocType;

        }

    }


    public class SwModelWrapper
    {
        private SldWorks swApp;
        private ModelDoc2 swMainModel;
        private Configuration swMainConfig;
        private ModelDocExtension swModelDocExt;
        private AssemblyDoc swMainAssembly;

        #region Class Properties

        // model name with path
        private string pathName;
        public string PathName
        {
            get
            {
                return pathName;
            }
        }

        // model name
        private string modelName;
        public string ModelName
        {
            get
            {
                return modelName;
            }
        }

        private List<string> configNames = new List<string>();
        public List<string> ConfigNames
        {
            get
            {
                return configNames;
            }
        }

        // referenced configuration name
        private string configName;
        public string ConfigName
        {
            get
            {
                return configName;
            }
            set
            {
                SetConfigName(value);
            }
        }

        public int LiteCompCount
        {
            get
            {
                if (swMainAssembly != null)
                    return swMainAssembly.GetLightWeightComponentCount();
                else
                    return 0;
            }
        }

        public bool ShowChildComponentsInBOM
        {
            get
            {
                return swMainConfig.ShowChildComponentsInBOM;
            }
        }

        #endregion

        #region Initialization

        public SwModelWrapper(SldWorks swApp, swDocumentTypes_e swDocType, ModelDoc2 swMainModel, string strConfigName)
        {
            this.swApp = swApp;
            this.swMainModel = swMainModel;

            swModelDocExt = (ModelDocExtension)swMainModel.Extension;

            if (swDocType == swDocumentTypes_e.swDocASSEMBLY)
                swMainAssembly = (AssemblyDoc)swMainModel;

            if (strConfigName != null)
                this.swMainConfig = (Configuration)swMainModel.GetConfigurationByName(strConfigName);
            else
                this.swMainConfig = (Configuration)swMainModel.GetActiveConfiguration();
                strConfigName = this.swMainConfig.Name;


            // Write model info to shared variables
            string[] configsArray = swMainModel.GetConfigurationNames();
            this.configNames.AddRange(configsArray);
            this.configNames.Sort();
            this.pathName = swMainModel.GetPathName();
            this.modelName = swMainModel.GetTitle();
            this.configName = strConfigName;
        }

        private void SetConfigName(string configName)
        {
            if (configName == this.configName || configName == "")
                return;
            if (!configNames.Contains(configName))
            {
                string strExcept = String.Format("Config name {0} is not in this model", configName);
                throw new Exception(strExcept);
            }
            swMainConfig = (Configuration)swMainModel.GetConfigurationByName(configName);
            this.configName = configName;
        }
        #endregion

        #region Custom Properties
        public SwCustProp GetCustProp(string configName, bool withImage = false, bool merge = false)
        {
            if (configName == "")
                return GetCustProp(withImage: withImage, fileLevel: true, merge: merge);
            SetConfigName(configName);
            return GetCustProp(withImage: withImage, merge: merge);
        }

        public SwCustProp GetCustProp(bool withImage = false, bool fileLevel = false, bool merge = false)
        {
            // Get property manager for this config
            CustomPropertyManager swCustPropMgr = (CustomPropertyManager)swModelDocExt.get_CustomPropertyManager(configName);

            // Get property manager for file-system-level (name of standard config = "")
            CustomPropertyManager swAltCustPropMgr = (CustomPropertyManager)swModelDocExt.get_CustomPropertyManager("");

            // Init a custom property container
            SwCustProp prop = new SwCustProp();
            prop.PropertyValues["filename"] = pathName;
            prop.PropertyValues["configname"] = configName;
            prop.PropertyValues["PlaceHoldFlag"] = 0;
            prop.PropertyValues["ShowChildren"] = swMainConfig.ShowChildComponentsInBOM ? 1 : 0;

            // Get SolidWorks custom properties
            string strVal;
            string strResolved;
            foreach (string strPropName in prop.PropNames)
            {
                if (fileLevel)
                    swAltCustPropMgr.Get4(strPropName, false, out strVal, out strResolved);
                else
                    swCustPropMgr.Get4(strPropName, false, out strVal, out strResolved);
                strResolved = strResolved.Trim();
                if (merge && (strResolved == null || strResolved == ""))
                {
                    swAltCustPropMgr.Get4(strPropName, false, out strVal, out strResolved);
                    strResolved = strResolved.Trim();
                }
                prop.PropertyValues[strPropName] = strResolved;
            }

            // Get model image
            // swIsometricView = 7
            if (withImage)
                prop.PropertyValues["Image"] = SwCustProp.ImageToByteArray(GetIsometricImage());

            return prop;

        }

        public List<SwCustProp> GetConfigsCustProps()
        {
            List<SwCustProp> props = new List<SwCustProp>();

            // Get file level custom properties
            props.Add(GetCustProp(fileLevel: true));

            // Get configuration custom properties
            foreach (string configName in this.configNames)
            {
                props.Add(GetCustProp(configName: configName));
            }
            return props;
        }

        public string GetProductCode()
        {
            // Get and merge the current configuration and the file system level custom properties
            SwCustProp configProp = GetCustProp(merge: true);
            string partNum = (string)configProp.PropertyValues["PartNum"];
            string revision = (string)configProp.PropertyValues["Revision"];
            if (partNum == null || partNum == "")
                return null;
            if (revision == null || revision == "")
                revision = "-0";
            return partNum + "." + revision;
        }

        public void WriteCustProp(SwCustProp props, string thisConfigName)
        {
            CustomPropertyManager swCustPropMgr = (CustomPropertyManager)swModelDocExt.get_CustomPropertyManager(thisConfigName);

            // We always store custom properties as text (i.e. swCustomInfoType_e.swCustomInfoText)
            foreach (string propName in props.PropNames)
                swCustPropMgr.Add3(
                    propName,
                    (int)swCustomInfoType_e.swCustomInfoText,
                    props.PropertyValues[propName].ToString(),
                    (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);

            swMainModel.SetSaveFlag();
        }

        #endregion

        #region Model Image

        private Bitmap GetViewImage(int width, int height, string namedView = null, int swStandardView = 0)
        {
            // Where swStandardView is one of the following:
            // swStandardViews_e.swIsometricView = 7
            // swStandardViews_e.swTrimetricView = 8
            // swStandardViews_e.swDimetricView = 9
            // current view = 0
            // named view = -1

            ModelView swModelView = this.swMainModel.ActiveView;
            int errors = 0;
            if (swModelView == null)
                swApp.ActivateDoc3(modelName, false, (int)swRebuildOnActivation_e.swRebuildActiveDoc, ref errors);
                swModelView = this.swMainModel.ActiveView;
            swModelView.FrameState = (int)swWindowState_e.swWindowMaximized;

            // get current user settings
            bool prefViewDisplayHideAllTypes = swMainModel.GetUserPreferenceToggle((int)swUserPreferenceToggle_e.swViewDisplayHideAllTypes);

            // change settings for image extraction
            swMainModel.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swViewDisplayHideAllTypes, true);
            swMainModel.Extension.InsertScene("\\scenes\\01 basic scenes\\11 white kitchen.p2s");
            swModelView.DisplayMode = (int)swViewDisplayMode_e.swViewDisplayMode_HiddenLinesRemoved;
            if (namedView != null | swStandardView != 0)
            {
                // see enumeration swStandardViews_e
                swMainModel.ShowNamedView2(namedView, swStandardView);
            }
            swMainModel.ViewZoomtofit2();

            // extract the image
            string tmpFilePathName = Path.GetTempFileName();
            swMainModel.SaveBMP(tmpFilePathName, width, height);
            Bitmap bmp = (Bitmap)FromFile(tmpFilePathName);
            File.Delete(tmpFilePathName);

            // apply original user settings
            swMainModel.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swViewDisplayHideAllTypes, prefViewDisplayHideAllTypes);
            swModelView.DisplayMode = (int)swViewDisplayMode_e.swViewDisplayMode_ShadedWithEdges;

            return bmp;
        }

        private static Image FromFile(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var ms = new MemoryStream(bytes);
            var img = Image.FromStream(ms);
            return img;
        }

        private static byte[][] GetRGB(Bitmap bmp)
        {

            BitmapData bmp_data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            IntPtr ptr = bmp_data.Scan0;
            int num_pixels = bmp.Width * bmp.Height;
            int num_bytes = bmp_data.Stride * bmp.Height;
            int padding = bmp_data.Stride - bmp.Width * 3;
            int i = 0;
            int ct = 1;

            byte[] r = new byte[num_pixels];
            byte[] g = new byte[num_pixels];
            byte[] b = new byte[num_pixels];
            byte[] rgb = new byte[num_bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgb, 0, num_bytes);

            for (int x = 0; x < num_bytes - 3; x += 3)
            {
                if (x == (bmp_data.Stride * ct - padding))
                {
                    x += padding; ct++;
                }
                r[i] = rgb[x];
                g[i] = rgb[x + 1];
                b[i] = rgb[x + 2];
                i++;
            }

            bmp.UnlockBits(bmp_data);
            return new byte[3][] { r, g, b };

        }

        private static Bitmap AutoCrop(Bitmap bmp)
        {

            //Get an array containing the R,G,B components of each pixel
            var pixels = GetRGB(bmp);

            int h = bmp.Height - 1;
            int w = bmp.Width;
            int top = 0;
            int bottom = h;
            int left = bmp.Width;
            int right = 0;
            int white = 0;
            int tolerance = 95; // 95%

            bool prev_color = false;
            for (int i = 0; i < pixels[0].Length; i++)
            {
                int x = (i % (w));
                int y = (int)(Math.Floor((decimal)(i / w)));
                int tol = 255 * tolerance / 100;

                if (pixels[0][i] >= tol && pixels[1][i] >= tol && pixels[2][i] >= tol)
                {
                    white++; right = (x > right && white == 1) ? x : right;
                }
                else
                {
                    left = (x < left && white >= 1) ? x : left;
                    right = (x == w - 1 && white == 0) ? w - 1 : right;
                    white = 0;
                }
                if (white == w)
                {
                    top = (y - top < 3) ? y : top;
                    bottom = (prev_color && x == w - 1 && y > top + 1) ? y : bottom;
                }
                left = (x == 0 && white == 0) ? 0 : left;
                bottom = (y == h && x == w - 1 && white != w && prev_color) ? h + 1 : bottom;
                if (x == w - 1)
                {
                    prev_color = (white < w) ? true : false; white = 0;
                }
            }
            right = (right == 0) ? w : right;
            left = (left == w) ? 0 : left;

            //Crop the image
            if (bottom - top > 1)
            {
                Bitmap bmpCrop = bmp.Clone(new Rectangle(left, top, right - left + 1, bottom - top), bmp.PixelFormat);

                return (Bitmap)(bmpCrop);
            }
            else
            {
                return bmp;
            }

        }

        private static Bitmap ResizeImage(Bitmap bmpOrig, int intWidth, int intHeight)
        {

            bmpOrig.Save("C:\\temp\\test_orig.png", System.Drawing.Imaging.ImageFormat.Png);
            Image sourceImage = (Image)AutoCrop(bmpOrig);
            sourceImage.Save("C:\\temp\\test_cropped.png", System.Drawing.Imaging.ImageFormat.Png);

            //return (Bitmap)sourceImage;

            System.Drawing.Size sizeOut = new System.Drawing.Size(intWidth, intHeight);
            int sourceWidth = sourceImage.Width;
            int sourceHeight = sourceImage.Height;

            // percent size change
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            nPercentW = ((float)sizeOut.Width / (float)sourceWidth);
            nPercentH = ((float)sizeOut.Height / (float)sourceHeight);

            // keeping aspect ratio
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;


            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            int leftOffset = (int)((sizeOut.Width - destWidth) / 2);
            int topOffset = (int)((sizeOut.Height - destHeight) / 2);

            var destRect = new Rectangle(leftOffset, topOffset, destWidth, destHeight);


            Bitmap destImage = new Bitmap(sizeOut.Width, sizeOut.Height);
            destImage.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);

            using (var graphics = Graphics.FromImage((Image)destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.Clear(Color.White);

                //graphics.DrawImage(sourceImage, destRect, -leftOffset, -topOffset, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel);
                graphics.DrawImage(sourceImage, destRect, 0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel);

                //using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                //{
                //    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                //    graphics.DrawImage(sourceImage, destRect, leftOffset, topOffset, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel, wrapMode);
                //}
            }
            destImage.Save("C:\\temp\\test_resized.png", System.Drawing.Imaging.ImageFormat.Png);

            return (Bitmap)destImage;

        }

        public Bitmap GetIsometricImage()
        {
            int imageWidth = AZI_SWCustomProperties.Properties.AppSettings.Default.ImageWidth;
            int imageHeight = AZI_SWCustomProperties.Properties.AppSettings.Default.ImageHeight;
            Bitmap bmp = GetViewImage(imageWidth*2, imageHeight*2, null, (int)swStandardViews_e.swIsometricView);
            Bitmap bmp2 = ResizeImage(bmp, imageWidth, imageHeight);
            return bmp2;
        }

        public Bitmap GetNamedImage(string namedView)
        {
            int imageWidth = AZI_SWCustomProperties.Properties.AppSettings.Default.ImageWidth;
            int imageHeight = AZI_SWCustomProperties.Properties.AppSettings.Default.ImageHeight;
            Bitmap bmp = GetViewImage(imageWidth * 2, imageHeight * 2, namedView, -1);
            Bitmap bmp2 = ResizeImage(bmp, imageWidth, imageHeight);
            return bmp2;
        }

        public Bitmap GetCurrentImage()
        {
            int imageWidth = AZI_SWCustomProperties.Properties.AppSettings.Default.ImageWidth;
            int imageHeight = AZI_SWCustomProperties.Properties.AppSettings.Default.ImageHeight;
            Bitmap bmp = GetViewImage(imageWidth * 2, imageHeight * 2, null, -1);
            Bitmap bmp2 = ResizeImage(bmp, imageWidth, imageHeight);
            return bmp2;
        }

        public Bitmap GetStandardImage(int viewNumber)
        {
            int imageWidth = AZI_SWCustomProperties.Properties.AppSettings.Default.ImageWidth;
            int imageHeight = AZI_SWCustomProperties.Properties.AppSettings.Default.ImageHeight;
            Bitmap bmp = GetViewImage(imageWidth * 2, imageHeight * 2, null, viewNumber);
            Bitmap bmp2 = ResizeImage(bmp, imageWidth, imageHeight);
            return bmp2;
        }

        #endregion

        public void ResolveAllComps()
        {
            swMainAssembly.ResolveAllLightWeightComponents(false);
        }

        public SwComponentWrapper GetRootComponentWrapper()
        {
            return new SwComponentWrapper(swApp, (Component2)swMainConfig.GetRootComponent());
        }
    }

    public class SwComponentWrapper
    {
        private SldWorks swApp;
        private Component2 swComp;
        public bool Suppressed
        {
            get
            {
                return (swComponentSuppressionState_e)swComp.GetSuppression() == swComponentSuppressionState_e.swComponentSuppressed;
            }
        }
        public bool ExcludeFromBOM
        {
            get
            {
                return swComp.ExcludeFromBOM;
            }
        }
        public string PathName
        {
            get
            {
                return swComp.GetPathName();
            }
        }
        public string FileName
        {
            get
            {
                string pathName = swComp.GetPathName();
                return pathName.Substring(
                    pathName.LastIndexOf("\\") + 1,
                    pathName.Length - pathName.LastIndexOf("\\") - 1);
            }
        }
        public string ConfigName
        {
            get
            {
                return swComp.ReferencedConfiguration;
            }
        }

        public SwComponentWrapper(SldWorks swApp, Component2 SwCompWrap)
        {
            this.swApp = swApp;
            this.swComp = SwCompWrap;
        }

        public SwModelWrapper GetModelWrapper()
        {
            ModelDoc2 swModel = swComp.GetModelDoc2();
            return new SwModelWrapper(swApp, (swDocumentTypes_e)swModel.GetType(), swModel, this.swComp.ReferencedConfiguration);
        }

        public SwModelWrapper GetModelWrapper(string configName)
        {
            ModelDoc2 swModel = swComp.GetModelDoc2();
            return new SwModelWrapper(swApp, (swDocumentTypes_e)swModel.GetType(), swModel, configName);
        }

        public List<SwComponentWrapper> GetComponents()
        {
            object oChildren = this.swComp.GetChildren();
            System.Array aChildren = (Array)oChildren;
            List<SwComponentWrapper> comps = new List<SwComponentWrapper>();
            foreach (Component2 comp in aChildren)
            {
                comps.Add(new SwComponentWrapper(swApp, comp));
            }
            return comps;
        }

    }

    public class SwCustProp
    {
        // Custom property types:
        // * Text
        // * Date
        // * Number
        // * Yes or No

        #region Custom Property Data Structure

        // ******************************************************************************
        // ***                                                                        ***
        // ***        The custom property for 'Units of Measure' was originally       ***
        // ***        named 'Alternate Quantity'.  When we added a property for       ***
        // ***        tracking alternate quantity values (double precision            ***
        // ***        numbers), we didn't want to go back and change the custom       ***
        // ***        properties in every part file.                                  ***
        // ***        As a work around:                                               ***
        // ***            -we labeled the 'Alternate Quantity' text field 'UOM'       ***
        // ***            -we are writing the units of measure to the                 ***
        // ***             'Alternate Quantity' custom property                       ***
        // ***            -we labeled the 'UOM' text field 'Alternate Quantity'       ***
        // ***            -we are writing the alternate quantity value to the         ***
        // ***             'UOM' custom property                                      ***
        // ***                                                                        ***
        // ******************************************************************************
        private readonly List<string> propNames = new List<string>(){
            "AltQty",
            "PartNum",
            "Description",
            "Designed By",
            "Date1",
            "Type",
            "UOM",
            "Eng Approval",
            "Eng Appr Date",
            "Mfg Approval",
            "Mfg Appr Date",
            "QA Approval",
            "QA Appr Date",
            "Purch Approval",
            "Purch Appr Date",
            "Material",
            "Finish",
            "Coating",
            "Notes",
            "Revision",
            "ECO",
            "EcoRevs",
            "Zone",
            "EcoDescription",
            "Date2",
            "EcoChk",
            "P_M",
            "MaterialPn",
            "RouteTemplate",
            "PurchFlag",
        };
        public List<string> PropNames
        {
            get
            {
                return propNames;
            }
        }

        private readonly List<string> fieldNames = new List<string>(){
            "Uom",
            "PartNum",
            "Description",
            "DesignedBy",
            "DrawDate",
            "Type",
            "AltQty",
            "EngApproval",
            "EngApprDate",
            "MfgApproval",
            "MfgApprDate",
            "QaApproval",
            "QaApprDate",
            "PurchApproval",
            "PurchApprDate",
            "Material",
            "Finish",
            "Coating",
            "Notes",
            "Revision",
            "Ecos",
            "EcoRevs",
            "Zone",
            "EcoDescriptions",
            "EcoDates",
            "EcoChks",
            "Catalog",
            "MaterialPn",
            "RouteTemplate",
            "PurchFlag",
        };
        public List<string> FieldNames
        {
            get
            {
                return fieldNames;
            }
        }

        private readonly Dictionary<string, int> propTypes = new Dictionary<string, int>(){
            { "AltQty", (int)swCustomInfoType_e.swCustomInfoText },
            { "PartNum", (int)swCustomInfoType_e.swCustomInfoText },
            { "Description", (int)swCustomInfoType_e.swCustomInfoText },
            { "Designed By", (int)swCustomInfoType_e.swCustomInfoText },
            { "Date1", (int)swCustomInfoType_e.swCustomInfoText },
            { "Type", (int)swCustomInfoType_e.swCustomInfoText },
            { "UOM", (int)swCustomInfoType_e.swCustomInfoText },
            { "Eng Approval", (int)swCustomInfoType_e.swCustomInfoText },
            { "Eng Appr Date", (int)swCustomInfoType_e.swCustomInfoText },
            { "Mfg Approval", (int)swCustomInfoType_e.swCustomInfoText },
            { "Mfg Appr Date", (int)swCustomInfoType_e.swCustomInfoText },
            { "QA Approval", (int)swCustomInfoType_e.swCustomInfoText },
            { "QA Appr Date", (int)swCustomInfoType_e.swCustomInfoText },
            { "Purch Approval", (int)swCustomInfoType_e.swCustomInfoText },
            { "Purch Appr Date", (int)swCustomInfoType_e.swCustomInfoText },
            { "Material", (int)swCustomInfoType_e.swCustomInfoText },
            { "Finish", (int)swCustomInfoType_e.swCustomInfoText },
            { "Coating", (int)swCustomInfoType_e.swCustomInfoText },
            { "Notes", (int)swCustomInfoType_e.swCustomInfoText },
            { "Revision", (int)swCustomInfoType_e.swCustomInfoText },
            { "ECO", (int)swCustomInfoType_e.swCustomInfoText },
            { "EcoRevs", (int)swCustomInfoType_e.swCustomInfoText },
            { "Zone", (int)swCustomInfoType_e.swCustomInfoText },
            { "EcoDescription", (int)swCustomInfoType_e.swCustomInfoText },
            { "Date2", (int)swCustomInfoType_e.swCustomInfoText },
            { "EcoChk", (int)swCustomInfoType_e.swCustomInfoText },
            { "P_M", (int)swCustomInfoType_e.swCustomInfoText },
            { "MaterialPn", (int)swCustomInfoType_e.swCustomInfoText },
            { "RouteTemplate", (int)swCustomInfoType_e.swCustomInfoText },
            { "PurchFlag", (int)swCustomInfoType_e.swCustomInfoText },
        };
        public Dictionary<string, int> PropTypes
        {
            get
            {
                return propTypes;
            }
        }

        private readonly List<string> otherFieldNames = new List<string>(){
            "filename",
            "configname",
            "PlaceHoldFlag",
            "ShowChildren",
            "Image",
            "CuttingLengthOuter",
            "CuttingLengthInner",
            "CutOutCount",
            "BendCount",
        };
        public List<string> OtherFieldNames
        {
            get
            {
                return otherFieldNames;
            }
        }

        #endregion

        private Dictionary<string, string> dictPropField = new Dictionary<string, string>();
        public Dictionary<string, string> PropFieldMap
        {
            get
            {
                return dictPropField;
            }
        }

        private Dictionary<string, string> dictFieldProp = new Dictionary<string, string>();
        public Dictionary<string, string> FieldPropMap
        {
            get
            {
                return dictFieldProp;
            }
        }

        private Dictionary<string, Object> dictPropValues = new Dictionary<string, Object>();
        public Dictionary<string, Object> PropertyValues
        {
            get
            {
                return dictPropValues;
            }
            set
            {
                dictPropValues = value;
            }
        }

        private Dictionary<string, Object> dictFieldValues = new Dictionary<string, Object>();
        public Dictionary<string, Object> FieldValues
        {
            get
            {
                return MapFieldValues();
            }
        }

        public SwCustProp()
        {
            // Map SolidWorks custom property names to DB field names
            foreach (string key in propNames)
                dictPropField.Add(key, fieldNames[propNames.IndexOf(key)]);

            // Map DB field names to SolidWorks custom property names
            foreach (string key in fieldNames)
                dictFieldProp.Add(key, propNames[fieldNames.IndexOf(key)]);

            // Create dictionary of null values by property name
            foreach (string key in propNames)
                dictPropValues.Add(key, null);

            // Add other property keys
            foreach (string key in otherFieldNames)
                dictPropValues.Add(key, null);
        }

        private Dictionary<string, Object> MapFieldValues()
        {
            Dictionary<string, Object> dictFieldValues = new Dictionary<string, Object>();
            foreach (string key in propNames)
                dictFieldValues.Add(dictPropField[key], dictPropValues[key]);
            foreach (string key in otherFieldNames)
                dictFieldValues.Add(key, dictPropValues[key]);
            return dictFieldValues;
        }

        public void UpdateFieldValue(string fieldName, Object fieldValue)
        {
            dictPropValues[dictFieldProp[fieldName]] = fieldValue;
        }

        public static byte[] ImageToByteArray(Bitmap bitmapIn)
        {
            Image imageIn = (Image)bitmapIn;
            if (imageIn == null) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null) return null;
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

    }

}
