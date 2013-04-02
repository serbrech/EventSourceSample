Sample app to show how to use Server sent events and EventSource object using NancyFx.  

1. Run console app  
2. Navigate to http://localhost:1235  
3. http post http://localhost:1235/event/&lt;whatever&gt;  
4. see the message being pushed to the client in your browser.  


The EventSource object handles retries, so you can stop and restart the console app.  
A try catch block "handles" disconnections on the server side.