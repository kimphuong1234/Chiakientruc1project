using MISA.ApplicationCore.Interface;
using MISA.ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class BaseService<MISAEntity> : IBaseServices<MISAEntity>
    {
        IBaseRepository<MISAEntity> _baseRepository;
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public ServiceResult Add(MISAEntity entity)
        {
            var res = Validate(entity, "add");
            if (!res.Success)
            {
                return res;
            }
            else
            {
                res.Success = true;
                res.Messenger = "Thêm thành công";
                res.Data = _baseRepository.Add(entity);
                return res;
            }
            
        }

        public ServiceResult Delete(Guid id)
        {
            var res = new ServiceResult();
            res.Success = true;
            res.Data = _baseRepository.DeleteById(id);
            res.Messenger = "Xóa thành công";
            return res;
        }

        public IEnumerable<MISAEntity> GET()
        {
            return _baseRepository.Get();
        }
        public IEnumerable<MISAEntity> GetById(string id)
        {
            return _baseRepository.GetById(id);
        }
        public ServiceResult Update(MISAEntity entity)
        {
            var res = Validate(entity, "update");
            if (!res.Success)
            {
                return res;
            }
            res.Data = _baseRepository.Update(entity);
            return res;
        }
        private ServiceResult Validate(MISAEntity entity, string actionType)
        {
            var res = new ServiceResult();
            res.Success = true;
            var listMessage = new List<string>();
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                var propertyName = property.Name;
                var displayName = "";
                if (property.IsDefined(typeof(DisplayName), false))
                {
                    var displayAttribute = property.GetCustomAttributes(typeof(DisplayName), true)[0];
                    displayName = (displayAttribute as DisplayName).PropertyName;
                }
                if (property.IsDefined(typeof(Required), false))
                {
                    if (string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        res.Success = false;
                        listMessage.Add($"{displayName} không được phép để trống");
                    }
                }
                if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    if (!_baseRepository.CheckBySpec(entity, property, actionType))
                    {
                        res.Success = false;
                        listMessage.Add($"Trùng {displayName} ");
                    }
                }
                if (property.IsDefined(typeof(MaxLength), false))
                {
                    var maxLengthAttribute = property.GetCustomAttributes(typeof(MaxLength), true)[0];
                    var length = (maxLengthAttribute as MaxLength).Length;
                    if (propertyValue.ToString().Length > length)
                    {
                        res.Success = false;
                        listMessage.Add($"{displayName} không được dài quá {length} ký tự");
                    }
                }
            }
            res.Messenger = listMessage;
            return res;
        }
    }
}
