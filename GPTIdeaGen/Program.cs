using ChatGPT.Net;
using ChatGPT.Net.DTO.ChatGPT;
using System.IO;

var apiKey = Environment.GetEnvironmentVariable("CHATGPT_API_KEY", EnvironmentVariableTarget.User);
// @TODO upgrade to gpt 4 api  
var bot = new ChatGpt(apiKey);

var prompt = string.Empty;

while (true)
{
    string systemPrompt = File.ReadAllText("SystemPrompt.txt");
    ChatGptConversation conversation = bot.GetConversation(null);
    bot.SetConversationSystemMessage(conversation.Id, systemPrompt); 

    Console.Write("You: ");
    prompt = Console.ReadLine();
    if (prompt is null) break;
    if (string.IsNullOrWhiteSpace(prompt)) break;
    if (prompt == "exit") break;
    Console.Write("ChatGPT: ");
    string resp = await bot.Ask(prompt, conversation.Id);
    Console.WriteLine(resp);

}