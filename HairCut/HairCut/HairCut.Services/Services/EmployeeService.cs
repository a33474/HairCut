using AutoMapper;
using DataAccessLayer.Core.Interfaces.UoW;
using HairCut.BLL.Entities;
using HairCut.Services.Interfaces;
using HairCut.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HairCut.Services.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {

        public EmployeeService(IUnitOfWork uow):base(uow)
        {

        }
        public IEnumerable<EmployeeVm> GetEmployees(Expression<Func<Employee, bool>> filterPredicate = null)
        {
            IEnumerable<Employee> employees = _uow.Repository<Employee>().GetRange(filterPredicate: filterPredicate, orderByPredicate: y => y.OrderBy(p => p.FirstName), 
                                                                                    tablePredicate: p => p.BookedAppointments, 
                                                                                    enableTracking: false);
            IEnumerable<EmployeeVm> employeeVm = AutoMapper.Mapper.Map<IEnumerable<EmployeeVm>>(employees);
            return employeeVm;
        }

        public EmployeeVm GetEmployee(Expression<Func<Employee, bool>> filterPredicate = null)
        {
            Employee employee = _uow.Repository<Employee>().Get(filterPredicate: filterPredicate);
            EmployeeVm employeeVm = Mapper.Map<EmployeeVm>(employee);
            return employeeVm;
        }

        public void AddOrUpdateEmployee(EmployeeVm employeeVm)
        {
            var employee = Mapper.Map<Employee>(employeeVm);
            employee.FirstName = string.Empty;
            _uow.Repository<Employee>().AddOrUpdate(y => y.FirstName == employee.FirstName, employee);
            _uow.Save();
        }
    }
}
