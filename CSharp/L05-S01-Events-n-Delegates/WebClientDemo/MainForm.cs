using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WebClientDemo
{
	public partial class MainForm : Form
	{
		WebClient client;
		private HttpServer httpServer;

		private static Dictionary<string, Action<HttpListenerResponse>> uriHandlerMap;
		private static Encoding defaultResponseEncoding = Encoding.UTF8;
		private const string SERVER_URL = "http://localhost:34256/";

		static MainForm()
		{
			uriHandlerMap = new Dictionary<string, Action<HttpListenerResponse>>();
			uriHandlerMap.Add("/", HomePage);
			uriHandlerMap.Add("/random.zip", ZipFileWithContentLength);
		}

		public MainForm()
		{
			InitializeComponent();

			pictureBoxServerStatus.Image = imageListIcons.Images["server-stopped"];
		}

		private void HandleDownloadZipButtonClick(object sender, EventArgs e)
		{
			if (httpServer == null || !httpServer.IsStarted)
			{
				httpServer = StartHttpServer();

				pictureBoxServerStatus.Image = imageListIcons.Images["server-started"];
				linkLabelServer.Text = SERVER_URL;
				linkLabelServer.Visible = true;
			}

			if (client != null) return;

			client = new WebClient();
			client.DownloadDataCompleted += DownloadDataCompleted;
			client.DownloadProgressChanged += DownloadProgressChanged;
			client.DownloadDataAsync(new Uri(SERVER_URL + "random.zip"));
		}

		private void HandleFormClosing(object sender, FormClosingEventArgs e)
		{
			if (httpServer != null)
			{
				httpServer.Stop();
				httpServer = null;
			}

			if (client != null)
			{
				client.CancelAsync();
			}
		}

		void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			progressBarDownload.Visible = true;
			progressBarDownload.Value = e.ProgressPercentage;
		}

		void DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
		{
			client = null;
			progressBarDownload.Visible = false;
			progressBarDownload.Value = 0;
		}

		private void linkLabelServer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			LinkLabel linkLabel = (LinkLabel)sender;
			Process.Start(linkLabel.Text);
		}
		
		#region Реализация локального http-сервера

		private static HttpServer StartHttpServer()
		{
			var httpServer = new HttpServer();
			httpServer.ReceiveWebRequest += ProcessHttpRequest;
			httpServer.Start(SERVER_URL);
			return httpServer;
		}

		private static void ProcessHttpRequest(HttpListenerContext httpContext)
		{
			HttpListenerRequest request = httpContext.Request;
			HttpListenerResponse response = httpContext.Response;
			Action<HttpListenerResponse> requestHandler;
			if (uriHandlerMap.TryGetValue(request.RawUrl, out requestHandler))
			{
				requestHandler(response);
			}
			else
			{
				Page404(response);
			}
		}

		private static void HomePage(HttpListenerResponse response)
		{
			const string responseString = "<HTML><BODY>Hello world!</BODY></HTML>";
			byte[] buffer = defaultResponseEncoding.GetBytes(responseString);
			response.ContentLength64 = buffer.Length;
			using (Stream output = response.OutputStream)
			{
				output.Write(buffer, 0, buffer.Length);
			}
		}

		private static void Page404(HttpListenerResponse response)
		{
			response.StatusCode = 404;
			const string responseString = "<HTML><BODY>404</BODY></HTML>";
			byte[] buffer = defaultResponseEncoding.GetBytes(responseString);
			response.ContentLength64 = buffer.Length;
			using (Stream output = response.OutputStream)
			{
				output.Write(buffer, 0, buffer.Length);
			}
		}

		private static void ZipFileWithContentLength(HttpListenerResponse response)
		{
			const int chunkSize = 4096 * 4;
			const int chunks = 200;
			response.ContentLength64 = chunkSize * chunks;
			response.ContentType = "application/zip";
			using (Stream output = response.OutputStream)
			{
				byte[] buffer = new byte[chunkSize];
				Random rnd = new Random(Environment.TickCount);
				for (int i = 0; i < chunks; i++)
				{
					rnd.NextBytes(buffer);
					try
					{
						output.Write(buffer, 0, buffer.Length);
						output.Flush();
					}
					catch (HttpListenerException)
					{
						break;
					}
					Thread.Sleep(100);
				}
			}
		}

		#endregion
	}
}
