using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MDKDataReaderV1.Model
{
    public class QueryManager
    {

        public ObservableCollection<PatientModel> lstPatient { set; get; }
        public ObservableCollection<string> lstCheckType { set; get; }

        public void Init()
        {
            lstCheckType = new ObservableCollection<string>();
            lstCheckType.Add("胃镜");
            lstCheckType.Add("肠镜01");
            lstCheckType.Add("胃镜");
            lstCheckType.Add("胃镜01");
            lstCheckType.Add("肠镜");
            lstCheckType.Add("胃镜");
            lstCheckType.Add("肠镜02");
            lstCheckType.Add("胃镜55");
            lstCheckType.Add("肠镜6");
            lstCheckType.Add("胃镜1111");
            lstCheckType.Add("肠镜01");
            lstCheckType.Add("胃镜");
            lstCheckType.Add("胃镜01");
            lstCheckType.Add("肠镜");
            lstCheckType.Add("胃镜");
            lstCheckType.Add("肠镜02");
            lstCheckType.Add("胃镜55");
            lstCheckType.Add("肠镜6");
            lstPatient = new ObservableCollection<PatientModel>();
            lstPatient.Add(new PatientModel(1, 001, "AAA", "男", 20, "无痛胃镜", "电子无痛胃镜", 0002, "2019-12-20 14:10"));
            lstPatient.Add(new PatientModel(2, 001, "BBB", "男", 20, "无痛胃镜", "电子无痛胃镜", 0002, "2019-12-20 14:10"));
            lstPatient.Add(new PatientModel(3, 001, "CCC", "男", 20, "无痛胃镜", "电子无痛胃镜", 0002, "2019-12-20 14:10"));
            lstPatient.Add(new PatientModel(4, 001, "DDD", "男", 20, "无痛胃镜", "电子无痛胃镜", 0002, "2019-12-20 14:10"));
            lstPatient.Add(new PatientModel(5, 001, "EEE", "男", 20, "无痛胃镜", "电子无痛胃镜", 0002, "2019-12-20 14:10"));
            lstPatient.Add(new PatientModel(6, 001, "FFF", "男", 20, "无痛胃镜", "电子无痛胃镜", 0002, "2019-12-20 14:10"));
            lstPatient.Add(new PatientModel(7, 001, "GGG", "男", 20, "无痛胃镜", "电子无痛胃镜", 0002, "2019-12-20 14:10"));
            
        }
    }
}
