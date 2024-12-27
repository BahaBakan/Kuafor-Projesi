using Microsoft.AspNetCore.Mvc;
using OpenAI;
using OpenAI.Chat;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace KuaforProjesi.Controllers
{
    public class SacModeliniBulController : Controller
    {
        private const string ApiKey = "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";

        public IActionResult SacModeliniBul()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> FindModel(IFormFile photo)
        {
            try
            {
                if (photo == null)
                {
                    return Json(new { success = false, responseMessage = "Fotoğraf yüklenmedi.", imagePath = "" });
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string filePath = Path.Combine(uploadsFolder, photo.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }

                await ResizeImageAsync(filePath);

                string responseMessage = await GetOpenAiResponse(filePath);

                // sonradan eklendi


                var result = new
                {
                    success = true,
                    responseMessage,
                    imagePath = "/uploads/sacsekli.jpg"
                };

                
                return Json(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return Json(new { success = false, responseMessage = "Bir hata oluştu. Lütfen tekrar deneyin.", imagePath = "" });
            }
        }

        public async Task ResizeImageAsync(string imagePath, int maxSize = 2048)
        {
            using (var image = await Image.LoadAsync(imagePath))
            {
                var ratio = Math.Min((float)maxSize / image.Width, (float)maxSize / image.Height);
                int newWidth = (int)(image.Width * ratio);
                int newHeight = (int)(image.Height * ratio);
                image.Mutate(x => x.Resize(newWidth, newHeight));

                using (var output = System.IO.File.OpenWrite(imagePath))
                {
                    await image.SaveAsync(output, new JpegEncoder());
                }
            }
        }

        private async Task<string> GetOpenAiResponse(string imagePath)
        {
            ChatClient client = null;
            try
            {
                Logger.LogError("ChatClient başlatılıyor");

                string apiKey = "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";
                if (string.IsNullOrEmpty(apiKey))
                {
                    throw new InvalidOperationException("API key bulunamadı. Lütfen 'OPENAI_API_KEY' ortam değişkenini kontrol edin.");
                }

                client = new("gpt-4o-mini", apiKey);
            }
            catch (Exception ex)
            {
                Logger.LogError($"ChatClient başlatılırken hata oluştu: {ex.Message}\n{ex.StackTrace}");
            }

            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            string imageFilePath = Path.Combine(uploadsFolder, "images.jpg");
            string imageFilePath2 = Path.Combine(uploadsFolder, "sacsekli.jpg");

            using FileStream imageStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
            using FileStream imageStream2 = new FileStream(imageFilePath2, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);

            BinaryData imageBytes = await BinaryData.FromStreamAsync(imageStream);
            BinaryData imageBytes2 = await BinaryData.FromStreamAsync(imageStream2);

            List<ChatMessage> messages = new()
            {
                new UserChatMessage(
                    ChatMessageContentPart.CreateTextPart("Sana her mesajda iki adet fotoğraf göndereceğim. Fotoğraflardan biri erkek bir kişiye ait olacak. Diğeri ise 25 farklı saç şeklinin numaralandırıldığı bir fotoğraf olacak. Senden bu kişi için uygun saç şeklini yazılı olarak önermeni istiyorum. Öneri maksimum 2 cümle ve maksimum 50 karakter uzunluğunda olmalı. Ayrıyetten 25 farklı saç şeklinin numaralandırıldığı fotoğraf içinden senin önerine en yakın olan saç şekline ait numarayı seçmeni istiyorum. Seçimini önerinle birlikte paylaşacaksın. Verdiğin cevap şu şekilde olmalı: (seçtiğin saç şekli numarası?öneri) Örneğin: 18?Yüz hatlarını yumuşatmak için katmanlı uzun kesim ve ortadan ayrılan doğal dalgalar idealdir. Bu tarz, yüz şeklini daha dengeli gösterir."),
                    ChatMessageContentPart.CreateImagePart(imageBytes, "image/jpeg", "low"),
                    ChatMessageContentPart.CreateImagePart(imageBytes2, "image/jpeg", "low")),
            };

            ChatCompletion completion = await client.CompleteChatAsync(messages);

            string responseText = completion.Content[0].Text;

            if (responseText.Contains("?"))
            {
                var parts = responseText.Split('?', 2);
                string modelNumber = parts[0];
                string suggestion = parts[1];

                string formattedResponse = $"{suggestion} Örneğin {modelNumber}. görsel.";

                return formattedResponse;
            }

            return responseText;
        }
    }
}
