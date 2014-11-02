using System;
using System.ComponentModel;
using System.Net;

namespace WebClientDemo
{
	/// <summary>
	/// Базовый класс для создания веб-сервера
	/// </summary>
	/// <remarks>
	/// За основу был взят класс из блога Рика Страла (Rick Strahl)
	/// http://weblog.west-wind.com/posts/2005/Dec/04/Add-a-Web-Server-to-your-NET-20-app-with-a-few-lines-of-code
	/// </remarks>
	public sealed class HttpServer : IDisposable, INotifyPropertyChanged
	{
		private HttpListener _listener;

		private bool _isStarted;
		public bool IsStarted
		{
			get { return _isStarted; }
			private set
			{
				_isStarted = value;
				OnPropertyChanged("IsStarted");
			}
		}

		public event Action<HttpListenerContext> ReceiveWebRequest;

		/// <summary>
		/// Starts the Web Service
		/// </summary>
		/// <param name="uriPrefix">
		/// A Uri that acts as the base that the server is listening on.
		/// Format should be: http://127.0.0.1:8080/ or http://127.0.0.1:8080/somevirtual/
		/// Note: the trailing backslash is required! For more info see the
		/// HttpListener.Prefixes property on MSDN.
		/// </param>
		public void Start(string uriPrefix)
		{
			if (IsStarted) return;

			if (_listener == null)
			{
				_listener = new HttpListener();
			}

			_listener.Prefixes.Add(uriPrefix);

			_listener.Start();
			IsStarted = true;

			_listener.BeginGetContext(WebRequestCallback, _listener);
		}

		/// <summary>
		/// Shut down the Web Service
		/// </summary>
		public void Stop()
		{
			if (_listener != null)
			{
				//Reflection.ReflectionHelper.InvokeMethod(httpListener, "RemoveAll", new object[] { false });
				_listener.Close();
				_listener = null;
				IsStarted = false;
			}
		}

		private void WebRequestCallback(IAsyncResult asyncResult)
		{
			if (_listener == null) return;

			HttpListenerContext httpContext = _listener.EndGetContext(asyncResult);

			// *** Immediately set up the next context
			_listener.BeginGetContext(WebRequestCallback, _listener);

			if (ReceiveWebRequest != null)
			{
				ReceiveWebRequest(httpContext);
			}
		}

		void IDisposable.Dispose()
		{
			Stop();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
