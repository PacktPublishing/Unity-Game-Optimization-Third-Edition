using Unity.Collections;
using Unity.Jobs;
using UnityEngine;


public struct SimpleJob : IJob
{
    public float number;
    public NativeArray<float> data;
    public void Execute()
    {
        data[0] += number;
    }
}

public class SimpleJobRunner : MonoBehaviour
{

    // Float to adds in the myData
    public float numberToAdd = 5;

    // Simple native container of type float.
    private NativeArray<float> theData;

    // Handle use to operate job in main thread.
    private JobHandle simpleJobHandle;

    void Start()
    {

        theData = new NativeArray<float>(1, Allocator.TempJob);
        theData[0] = 2;

        // Initialize a Job
        SimpleJob simpleJob = new SimpleJob
        {
            number = numberToAdd,
            data = theData
        };

        // Schedule the job for execution.
        simpleJobHandle = simpleJob.Schedule();

        // Actually run the job.
        JobHandle.ScheduleBatchedJobs();

        // Wait...
        simpleJobHandle.Complete();

        // Check if completed or not and used data from the job result.
        if (simpleJobHandle.IsCompleted)
        {
            Debug.Log(simpleJob.data[0]);
        }

        theData.Dispose();
    }
}
