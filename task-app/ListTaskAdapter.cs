using System;
using Android.Content;
using Android.Widget;
using Android.Views;
using System.Collections.Generic;
using Android.Provider;
using Android.App;
using Java.Lang;
using Android.Util;
using Android.Support.V7;
using System.IO;
using Android.OS;
using SQLite;
using Android.Support.V7.Widget;

namespace task_app
{
    class ListTaskAdapter : RecyclerView.Adapter
    {
        List<Task> listOfTasks;

        public ListTaskAdapter(List<Task> listOfTasks)
        {
            this.listOfTasks = listOfTasks;
        }
        
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.single_task_item, parent, false);

            TaskHolder taskHolder = new TaskHolder(itemView);
            return taskHolder;
        }
        
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {

            TaskHolder taskHolder = holder as TaskHolder;

            Task task = listOfTasks[position];

            var strTask = task.shortDescription + "    " + task.percentage + "%";
            taskHolder.textView.Text = strTask;

        }
        
        public override int ItemCount
        {
            get { return listOfTasks.Count; }
        }

        //------------------------------------------------------------------------------------------------------------------

    }


}