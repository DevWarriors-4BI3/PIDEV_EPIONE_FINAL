using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using System.Threading.Tasks;
using Data;
using Service;
using System.Net.Mail;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace GUI
{
    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Element
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string status { get; set; }
    }

    public class Row
    {
        public Element[] elements { get; set; }
    }

    public class Parent
    {
        public string[] destination_addresses { get; set; }
        public string[] origin_addresses { get; set; }
        public Row[] rows { get; set; }
        public string status { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            MapsAPICall();
        }

        //    var message = new MailMessage("devworriors@gmail.com", "medmalek125@gmail.com");
        //    //message.From=new MailAddress("devworriors@gmail.com");
        //    //message.From = new MailAddress("medmalek125@gmail.tn");
        //    message.Subject = "Nouveau rendez-vous";
        //    message.Body = "Hello";
        //    System.Net.Mail.SmtpClient SC = new System.Net.Mail.SmtpClient("smtp.gmail.com");
        //    SC.Port = 587;
        //    SC.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    SC.UseDefaultCredentials = false;
        //    SC.Credentials = new NetworkCredential("devworriors@gmail.com", "pidev-123456789");
        //    SC.EnableSsl = true;
        //    SC.Timeout = 20000;
        //    message.Priority = MailPriority.High;
        //    try
        //    {
        //        SC.Send(message);

        //    }
        //    catch (Exception e)
        //    {

        //        Console.WriteLine(e.Message);
        //        Console.ReadKey();
        //    }
        //}





        public static string url = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=Washington,DC&destinations=New+York+City,NY&key=AIzaSyA3E4sv-3MduZrfRvlQmnogNaD09dzGGS4";
        private static void MapsAPICall()
        {
            //Pass request to google api with orgin and destination details
            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                if (!string.IsNullOrEmpty(result))
                {
                    Distance t = JsonConvert.DeserializeObject<Distance>(result);
                    Console.WriteLine(result);
                  
                         Console.WriteLine(t);
                    Console.ReadKey();
                }

            }
        }

    }
  

}
