using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalReco
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        Dictionary<string, Dictionary<string, double>> Recommendations;
        
        
        
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            Shashvat();
            btnLoadData.Enabled = false;
        }


        private void btnRecommend_Click(object sender, EventArgs e)
        {
            Shashvat();
            int numberOfResults = 0;
            int temp;
            bool suc=Int32.TryParse(input1.Text, out temp);
            if (input1.TextLength == 0 || temp>942 || temp<0)
                MessageBox.Show("Please enter a valid User ID", "Invalid Input");
            else if (suc==false)
            {
                MessageBox.Show("User ID should be an integer!","Invalid Format of Input!");
            }
            else if (!Int32.TryParse(input2.Text, out numberOfResults) && input2.TextLength!=0)
            {
                MessageBox.Show("Number of results should be an integer!", "Invalid Format of Input!");
            }
            else
            {
                txtcon.AppendText("\t\t*****************************\n");
                txtcon.AppendText("Starting the module...");
                txtcon.AppendText(Environment.NewLine);
                txtcon.AppendText(Environment.NewLine);

                

                var Similarities = RankCritics(input1.Text);

                //Sorting in Descending order using LINQ
                var items = from pair in Similarities
                            orderby pair.Value descending
                            where pair.Value != -1
                            select pair;

                txtcon.AppendText(Environment.NewLine);
                txtcon.AppendText("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
                
                txtcon.AppendText(Environment.NewLine);
                
                txtcon.AppendText(Environment.NewLine);


                var notWatch = notWatched();
                //Make a list of all the final Scores and sort them in descending order
                Dictionary<string, double> Scores = new Dictionary<string, double>();

                double finalScore;
                foreach (string s in notWatch)
                {
                    finalScore = getRecommendationsScoreM(Similarities, input1.Text, s);
                    Scores.Add(s, finalScore);
                    //txtcon.AppendText(Environment.NewLine);
                    //txtcon.AppendText(s + " : " + finalScore.ToString());
                    //txtcon.AppendText(Environment.NewLine);
                }


                int counter = 1;
                if (input2.TextLength != 0)
                {
                    Int32.TryParse(input2.Text, out numberOfResults);
                    var sortedScores = (from pair in Scores
                                        orderby pair.Value descending
                                        where pair.Value != -1
                                        select pair).Take(numberOfResults);
                    foreach (KeyValuePair<string, double> score in sortedScores)
                    {
                        //txtcon.AppendText(counter + "\t" + score.Key + "\t" + " : " + score.Value);
                        txtcon.AppendText(counter + "\t" + score.Value.ToString("0.00") + "\t:\t" + score.Key);
                        txtcon.AppendText(Environment.NewLine);
                        counter++;
                    }
                }
                else
                {
                    
                    var sortedScores = from pair in Scores
                                       orderby pair.Value descending
                                       where pair.Value != -1
                                       select pair;
                    foreach (KeyValuePair<string, double> score in sortedScores)
                    {
                        //txtcon.AppendText(counter + "\t" + score.Key + "\t" + " : " + score.Value);
                        txtcon.AppendText(counter + "\t" + score.Value.ToString("0.00") + "\t:\t" + score.Key);
                        txtcon.AppendText(Environment.NewLine);
                        counter++;
                    }
                }


            }
            


        }
       

        //Function to print all the ratings of all the movies by all the critics

        public void PrintData()
        {
            var Dic = Shashvat();
            foreach (KeyValuePair<string, Dictionary<string, double>> pair in Dic)
            {
                txtcon.AppendText("Critic Name : " + pair.Key);
                txtcon.AppendText(Environment.NewLine);
                foreach (KeyValuePair<string, double> movie in pair.Value)
                {
                    txtcon.AppendText('\t' + movie.Key + " :: " + movie.Value);
                    txtcon.AppendText(Environment.NewLine);
                }
                txtcon.AppendText(Environment.NewLine);
                txtcon.AppendText("\t***********************");
                txtcon.AppendText(Environment.NewLine);
            }
        }

        //Function to combine user.item and u.data 
        public Dictionary<string, Dictionary<string, double>> Shashvat()
        {
            //Gets 1000 movie ratings
            string[] text = System.IO.File.ReadLines(@"D:\Visual Studio 2010\Projects\Recommender\DatasetOfMovieRatings\u.data").Take(100000).ToArray();
            int counter = 0;
            Dictionary<string, Dictionary<string, double>> extDic = new Dictionary<string, Dictionary<string, double>>();
            var movieData = getMovieNameAndID();
            foreach (string s in text)
            {
                int rating;
                string[] splitted = s.Split('\t');

                string username = splitted[0];
                string movieID = splitted[1];
                string movieName = movieData[movieID];
                Int32.TryParse(s.Split('\t')[2], out rating);

                if (!extDic.ContainsKey(username))
                {
                    //create a new dictionary for every new user
                    extDic.Add(username, new Dictionary<string, double>());
                }

                extDic[username][movieName] = rating;
               
                counter++;
            }

            //Recommendations.Clear();
            Recommendations = extDic;
            return extDic;
        }

        public Dictionary<string, string> getMovieNameAndID()
        {
            
            string[] text = System.IO.File.ReadLines(@"D:\Visual Studio 2010\Projects\Recommender\DatasetOfMovieRatings\u.item").ToArray();

            Dictionary<string, string> NameAndID = new Dictionary<string, string>();
            txtcon.AppendText(Environment.NewLine);
            foreach (string s in text)
            {
                string moviename = s.Split('|')[1];
                string movieID = s.Split('|')[0];
                NameAndID.Add(movieID, moviename);
            }

            return NameAndID;
        }



        //Get Recommendations - MOVIE WISE
        public double getRecommendationsScoreM(Dictionary<string, double> similarities, string name, string movie)
        {

            string other;
            double weightedSimilarity = 0;
            int counter = 0;
            double simSum = 0;

            foreach (KeyValuePair<string, Dictionary<string, double>> cr in Recommendations)
            {
                if (name != cr.Key)
                {
                    other = cr.Key;
                    foreach (KeyValuePair<string, double> pair in Recommendations[other])
                    {
                        if (pair.Key == movie)
                        {
                            if (similarities[other] > 0)
                            {
                                weightedSimilarity += pair.Value * similarities[other];
                                simSum += similarities[other];
                                counter++;
                            }
                        }
                    }
                }

            }

            if (counter == 0)
            {
                //txtcon.AppendText("Counter==0 in GetRecommendationsM function");
                return -1;
            }
            else
            {
                var result = weightedSimilarity / simSum;
                return result;
            }
        }



        //Function to rank Critics according to Similarity
        public Dictionary<string, double> RankCritics(string critic)
        {
            Dictionary<string, double> ranks = new Dictionary<string, double>();
            txtcon.AppendText(Environment.NewLine);
            txtcon.AppendText("*************************************************");
            txtcon.AppendText(Environment.NewLine);
            txtcon.AppendText(Environment.NewLine);
            txtcon.AppendText("*************************************************");
            txtcon.AppendText(Environment.NewLine);

            foreach (KeyValuePair<string, Dictionary<string, double>> pair in Recommendations)
            {
                if (pair.Key != critic)
                {
                    double PC = pearsonsCoeff(critic, pair.Key);
                    
                    if(PC!=-1)
                        ranks.Add(pair.Key, PC);
                    else
                        ranks.Add(pair.Key, -1);
                }
            }


            return ranks;
        }



        //Function to calculate the Pearson's Coefficient
        public double pearsonsCoeff(string critic, string other)
        {

            
            //txtcon.AppendText(Environment.NewLine);

            Dictionary<string, Dictionary<string, double>> Dic = new Dictionary<string, Dictionary<string, double>>();
            if (commonRatings(critic, other)!=null )
                Dic = commonRatings(critic, other);
            else
            {
                //When they don't have any movies in common
                return -1;
            }

            //n is the number of common ratings
            int n = 0;
            //Sum up all the Preferences
            double sum1 = 0;
            double sum2 = 0;
            foreach (KeyValuePair<string, double> pair in Dic[critic])
            {
                sum1 = sum1 + pair.Value;
                n++;
            }
            foreach (KeyValuePair<string, double> pair in Dic[other])
            {
                sum2 = sum2 + pair.Value;
            }

            double sum1Sq = 0;
            double sum2Sq = 0;

            foreach (KeyValuePair<string, double> pair in Dic[critic])
            {
                sum1Sq = sum1Sq + Math.Pow(pair.Value, 2);
            }

            foreach (KeyValuePair<string, double> pair in Dic[other])
            {
                sum2Sq = sum2Sq + Math.Pow(pair.Value, 2);
            }

            double pSum = 0;
            //Sum of products
            foreach (KeyValuePair<string, double> pair in Dic[critic])
            {
                foreach (KeyValuePair<string, double> pair2 in Dic[other])
                {
                    if (pair.Key == pair2.Key)
                    {
                        pSum = pSum + (pair.Value * pair2.Value);
                    }
                }
            }

            //Calculate Pearson Score
            double numerator = pSum - (sum1 * sum2) / n;
            double denominator = Math.Sqrt((sum1Sq - Math.Pow(sum1, 2) / n) * (sum2Sq - Math.Pow(sum2, 2) / n))+1;

            return (numerator / denominator)+1;
        }


        //Function returning the Ratings of the common movies
        public Dictionary<string, Dictionary<string, double>> commonRatings(string name1, string name2)
        {
            int si = 0;

            //txtcon.AppendText(Environment.NewLine);
            //txtcon.AppendText("*************************************************");
            //txtcon.AppendText(Environment.NewLine);
            //txtcon.AppendText("Entering commonRatings(name1,name2)" + name1 + " , " + name2);
            //txtcon.AppendText(Environment.NewLine);
            //txtcon.AppendText("*************************************************");
            //txtcon.AppendText(Environment.NewLine);

            Dictionary<string, Dictionary<string, double>> testDic = new Dictionary<string, Dictionary<string, double>>();


            //Get the common Movies between name1 and name2

            List<string> commonMoviesList = getCommonMoviesFunction(name1, name2);
            si = commonMoviesList.Count();

            //When they don't have any movies in common
            if (si == 0)
                return null;

            //Make one dictionary which contains2 keys, name1 and name2, and each key contains a list of all the moves and their ratings.
            Dictionary<string, string[,]> commonMovies = new Dictionary<string, string[,]>();

            Dictionary<string, double> test = new Dictionary<string, double>();
            Dictionary<string, double> test2 = new Dictionary<string, double>();

            //Adding Ratings by name1
            test.Clear();
            foreach (KeyValuePair<string, double> pair in Recommendations[name1])
            {
                if (commonMoviesList.Contains(pair.Key))
                {
                    test.Add(pair.Key, pair.Value);

                }
            }
            testDic.Add(name1, test);

            //Adding Ratings by name2

            foreach (KeyValuePair<string, double> pair in Recommendations[name2])
            {
                if (commonMoviesList.Contains(pair.Key))
                {
                    test2.Add(pair.Key, pair.Value);

                }
            }

            testDic.Add(name2, test2);

            return testDic;

        }



        //To find the common movies between name1 and name2
        public List<string> getCommonMoviesFunction(string name1, string name2)
        {
            
            List<string> commonMoviesList = new List<string>();
            foreach (KeyValuePair<string, double> pair in Recommendations[name1])
            {
                foreach (KeyValuePair<string, double> pair2 in Recommendations[name2])
                {
                    if (pair.Key == pair2.Key)
                    {
                        //txtcon.AppendText(pair.Key);
                        //txtcon.AppendText(Environment.NewLine);
                        commonMoviesList.Add(pair.Key);
                    }
                }
            }

            return commonMoviesList;
        }

        public List<string> getAllMovies()
        {
            List<string> allMovies = new List<string>();
            foreach (KeyValuePair<string, Dictionary<string, double>> pair in Recommendations)
            {
                foreach (KeyValuePair<string, double> movie in pair.Value)
                {
                    if (!allMovies.Contains(movie.Key))
                    {
                        allMovies.Add(movie.Key);
                    }
                }
            }
            return allMovies;
        }

        public List<string> notWatched()
        {
            List<string> allMovies = getAllMovies();

            List<string> NW = new List<string>();
            //mm containes list of all the movies watched
            var mm = Recommendations[input1.Text];
            foreach (KeyValuePair<string, double> pair in mm)
            {
                foreach (var i in allMovies)
                {
                    if ((!mm.ContainsKey(i)) && !(NW.Contains(i)))
                    {
                        NW.Add(i);
                    }
                }

            }

            return NW;
        }

        private void btnClearConsole_Click(object sender, EventArgs e)
        {
            txtcon.Clear();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            txtcon.Clear();
            txtcon.AppendText("Welcome!");
            txtcon.AppendText(Environment.NewLine);
            txtcon.AppendText("This little app recommends its users movies based on a databse of 100,000 movie ratingsmade by 943 users.");
            txtcon.AppendText(Environment.NewLine);
            txtcon.AppendText("You can choose any to recommend movies to any of those users!");
            txtcon.AppendText(Environment.NewLine);
            txtcon.AppendText("So go ahead and select any of the 943 users by entering any number between 0-942 (their userIDs) and the app would recomment them movies.");
        }

        

        

        

       

        

       

        
    }
}
