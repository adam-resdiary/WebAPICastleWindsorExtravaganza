using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Lifestyle;
using HandheldServer.Models;

namespace HandheldServer.DIInstallers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDeliveryItemRepository>().ImplementedBy<DeliveryItemRepository>().LifestylePerWebRequest(),
                Component.For<IDeliveryRepository>().ImplementedBy<DeliveryRepository>().LifestylePerWebRequest(),
                Component.For<IDepartmentRepository>().ImplementedBy<DepartmentRepository>().LifestylePerWebRequest(),
                Component.For<IExpenseRepository>().ImplementedBy<ExpenseRepository>().LifestylePerWebRequest(),
                Component.For<IInventoryItemRepository>().ImplementedBy<InventoryItemRepository>().LifestylePerWebRequest(),
                Component.For<IInventoryRepository>().ImplementedBy<InventoryRepository>().LifestylePerWebRequest(),
                Component.For<IItemGroupRepository>().ImplementedBy<ItemGroupRepository>().LifestylePerWebRequest());
        }
    }
}