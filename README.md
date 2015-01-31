# TrueCrypt-AMS
Securely stores a TrueCrypt volume password and automatically mounts the volume from removable media. Uses the TrueCrypt 7.1a driver

**Includes:**
* **AutoMountSecured** - Main program
  - Runs in the notification tray
  - Listens for removable drives, checking for target
  - Manages the TrueCrypt driver
  - Runs as Administrator
* **SimpleCrypto** - Fork of [Encryptamajig](https://github.com/jbubriski/Encryptamajig)
  - Used for encrypting the TrueCrypt volume password and hashing the Master Password
  - Uses managed AES 256 with a 128 bit random salt and random initialization vector
  - Salt and IV are embedded in the CypherText
* **TrueCryptDriver** - Rewritten code base inspired by [TrueCryptAPI](https://truecryptapi.codeplex.com/)
  - Huge rewrites from initial translation, incorporating managed code features
  - Interfaces with the official TrueCrypt driver 7.1a
* **DeviceMonitor** - Removable Media Monitor inspired by [Detect USB Removal in C#](http://www.codeproject.com/Articles/18062/)
  - Monitors the attachment and removal of removable devices
  - Raises events when targeted volumes are attached, request removal, or removed
  - Hooks into targeted devices to be notified of removal requests


## Installation

TODO: Describe the installation process

## Usage

TODO: Write usage instructions

## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :D

## History

TODO: Write history

## Credits

TODO: Write credits

## License

TODO: Write license
