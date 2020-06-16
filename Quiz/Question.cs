using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Quiz
{
    class Question
    {
        /// <summary>
        /// Picture for "View"
        /// </summary>
        public BitmapImage Picture { get; set; }

        /// <summary>
        /// Answer for Picture
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// Question Creation
        /// </summary>
        /// <param name="PathBitmapImageSource">A path to a picture</param>
        /// <param name="AnswerSource">An answer</param>
        
        public Question(string PathBimapImageSource, string AnswerSource)
        {
            this.Picture = new BitmapImage();
            this.Picture.BeginInit();
            this.Picture.UriSource = new Uri(PathBimapImageSource, UriKind.Relative);
            this.Picture.EndInit();
            this.Answer = AnswerSource;
        }
    }
}
