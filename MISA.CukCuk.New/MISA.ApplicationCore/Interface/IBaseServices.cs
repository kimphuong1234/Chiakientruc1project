
using MISA.ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    public interface IBaseServices<MISAEntity>
    {
        IEnumerable<MISAEntity> GET();
        IEnumerable<MISAEntity> GetById(string id);
        ServiceResult Add(MISAEntity entity);
        ServiceResult Update(MISAEntity entity);
        ServiceResult Delete(Guid id);
    }
}
