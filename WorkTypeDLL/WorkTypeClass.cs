/* Title:           Work Type Class
 * Date:            8-17-17
 * Author:          Terry Holmes */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace WorkTypeDLL
{
    public class WorkTypeClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        WorkTypeDataSet aWorkTypeDataSet;
        WorkTypeDataSetTableAdapters.worktypeTableAdapter aWorkTypeTableAdpater;

        InsertWorkTypeEntryTableAdapters.QueriesTableAdapter aInsertWorkTypeTableAdapter;

        FindWorkTypeSortedDataSet aFindWorkTypeSortedDataSet;
        FindWorkTypeSortedDataSetTableAdapters.FindWorkTypeSortedTableAdapter aFindWorkTypeSortedTableAdapter;

        FindWorkTypeByTypeIDDataSet aFindWorkTypeByTypeIDDataSet;
        FindWorkTypeByTypeIDDataSetTableAdapters.FindWorkTypeByTypeIDTableAdapter aFindWorkTypeByTypeIDTableAdapter;

        FindWorkTypeByTypeDataSet aFindWorkTypeByTypeDataSet;
        FindWorkTypeByTypeDataSetTableAdapters.FindWorkTypeByTypeTableAdapter aFindWorkTypeByTypeTableAdapter;

        public FindWorkTypeByTypeDataSet FindWorkTypeByType(string strWorkType)
        {
            try
            {
                aFindWorkTypeByTypeDataSet = new FindWorkTypeByTypeDataSet();
                aFindWorkTypeByTypeTableAdapter = new FindWorkTypeByTypeDataSetTableAdapters.FindWorkTypeByTypeTableAdapter();
                aFindWorkTypeByTypeTableAdapter.Fill(aFindWorkTypeByTypeDataSet.FindWorkTypeByType, strWorkType);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Type Class // Find Work Type by Type " + Ex.Message);
            }

            return aFindWorkTypeByTypeDataSet;
        }
        public FindWorkTypeByTypeIDDataSet FindWorkTypeByTypeID(int intTypeID)
        {
            try
            {
                aFindWorkTypeByTypeIDDataSet = new FindWorkTypeByTypeIDDataSet();
                aFindWorkTypeByTypeIDTableAdapter = new FindWorkTypeByTypeIDDataSetTableAdapters.FindWorkTypeByTypeIDTableAdapter();
                aFindWorkTypeByTypeIDTableAdapter.Fill(aFindWorkTypeByTypeIDDataSet.FindWorkTypeByTypeID, intTypeID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Type Class // Find Work Type by Type ID " + Ex.Message);
            }

            return aFindWorkTypeByTypeIDDataSet;
        }
        public FindWorkTypeSortedDataSet FindWorkTypeSorted()
        {
            try
            {
                aFindWorkTypeSortedDataSet = new FindWorkTypeSortedDataSet();
                aFindWorkTypeSortedTableAdapter = new FindWorkTypeSortedDataSetTableAdapters.FindWorkTypeSortedTableAdapter();
                aFindWorkTypeSortedTableAdapter.Fill(aFindWorkTypeSortedDataSet.FindWorkTypeSorted);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Type Class // Find Work Type Sorted " + Ex.Message);
            }

            return aFindWorkTypeSortedDataSet;
        }
        public bool InsertWorkType(string strWorkType)
        {
            bool blnFatalError = false;

            try
            {
                aInsertWorkTypeTableAdapter = new InsertWorkTypeEntryTableAdapters.QueriesTableAdapter();
                aInsertWorkTypeTableAdapter.InsertWorkType(strWorkType);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Type Class // Insert Work Type " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public WorkTypeDataSet GetWorkTypeInfo()
        {
            try
            {
                aWorkTypeDataSet = new WorkTypeDataSet();
                aWorkTypeTableAdpater = new WorkTypeDataSetTableAdapters.worktypeTableAdapter();
                aWorkTypeTableAdpater.Fill(aWorkTypeDataSet.worktype);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Type Class // Get Work Type Info " + Ex.Message);
            }

            return aWorkTypeDataSet;
        }
        public void UpdateWorkTypeDB(WorkTypeDataSet aWorkTypeDataSet)
        {
            try
            {
                aWorkTypeTableAdpater = new WorkTypeDataSetTableAdapters.worktypeTableAdapter();
                aWorkTypeTableAdpater.Update(aWorkTypeDataSet.worktype);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Type Class // Update Work Type DB " + Ex.Message);
            }
        }
    }
}
