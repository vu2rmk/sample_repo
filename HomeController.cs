[HttpPost]
        public async Task<ActionResult> DownloadFileZip(string fileName)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        var demoFile = archive.CreateEntry("test.pdf", CompressionLevel.Fastest);

                        using (var entryStream = demoFile.Open())
                        {

                            string someUrl = "http://www.africau.edu/images/default/sample.pdf";
                            Uri documentURL = new Uri(someUrl, UriKind.Absolute);

                            client.DefaultRequestHeaders.ConnectionClose = true;
                            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                            byte[] imageBytes = await client.GetByteArrayAsync(documentURL);
                            entryStream.Write(imageBytes, 0, imageBytes.Length);
                        }
                    }
                    string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));

                    return File(memoryStream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Zip, zipName);
                    //string base64 = Convert.ToBase64String(memoryStream.ToArray(), 0, memoryStream.ToArray().Length);
                    //return Content(base64);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
