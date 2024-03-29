// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/cinema.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace MyLiMsRPC {
  /// <summary>
  /// The greeting service definition.
  /// </summary>
  public static partial class Cinema
  {
    static readonly string __ServiceName = "cinema.Cinema";

    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MyLiMsRPC.GetAvailableMoviesResponse> __Marshaller_cinema_GetAvailableMoviesResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MyLiMsRPC.GetAvailableMoviesResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MyLiMsRPC.GetAvailableTicketsForMovieRequest> __Marshaller_cinema_GetAvailableTicketsForMovieRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MyLiMsRPC.GetAvailableTicketsForMovieRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MyLiMsRPC.GetAvailableTicketsForMovieResponse> __Marshaller_cinema_GetAvailableTicketsForMovieResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MyLiMsRPC.GetAvailableTicketsForMovieResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::MyLiMsRPC.GetAvailableMoviesResponse> __Method_GetAvailableMovies = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::MyLiMsRPC.GetAvailableMoviesResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetAvailableMovies",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_cinema_GetAvailableMoviesResponse);

    static readonly grpc::Method<global::MyLiMsRPC.GetAvailableTicketsForMovieRequest, global::MyLiMsRPC.GetAvailableTicketsForMovieResponse> __Method_GetAvailableTicketsForMovie = new grpc::Method<global::MyLiMsRPC.GetAvailableTicketsForMovieRequest, global::MyLiMsRPC.GetAvailableTicketsForMovieResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAvailableTicketsForMovie",
        __Marshaller_cinema_GetAvailableTicketsForMovieRequest,
        __Marshaller_cinema_GetAvailableTicketsForMovieResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::MyLiMsRPC.CinemaReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Cinema</summary>
    [grpc::BindServiceMethod(typeof(Cinema), "BindService")]
    public abstract partial class CinemaBase
    {
      /// <summary>
      /// Get available movies
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="responseStream">Used for sending responses back to the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>A task indicating completion of the handler.</returns>
      public virtual global::System.Threading.Tasks.Task GetAvailableMovies(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::IServerStreamWriter<global::MyLiMsRPC.GetAvailableMoviesResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Get available ticket count
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::MyLiMsRPC.GetAvailableTicketsForMovieResponse> GetAvailableTicketsForMovie(global::MyLiMsRPC.GetAvailableTicketsForMovieRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(CinemaBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetAvailableMovies, serviceImpl.GetAvailableMovies)
          .AddMethod(__Method_GetAvailableTicketsForMovie, serviceImpl.GetAvailableTicketsForMovie).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, CinemaBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetAvailableMovies, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::MyLiMsRPC.GetAvailableMoviesResponse>(serviceImpl.GetAvailableMovies));
      serviceBinder.AddMethod(__Method_GetAvailableTicketsForMovie, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::MyLiMsRPC.GetAvailableTicketsForMovieRequest, global::MyLiMsRPC.GetAvailableTicketsForMovieResponse>(serviceImpl.GetAvailableTicketsForMovie));
    }

  }
}
#endregion
