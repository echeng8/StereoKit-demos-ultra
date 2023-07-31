using ChatGPT.Net;
using System.IO;

var apiKey = Environment.GetEnvironmentVariable("CHATGPT_API_KEY", EnvironmentVariableTarget.User);
var bot = new ChatGpt(apiKey);

var prompt = string.Empty;

while (true)
{     
    Console.Write("You: ");
    prompt = Console.ReadLine();
    if (prompt is null) break;
    if (string.IsNullOrWhiteSpace(prompt)) break;
    if (prompt == "exit") break;
    Console.Write("ChatGPT: ");
    await bot.AskStream(Console.Write, prompt, "default");
    Console.WriteLine();
}