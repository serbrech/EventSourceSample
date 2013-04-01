using System;
using System.Collections.Generic;
using Nancy;

namespace EventSourceSample
{

    public class EventModule : NancyModule
    {
        public static IList<EventStreamWriterResponse> Clients = new List<EventStreamWriterResponse>();

        public EventModule()
        {
            Get["/"] = x => View["/events"];

            Get["/connect"] = x =>
            {
                var responseWriter = new EventStreamWriterResponse(Response, "Open", new { data = "connection is opened!" });
                Clients.Add(responseWriter);
                return responseWriter;
            };

            Post["/event/{id}/{message}"] = p =>
            {
                Dispatch(writer => writer.Write(p.id, new { id = p.id, data = p.message }));
                return 200;
            };

            Post["/event/{message}"] = p =>
                {
                    Dispatch(writer => writer.Write(null, new { data = p.message }));
                    return 200;
                };
        }


        private static void Dispatch(Action<EventStreamWriterResponse> write)
        {
            foreach (var writer in Clients)
            {
                try
                {
                    write(writer);
                }
                catch (Exception)
                {
                    Console.WriteLine("failed to write to client, removing reference.");
                    Clients.Remove(writer);
                }
            }
        }
    }
}
