using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;

namespace LearnFirebase
{
    public class StudentDatabase
    {
        public StudentList StudList { get; set; }
        private const string FIREBASE_PROJD = "simpledb-7f2e9";
        private FirestoreDb db;

        public StudentDatabase()
        {
            StudList = new StudentList();
        }

        public void initFirestore()
        {
            FirebaseApp.Create();
            db = FirestoreDb.Create(FIREBASE_PROJD);
            Console.WriteLine("Created Cloud Firestore client with project ID: {0}", FIREBASE_PROJD);
        }

        public async Task SaveStudent(Student student)
        {
            CollectionReference collectionRef = db.Collection("SimpleCollection");
            DocumentReference docRef = collectionRef.Document(student.Id);

            Dictionary<string, object> values = new Dictionary<string, object>
                  {   // key        // value
                { "Id",            student.Id},
                { "Name",         student.Name},
                { "Age",          student.Age },
                { "SubjectTaken", student.SubjectTaken },
                  };

            Console.WriteLine("Adding doc with ID " + docRef.Id);
            await docRef.SetAsync(values);
        }

        public async Task RestoreStudent()
        {
            Query collectionQuery = db.Collection("SimpleCollection");
            QuerySnapshot allQuerySnapshot = await collectionQuery.GetSnapshotAsync();

            StudList.Clear();
            foreach (DocumentSnapshot documentSnapshot in allQuerySnapshot.Documents)
            {
                Dictionary<string, object> data = documentSnapshot.ToDictionary();
                string name = (data["Name"].ToString());
                int age = int.Parse(data["Age"].ToString());
                int subjecttaken = int.Parse(data["SubjectTaken"].ToString());
                Student student = new Student(name, age, subjecttaken, data["Id"].ToString());

                StudList.Add(student);
            }
        }

        public async Task DelStudent(string data)
        {
            Console.WriteLine("Deleting  " + data);
            CollectionReference collectionRef = db.Collection("SimpleCollection");
            DocumentReference docRef = collectionRef.Document(data);
            await docRef.DeleteAsync();
        }
    }
    
}
