using PangyaAPI.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Web;
using System.Collections.Generic;

namespace PangyaAPI.Translation
{
    public static class TranslationAPI
    {

        public static string Get(string txt)
        {
            GoogleTranslate google = new GoogleTranslate();

            //Notice that we set the source language to Language.Automatic. This means Google Translate automatically detect the source language before translating.
            var translateResult = google.Translate(Language.Automatic, Language.Portuguese, txt)[0];

            //foreach( var translation in results)
            //{
            //    Console.WriteLine("Detected language: " + translation.DetectedSourceLanguage + " translation: " + translation.TranslatedText);
            //}

            string traducao = translateResult.TranslatedText;
            var test = traducao;
            RemoveDiacritics(ref traducao);
            System.Diagnostics.Debug.WriteLine($"Original: {txt}");
            System.Diagnostics.Debug.WriteLine($"TranslationV1: {test}");
            System.Diagnostics.Debug.WriteLine($"TranslationV2: {traducao}\r\n");
            return traducao;
        }

        public static string GetV2(string translation)
        {
            var bcktranslation = translation;
            try
            {
                if (bcktranslation == "")
                {
                    return translation;
                }
                if (!Request_Traducao(out HttpWebResponse response, translation))
                {
                    if (response != null)
                    { response.Close(); }
                    else { return bcktranslation; }
                }

                var json = ReadResponse(response);


                response.Close();

                var translateResult = JsonConvert.DeserializeObject<dynamic>(json);


                string traducao = translateResult.text[0].ToString();
                var test = traducao;
                RemoveDiacritics(ref traducao);
                System.Diagnostics.Debug.WriteLine($"Original: {translation}");
                System.Diagnostics.Debug.WriteLine($"TranslationV1: {test}");
                System.Diagnostics.Debug.WriteLine($"TranslationV2: {traducao}\r\n");
                return traducao;
            }
            catch
            {
                return bcktranslation;
            }
        }

        /// <summary>
        /// Lê uma resposta e a transforma em uma string
        /// </summary>
        /// <param name="response">HttpResponse</param>
        /// <returns>Resposta no formato string</returns>
        static string ReadResponse(HttpWebResponse response)
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                Stream streamToRead = responseStream;
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    if (streamToRead != null) streamToRead = new GZipStream(streamToRead, CompressionMode.Decompress);
                }
                else if (response.ContentEncoding.ToLower().Contains("deflate"))
                {
                    if (streamToRead != null) streamToRead = new DeflateStream(streamToRead, CompressionMode.Decompress);
                }

                if (streamToRead != null)
                    using (StreamReader streamReader = new StreamReader(streamToRead, Encoding.UTF8))
                    {
                        return streamReader.ReadToEnd();
                    }
            }
            return null;
        }

        static bool Request_Traducao(out HttpWebResponse response, string texto)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://translate.yandex.net/api/v1/tr.json/translate?id=36b03cb0.6355b410.e0e228b1.74722d74657874-0-0&srv=tr-text&lang=en-pt&reason=auto&format=text&yu=1514012041636333636&yum=16363336431030412811");
                request.KeepAlive = true;
                request.Headers.Add("sec-ch-ua", @"""Google Chrome"";v=""95"", ""Chromium"";v=""95"", "";Not A Brand"";v=""99""");
                request.Headers.Add("sec-ch-ua-mobile", @"?0");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.69 Safari/537.36";
                request.Headers.Add("sec-ch-ua-platform", @"""Windows""");
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "*/*";
                request.Headers.Add("Origin", @"https://translate.yandex.com");
                request.Headers.Add("Sec-Fetch-Site", @"cross-site");
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Headers.Add("Sec-Fetch-Dest", @"empty");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = $@"text={HttpUtility.UrlEncode(texto)}&options=4";
                byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(body);
                request.ContentLength = postBytes.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(postBytes, 0, postBytes.Length);
                stream.Close();

                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
                else return false;
            }
            catch (Exception)
            {
                if (response != null) response.Close();
                return false;
            }

            return true;
        }
        static char[] GetDiacritics()
        {
            char[] accents = new char[256];

            for (int i = 0; i < 256; i++)
                accents[i] = (char)i;

            accents[(byte)'á'] = accents[(byte)'à'] = accents[(byte)'ã'] = accents[(byte)'â'] = accents[(byte)'ä'] = 'a';
            accents[(byte)'Á'] = accents[(byte)'À'] = accents[(byte)'Ã'] = accents[(byte)'Â'] = accents[(byte)'Ä'] = 'A';

            accents[(byte)'é'] = accents[(byte)'è'] = accents[(byte)'ê'] = accents[(byte)'ë'] = 'e';
            accents[(byte)'É'] = accents[(byte)'È'] = accents[(byte)'Ê'] = accents[(byte)'Ë'] = 'E';

            accents[(byte)'í'] = accents[(byte)'ì'] = accents[(byte)'î'] = accents[(byte)'ï'] = 'i';
            accents[(byte)'Í'] = accents[(byte)'Ì'] = accents[(byte)'Î'] = accents[(byte)'Ï'] = 'I';

            accents[(byte)'ó'] = accents[(byte)'ò'] = accents[(byte)'ô'] = accents[(byte)'õ'] = accents[(byte)'ö'] = 'o';
            accents[(byte)'Ó'] = accents[(byte)'Ò'] = accents[(byte)'Ô'] = accents[(byte)'Õ'] = accents[(byte)'Ö'] = 'O';

            accents[(byte)'ú'] = accents[(byte)'ù'] = accents[(byte)'û'] = accents[(byte)'ü'] = 'u';
            accents[(byte)'Ú'] = accents[(byte)'Ù'] = accents[(byte)'Û'] = accents[(byte)'Ü'] = 'U';

            accents[(byte)'ç'] = 'c';
            accents[(byte)'Ç'] = 'C';

            accents[(byte)'ñ'] = 'n';
            accents[(byte)'Ñ'] = 'N';

            accents[(byte)'ÿ'] = accents[(byte)'ý'] = 'y';
            accents[(byte)'Ý'] = 'Y';
            return accents;
        }

        static string ReplaceFirst(string text, string search, string replace)
        {
            for (int i = 0; i < 10; i++)
            {
                int pos = text.IndexOf(search);
                if (pos < 0)
                {
                    return text;
                }
                text =text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
            }
            return text;
        }

        static void RemoveDiacritics(ref string text)
        {

            text = ReplaceFirst(text, "&quot;", @"""");
            text = ReplaceFirst(text, "&#39;", @"'");
            text = ReplaceFirst(text, "&gt;", ">");
            char[] s_Diacritics = GetDiacritics();

            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] > 255)
                    sb.Append(text[i]);
                else
                    sb.Append(s_Diacritics[text[i]]);
            }
            if (true)
            {

            }
            text = sb.ToString();
        }
    }
}

