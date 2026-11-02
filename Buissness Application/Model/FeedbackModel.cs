using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buissness_Application.Model
{
    public class FeedbackModel
    {
        public float rating;
        public string feedback;
        public string name;
        public FeedbackModel () { }
        public FeedbackModel(float rating, string feedback, string name)
        {
            this.rating = rating;
            this.feedback = feedback;
            this.name = name;
        }
        public override string ToString()
        {
            return rating + "," + feedback + "," + name;
        }
    }
}
