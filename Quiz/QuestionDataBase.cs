using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class QuestionDataBase
    {
        /// <summary>
        /// The question collection
        /// </summary>
        private List<Question> dB;

        /// <summary>
        /// Current question index
        /// </summary>
        private int index;

        /// <summary>
        /// The current question
        /// </summary>
        public Question CurrentQuestion
        {
            get
            {
                index++;
                return dB[index % dB.Count];
            }
        }

        /// <summary>
        /// "QuestionDb" creation
        /// </summary>
        public QuestionDataBase()
        {
            this.dB = new List<Question>();
            this.index = 0;
            //Debug.WriteLine(@"..\..\Images\answers.txt");

            var dateFile = File.ReadAllLines(@"..\..\Images\answers.txt");

            foreach (var e in dateFile)
            {
                var args = e.Split('W');
                dB.Add(new Question(args[0], args[1]));
            }
        }
    }
}
