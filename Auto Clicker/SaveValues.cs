using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Forms;


namespace Auto_Clicker
{
    internal class SaveValues
    {
        public string Name;
        public int NumberToRepeat;
        public List<CursorPositionValue> CusorPositions;

        public SaveValues(string StrName, int NbrRepeat, List<CursorPositionValue>  CursorVals)
        {
            Name = StrName;
            NumberToRepeat = NbrRepeat;
            CusorPositions = CursorVals;
        }
    }

    internal class CursorPositionValue
    {
        public int X;
        public int Y;
        public bool RightClick;
        public int Sleep;

        public CursorPositionValue(int _X, int _Y, bool _RightClick = false, int _Sleep = 1000)
        {
            X = _X;
            Y = _Y;
            RightClick = _RightClick;
            Sleep = _Sleep;
        }
    }

    internal static class SaveHelper
    {
        public static void SaveEverything(string Name, TextBox NumRepeatsTextBox, ListView PositionsListView)
        {
            SaveValues sv = CreateSaveObject(Name, NumRepeatsTextBox, PositionsListView);
            string svJSON = ConvertSaveValuesToJSON(sv);
            SaveJSON(Name, svJSON);
        }

        public static SaveValues LoadEverything(string Name)
        {
            string svJSON = LoadJSON(Name);
            if(string.IsNullOrEmpty(svJSON))
                return null;

            SaveValues sv = LoadSaveValuesFromJSON(svJSON);
            return sv;
        }

        private static SaveValues CreateSaveObject(string Name, TextBox NumRepeatsTextBox, ListView PositionsListView)
        {
            List<CursorPositionValue> AllCursorVals = new List<CursorPositionValue>();
            foreach (ListViewItem item in PositionsListView.Items)
            {
                int X = Convert.ToInt32(item.Text);
                int Y = Convert.ToInt32(item.SubItems[1].Text);
                bool RightClick = item.SubItems[2].Text == "R" ? true : false;
                int Sleep = Convert.ToInt32(item.SubItems[3].Text);
                CursorPositionValue curson = new CursorPositionValue(X, Y, RightClick, Sleep);
                AllCursorVals.Add(curson);
            }
            int Repeat = Convert.ToInt32(NumRepeatsTextBox.Text);
            SaveValues save = new SaveValues(Name, Repeat, AllCursorVals);
            return save;
        }

        private static string ConvertSaveValuesToJSON(SaveValues save)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(save);
            return json;
        }

        private static SaveValues LoadSaveValuesFromJSON(string json)
        {
            SaveValues fromJSON = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveValues>(json);
            return fromJSON;
        }

        private static void SaveJSON(string Name, string JSON)
        {
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            if (isoStore.FileExists($@"{Name}.json"))
            {
                Console.WriteLine("The file already exists... Overwriting!");
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream($@"{Name}.json", FileMode.Truncate, isoStore))
                {
                    
                    using (StreamWriter writer = new StreamWriter(isoStream))
                    {
                        writer.Write(JSON);
                    }
                }
            }
            else
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream($@"{Name}.json", FileMode.CreateNew, isoStore))
                {
                    using (StreamWriter writer = new StreamWriter(isoStream))
                    {
                        writer.Write(JSON);
                    }
                }
            }
        }

        private static string LoadJSON(string Name)
        {
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            string JSON = "";
            if (isoStore.FileExists($@"{Name}.json"))
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream($@"{Name}.json", FileMode.Open, isoStore))
                {
                    using (StreamReader reader = new StreamReader(isoStream))
                    {
                        Console.WriteLine("Reading contents:");
                        JSON = reader.ReadToEnd();
                    }
                }
            }
            else
            {
                Console.WriteLine("No save file found with that name!");
            }

            return JSON;
            
        }

        public static List<string> GetSaveFileList()
        {
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            List<string> fileList = new List<String>(isoStore.GetFileNames($@"*.json"));

            for (int i = 0; i < fileList.Count; i++)
                fileList[i] = fileList[i].Replace(".json", "");

            fileList.Remove("Default");

            return fileList;
        }

    }
}
