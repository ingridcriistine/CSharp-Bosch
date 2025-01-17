using System.Collections.Generic;

namespace DataBase;

public abstract class DataBase<T>
{
    public string basePath;
    public string DBPath;
    public List<T> All;

    protected static DataBase<T> app = null;

    protected abstract List<string> openFile();
    protected abstract bool saveFile(List<string> list);
    public abstract void Save(List<T> all);
}
