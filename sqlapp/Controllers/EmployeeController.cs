using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sqlapp.Services;
using sqlapp.Models;
using Microsoft.Extensions.Configuration;

namespace sqlapp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService employeeservice;
        private readonly IConfiguration configuration;
        public EmployeeController(EmployeeService service,IConfiguration iconfig)
        {
            employeeservice = service;
            configuration = iconfig;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> employees = employeeservice.GetEmployee(configuration.GetConnectionString("SqlConn"));
            return View(employees);
        }
    }
}
