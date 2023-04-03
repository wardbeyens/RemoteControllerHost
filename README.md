# RemoteController Host

RemoteController Host is a server-side program designed to allow remote control of a Windows PC using a client program such as the one provided at `wardbeyens/RemoteControllerClient`. This program creates a virtual Xbox360 controller that can be controlled remotely from a client program on a different device.

## Installation

To use this program, you will need to have the `ViGEmBus` driver installed on your Windows PC. You can download this driver from the following GitHub repository: https://github.com/ViGEm/ViGEmBus.

Once you have installed the driver, you can run the following command in your command prompt to install the program:

```bash
git clone https://github.com/wardbeyens/RemoteControllerHost
cd RemoteControllerHost
dotnet build
```

## Usage

To start the server, navigate to the `RemoteControllerHost` directory in your command prompt and run the following command:

```bash
dotnet run
```

You can then connect to the server using the client program at `wardbeyens/RemoteControllerClient`.

## Dependencies

- `ViGEmBus` driver
- `Fleck` (WebSocket server in C#)
- `Nefarius.ViGEm.Client` (virtual controller input library)
- `Newtonsoft.Json` (JSON parsing library)

## Contributing

Contributions to this project are welcome! If you have any ideas or suggestions, please open an issue or pull request.

## License

To Be Determined
