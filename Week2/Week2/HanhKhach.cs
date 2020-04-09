using System;
using System.Collections.Generic;
using System.Drawing;
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
        private List<Image> animation;
        private int posX;
        private int posY;
        private int currentFrame;
        private int queueType;
        public int ID {
            get { return id; }
            set { id = value; }
        }
        public int QUEUETYPE
        {
            get { return queueType; }
            set { queueType = value; }
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
        public int POSX
        {
            get { return posX; }
            set { posX = value; }
        }
        public int POSY
        {
            get { return posY; }
            set { posY = value; }
        }
        public int CURRENTFRAME
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }
        public List<Image> ANIMATION
        {
            get { return animation; }
            set { animation = value; }
        }
        public HanhKhach(int id, int type, int duration)/*, int x , int y)*/
        {
            this.id = id;
            this.type = type;
            this.duration = duration;
            this.queueType = type;
            label = new Label();
            currentFrame = 0;

            //label.Location = new System.Drawing.Point(x, y);
        }
    }
}
