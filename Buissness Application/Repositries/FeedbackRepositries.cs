using Buissness_Application.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buissness_Application.Repositries
{
    public class FeedbackRepositries
    {
        private readonly string _FeedbackFile = "C:\\BSCS_2nd_Semester\\OOP Programming\\Buissness Project\\Buissness Application\\FeedbackRecord.txt";
        public void SaveObject(FeedbackModel review)
        {
            using (StreamWriter write = new StreamWriter(_FeedbackFile, true))
            {
                write.WriteLine(review.ToString());
            }
        }
        public void SaveList(List<FeedbackModel> FeedbackList)
        {
            ClearData();
            using (StreamWriter write = new StreamWriter(_FeedbackFile, true))
            {
                foreach (var i in FeedbackList)
                {
                    write.WriteLine(i.ToString());
                }
            }
        }
        public string GetField(string record, int field)
        {
            int commaCount = 1;
            string word = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    word = word + record[i];
                }
            }
            return word;
        }
        public List<FeedbackModel> GetData()
        {
            List<FeedbackModel> FeedbackList = new List<FeedbackModel>();
            FeedbackModel review = new FeedbackModel();
            StreamReader read = new StreamReader(_FeedbackFile);
            string details;
            while ((details = read.ReadLine()) != null)
            {
                string rating = GetField(details, 1);
                review.rating = float.Parse(rating);
                review.feedback = GetField(details, 2);
                review.name = GetField(details, 3);
                FeedbackList.Add(new FeedbackModel(review.rating, review.feedback, review.name));
            }
            read.Close();
            return FeedbackList;
        }
        public void ClearData()
        {
            File.WriteAllText(_FeedbackFile, string.Empty);
        }
    }
}
