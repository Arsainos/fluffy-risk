using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Aggregator.services
{
    public static class GrpcCallerService
    {
        public static T CallService<T>(string urlGrpc, Func<GrpcChannel, T> func)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);

            var channel = GrpcChannel.ForAddress(urlGrpc);

            try
            {
                return func(channel);
            }
            catch
            {
                return default;
            }
            finally
            {
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", false);
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", false);
            }
        }

        public static async Task<TResponse> CallServiceAsync<TResponse>(string urlGrpc, Func<GrpcChannel, Task<TResponse>> func)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);

            var channel = GrpcChannel.ForAddress(urlGrpc);

            try
            {
                return await func(channel);
            }
            catch
            {
                return default;
            }
            finally
            {
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", false);
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", false);
            }
        }

        public static async Task CallServiceAsync(string urlGrpc, Func<GrpcChannel, Task> func)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);

            var channel = GrpcChannel.ForAddress(urlGrpc);

            try
            {
                await func(channel);
            }
            finally
            {
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", false);
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", false);
            }
        }

        public static T CallServiceWithCredentials<T>(string urlGrpc, string token, Func<GrpcChannel, T> func)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);

            CallCredentials credentials = CallCredentials.FromInterceptor((context, metadata) =>
            {
                // В тело ответа будет записываться токен
                if (!string.IsNullOrEmpty(token))
                    metadata.Add("Authorization", $"Bearer {token}");

                return Task.CompletedTask;
            });

            var channel = GrpcChannel.ForAddress(urlGrpc, new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
            });

            try
            {
                return func(channel);
            }
            catch
            {
                return default;
            }
            finally
            {
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", false);
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", false);
            }
        }

        public static async Task<TResponse> CallServiceWithCredentialsAsync<TResponse>(string urlGrpc, string token, Func<GrpcChannel, Task<TResponse>> func)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);

            CallCredentials credentials = CallCredentials.FromInterceptor((context, metadata) =>
            {
                // В тело ответа будет записываться токен
                if (!string.IsNullOrEmpty(token))
                    metadata.Add("Authorization", $"Bearer {token}");

                return Task.CompletedTask;
            });

            var channel = GrpcChannel.ForAddress(urlGrpc, new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
            });

            try
            {
                return await func(channel);
            }
            catch
            {
                return default;
            }
            finally
            {
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", false);
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", false);
            }
        }

        public static async Task CallServiceWithCredentialsAsync(string urlGrpc, string token, Func<GrpcChannel, Task> func)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);

            CallCredentials credentials = CallCredentials.FromInterceptor((context, metadata) =>
            {
                // В тело ответа будет записываться токен
                if (!string.IsNullOrEmpty(token))
                    metadata.Add("Authorization", $"Bearer {token}");

                return Task.CompletedTask;
            });

            var channel = GrpcChannel.ForAddress(urlGrpc, new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
            });

            try
            {
                await func(channel);
            }
            finally
            {
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", false);
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", false);
            }
        }
    }    
}
