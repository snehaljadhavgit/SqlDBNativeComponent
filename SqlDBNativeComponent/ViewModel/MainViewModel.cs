using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using Plugin.Connectivity;
using PropertyChanged;
using SqlDBNativeComponent.Helper;
using SqlDBNativeComponent.Models;

namespace SqlDBNativeComponent.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel : ViewModelBase
    {
        INavigationService navigationService { get => ServiceLocator.Current.GetInstance<INavigationService>(); }

        public ObservableCollection<Employee> AllEmployees { get; set; } = new ObservableCollection<Employee>();

        public MainViewModel()
        {

        }

        public async Task<bool> DownloadAllEmployeesData()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                UserDialogs.Instance.ShowLoading("");

                if (await DownloadManager.DownloadManagerInstance.DownloadAllEmployeesData())
                {
                    UserDialogs.Instance.HideLoading();

                    return true;
                }

                UserDialogs.Instance.HideLoading();

                //Show error alert to the user 
                var tryAgain = await UserDialogs.Instance.ConfirmAsync(StringConstants.DOWNLOAD_EMPLOYEE_FAIL,
                                                                       StringConstants.DOWNLOAD_ERROR,
                                                                       StringConstants.TRY_AGAIN,
                                                                       StringConstants.CANCEL, null);

                if (tryAgain)
                {
                    await DownloadAllEmployeesData();
                }
            }
            else
            {
                UserDialogs.Instance.HideLoading();

                //Show no connectivity alert to the user 
                await UserDialogs.Instance.AlertAsync(StringConstants.NO_INTERNET_CONNECTION,
                                                      StringConstants.CONNECTIVITY_ERROR,
                                                      StringConstants.OK, null);
            }

            return false;
        }

        public void BuildEmployeeList()
        {
            Stream dataStream;

            string employeeList = string.Empty;

            var assembly = typeof(MainViewModel).GetTypeInfo().Assembly;

            dataStream = assembly.GetManifestResourceStream(StringConstants.EMPLOYEE_JSON_FILE);

            if (dataStream != null)
            {
                using (var reader = new StreamReader(dataStream))
                {
                    employeeList = reader.ReadToEnd();
                }
            }
        
            SqlDBNativeComponent.Locator.MainVm.AllEmployees = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(employeeList);

        }

        public void AddEmployee(string txtName, string txtPhoneNum, string txtEmailId, string txtDOB)
        {
            Employee emp = new Employee();
            emp.Name = txtName;
            emp.Phone = txtPhoneNum;
            emp.EmailId = txtEmailId;
            emp.DOB = txtDOB;
            int a = SqlDBNativeComponent.Locator.MainVm.AllEmployees.Count + 1;
            emp.Id = a + 100;
            SqlDBNativeComponent.Locator.MainVm.AllEmployees.Add(emp);

        }

        public void SaveEmployeeInDB(RegEntity reg,SqlHelper Database){

            Database.SaveItem(reg);
        }
        public RegEntity GetEmp(string empUName, SqlHelper Database)
        {
            return Database.GetItem(empUName);
        }
    }
}
