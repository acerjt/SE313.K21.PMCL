using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week2
{
    public class HanhKhach
    {
        private int id;
        private int type;
        private int duration;
        private Label label;
        private Boolean isProcess;

        public int ID {
            get { return id; }
            set { id = value; }
        }

        public int TYPE
        {
            get { return type; }
            set { type = value; }
        }

        public int DURATION
        {
            get { return duration; }
            set { duration = value; }
        }

        public Label LABEL
        {
            get { return label ; }
            set { label = value; }
        }
        public Boolean ISPROCESS
        {
            get { return isProcess; }
            set { isProcess = value; }
        }
        public HanhKhach(int id, int type, int duration)/*, int x , int y)*/
        {
            this.id = id;
            this.type = type;
            this.duration = duration;
            label = new Label();
            //label.Location = new System.Drawing.Point(x, y);
        }
    }
}
