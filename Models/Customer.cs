﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercise.Models;
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public MailAddress Email { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public List<Order> Orders { get; set; }
}