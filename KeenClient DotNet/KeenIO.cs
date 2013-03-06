using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeenClient_DotNet
{
    public class KeenIO
    {
        /// <summary>
        /// Versionses this instance.
        /// </summary>
        public void Versions()
        {
            var reply = CallKeenWebService();
        }

        private object CallKeenWebService()
        {
            throw new NotImplementedException();
        }
        public void Discovery()
        {
        }
        public void Projects()
        {
        }
        public void ProjectRow()
        {
        }
        public void Event()
        {
        }
        public void EventCollection()
        {
        }
        public void Queries()
        {
        }
        public void Count()
        {
        }
        public void CountUnique()
        {
        }
        public void Minimum()
        {
        }
        public void Maximum()
        {
        }
        public void Average()
        {
        }
        public void Sum()
        {
        }
        public void SelectUnique()
        {
        }
        public void Extraction()
        {
        }
        public void FunnelResource()
        {
        }
        public void SavedQueriesList()
        {
        }
        public void SavedQueryRow()
        {
        }
        public void SavedQuieryRowResult()
        {
        }
    }

    public class KeenUser
    {
        public string APIKEY { get; set; }

    }
}
