using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Content;
using System;

namespace task_app
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);



            Button buttonNewTask = FindViewById<Button>(Resource.Id.buttonNewTask);
            buttonNewTask.Click += (sender, args) =>
            {
                ShowNewTaskForm(sender, args);
            };

            Button buttonShowAll = FindViewById<Button>(Resource.Id.ButtonShowAll);
            buttonShowAll.Click += (sender, args) =>
            {
                ShowTaskList(sender, args);
            };


        }




        public void ShowNewTaskForm(object sender, EventArgs e)
        {
            Log.Debug("AIAA", "click ButtonNewTask");

            Intent intent = new Intent(this, typeof(NewTaskFormActivity));
            StartActivity(intent);
        }


        public void ShowTaskList(object sender, EventArgs e)
        {
            Log.Debug("AIAA", "click ButtonShowAll");

            Intent intent = new Intent(this, typeof(TaskListActivity));
            StartActivity(intent);
        }
    }
}

