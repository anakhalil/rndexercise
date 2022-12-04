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


