using HairCut.BLL.Entities;
using HairCut.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HairCut.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeVm> GetEmployees(Expression<Func<Employee, bool>> filterPredicate = null);
        AddOrUpdateEmployeeVm GetEmployee(Expression<Func<Employee, bool>> filterPredicate = null);
        void AddOrUpdateEmployee(AddOrUpdateEmployeeVm employeeVm);
        void DeleteEmployee(int employeeId);
    }
}
