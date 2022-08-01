## Haxion Wallet

#### Supported blockchains

- Ethereum  
- Terra  
- Tron 

## How To 
### How to use the HaxionWallet
#### Ethereum
##### With mnemonic 
	Mnemonic mnemonic = new Mnemonic(Wordlist.English, WordCount.TwentyFour);
	IHaxionWallet<EthereumWallet> ethWallet = new EthereumHaxionWallet(mnemonic.ToString(), "passphrase");
	var address = ethWallet.GetAccount(0).GetExternalWallet(0);

##### With seed
	Mnemonic mnemonic = new Mnemonic(Wordlist.English, WordCount.TwentyFour);
	IHaxionWallet<EthereumWallet> ethWallet = new EthereumHaxionWallet("seed");
	var address = ethWallet.GetAccount(0).GetExternalWallet(0);

#### Terra
	Mnemonic mnemonic = new Mnemonic(Wordlist.English, WordCount.TwentyFour);
	IHaxionWallet<TerraWallet> terraWallet = new TerraHaxionWallet(mnemonic.ToString(), "passphrase");
	var address = terraWallet.GetAccount(0).GetExternalWallet(0);

#### Tron
	Mnemonic mnemonic = new Mnemonic(Wordlist.English, WordCount.TwentyFour);
	IHaxionWallet<TronWallet> tronWallet = new TronHaxionWallet(mnemonic.ToString(), "passphrase");
	var address = tronWallet.GetAccount(0).GetExternalWallet(0);