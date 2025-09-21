# Firestore Testing Guide

## Setup Instructions

### 1. Add the FirestoreTester Script
1. In Unity, create an empty GameObject in your scene
2. Add the `FirestoreTester` script to this GameObject
3. Make sure you also have the `FirebaseInit` and `SavePosition` scripts in your scene

### 2. Firebase Configuration
Ensure your Firebase project is properly configured:
- `google-services.json` is in the correct location
- Firebase SDK is properly imported
- Firestore rules allow read/write access for testing

## Testing Methods

### Method 1: Using Context Menu (Recommended for Development)
1. Select the GameObject with `FirestoreTester` script
2. In the Inspector, right-click on the script component
3. Choose any of the test methods from the context menu:
   - **Test Save Simple Position**: Saves a basic position
   - **Test Save Multiple Positions**: Saves several test positions
   - **Test Save Custom Data**: Saves custom structured data
   - **Test Read Data**: Reads all data from coordinates collection
   - **Test Read Specific Document**: Reads a specific document
   - **Test Data Integrity**: Saves data and immediately reads it back
   - **Run All Tests**: Executes all tests in sequence
   - **Clear Test Data**: Removes all test data from Firestore

### Method 2: Using Runtime UI (During Play Mode)
1. Enter Play Mode in Unity
2. Look for the "Firestore Testing Panel" in the top-left corner of the Game view
3. Click the buttons to run various tests
4. Check the Console for detailed logs

### Method 3: Programmatic Testing
Call the test methods from other scripts:
```csharp
FirestoreTester tester = FindObjectOfType<FirestoreTester>();
tester.TestSaveSimplePosition();
tester.TestReadData();
```

## What Each Test Does

### Data Writing Tests
- **Simple Position**: Creates a test object and saves its position
- **Multiple Positions**: Saves several objects with different positions
- **Custom Data**: Saves structured data with timestamps and metadata

### Data Reading Tests
- **Read All Data**: Retrieves all documents from the coordinates collection
- **Read Specific**: Retrieves a specific document by ID
- **Data Integrity**: Saves data then immediately reads it back to verify accuracy

### Data Validation
- Checks that saved data matches what was sent
- Verifies all fields are present and correct
- Provides clear pass/fail feedback

## Monitoring Results

### Console Logs
- ✓ Green checkmarks indicate successful operations
- ✗ Red X marks indicate failures
- Detailed error messages help identify issues

### Firestore Console
1. Go to [Firebase Console](https://console.firebase.google.com)
2. Select your project
3. Navigate to Firestore Database
4. Check the "coordinates" and "test_data" collections
5. Verify data appears correctly

## Troubleshooting

### Common Issues
1. **Firebase not initialized**: Ensure `FirebaseInit` script runs before other scripts
2. **Permission denied**: Check Firestore security rules
3. **Network issues**: Verify internet connection and Firebase configuration
4. **Null reference errors**: Ensure all required GameObjects exist

### Debug Tips
- Enable "Enable Debug Logs" in the FirestoreTester component
- Check Unity Console for detailed error messages
- Use the Firestore Console to verify data persistence
- Test with simple data first before complex structures

## Test Data Structure

### Coordinates Collection
```json
{
  "name": "TestObject",
  "x": 1.5,
  "y": 2.0,
  "z": 3.5,
  "rotationX": 0.0,
  "rotationY": 90.0,
  "rotationZ": 0.0,
  "timestamp": "2024-01-15 14:30:25",
  "sceneName": "MainScene"
}
```

### Test Data Collection
```json
{
  "timestamp": "2024-01-15T14:30:25",
  "user_id": "test_user_123",
  "scene_name": "MainScene",
  "device_type": "Desktop",
  "position": {"x": 1.0, "y": 2.0, "z": 3.0},
  "rotation": {"x": 0.0, "y": 90.0, "z": 0.0}
}
```

## Best Practices

1. **Test in Development First**: Always test in development environment before production
2. **Clear Test Data**: Use "Clear Test Data" to clean up after testing
3. **Monitor Performance**: Watch for any performance issues during testing
4. **Verify Persistence**: Check that data persists after app restarts
5. **Test Edge Cases**: Try saving null objects, empty names, etc.

## Next Steps

Once basic testing is working:
1. Test with your actual game objects
2. Implement data validation in your production code
3. Add error handling for network failures
4. Consider implementing offline data caching
5. Set up proper Firestore security rules for production
