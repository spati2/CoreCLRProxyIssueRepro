# CoreCLRProxyIssueRepro
This repro is a very simple simulation to represent the "Stream was already consumed exception" being encountered and explained in the github issue - https://github.com/dotnet/corefx/issues/27971

## Steps to simulate issue

1. I used Telerik fiddler as the proxy and the wire monitor. It is a very useful tool and can be downloaded [here](https://www.telerik.com/download/fiddler)
2. Clone this repo.
3. Open Fiddler and navigate to Rules and select Require Proxy Authentication. The default proxy credentials are "1"/"1".
4. Navigate to Tools > Options > Connections and verify the port number in there. In my repro it was "8888". Feel free to change that if a different port is needed.
5. While Fiddler is running with the proxy settings in the background, run the console application of my repro. You should see the "Stream was already consumed" exception being surfaced as a level 2 innerexception.
6. In this repro, I am creating a custom stream off of memory stream , with the canseek property overriden to false.
