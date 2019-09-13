using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFlowManager.Models
{
    public class Question : BaseModel
    {
        public string QuestionText { get; set; }
        public int QuestionId { get; set; }
        public int CourseId { get; set; }
        public Choice Choices { get; set; }
        public Answer Answers { get; set; }
        public string Course { get; set; }

    }
    public class Choice
    {
        public int CHoiceId { get; set; }
        public string ChoiceText { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
