using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_Expression.Entity;

public class People
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public override string ToString() => $"Id={Id},Name={Name}";
}