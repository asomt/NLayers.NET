using NLayers.BusinessLogic.Contracts;
using NLayers.DataAccess.Contracts;
using NLayers.Entites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayers.BusinessLogic.Managers
{
    public class DummyManager : IDummyManager
    {
        public IDummyStore DummyStore { get; set; }

        public DummyManager(IDummyStore dummyStore)
        {
            DummyStore = dummyStore;
        }

        public void ManagerDummyMethod()
        {
            //Logica de negocio y validaciones
            DummyStore.StoreDummyMethod();

            DummyStore.OtherStoreDummyMethod();
        }
    }
}
