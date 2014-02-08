﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace pserv4.processes
{
    public class ProcessesDataController : DataController
    {
        private static List<ObjectColumn> ActualColumns;

        public ProcessesDataController()
        {
        }

        public override IEnumerable<ObjectColumn> Columns
        {
            get
            {
                if (ActualColumns == null)
                {
                    ActualColumns = new List<ObjectColumn>();
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_ID, "IDString"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_Name, "Name"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_Path, "Path"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_User, "User"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_FileDescription, "FileDescription"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_FileVersion, "FileVersion"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_Product, "Product"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_ProductVersion, "ProductVersion"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_ThreadCount, "ThreadCount"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_HandleCount, "HandleCount"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_MainWindowHandle, "MainWindowHandle"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_MainWindowTitle, "MainWindowTitle"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_Responding, "Responding"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_StartTime, "StartTime"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_TotalProcessorTime, "TotalProcessorTime"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_TotalRunTime, "TotalRunTime"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_PrivilegedProcessorTime, "PrivilegedProcessorTime"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_ProcessPriorityClass, "ProcessPriorityClass"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_SessionId, "SessionId"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_StartInfoArguments, "StartInfoArguments"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_NonpagedSystemMemorySize64, "NonpagedSystemMemorySize64"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_PagedMemorySize64, "PagedMemorySize64"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_PeakPagedMemorySize64, "PeakPagedMemorySize64"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_PagedSystemMemorySize64, "PagedSystemMemorySize64"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_PeakVirtualMemorySize64, "PeakVirtualMemorySize64"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_PeakWorkingSet64, "PeakWorkingSet64"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_PrivateMemorySize64, "PrivateMemorySize64"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_VirtualMemorySize64, "VirtualMemorySize64"));
                    ActualColumns.Add(new ObjectColumn(pserv4.Properties.Resources.PROCESS_C_WorkingSet64, "WorkingSet64"));
                }
                return ActualColumns;
            }
        }

        public override void Refresh(ObservableCollection<DataObject> objects)
        {
            Dictionary<int, ProcessDataObject> existingObjects = new Dictionary<int, ProcessDataObject>();

            foreach (DataObject o in objects)
            {
                ProcessDataObject sdo = o as ProcessDataObject;
                if (sdo != null)
                {
                    existingObjects[sdo.ID] = sdo;
                }
            }

            foreach (Process p in Process.GetProcesses())
            {
                ProcessDataObject pdo = null;

                if (existingObjects.TryGetValue(p.Id, out pdo))
                {
                    // todo: refresh existing instance from updated data
                }
                else
                {
                    objects.Add(new ProcessDataObject(p));
                }
            }
        }
    }
}
