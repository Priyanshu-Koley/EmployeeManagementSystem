using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Dtos
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
    }
}
