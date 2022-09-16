using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moxitech_Tasklist_Open_Source
{
    internal class MoxVerticalStackLayout : VerticalStackLayout
    {
        public static int idOfAllTask = 0;
        private int localId = 0;
        public MoxVerticalStackLayout() : base()
        {
            localId = idOfAllTask;
            idOfAllTask++;
        }
        public List<TaskView> ToArrayView()
        {
           List<TaskView> list = new List<TaskView>();
            for (int i = 0; i < localId; i++)
            {
                list.Add((TaskView)this[i]);
            }
            return list;
        }
    }
}
