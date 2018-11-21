using System;
namespace SqlDBNativeComponent.Helper
{
    public static class StringConstants
    {
        public const string EMPLOYEE_LIST_PAGETITLE = "Employees List";

        public static readonly string API_EMPLOYEE = "/api/allemployees";

        public const string OK = "Ok";
        public const string TRY_AGAIN = "Try again";
        public const string CANCEL = "Cancel";
        public const string SUCCESS = "Success";
        public const string FAILURE = "Failure";
        public const string DOWNLOAD_ERROR = "Download Error";
        public const string CONNECTIVITY_ERROR = "Connectivity Error";
        public const string NO_INTERNET_CONNECTION = "No internet connection, please connect your phone to internet";
        public const string DOWNLOAD_EMPLOYEE_FAIL = "Failed to download employees data. Please try again after some time";
        public static readonly string EMPLOYEE_JSON_FILE = "ACI_GPS.Data.employee.json";
    }
}
