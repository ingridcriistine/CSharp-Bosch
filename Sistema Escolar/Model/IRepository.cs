using DataBase;

namespace Model;

public interface IRepository<T>
    where T : DataBaseObject
{
    List<T> All { get; set; }
    void Add(T obj);
}
