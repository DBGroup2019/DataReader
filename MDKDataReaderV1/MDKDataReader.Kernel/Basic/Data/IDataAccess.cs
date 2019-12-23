using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MDKDataReader.Kernel.Basic.Data
{
    /// <summary>
    /// 数据库操作
    /// </summary>
    public interface IDataAccess
    {
        string GetDataBase();

        string GetDBSvrIP();

        DbConnection GetConnection();

        object GetSingleObject(string sql);

        void AsyncGetSingleObject(string sql, object tag = null, Action<object, string, object> OnAsyncResult = null);

        DataTable GetDataTable(string sql);

        DataTable GetDataTable(string sql, int nStartNum, int nPageNum);

        DataTable GetDataTable(string sql, bool cache);

        void AsyncGetDataTable(string sql, object tag = null, Action<DataTable, string, object> OnAsyncResult = null);

        DataSet GetDataSet(string sql);

        void AsyncGetDataSet(string sql, object tag = null, Action<DataSet, string, object> OnAsyncResult = null);

        bool ExecuteSql(string sql);

        void AsyncExecuteSql(string sql, object tag = null, Action<bool, string, object> OnAsyncResult = null);

        int ExecuteSql2(string sql);

        void AsyncExecuteSql2(string sql, object tag = null, Action<int, string, object> OnAsyncResult = null);

        bool Exists(string strSql);

        void AsyncExists(string sql, object tag = null, Action<bool, string, object> OnAsyncResult = null);

        bool ExecuteSqlTran(List<String> sSqlList);

        void AsynExecuteSqlTran(List<string> sSqlList, object tag = null, Action<bool, string, object> OnAsyncResult = null);

        bool ExecuteSqlTran(System.Collections.Hashtable sSqlList);

        void AsynExecuteSqlTran(Hashtable sSqlList, object tag = null, Action<bool, string, object> OnAsyncResult = null);

        DataTable GetDataTable(string sql, params IDataParameter[] cmdParms);

        void AsyncGetDataTable(string sql, IDataParameter[] cmdParms, object tag = null, Action<DataTable, string, object> OnAsyncResult = null);

        DataSet GetDataSet(string sql, params IDataParameter[] cmdParms);

        void AsyncGetDataSet(string sql, IDataParameter[] cmdParms, object tag = null, Action<DataSet, string, object> OnAsyncResult = null);

        bool ExecuteSql(string sql, params IDataParameter[] cmdParms);

        void AsyncExecuteSql(string sql, IDataParameter[] cmdParms, object tag = null, Action<bool, string, object> OnAsyncResult = null);

        int ExecuteSql2(string sql, params IDataParameter[] cmdParms);

        void AsyncExecuteSql2(string sql, IDataParameter[] cmdParms, object tag = null, Action<int, string, object> OnAsyncResult = null);

        object GetSingleObject(string sql, params IDataParameter[] cmdParms);

        DataTable ExecuteProcedure(string sProcName, IDataParameter[] cmdParms);

        void AsyncExecuteProcedure(string sProcName, IDataParameter[] cmdParms, object tag = null, Action<DataTable, string, object> OnAsyncResult = null);

        DataSet ExecuteProcedure(string sProcName, IDataParameter[] cmdParms, string tableName);

        void AsyncExecuteProcedure(string sProcName, IDataParameter[] cmdParms, string tableName, object tag = null, Action<DataSet, string, object> OnAsyncResult = null);

        int ExecuteProcedure(string sProcName, IDataParameter[] cmdParms, out int nRows);

        void AsyncExecuteProcedure(string sProcName, IDataParameter[] cmdParms, object tag = null, Action<int, string, object> OnAsyncResult = null);

        bool UpdateTableField(string sTable, int nID, string sField, string sValue);

        void AsyncUpdateTableField(string sTable, int nID, string sField, string sValue, object tag = null, Action<bool, string, object> OnAsyncResult = null);

    }
}
