using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SZTGUI_FF_T11_Logic;

namespace SZTGUI_FF_T11_Demo
{
    class MyIOC : SimpleIoc, IServiceLocator
    {
        public static MyIOC Instance { get; private set; } = new MyIOC();
    }
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => MyIOC.Instance);

            MyIOC.Instance.Register<ILoadAndSaveLogic, LoadAndSaveLogic>();
           
        }
    }
}
