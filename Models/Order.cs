using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercise.Models;
public class Order
{
    public OrderStatus Status { get; set; }
    public List<Product> Cart { get; set; }
}
