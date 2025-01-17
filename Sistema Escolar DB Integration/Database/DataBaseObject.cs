using System;
using System.Data;

namespace DataBase;

public abstract class DataBaseObject
{
    protected internal abstract void LoadFrom(string[] data);
    protected internal abstract string[] SaveTo();
    protected internal abstract void LoadFromSqlRow(DataRow data);
    protected internal abstract string SaveToSql();
}
