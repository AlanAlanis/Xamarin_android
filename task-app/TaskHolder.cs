using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace task_app
{
        public class TaskHolder : RecyclerView.ViewHolder
        {
            public TextView textView { get; set; }
            public TaskHolder(View itemView)
                : base(itemView)
            {
                textView = itemView.FindViewById<TextView>(Resource.Id.taskItem);
            }
        }
 }