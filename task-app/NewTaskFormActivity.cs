using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SQLite;


namespace task_app
{
    [Activity(Label = "NewTaskFormActivity")]
    public class NewTaskFormActivity : Activity
    {

        int intTaskProgress = 0;

        string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db");


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_new_task_form);


            //                                              //Cancel button
            Button buttonCancel = FindViewById<Button>(Resource.Id.ButtonCancel);
            buttonCancel.Click += (sender, args) =>
            {
                CancelNewTask(sender, args);
            };


            Button buttonSave = FindViewById<Button>(Resource.Id.ButtonSave);
            buttonSave.Click += (sender, args) =>
            {
                SaveNewTask(sender, args);
            };

            //                                              //Listener
            TextView textPercentage = FindViewById<TextView>(Resource.Id.TextViewPercentage);

            bool boolDone = false;
            int intSeekBarProgress = 0;


            SeekBar seekBarPercentage = FindViewById<SeekBar>(Resource.Id.SeekbarPercentage);
            seekBarPercentage.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) =>
            {
                intSeekBarProgress = e.Progress;
                Log.Debug("AIAA", "Done: " + boolDone);
                if (boolDone)
                {
                    textPercentage.Text = "100%";
                    intTaskProgress = 100;
                }
                else
                {
                    textPercentage.Text = String.Format("{0}%", intSeekBarProgress);
                    intTaskProgress = intSeekBarProgress;
                }
                Log.Debug("***********************", textPercentage.Text);
            };

            Switch switchDone = FindViewById<Switch>(Resource.Id.SwitchDone);
            switchDone.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) =>
            {
                if (e.IsChecked)
                {
                    boolDone = true;
                    textPercentage.Text = "100%";
                    intTaskProgress = 100;
                }
                else
                {
                    boolDone = false;
                    textPercentage.Text = String.Format("{0}%", intSeekBarProgress);
                    intTaskProgress = intSeekBarProgress;
                    
                }
                Log.Debug("***********************", textPercentage.Text);
            };





        }

        public void CancelNewTask(object sender, EventArgs e)
        {
            Log.Debug("AIAA", "click ButtonCancel");

            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        public void SaveNewTask(object sender, EventArgs e)
        {
            Task task = new Task();

            TextView shortDescription = FindViewById<TextView>(Resource.Id.EditTextShortDescription);
            task.shortDescription = shortDescription.Text;

            TextView longDescription = FindViewById<TextView>(Resource.Id.EditTextLongDescription);
            task.longDescription = longDescription.Text;


            task.percentage = this.intTaskProgress;

            var db = new SQLiteConnection(dbpath);

            db.CreateTable<Task>();

            db.Insert(task);

            var tableTask = db.Table<Task>();
            foreach (var row in tableTask)
            {
                Task PersistenceTask = new Task(row.shortDescription, row.longDescription, row.percentage);
                Log.Debug("AIAA*********", "FROM THE DB TASK: " + PersistenceTask.ToString());
            }


            Finish();
        }
    }
}