using System;
using System.IO;
using System.Linq;
using Vanilla_IRP.Domain;

namespace Vanilla_IRP.Database
{
    public class Bootstrap
    {
        public static void LoadData()
        {
            LoadModels();
            LoadLines();
            LoadDefectTypes();
            LoadDefects();
        }

        private static void Reader(string resource, Action<string> action)
        {
            using (var sr = new StringReader(resource))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    action.Invoke(line);
                }
            }
        }

        //Will try to load the default list from the provided CSV file and map it to the LiteDB
        private static void LoadModels()
        {
            if (Properties.Resources.Models == null) return;
            Reader(Properties.Resources.Models, delegate (string s)
            {
                var model = new Model
                {
                    Name = s.Split(',').First().Trim(),
                    Blueprint = s.Split(',').Last().Trim()
                };

                if (!CommonsDb.Db().Query<Model>().Where(x => x.Equals(model)).Exists())
                {
                    CommonsDb.Db().Insert(model);
                }
            });
        }

        private static void LoadLines()
        {
            if (Properties.Resources.Lines == null) return;
            Reader(Properties.Resources.Lines, delegate (string s)
            {
                var line = new Line { Name = s };
                if (!CommonsDb.Db().Query<Line>().Where(x => x.Equals(line)).Exists())
                {
                    CommonsDb.Db().Insert(line);
                }
            });
        }

        private static void LoadDefectTypes()
        {
            if (Properties.Resources.DefectTypes == null) return;
            Reader(Properties.Resources.DefectTypes, delegate (string s)
            {
                var name = s.Split(',').First().Trim();
                if (Int32.TryParse(s.Split(',').Last().Trim(), out var severity))
                {
                    var defectType = new DefectType
                    {
                        Name = name,
                        Severity = severity
                    };
                    if (!CommonsDb.Db().Query<DefectType>().Where(x => x.Equals(defectType)).Exists())
                    {
                        CommonsDb.Db().Insert(defectType);
                    }
                }
            });
        }
        private static void LoadDefects()
        {
            if (Properties.Resources.Defects == null) return;
            Reader(Properties.Resources.Defects, delegate (string s)
            {
                var name = s.Split(',')[0].Trim();
                var fullName = s.Split(',')[1].Trim();
                var defName = s.Split(',')[2].Trim();
                var def = CommonsDb.Db().Query<DefectType>().Where(x => x.Name == defName).First();

                var defect = new Defect
                {
                    Name = name,
                    FullName = fullName,
                    DefectType = def
                };
                if (!CommonsDb.Db().Query<Defect>()
                    .Include(x => x.DefectType)
                    .Where(x => x.Equals(defect))
                    .Exists())
                {
                    CommonsDb.Db().Insert(defect);
                }
            });
        }


    }
}
