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

        public AddOrUpdateEmployeeVm GetEmployee(Expression<Func<Employee, bool>> filterPredicate = null)
        {
            Employee employee = _uow.Repository<Employee>().Get(filterPredicate: filterPredicate);
            AddOrUpdateEmployeeVm employeeVm = Mapper.Map<AddOrUpdateEmployeeVm>(employee);
            return employeeVm;
        }

        public void AddOrUpdateEmployee(AddOrUpdateEmployeeVm employeeVm)
        {
            Employee employee = _uow.Repository<Employee>().Get(employeeVm.Id);
            employee.FirstName = employeeVm.FirstName;
            employee.LastName = employeeVm.LastName;

            //_uow.Repository<Employee>().Update(<y< => y.Id==employeeVm.Id, employee);
            _uow.Save();
        }

        public void DeleteEmployee(int employeeId)
        {
            Employee employee = _uow.Repository<Employee>().Get(employeeId);
            if (employee != null)
            {
                _uow.Repository<Employee>().Delete(employee);
                _uow.Save();
            }
        }
    }
}
