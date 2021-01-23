using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    public interface IBaseRepository<MISAEntity>
    {
        IEnumerable<MISAEntity> Get();
        IEnumerable<MISAEntity> GetById(string id);
        int Add(MISAEntity entity);
        int Update(MISAEntity entiy);
        int DeleteById(Guid id);
        bool CheckBySpec(MISAEntity entity, PropertyInfo property, string actionType);
    }
}
