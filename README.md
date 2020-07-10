# ChatManager

`ChatManager` contains 2 projects, `ConsoleServer` and `ConsoleClient`.

I tried to make a chat with `WCF` at 1st and failed good, and most examples do not compile. 

But I have noticed that everybody that tries to help are talking about Asynchronous Desing, so I've changed to that.

The names `ConsoleServer`, `ConsoleClient`, `Interfaces` are because when I created those projects it was for testing, but since it went good I continued with them.

### `Interfaces`

A common dll, containing interfaces, DALs, and some consts (although they are not set to `const`)


### `WinformServer`

This is the Server. Most important thing to understand is that `Manager` class is the "Real" server, and the `Server` class is actually just a proxy channel for the clients. They all talk to him and he's talking back `Manager`, that can talk back to the clients.

### `WinformClient`

Clients UI.

## Database Added

If you want to try run the `ChatManager.sql` in your machine, and change `YOUR-LOCALHOST-NAME\admin` to your AD value (cmd => `whoami`)