using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace task_app
{
    public class Task
    {
        public String shortDescription { get; set; }
        public String longDescription { get; set; }
        public int percentage { get; set; }

        public Task(String shortDescription, String longDescription, int percentage)
        {
            this.shortDescription = shortDescription;
            this.longDescription = longDescription;
            this.percentage = percentage;
        }
        public Task()
        {

        }

        public override String ToString()
        {
            return string.Format("Short description: {0}, percentage: {1}", this.shortDescription, this.percentage);
        }
    }
}