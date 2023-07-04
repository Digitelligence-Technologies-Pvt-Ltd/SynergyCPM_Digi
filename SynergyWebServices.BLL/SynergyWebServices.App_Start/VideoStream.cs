using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace SynergyWebServices.App_Start;

public class VideoStream
{
	private readonly string _filename;

	public VideoStream(string filename, string ext)
	{
		_filename = "D:\\" + filename + "." + ext;
	}

	public async void WriteToStream(Stream outputStream, HttpContent content, TransportContext context)
	{
		try
		{
			byte[] buffer = new byte[65536];
			using FileStream video = File.Open(_filename, FileMode.Open, FileAccess.Read);
			int length = (int)video.Length;
			int bytesRead = 1;
			while (length > 0 && bytesRead > 0)
			{
				bytesRead = video.Read(buffer, 0, Math.Min(length, buffer.Length));
				await outputStream.WriteAsync(buffer, 0, bytesRead);
				length -= bytesRead;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			outputStream.Close();
		}
	}
}
