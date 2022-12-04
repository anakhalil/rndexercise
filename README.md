Design assumptions:

.NET version: 7.0

Endpoints:
.          [POST]
simulate   [GET]
start      [GET]
que        [GET]
{id}       [GET]
progress   [GET]

Made some design changes compared to the first iteration. Now a job has a model and contains a state value. A collection of jobs can then be created and processed by the consumer. 

The endpoints have changed as well. You can post with an empty body to create a new job with random value (time to sleep). 
Use the que endpoint to return all jobs in the queue or pass an id to return a specific job from the queue. Lastly, progress will return a summary of the job queue.

The Tests README has some instructions on how to run the code and use the endpoints.


Design issues:
- I wanted to look into async functions more and considered not using tasks / threads but only one.
- The Job model can be updated so that instead of a Value, it could have a generic command or Task. This would allow it to run any function and allow the jobs to be generic. I had issues getting this feature working.
- I know there are some issues with async / multi thread behavior. I needed to look into locking functions / variables to minimize these problems. I tried to mitigate unwanted behavior by copying the jobs list before using it.
- simulate is accessible via the endpoint. It should really only be used via the broker. This is to aid in the unit testing and demonstrates the non-blocking behavior.
- It might also be better to return properly formatted messages, with codes and the data in the body and in json format. I.e. IActionResult.
- I did note that there is a delay, in starting each job, when the jobs list is large.
- It would be nice to return some JSON rather then a list.
- I don't think its fully async as the service should release the client then contact when its done running simulate. My design is a asynrous broker which allows multiple clients to communicate, with it, as the same time. However each client connection is not async.

Considering it's my first time with .net I took advantage of ContosoPizza template. Please see the commit history as I have updated the readme as the project advanced.
