using System;
using System.Data;
using System.Management;
using System.Web.UI.WebControls;

namespace ServerInfo.AppCode
{
    public class ProgramHelp : IDisposable
    {

        private DataTable _DTServerData = new DataTable();
        
        // Track whether Dispose has been called.
        private bool disposed = false;

        // Pointer to an external unmanaged resource.
        //private IntPtr handle;


    #region Public Functions

        public ProgramHelp()
        {
            CreateColForTable();
        }

        public GridView CreateGridView()
        {
            System.Web.UI.WebControls.GridView GridView1 = new System.Web.UI.WebControls.GridView();
            GridView1.HeaderStyle.Font.Bold = true;

            return GridView1;
        }

        public string MakeHeaderTitle(string query)
        {
            int WhereIsFrom = query.ToLower().IndexOf("from") + 4;
            string Header = query.Substring(WhereIsFrom, query.Length - WhereIsFrom).Trim();

            if (Header.IndexOf(" ") > 0)
                Header = Header.Substring(0, Header.Length - Header.IndexOf(" "));

            return Header;
        }

        public DataTable OutPutAllwmiSelect(string WMISelect)
        {
            _DTServerData.Clear();
            string query = WMISelect;
            var search = new ManagementObjectSearcher(query);
            var collection = search.Get();
            string OutputFileData = string.Empty;

            foreach (ManagementObject quickFix in collection)
            {
                foreach (PropertyData PD in quickFix.Properties)
                {
                    if (quickFix[PD.Name] != null)
                    {
                        DataRow dr = _DTServerData.NewRow();
                        dr["ValueName"] = PD.Name;
                        dr["Value"] = quickFix[PD.Name];
                        _DTServerData.Rows.Add(dr);
                    }
                }

            }
            search.Dispose();
            collection.Dispose();
            
            return _DTServerData;

        }

        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }


    #endregion

    #region Private Functions

        private void CreateColForTable()
        {
            _DTServerData = new DataTable();
            DataColumn dc = new DataColumn("ValueName");
            dc.DataType = System.Type.GetType("System.String");
            _DTServerData.Columns.Add(dc);
            dc = new DataColumn("Value");
            dc.DataType = System.Type.GetType("System.String");
            _DTServerData.Columns.Add(dc);
            dc.Dispose();
        }

    #endregion





    /// <summary>
        /// http://msdn.microsoft.com/en-us/library/system.idisposable.aspx
    /// </summary>
        #region Dispose

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    _DTServerData.Clear();
                    _DTServerData.Dispose();
                    _DTServerData = null;
                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                //CloseHandle(handle);
                //handle = IntPtr.Zero;

                // Note disposing has been done.
                disposed = true;

            }
        }

        // Use interop to call the method necessary
        // to clean up the unmanaged resource.
        //[System.Runtime.InteropServices.DllImport("Kernel32")]
        //private extern static Boolean CloseHandle(IntPtr handle);

        // Use C# destructor syntax for finalization code.
        // This destructor will run only if the Dispose method
        // does not get called.
        // It gives your base class the opportunity to finalize.
        // Do not provide destructors in types derived from this class.
        ~ProgramHelp()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
        }

        #endregion
       
    }
}