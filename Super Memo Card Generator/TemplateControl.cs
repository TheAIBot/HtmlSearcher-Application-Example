using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using HtmlSearcher;

namespace Super_Memo_Card_Generator
{
    public static class TemplateControl
    {
        private const string DirectoryName = "Templates";
        public static List<LayoutTemplate> Templates = new List<LayoutTemplate>();

        internal static void LoadEverything()
        {
            //create directory to store the templates in, if it doesn't exist
            if (!Directory.Exists(DirectoryName))
            {
                Directory.CreateDirectory(DirectoryName);
            }
            //if the default template doesn't exists then it's created and saved to the Template directory
            if (!File.Exists(Path.Combine(DirectoryName, new LayoutTemplate().Name)))
            {
                LayoutTemplate Plate = new LayoutTemplate();
                Plate.IsDefault = true;
                string SavePath = Path.Combine(DirectoryName, Plate.Name);
                Tools.SaveAsXML<LayoutTemplate>(Plate, SavePath);
            }
            //load all saved templates
            Templates = LoadAllTemplates();
        }

        public static void AddTemplate(LayoutTemplate Plate)
        {
            string SavePath = Path.Combine(DirectoryName, Plate.Name);
            Tools.SaveAsXML<LayoutTemplate>(Plate, SavePath);
            if (Plate.IsDefault)
            {
                LayoutTemplate TPlate = Templates.Single(x => x.IsDefault);
                TPlate.IsDefault = false;
                Tools.SaveAsXML<LayoutTemplate>(Plate, SavePath);
            }
            Templates.Add(Plate);
        }

        public static void RemoveTemplate(LayoutTemplate Plate)
        {
            Templates.Remove(Plate);
            File.Delete(Path.Combine(DirectoryName, Plate.Name));
        }

        public static void SaveTemplate(LayoutTemplate Plate)
        {
            string SavePath = Path.Combine(DirectoryName, Plate.Name);
            Tools.SaveAsXML<LayoutTemplate>(Plate, SavePath);
        }

        public static void ChangeTemplate(LayoutTemplate ToChange, LayoutTemplate ChangeTo)
        {
            if (!ToChange.IsDefault && ChangeTo.IsDefault)
            {
                LayoutTemplate TPlate = Templates.Single(x => x.IsDefault);
                TPlate.IsDefault = false;
                string SavePath = Path.Combine(DirectoryName, TPlate.Name);
                Tools.SaveAsXML<LayoutTemplate>(TPlate, SavePath);
            }
            File.Delete(Path.Combine(DirectoryName, ToChange.Name));
            string SavePath2 = Path.Combine(DirectoryName, ChangeTo.Name);
            Tools.SaveAsXML<LayoutTemplate>(ChangeTo, SavePath2);
            Templates = LoadAllTemplates();
        }

        public static List<LayoutTemplate> LoadAllTemplates()
        {
            List<LayoutTemplate> Plates = new List<LayoutTemplate>();
            foreach (string FilePath in Directory.GetFiles(DirectoryName))
            {
                using (FileStream FStream = new FileStream(FilePath, FileMode.Open))
                {
                    XmlSerializer Serializer = new XmlSerializer(typeof(LayoutTemplate));
                    LayoutTemplate TPlate = (LayoutTemplate)Serializer.Deserialize(FStream);
                    Plates.Add(TPlate);
                }
            }
            return Plates;
        }
    }

    [Serializable]
    public class LayoutTemplate
    {
        public string Name = "Default Template";
        public string Structure = "q: {1}" + Environment.NewLine +
                                  "a: {2}" + Environment.NewLine + Environment.NewLine;
        public Boolean IsDefault = false;
        public int AmountOfTexts = 2;
        public Boolean UnlimitedCards = true;
        public int MaxCards = int.MaxValue;

        public bool UseConverter = false;
        public WordConverter Converter;
    }
}
