using UnityEngine;
using Firebase.Firestore;
using Firebase;

public class SimpleFirestoreTest : MonoBehaviour
{
    private FirebaseFirestore db;

    void Start()
    {
        InitializeFirestore();
        Debug.Log("Simple Firestore Test ready!");
        Debug.Log($"Object name: {gameObject.name}");
        Debug.Log($"Object position: {transform.position}");
        Debug.Log($"Has collider: {GetComponent<Collider>() != null}");
    }

    private void InitializeFirestore()
    {
        if (db == null)
        {
            if (FirebaseApp.DefaultInstance == null)
            {
                Debug.LogError("Firebase not initialized! Make sure FirebaseInit script is in your scene.");
                return;
            }
            db = FirebaseFirestore.DefaultInstance;
            Debug.Log("Firestore initialized successfully!");
        }
    }

    void OnMouseDown()
    {
        InitializeFirestore();
        if (db == null)
        {
            Debug.LogError("Cannot save to Firestore - Firebase not initialized!");
            return;
        }
        
        Debug.Log("Object clicked! Sending random coordinates to Firestore...");
        
        // Generate random coordinates
        Vector3 randomPosition = new Vector3(
            Random.Range(-10f, 10f),
            Random.Range(0f, 5f),
            Random.Range(-10f, 10f)
        );

        // Create data to save
        var data = new
        {
            name = "RandomTest_" + System.DateTime.Now.ToString("HHmmss"),
            x = randomPosition.x,
            y = randomPosition.y,
            z = randomPosition.z,
            timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };

        Debug.Log($"Saving coordinates: {randomPosition}");

        // Save to Firestore
        db.Collection("coordinates").Document(data.name).SetAsync(data).ContinueWith(task =>
        {
            if (task.IsCompletedSuccessfully)
            {
                Debug.Log($"✅ SUCCESS! Coordinates saved to Firestore: {randomPosition}");
            }
            else
            {
                Debug.LogError($"❌ FAILED to save coordinates: {task.Exception}");
            }
        });
    }

    void OnMouseEnter()
    {
        Debug.Log("Hovering over clickable object");
    }

    // Manual test method - you can call this from Inspector
    [ContextMenu("Test Firestore Save")]
    public void TestFirestoreSave()
    {
        InitializeFirestore();
        if (db == null)
        {
            Debug.LogError("Cannot save to Firestore - Firebase not initialized!");
            return;
        }
        
        Debug.Log("Manual test triggered! Sending random coordinates to Firestore...");
        
        // Generate random coordinates
        Vector3 randomPosition = new Vector3(
            Random.Range(-10f, 10f),
            Random.Range(0f, 5f),
            Random.Range(-10f, 10f)
        );

        // Create data to save
        var data = new
        {
            name = "ManualTest_" + System.DateTime.Now.ToString("HHmmss"),
            x = randomPosition.x,
            y = randomPosition.y,
            z = randomPosition.z,
            timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };

        Debug.Log($"Saving coordinates: {randomPosition}");

        // Save to Firestore
        db.Collection("coordinates").Document(data.name).SetAsync(data).ContinueWith(task =>
        {
            if (task.IsCompletedSuccessfully)
            {
                Debug.Log($"✅ SUCCESS! Coordinates saved to Firestore: {randomPosition}");
            }
            else
            {
                Debug.LogError($"❌ FAILED to save coordinates: {task.Exception}");
            }
        });
    }
}
