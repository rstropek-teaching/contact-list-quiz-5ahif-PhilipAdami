using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactList.Services;

namespace ContactUnitTests
{
    [TestClass]
    public class ContactTests
    {
        [TestMethod]
        public void FindFabian()
        {
            string name = "Fabian";
            ContactRepository cr = new ContactRepository();
            Assert.IsNotNull(cr.FindByName(name));
        }
        [TestMethod]
        public void DeleteSomeone()
        {
            ContactRepository cr = new ContactRepository();
            cr.DeleteById(1);
            Assert.Equals(1, cr.GetList().Count);
        }
    }
}
