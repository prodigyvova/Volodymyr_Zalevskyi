To run scenarios on your DropBox go to Scenarios.cs and at Authentication class change token value to yours.


To run scenarios from console:
1) Change diretory at command line to directory of this project.
2) Type "dotnet test" and press enter.


Project made with Factory Design Pattern, where RequestSenders classes at RequestSenders.cs use factory method to get needed Request type.
Request classes build RestRequest from RestSharper, which RequestSenders sends and return response, which is compared to HTTP OK status at Scenarios.cs.
