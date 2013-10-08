//using Microsoft.WindowsAzure;
//using Microsoft.WindowsAzure.StorageClient;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace PageAndServices.Helpers
//{
//    public class BlobStorage
//    {
//        private const string account = "jobsystems";
//        private const string key = "/3yrVZAK1gkN08s8XVqejDgGj5prsw8QTbivgrlQmrnTSqZFIlMw/jOHmV5lcl65Uwv8zMN4uTmxeDDidhc8eQ==";
//        private const string url = "http://jobsystems.blob.core.windows.net/";
//        private const string containerName = "";
//        private const string blobName = "";

//        public BlobStorage() { }

//        public void saveImage(string filename, BlobStream stream) 
//        {
//            // get storage
//            StorageCredentialsAccountAndKey creds = new StorageCredentialsAccountAndKey(account, key);
//            CloudBlobClient blobStorage = new CloudBlobClient(url, creds);

//            // get blob container
//            CloudBlobContainer blobContainer = blobStorage.GetContainerReference(containerName);

//            // get blob data
//            CloudBlob cloudBlob = blobContainer.GetBlobReference(blobName);
//            string text = cloudBlob.DownloadText();

//            // print text
//            Console.WriteLine(text);

//            // set blob data
//            cloudBlob.UploadText("Hello C#");
//        }
//    }
//}