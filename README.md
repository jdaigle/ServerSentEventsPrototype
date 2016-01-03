This project is a simple prototype of [Server-sent events](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events) using ASP.NET and some simple JavaScript.

Note that this only works in Chrome/FireFox and requires a polyfill for IE.

Server-sent events is basically a more mature version of long-polling or [Comet](https://en.wikipedia.org/wiki/Comet_(programming)) like model. It provides a simple API exposed through the [EventSource](https://developer.mozilla.org/en-US/docs/Web/API/EventSource) object. In essence, the UA will open a connection to a URL with ACCEPT header of `text/event-stream`. The connection stays open on the server, with the server writing events back when available. Events can be named, or unnamed (called messages). Events can also have a corresponding ID. If the connection is lost, either by the UA or the server, the UA will retry after waiting three seconds. It'll include the last event ID in the header if applicable.

And that's it.

The server should, of course, correctly implement asynchronous and non-blocking behavior to prevent worker thread starvation.

It'll be interesting to see how this approach scales. And how it works with load balancers and other proxies. It's also untested on mobile.