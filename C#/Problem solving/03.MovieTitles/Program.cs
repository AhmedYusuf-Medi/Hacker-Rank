namespace _03.MovieTitles
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;

    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();

            Console.WriteLine($"Count of movies with title: {GetCountOfMovies(title)}");
        }

        /// <summary>
        /// Makes get queiry to hackerank api movie table and filters all
        /// movies by selected title then from the JSON reposne we get the total property
        /// created by pagination
        /// </summary>
        public static int GetCountOfMovies(string substr)
        {
            const string host = "https://jsonmock.hackerrank.com/api/movies/search/?Title=";

            var client = new HttpClient();

            var encodedSubstring = Uri.EscapeDataString(substr);

            var response = client.GetStringAsync(host + encodedSubstring).Result;

            if (!string.IsNullOrEmpty(response))
            {
                dynamic filmList = JsonConvert.DeserializeObject(response);

                return filmList.total;
            }

            return 0;
        }
    }
}