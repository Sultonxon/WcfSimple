using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfSimple
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IContactManager1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IContactManager1
    {
        [OperationContract]
        void AddContact(Contact contact);

        [OperationContract]
        Contact[] GetContacts();
    }

    [DataContract]
    public class Contact
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }
        
        [OnSerializing]
        public void OnSerializing(StreamingContext context)
        {
            
        }
    }

    [DataContract]
    [KnownType(typeof(Customer))]
    public class Customer : Contact
    {
        [DataMember]
        public int CustomerNumber { get; set; }
    }
}
