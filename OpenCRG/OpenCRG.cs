using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCRG
{
        class OpenCRG
        {
            /* ====== METHODS in crgMgr.c ====== */
            /** 
            * destroy the data of the given data set
            * @param dataSetId    identifier of the applicable dataset
            * @return 1 if successful, 0 if failed
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgDataSetRelease(int dataSetId);

            /**
            * print information contained in the CRG file's header
            * @param dataSetId    identifier of the applicable dataset
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static void crgDataPrintHeader(int dataSetId);

            /**
            * print information about the CRG file's channels
            * @param dataSetId    identifier of the applicable dataset
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static void crgDataPrintChannelInfo(int dataSetId);

            /**
            * print information about the CRG road
            * @param dataSetId    identifier of the applicable dataset
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static void crgDataPrintRoadInfo(int dataSetId);

            /**
            * get the u co-ordinate range of a CRG data set
            * @param dataSetId    identifier of the applicable dataset
            * @param uMin         return value of minimum u co-ordinate
            * @param uMax         return value of maximum u co-ordinate
            * @return 1 upon success, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgDataSetGetURange(int dataSetId, out double uMin, out double uMax);


            /**
            * get the v co-ordinate range of a CRG data set
            * @param dataSetId    identifier of the applicable dataset
            * @param vMin         return value of minimum v co-ordinate
            * @param vMax         return value of maximum v co-ordinate
            * @return 1 upon success, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgDataSetGetVRange(int dataSetId, out double vMin, out double vMax);
            /**
            * get the u and v co-ordinate increments
            * @param dataSetId    identifier of the applicable dataset
            * @param uInc         return value of u increment
            * @param vInc         return value of v increment (0 if explicit v section have been defined)
            * @return 1 upon success, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgDataSetGetIncrements(int dataSetId, out double uInc, out double vInc);
            /**
            * get closed track utility data
            * @param dataSetId    identifier of the applicable dataset
            * @param uIsClosed    return remember whether reference line can be closed
            * @param uCloseMin    return minimum u of closed reference line (NaN if uIsClosed == 0)
            * @param uCloseMax    return maximum u of closed reference line (NaN if uIsClosed == 0)
            * @return 1 upon success, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgDataSetGetUtilityDataClosedTrack(int dataSetId, out int uIsClosed, out double uCloseMin, out double uCloseMax);

        /**
            * set/add an integer value modifier to be applied to the data set
            * CRG data using the indicated data point
            * @param  dataSetId    identifier of the applicable dataset
            * @param  modId        identifier of the modifier which is to be set/added
            *                      (see defines above: dCrgModXXXX)
            * @param  modValue     (new) value of the indicated modifier (may be a mask,
            *                      depending on the type)
            * @return 1 if successful, otherwise 0
            */

            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgDataSetModifierSetInt(int dataSetId, uint optionId, uint optionValue);

        /**
        * set/add a double value option to be applied while handling / evaluating 
        * CRG data using the indicated data point
        * @param  dataSetId    identifier of the applicable dataset
        * @param  modId        identifier of the modifier which is to be set/added
        *                      (see defines above: dCrgModXXXX)
        * @param  modValue     (new) value of the indicated modifier
        * @return 1 if successful, otherwise 0
        */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgDataSetModifierSetDouble(int dataSetId, uint optionId, double optionValue);

            /**
            * get the value of an integer option
            * @param  dataSetId    identifier of the applicable dataset
            * @param  modId        identifier of the modifier which is to be set/added
            *                      (see defines above: dCrgModXXXX)
            * @param  modValue     pointer to memory location for return value
            * @return 1 if option is set, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgDataSetModifierGetInt(int dataSetId, uint optionId, out int modValue);
            /**
            * get the value of a double option
            * @param  dataSetId    identifier of the applicable dataset
            * @param  modId        identifier of the modifier which is to be set/added
            *                      (see defines above: dCrgModXXXX)
            * @param  modValue     pointer to memory location for return value
            * @return 1 if option is set, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgDataSetModifierGetDouble(int dataSetId, uint optionId, out double modValue);
            /**
            * remove a modifier from the data set settings's modifier list and apply the
            * corresponding default behavior
            * @param  dataSetId    identifier of the applicable dataset
            * @param  modId        identifier of the modifier which is to be set/added
            *                      (see defines above: dCrgModXXXX)
            * @return 1 if successful, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgDataSetModifierRemove(int dataSetId, uint modId);

            /**
            * remove all modifiers from the data set's modifier list
            * @param  dataSetId    identifier of the applicable dataset
            * @return 1 if successful, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgDataSetModifierRemoveAll(int dataSetId);

            /**
            * print the data set's current set of modifiers
            * @param  dataSetId    identifier of the applicable dataset
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static void crgDataSetModifiersPrint(int dataSetId);

            /**
            * apply all defined modifiers once to the given data set and remove them afterwards
            * @param  dataSetId    identifier of the applicable dataset
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static void crgDataSetModifiersApply(int dataSetId);

            /**
            * set the default modifiers for a data set
            * @param  dataSetId    identifier of the applicable dataset
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static void crgDataSetModifierSetDefault(int dataSetId);

            /**
            * set the default options for a data set; these will be transfered to
            * contact points which are derived from the data set
            * @param  dataSetId    identifier of the applicable dataset
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static void crgDataSetOptionSetDefault(int dataSetId);

            /**
            * release all data held by the crg library
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static void crgMemRelease();

            /**
            * get the release string indicating the current version
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            //public   extern static IntPtr crgGetReleaseInfo();
            public extern static IntPtr crgGetReleaseInfo();
            /**
            * wrap the isnan() functionality
            * @param dValue	the double value which is to be checked for NaN
            * @return 1 if value is NaN
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgIsNan(IntPtr dValue);

            /**
            * wrap the isnan() functionality
            * @param fValue	the float value which is to be checked for NaN
            * @return 1 if value is NaN
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgIsNanf(IntPtr dValue);
            /* ====== METHODS in crgMsg.c ====== */
            /**
            * set the maximum level of messages that will be handled,
            * example:  if set to "sCrgMsgLevelNotice", messages of the levels
            *           sCrgMsgLevelWarn and  sCrgMsgLevelFatal will be handled
            * @param level  new value for maximum handled criticality
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static void crgMsgSetLevel(int level);

            /** 
            * set the maximum number of warning / debug messages to be handled
            * @param maxNo  maximum number of messages to be handled (-1 for unlimited)
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static void crgMsgSetMaxWarnMsgs(int maxNo);

            /** 
            * set the maximum number of log messages to be handled
            * @param maxNo  maximum number of messages to be handled (-1 for unlimited)
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static void crgMsgSetMaxLogMsgs(int maxNo);

            /**
            * query whether messages of a certain level are to be printed (this may
            * change during runtime due to a restriction in the number of messages
            * that may be printed)
            * @param level  the desired level
            * @return 0 if message of the given level may be printed
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgMsgIsPrintable(int level);

            /* ====== METHODS in crgLoader.c ====== */
            /**
            * check CRG data for consistency and accuracy
            * @param  dataSetId    identifier of the applicable dataset
            * @return true         if crgData is valid
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgCheck(int dataSetId);

            /**
            * method for loading CRG data from an existing IPL-formatted file
            * @param filename   full filename of the CRG input file including path
            * @return identifier of the resulting data set or 0 if not successful
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgLoaderReadFile([MarshalAs(UnmanagedType.LPStr)] string filename);

            /* ====== METHODS in crgContactPoint.c ====== */
            /**
            * create a new contact point working on the indicated data set
            * @param  dataSetId index of data set which is to be used
            * @return id of new contact point or -1 if error occurred
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgContactPointCreate(int dataSetId);

            /**
            * delete a contact point and its associated data (not: crgData)
            * @param  cpId id of the contact point which is to be deleted
            * @return 1 if successful, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgContactPointDelete(int cpId);

            /**
            * delete all contact points and associated data for a given data set (not: crgData)
            * @param dataSetId  the ID of the data set for which to delete
            *                   the contact points; if ID=-1, then all contact points
            *                   of all data sets will be deleted
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static void crgContactPointDeleteAll(int dataSetId);

            /**
            * set/add an integer value option to be applied while handling / evaluating 
            * CRG data using the indicated data point
            * @param  cpId         id of the contact point which is to be configured
            * @param  optionId     identifier of the option which is to be set/added
            *                      (see defines above: dCrgCpOptionXXXX)
            * @param  optionValue  (new) value of the indicated option (may be a mask,
            *                      depending on the option type)
            * @return 1 if successful, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgContactPointOptionSetInt(int cpId, uint optionId, int optionValue);

            /**
            * set/add a double value option to be applied while handling / evaluating 
            * CRG data using the indicated data point
            * @param  cpId         id of the contact point which is to be configured
            * @param  optionId     identifier of the option which is to be set/added
            *                      (see defines above: dCrgCpOptionXXXX)
            * @param  optionValue  (new) value of the indicated option
            * @return 1 if successful, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgContactPointOptionSetDouble(int cpId, uint optionId, double optionValue);

            /**
            * get the value of an integer option
            * @param  cpId         id of the contact point which is to be used
            * @param  optionId     identifier of the option whose value shall be queried
            *                      (see defines above: dCrgCpOptionXXXX)
            * @param  optionValue  pointer to memory location for return value
            * @return 1 if option is set, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgContactPointOptionGetInt(int cpId, uint optionId, out int optionValue);
            /**
            * get the value of a double option
            * @param  cpId         id of the contact point which is to be used
            * @param  optionId     identifier of the option whose value shall be queried
            *                      (see defines above: dCrgCpOptionXXXX)
            * @param  optionValue  pointer to memory location for return value
            * @return 1 if option is set, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgContactPointOptionGetDouble(int cpId, uint optionId, out double optionValue);
            /**
            * remove an option from the contact point's option settings and apply the
            * corresponding default behavior
            * @param  cpId         id of the contact point which is to be configured
            * @param  optionId     identifier of the option which is to be set/added
            *                      (see defines above: dCrgCpOptionXXXX)
            * @return 1 if successful, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgContactPointOptionRemove(int cpId, uint optionId);

            /**
            * remove all options from the contact point's option settings
            * @param  cpId         id of the contact point which is to be configured
            * @return 1 if successful, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgContactPointOptionRemoveAll(int cpId);

            /**
            * print the contact point's current set of options
            * @param  cpId id of the contact point whose options are to be printed
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static void crgContactPointOptionsPrint(int cpId);

            /**
            * set the default options to be applied when using a contact point for data
            * evaluation etc.
            * @param  cpId index of the contact point which is to be modified
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static void crgContactPointSetDefaultOptions(int cpId);

            /**
            * set the size of a contact point's history
            * @param  cpId         index of the contact point which is to be modified
            * @param  histSize     new size of history stack
            * @return 1 if successful, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgContactPointSetHistory(int cpId, int histSize);

            /* ====== METHODS in crgEvalxy2uv.c ====== */
            /**
            * convert a given (x,y) position into the corresponding (u,v) position
            * @param cpId  id of the contact point to use for the query
            * @param x     x co-ordinate
            * @param y     y co-ordinate
            * @param u     pointer to resulting u co-ordinate
            * @param v     pointer to resulting v co-ordinate
            * @return 1 if successful, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgEvalxy2uv(int cpId, double x, double y, out double u, out double v);
            /* ====== METHODS in crgEvaluv2xy.c ====== */
            /**
            * convert a given (u,v) position into the corresponding (x,y) position
            * @param cpId  id of the contact point to use for the query
            * @param u     u co-ordinate
            * @param v     v co-ordinate
            * @param x     pointer to resulting x co-ordinate
            * @param y     pointer to resulting y co-ordinate
            * @return 1 if successful, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgEvaluv2xy(int cpId, double u, double v, out double x, out double y);
            /* ====== METHODS in crgEvalz.c ====== */
            /**
            * compute the z value at a given (u,v) position using bilinear interpolation
            * @param cpId  id of the contact point to use for the query
            * @param u     u co-ordinate
            * @param v     v co-ordinate
            * @param z     pointer to resulting z co-ordinate
            * @return 1 if successful, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgEvaluv2z(int cpId, double u, double v, out double z);
            /**
            * compute the z value at a given (x,y) position using bilinear interpolation
            * @param cpId  id of the contact point to use for the query
            * @param x     x co-ordinate
            * @param y     y co-ordinate
            * @param z     pointer to resulting z co-ordinate
            * @return 1 if successful, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgEvalxy2z(int cpId, double x, double y, out double z);
            /* ====== METHODS in crgEvalpk.c ====== */
            /**
            * compute the heading and curvature value at a given (u,v) position and store
            * it in the contact point structure
            * @param cpId  id of the contact point to use for the query
            * @param u     u co-ordinate
            * @param v     v co-ordinate
            * @param phi   pointer to resulting heading angle
            * @param curv  pointer to resulting curvature
            * @return 1 if successful, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgEvaluv2pk(int cpId, double u, double v, out double phi, out double curv);
            /**
            * compute the heading and curvature value at a given (x,y) position and store
            * it in the contact point structure
            * @param cpId  id of the contact point to use for the query
            * @param x     x co-ordinate
            * @param y     u co-ordinate
            * @param phi   pointer to resulting heading angle
            * @param curv  pointer to resulting curvature
            * @return 1 if successful, otherwise 0
            */
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static int crgEvalxy2pk(int cpId, double x, double y, out double phi, out double curv);
            /* ====== METHODS in crgPortability.c ====== */
            /**
            * print a message with a defined criticality level
            * @param level  criticality of the message
            * @param format variable argument list as for standard printf
            */
            //[DllImport("OpenCRG.dll")]
            //public   extern static void crgMsgPrint(int level, IntPtr format, ...);
            /**
            * set a user-defined callback method to free previously allocated space from memory,
            * @param func   pointer to the user-defined method
            * @param ptr    pointer to existing memory location
            */
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void crgFreeDelegate();
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static void crgFreeSetCallback(crgFreeDelegate cb);
            //public   extern static void crgFreeSetCallback(void ( * func ) (void* ptr ) );

            /**
            * set a user-defined callback method that should be called for all messages
            * instead of printing them to the console
            * @param func   pointer to the user-defined method accepting message level and text
            */
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void crgMsgDelegate(int level, StringBuilder message);
            [DllImport("OpenCRG.dll", CallingConvention = CallingConvention.Cdecl)]
            public extern static void crgMsgSetCallback(crgMsgDelegate cb);


        /**
        * Get Computed Z array from a DataSet
        * @param dataSetId   pointer to the user-defined method accepting message level and text
        * @param out arr     [out] double array as the buffer, to be modified
        */
        public static void crgGetZarray(int dataSetId, out double[,] arr)
            {
                double u1, u2, v1, v2, uinc, vinc;
                int vLim, uLim, cpId, res;
                double z;
                cpId = crgContactPointCreate(dataSetId);
                crgDataSetGetURange(dataSetId, out u1, out u2);
                crgDataSetGetVRange(dataSetId, out v1, out v2);
                crgDataSetGetIncrements(dataSetId, out uinc, out vinc);
                uLim = (int)((u2 - u1) / uinc);
                vLim = (int)((v2 - v1) / vinc);
                arr = new double[uLim, vLim];
                for (int i = 0; i < uLim && i * uinc + u1 <= u2; i++)
                    for (int j = 0; j < vLim && j * vinc + v1 <= v2; j++)
                    {
                        res = crgEvaluv2z(cpId, i * uinc + u1, j * vinc + v1, out z);
                        arr[i, j] = z;
                    }
            }
        }
    }
