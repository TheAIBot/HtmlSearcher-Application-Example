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
            //load all saved templates
            Templates = LoadAllTemplates();
        }

        public static void AddTemplate(LayoutTemplate Plate)
        {
            string SavePath = Path.Combine(DirectoryName, Plate.Name);
            Tools.SaveAsXML<LayoutTemplate>(Plate, SavePath);
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
            string DeletePath = Path.Combine(DirectoryName, ToChange.Name);
            File.Delete(DeletePath);

            string SavePath = Path.Combine(DirectoryName, ChangeTo.Name);
            Tools.SaveAsXML<LayoutTemplate>(ChangeTo, SavePath);

            Templates = LoadAllTemplates();
        }

        public static List<LayoutTemplate> LoadAllTemplates()
        {
            List<LayoutTemplate> Plates = new List<LayoutTemplate>();
            foreach (string FilePath in Directory.GetFiles(DirectoryName))
            {
                Plates.Add(Tools.LoadAsXML<LayoutTemplate>(FilePath));
            }
            return Plates;
        }
    }

    [Serializable]
    public class LayoutTemplate
    {
        public string Name;
        public List<GroupToFind> Groups = new List<GroupToFind>();
        public string Structure;

        public bool UseConverter = false;
        public WordConverter Converter;
    }
}
