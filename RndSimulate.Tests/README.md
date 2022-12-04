Testing.

Due to an issue with the project / solution structure. I did not get unit tests running in this version.

I did add a unit test in an older version and looked at integration tests with Net.HttpCLient. I used the xunit template to get started.

My unit tests would have been:
- calling SimulateSerice.Create() and then SimulateService.GetAll() to check if a new job had been created.
- calling SimulateSerice.Create() n times then SimulateSerice.Start() to see if the runner is processing the jobs. The assertion would be to check that job.Done is true.

Integration tests:
- I would have called create n times and then start. After I would call simulate and then call progress (using a new http client). This would show that: 
	- the runner is processing the job que. 
	- A client is busy sleeping in simulate
	- Another client can get progress of the que.




How I tested:

1) start service
$ dotnet run

2) use httprepel to get to api
$ httprepl url:port
$ ls
$ cd Simulation

3) list endpoints
$ ls

4) add jobs to list (repeat to add more)
$ post -c {}

5) get job n with id
$ get 1

6) start que
$ get start

7) check que status
$ get que

you will see some jobs with done = false and others true. They will eventually all be true

8) monitor progress
$ get progress


These commands can be run in a browser too. I considered using postman but found httprepel to be very affective.

To test the asynchronous behavior I ran $get simulate to cause the client to be busy. then used a browser to get progress / que. The simulate client does not block the browser client.
