using GBBDMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBBDMobile.Service
{
    public class NetManager
    {
        public static readonly string DTPPath = "jsonDTP.json";
        public static readonly string CarPath = "jsonCar.json";
        public static readonly string UserPath = "jsonUser.json";
        public static readonly string UsersOfDTPPath = "jsonUsersOfDTP.json";
        public static readonly string CarsOfDTPPath = "jsonCarsOfDTP.json";

        public static string CopyDTPPath { get => Path.Combine(FileSystem.Current.AppDataDirectory, "copyDTP.json"); }
        public static string CopyCarPath { get => Path.Combine(FileSystem.Current.AppDataDirectory, "copyCar.json"); }
        public static string CopyUserPath { get => Path.Combine(FileSystem.Current.AppDataDirectory, "copyUser.json"); }
        public static string CopyUsersOfDTPPath { get => Path.Combine(FileSystem.Current.AppDataDirectory, "copyUsersOfDTP.json"); }
        public static string CopyCarsOfDTPPath { get => Path.Combine(FileSystem.Current.AppDataDirectory, "copyCarsOfDTP.json"); }

        private static List<DTP> dTPs;
        public static List<DTP> DTPs
        {
            get
            {
                if (dTPs == null)
                {
                    dTPs = GetData<List<DTP>>(CopyDTPPath);
                }
                return dTPs;
            }
            set
            {
                dTPs = value;
                SetData<List<DTP>>(CopyDTPPath, dTPs);
            }
        }
        private static List<Car> cars;
        public static List<Car> Cars
        {
            get
            {
                if (cars == null)
                {
                    cars = GetData<List<Car>>(CopyCarPath);
                }
                return cars;
            }
            set
            {
                cars = value;
                SetData<List<Car>>(CopyCarPath, cars);
            }
        }
        private static List<User> users;
        public static List<User> Users
        {
            get
            {
                if (users == null)
                {
                    users = GetData<List<User>>(CopyUserPath);
                }
                return users;
            }
            set
            {
                users = value;
                SetData<List<User>>(CopyUserPath, users);
            }
        }

        private static List<UsersOfDTP> usersOfDTP;
        public static List<UsersOfDTP> UsersOfDTP
        {
            get
            {
                if (usersOfDTP == null)
                {
                    usersOfDTP = GetData<List<UsersOfDTP>>(CopyUsersOfDTPPath);
                }
                return usersOfDTP;
            }
            set
            {
                usersOfDTP = value;
                SetData<List<UsersOfDTP>>(CopyUsersOfDTPPath, usersOfDTP);
            }
        }


        private static List<CarsOfDTP> carsOfDTP;
        public static List<CarsOfDTP> CarsOfDTP
        {
            get
            {
                if (carsOfDTP == null)
                {
                    carsOfDTP = GetData<List<CarsOfDTP>>(CopyCarsOfDTPPath);
                }
                return carsOfDTP;
            }
            set
            {
                carsOfDTP = value;
                SetData<List<CarsOfDTP>>(CopyCarsOfDTPPath, carsOfDTP);
            }
        }

        private static void SetData<T>(string copyPath, T objec)
        {
            var jsondata = JsonConvert.SerializeObject(objec);
            File.WriteAllText(jsondata, copyPath);
        }

        private static T GetData<T>(string copyPath)
        {
            var data = JsonConvert.DeserializeObject<T>(File.ReadAllText(copyPath));
            return data;
        }

        internal static async void DataInit(string output, string source)
        {
            if (!File.Exists(output))
            {
                var file = File.Create(output);
                file.Close();
                File.WriteAllText(output, await ReaderAsset(source));
            }
        }

        private static async Task<string?> ReaderAsset(string source)
        {
            using (var stream = await FileSystem.OpenAppPackageFileAsync(source))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
