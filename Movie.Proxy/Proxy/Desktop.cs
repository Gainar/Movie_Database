using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Movie.Core.Models;

namespace Movie.Proxy.Proxy
{
    public class Desktop : IDesktop
    {
        public async void Add(MovieCreator mov)
        {
            var client = new HttpClient();
            await client.PostAsJsonAsync("http://moviedatabase.gear.host/api/Movies", mov);
        }

        public async void Delete(string tit)
        {
            var client = new HttpClient();
            await client.DeleteAsync($"http://moviedatabase.gear.host/api/Movies/{tit}/Delete");
        }

        public async void Edit(MovieCreator mov)
        {
            var client = new HttpClient();
            await client.PutAsJsonAsync($"http://moviedatabase.gear.host/api/Movies/{mov.Title}", mov);
        }

        public async Task<List<MovieCreator>>View()
        {
            var client = new HttpClient();
            var response =await client.GetAsync("http://moviedatabase.gear.host/api/Movies");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var x= await response.Content.ReadAsAsync<List<MovieCreator>>();
            return x;
        }
    }
}
