using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfSimple
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ContactManager1 : IContactManager1
    {
        private static List<Contact> contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            WebOperationContext webOperationContext = WebOperationContext.Current;
            OperationContext operationContext = OperationContext.Current;
            var sessionId = operationContext.SessionId;
            var host = operationContext.Host as ServiceHost;
            
            contacts.Add(contact);
        }

        public Contact[] GetContacts()
        {
            return contacts.ToArray();
        }
    }
}
