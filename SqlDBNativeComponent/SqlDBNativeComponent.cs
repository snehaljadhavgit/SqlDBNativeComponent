using System;
using SqlDBNativeComponent.ViewModel;

namespace SqlDBNativeComponent
{

    public class SqlDBNativeComponent
    {
        SqlDBNativeComponent() { }

        static SqlDBNativeComponent _instance;

        public static SqlDBNativeComponent Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SqlDBNativeComponent();
                }
                return _instance;
            }
        }

        static ViewModelLocator locator;

        public static ViewModelLocator Locator
        {
            get
            {
                if (locator == null)
                {
                    locator = new ViewModelLocator();
                }

                return locator;
            }
        }

        internal class AdditionalDetails
        {
        }
    }
}
