// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

using Microsoft.Azure.IoTMQ.IoTHubConnector.Client;
using System.Threading.Tasks;

namespace OpcPublisher.Interfaces
{
    /// <summary>
    /// Interface to encapsulate the IoTHub device/module client interface.
    /// </summary>
    public interface IHubClient
    {
        /// <summary>
        /// Stores custom product information that will be appended to the user agent string that is sent to IoT Hub.
        /// </summary>
        string ProductInfo { get; set; }

        /// <summary>
        /// Implement IDisposable.
        /// </summary>
        void Dispose();


        /// <summary>
        /// Close the client instance
        /// </summary>
        Task CloseAsync();

        /// <summary>
        /// Sets the retry policy used in the operation retries.
        /// </summary>
        //void SetRetryPolicy(IRetryPolicy retryPolicy);

        /// <summary>
        /// Registers a new delegate for the connection status changed callback. If a delegate is already associated, 
        /// it will be replaced with the new delegate.
        /// </summary>
        void SetConnectionStatusChangesHandler(Microsoft.Azure.IoTMQ.IoTHubConnector.Client.ConnectionStatusChangesHandler statusChangesHandler);

        /// <summary>
        /// Explicitly open the DeviceClient instance.
        /// </summary>
        Task OpenAsync();

        /// <summary>
        /// Registers a new delegate for the named method. If a delegate is already associated with
        /// the named method, it will be replaced with the new delegate.
        /// </summary>
        Task SetMethodHandlerAsync(string methodName, Microsoft.Azure.IoTMQ.IoTHubConnector.Client.MethodCallback methodHandler);

        /// <summary>
        /// Registers a new delegate that is called for a method that doesn't have a delegate registered for its name. 
        /// If a default delegate is already registered it will replace with the new delegate.
        /// </summary>
        Task SetMethodDefaultHandlerAsync(Microsoft.Azure.IoTMQ.IoTHubConnector.Client.MethodCallback methodHandler);

        /// <summary>
        /// Sends an event to device hub
        /// </summary>
        Task SendEventAsync(Microsoft.Azure.IoTMQ.IoTHubConnector.Client.Message message);
    }
}
