Design assumptions:

Endpoints:
/start      -> submits job
/progress   -> check on status of job runner
/result     -> check if runner is done


Since the "job" is a dummy, simulate, function; I was unsure on what result to return. I assume it's the result of the runner itself.

The use of "start" and "progress" then were determined by whether I wanted to handle multiple job submissions. I went with a runner that can only handle one job as it was simpler.

The api can be quired to see the state of the job (/progress) and its result (/result). If the api reports the runner is complete (using /result ) then a new submission can be made. This enforces that only one runner is active. The API can still be queried, but a new job submission will fail.

/Result returns a value representing if the runner is working, rather than the completion of each job. Since it can only handle one job, we can consider the thread completion as a job completion. Note it will always return the result of the last run job.

Progress is then the current state of the runner, rather than the number of completed vs uncompleted jobs.

The start function is then used to try and submit a job to the runner.

Design issues:
-Only one job submission
-simulate is accessible via the endpoint. It should really only be used via the broker. This is to aid in the unit testing and demonstrates the non-blocking behavior.
-It might also be better to return properly formatted messages, with codes and the data in the body and in json format. I.e. IActionResult.


Considering it's my first time with .net I took advantage of ContosoPizza template.

