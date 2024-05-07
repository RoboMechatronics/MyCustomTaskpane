using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace CustomTaskpane
{
    public class CreateHolePattern
    {
        private static SldWorks swApp = new SldWorks();
        public static void Main()
        {
            FeatureManager swFeatMgr = default(FeatureManager);
            Feature swFeat = default(Feature);
            ModelDoc2 swModel = default(ModelDoc2);

            swModel = (ModelDoc2)swApp.ActiveDoc;

            swFeatMgr = swModel.FeatureManager;

            #region Create the hole wizard countersink hole 
            int GenericHoleType = (int)swWzdGeneralHoleTypes_e.swWzdHole;
            int StandardIndex = (int)swWzdHoleStandards_e.swStandardAnsiMetric;
            int FastenerTypeIndex = (int)swWzdHoleStandardFastenerTypes_e.swStandardAnsiMetricDrillSizes;
            string SSize = (char)216 + "1.0";
            short EndType = (int)swEndConditions_e.swEndCondThroughAll;
            double Diameter = 0.000157; //unit: meter
            double Depth = 0.001;
            double Length = 0.01;
            double Value1 = 0;
            double Value2 = 0;
            double Value3 = 0;
            double Value4 = 0;
            double Value5 = 0;
            double Value6 = 0;
            double Value7 = 0;
            double Value8 = 0;
            double Value9 = 0;
            double Value10 = 0;
            double Value11 = 0;
            double Value12 = 0;
            string ThreadClass = "";
            bool RevDir = false;
            bool FeatureScope = true;
            bool AutoSelect = true;
            bool AssemblyFeatureScope = true;
            bool AutoSelectComponents = true;
            bool PropagateFeatureToParts = false;
            swFeat = swFeatMgr.HoleWizard5(GenericHoleType, StandardIndex, FastenerTypeIndex, SSize, EndType, Diameter, Depth, Length, Value1, Value2, Value3, Value4, Value5, Value6, Value7, Value8, Value9, Value10, Value11, Value12, ThreadClass, RevDir, FeatureScope, AutoSelect, AssemblyFeatureScope, AutoSelectComponents, PropagateFeatureToParts);
            #endregion
        }
    }
}