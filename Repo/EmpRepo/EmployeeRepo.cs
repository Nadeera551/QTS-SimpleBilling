﻿using QTS_SimpleBilling.BAL;
using QTS_SimpleBilling.Model;
using QTS_SimpleBilling.Repo.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QTS_SimpleBilling.EmpRepo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public int Create(Employee t)
        {
            int result = 0;
            try
            {
                using BillingContext context = new BillingContext();
                var emp = context.Employees.FirstOrDefault(c => c.EmployeeId == t.EmployeeId);
                if (emp == null)
                {
                    context.Add(t);
                    return result = context.SaveChanges();
                }
                else
                {
                    return Update(t);
                }
            }
            catch (Exception ex)
            {
                Exc.ErMessage(ex);
                return result = 0;
            }
        }

        public int Delete(Employee t)
        {
            int result = 0;
            try
            {
                using BillingContext context = new BillingContext();
                context.Employees.Remove(t);
                return result = context.SaveChanges();
            }
            catch (Exception ex)
            {
                Exc.ErMessage(ex);
                return result;
            }
        }

        public int Update(Employee t)
        {
            int result = 0;
            try
            {
                using BillingContext context = new BillingContext();
                context.Update(t);
                return result = context.SaveChanges();
            }
            catch (Exception ex)
            {
                Exc.ErMessage(ex);
                return result;
            }
        }

        public List<Employee> View()
        {
            try
            {
                using BillingContext context = new BillingContext();
                return context.Employees.ToList();
            }
            catch (Exception ex)
            {
                Exc.ErMessage(ex);
                return null;
            }
        }
    }
}
