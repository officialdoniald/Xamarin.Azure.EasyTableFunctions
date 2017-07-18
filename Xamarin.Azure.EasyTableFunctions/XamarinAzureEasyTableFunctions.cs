using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Xamarin.Azure.EasyTableFunctions
{
    public class XamarinAzureEasyTableFunctions
    {
        private static MobileServiceClient MobileService;

        public XamarinAzureEasyTableFunctions(string AzureURL)
        {
            MobileService = new MobileServiceClient(AzureURL);
        }

        public async Task<bool> DeleteInvMeDatabaseModel<T>(T model)
        {
            try
            {
                await MobileService.GetTable<T>().DeleteAsync(model);

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetInvMeDatabaseModel<T>(T model)
        {
            try
            {
                IEnumerable<T> modelList =
                    await MobileService.GetTable<T>().ReadAsync();

                return modelList;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool> InsertInvMeDatabaseModel<T>(T model)
        {
            try
            {
                await MobileService.GetTable<T>().InsertAsync(model);

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> UpdateInvMeDatabaseModel<T>(T model)
        {
            try
            {
                await MobileService.GetTable<T>().UpdateAsync(model);

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}
