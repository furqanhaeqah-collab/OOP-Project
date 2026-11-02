using Buissness_Application.Model;
using Buissness_Application.Repositries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buissness_Application.Service
{
    public class FeedbackService
    {
        private readonly FeedbackRepositries _repositry;
        private List<FeedbackModel> FeedbackList;
        public FeedbackService()
        {
            _repositry = new FeedbackRepositries();
            FeedbackList = _repositry.GetData();
        }
        public void AddFeedback(FeedbackModel review)
        {
            _repositry.SaveObject(review);
        }
        public List<FeedbackModel> GetFeedback()
        {
            return _repositry.GetData();
        }
        public FeedbackModel FindFeddbackByName(string name)
        {
            foreach(var feedback in FeedbackList)
            {
                if(name == feedback.name)
                {
                    return feedback;
                }
            }
            return null;
        }
        public void DeleteFeedback(FeedbackModel review)
        {
            FeedbackList.Remove(review);
            _repositry.SaveList(FeedbackList);
        }
    }
}