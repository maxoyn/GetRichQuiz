using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GetRich
{

    class Question
    {
        public Question(string Text, string Answers, string C_answer, string Info)
        {
            text = Text;
            answers = Answers;
            c_answer = C_answer;
            info = Info;
        }
        public string text { get; set; }
        public string answers { get; set; }
        public string c_answer { get; set; }
        public string info { get; set; }

    }



    class Program
    {
        public static Question[] qq = new Question[8];

        private static void LoadQuestions()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\CH\source\repos\GetRich\GetRich\GetRich\QXML.xml");
            string text, answers, c_answer, info;

            int i = 0;
            foreach (XmlNode node in doc.DocumentElement)
            {
                text = node.Attributes[0].InnerText;
                answers = node.ChildNodes[0].InnerText;
                c_answer = node.ChildNodes[1].InnerText;
                info = node.ChildNodes[2].InnerText;

                qq[i] = new Question(text, answers, c_answer, info);
                i++;
            }

        }

        static void Main(string[] args)
        {
            LoadQuestions();
            foreach (Question q in qq)
            {
                Console.WriteLine(q.text + "\n" + q.answers);
                if (Console.ReadLine().ToUpper() == q.c_answer)
                {
                    Console.WriteLine("Correct! Would you like some info? Y/N:");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        Console.WriteLine(q.info);
                        Console.WriteLine("");
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect! Game over.");
                    Console.ReadKey();
                    return;
                }
            }
            Console.ReadKey();
        }
    }
}
