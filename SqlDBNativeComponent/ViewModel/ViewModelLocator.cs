﻿using System;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace SqlDBNativeComponent.ViewModel
{
    /// <summary>
    /// This class will contain static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel MainVm
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        public static void Cleanup()
        {

        }
    }
}
