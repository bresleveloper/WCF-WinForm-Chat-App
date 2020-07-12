# ChatManager

## How to Run it?

1. Install .Net 4.6.1 from [microsoft here](https://www.microsoft.com/en-us/download/details.aspx?id=49981) (unless installed already)
2. Clone the GIT
3. Go to `ConsoleServer/WinformServer/bin/Debug` and run once `WinformServer.exe`
4. Go to `ConsoleClient/WinformClient/bin/Debug` and run `WinformClient.exe` an click `Connect as Moshe`
5. run `WinformClient.exe` again an click `Connect as Ruth`
6. Chat!

## How to use it for yourself?
You'll have to insert all relevat users into the db as described in the down here in `Database Added` section, or change the code to auto-insert any new user.


### Some details

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

Best to compile and run the `.exe` 3 times, with 2 of then use the `Connect As` buttons to really see the multi-chat capabilities.

## Database Added

If you want to try run the `ChatManager.sql` in your machine, and change `YOUR-LOCALHOST-NAME\admin` to your AD value (cmd => `whoami`)