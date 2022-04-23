using CommonServiceLocator;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using XCWED2_SG1_21_22_2.WpfClient.BL.Implementation;
using XCWED2_SG1_21_22_2.WpfClient.BL.Interfaces;
using XCWED2_SG1_21_22_2.WpfClient.Infrastructure;

namespace XCWED2_SG1_21_22_2.WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIocAsServiceLocator.Instance);

            SimpleIocAsServiceLocator.Instance.Register<IBoardGameEditorService, BoardGameEditorViaWindowService>();
            SimpleIocAsServiceLocator.Instance.Register<IBoardGameDisplayService, BoardGameDisplayService>();
            SimpleIocAsServiceLocator.Instance.Register<IBoardGameHandlerService, BoardGameHandlerService>();
            SimpleIocAsServiceLocator.Instance.Register(() => Messenger.Default);
        }
    }
}
