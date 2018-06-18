using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using SQLite;

namespace task_app
{
    [Activity(Label = "TaskListActivity")]
    public class TaskListActivity : Activity
    {

        string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db");
        RecyclerView.Adapter listTaskAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_task_list);

            Button buttonAll = FindViewById<Button>(Resource.Id.ButtonAll);
            buttonAll.Click += (sender, args) => ShowAllTask(sender, args);

        }

        public void ShowAllTask(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(dbpath);
            var tableTask = db.Table<Task>();
            List<Task> listOfTask = new List<Task>();
            foreach (var row in tableTask)
            {
                Task PersistenceTask = new Task(row.shortDescription, row.longDescription, row.percentage);
                listOfTask.Add(PersistenceTask);
                Log.Debug("AIAA", "FROM THE DB TASK: " + PersistenceTask.ToString());
            }
            
            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.recycletViewTasks);
            this.listTaskAdapter = new ListTaskAdapter(listOfTask);
            recyclerView.SetAdapter(this.listTaskAdapter);
            LinearLayoutManager manager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(manager);
            
        }
    }
}