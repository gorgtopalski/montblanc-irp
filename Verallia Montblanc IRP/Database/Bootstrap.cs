using IRP.Domain;
using IRP.Services;
using System;
using System.IO;
using System.Linq;

namespace IRP.Database
{
    public class Bootstrap
    {
        public static void LoadData()
        {
            LoadModels();
            LoadLines();
            LoadDefectTypes();
            LoadDefects();
            LoadRejectionStates();
        }

        //Line reader for the CSV files
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

        // Will try to load the default rejection states from the provided CSV file
        private static void LoadRejectionStates()
        {
            if (Properties.Resources.PaletRejectStates == null) return;

            var service = new BaseService<RejectionState>();

            Reader(Properties.Resources.PaletRejectStates, delegate (string s)
            {
                var state = new RejectionState { State = s.Split(',').First().Trim() };

                if (!state.Validate()) return;
                if (!service.GetAll().Exists(x => x.Equals(state)))
                    service.Save(state);
            });

        }

        //Will try to load the default models from the provided CSV file
        private static void LoadModels()
        {
            if (Properties.Resources.Models == null) return;

            var service = new BaseService<Model>();

            Reader(Properties.Resources.Models, delegate (string s)
            {
                var model = new Model
                {
                    Name = s.Split(',').First().Trim(),
                    Blueprint = s.Split(',').Last().Trim()
                };
                if (!model.Validate()) return;
                if (!service.GetAll().Exists(x => x.Equals(model)))
                    service.Save(model);
            });
        }

        //Will try to load the default lines from the provided CSV file
        private static void LoadLines()
        {
            if (Properties.Resources.Lines == null) return;

            var service = new BaseService<Line>();

            Reader(Properties.Resources.Lines, delegate (string s)
            {
                var line = new Line { Name = s.Split(',').First().Trim() };

                if (!line.Validate()) return;
                if (!service.GetAll().Exists(x => x.Equals(line)))
                    service.Save(line);
            });
        }

        //Will try to load the default defect types from the provided CSV file
        private static void LoadDefectTypes()
        {
            if (Properties.Resources.DefectTypes == null) return;

            var service = new BaseService<DefectType>();

            Reader(Properties.Resources.DefectTypes, delegate (string s)
            {
                var name = s.Split(',').First().Trim();
                if (!int.TryParse(s.Split(',').Last().Trim(), out var severity)) return;
                var defectType = new DefectType
                {
                    Name = name,
                    Severity = severity
                };
                if (!defectType.Validate()) return;
                if (!service.GetAll().Exists(x => x.Equals(defectType)))
                    service.Save(defectType);
            });
        }

        //Will try to load the default defects from the provided CSV file
        private static void LoadDefects()
        {
            if (Properties.Resources.Defects == null) return;

            var service = new DefectService();

            Reader(Properties.Resources.Defects, delegate (string s)
            {
                var defName = s.Split(',')[2].Trim();
                var def = new BaseService<DefectType>().GetAll().Find(x => x.Name == defName);

                var defect = new Defect
                {
                    Name = s.Split(',')[0].Trim(),
                    FullName = s.Split(',')[1].Trim(),
                    DefectType = def
                };
                if (!defect.Validate()) return;
                if (!service.GetAll().Exists( x => x.Equals(defect)))
                    service.Save(defect);
            });
        }
    }
}
