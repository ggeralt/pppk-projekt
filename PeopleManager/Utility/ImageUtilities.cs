using System.Data.SqlClient;
using System.IO;
using System.Windows.Media.Imaging;

namespace PeopleManager.Utility
{
    public static class ImageUtilities
    {
        public static BitmapImage ByteArrayToBitmapImage(byte[] picture)
        {
            using (var memoryStream = new MemoryStream(picture))
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                return bitmapImage;
            }
        }

        public static byte[] BitmapImageToByteArray(BitmapImage bitmapImage)
        {
            var jpegEncoder = new JpegBitmapEncoder();
            jpegEncoder.Frames.Add(BitmapFrame.Create(bitmapImage));

            using (var memoryStream = new MemoryStream())
            {
                jpegEncoder.Save(memoryStream);
                return memoryStream.ToArray();
            }
        }

        internal static byte[] ByteArrayFromSqlDataReader(SqlDataReader sqlDataReader, int column)
        {
            int currentBytes = 0;
            int bufferSize = 1024;
            byte[] buffer = new byte[bufferSize];

            using (var memoryStream = new MemoryStream())
            {
                using (var binaryWriter = new BinaryWriter(memoryStream))
                {
                    int readBytes;

                    do
                    {
                        readBytes = (int)sqlDataReader.GetBytes(column, currentBytes, buffer, 0, bufferSize);
                        binaryWriter.Write(buffer, 0, readBytes);
                        currentBytes += readBytes;
                    } while (readBytes == bufferSize);

                    return memoryStream.ToArray();
                }
            }
        }
    }
}
