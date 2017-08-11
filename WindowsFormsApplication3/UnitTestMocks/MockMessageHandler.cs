using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace UI.Tests
{
    /// <summary>
    /// Used to mock out the HttpMessageHandler used by an HttpClient() constructor.
    /// </summary>
    /// <seealso cref="System.Net.Http.HttpMessageHandler" />
    public class MockMessageHandler : HttpMessageHandler
    {
        private readonly HttpResponseMessage _response;
        private readonly Exception _exceptionToThrow;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockMessageHandler"/> class.
        /// </summary>
        /// <param name="response">The HttpResponseMessage response to use as return results for the SendAsync() method.</param>
        public MockMessageHandler(HttpResponseMessage response)
        {
            this._response = response;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MockMessageHandler"/> class.
        /// </summary>
        /// <param name="exceptionToThrow">The exception to throw.</param>
        public MockMessageHandler(Exception exceptionToThrow)
        {
            this._exceptionToThrow = exceptionToThrow;
        }

        /// <summary>
        /// Send an HTTP request as an asynchronous operation.
        /// </summary>
        /// <param name="request">The HTTP request message to send.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>
        /// Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.
        /// </returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_exceptionToThrow != null)
            {
                throw this._exceptionToThrow;
            }

            return Task.FromResult(_response);
        }

    }
}