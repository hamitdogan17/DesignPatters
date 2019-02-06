﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageSenderBase = new EmailSender();
            customerManager.UpdateCustomer();

            Console.ReadLine();
        }
    }

    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message Saved!");
        }

        public abstract void Send(Body body);
    }

    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender", body.Title);
        }
    }
    class EmailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via MailSender", body.Title);
        }
    }

    class CustomerManager 
    {
        //bridge
        public MessageSenderBase MessageSenderBase { get; set; }
        public void UpdateCustomer()
        {
            //// Kötü kodlama
            //SmsSender smsSender = new SmsSender(); 
            //smsSender.Send(new Body());


            //Bu desene göre bir tane bridge oluştur
           MessageSenderBase.Send(new Body{Title = "About the course!"});
            
            Console.WriteLine("Customer Updated.");
        }
    }

}
