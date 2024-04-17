using System;

public class BankTransferConfig
{
	public Config config;
	public const String filePath = @"Bank_transfer_config.json";
	public BankTransferConfig()
	{
		try
		{
			
		}
	}
	private Config ReadConfigFile()
	{
		string configJsonData = File.ReadAllText(filepath);
		config = JsonSerializer.Deserialize<Config>(configJsonData);
		return Config;
	}
	public void SetDefault()
	{
        nTTransfer = new nTTransfer(25000000, 6500, 15000);
        nTConfirmation nTConfirmation = new nTConfirmation("yes", "ya");
        List<string> methods = new List<string>() { "RTO(real - time)", "SKN", "RTGS", "BI FAST" };

        config = new BTConfig("en", bTTransfer, methods, bTConfirmation);
    }
	public void WriteNewConfigFile()
	{
		JsonSerializerOptions options = new JsonSerializerOptionss()
		{
			WriteIndented = true,
		};
		string jsonstring = JsonSerializer.Serializer(config, options);
		File.WriteAllText(filePath, jsonstring);
	}
}

public class Config
{
	public string lang {  get; set; }
	public int treshold { get; set; }
	public string methods { get; set; }
	public string confirmation { get; set; }

}

public class nTTransfer
{
    public int treshold { get; set; }
    public int low_fees { get; set; }
    public int high_fees { get; set; }
}

public class nTConfirmation
{
	public string en { get; set; }
	public string id { get; set; }
}

