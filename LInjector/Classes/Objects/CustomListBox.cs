using System;
using System.Windows.Forms;

namespace LInjector.Classes.Objects
{
    public class CustomListBox : ListBox
    {
        private bool mShowScroll;

        public bool ShowScrollbar
        {
            get { return mShowScroll; }
            set
            {
                if (value != mShowScroll)
                {
                    mShowScroll = value;
                    if (IsHandleCreated)
                        RecreateHandle();
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (!mShowScroll)
                    cp.Style = cp.Style & ~0x200000;
                return cp;
            }
        }

        public CustomListBox()
        {
            // Agregar el evento MouseWheel para permitir desplazamiento con el mouse
            MouseWheel += CustomListBox_MouseWheel;
        }

        private void CustomListBox_MouseWheel(object sender, MouseEventArgs e)
        {
            // Manejar el evento MouseWheel para realizar el desplazamiento en el CustomListBox
            int numberOfItemLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            int newIndex = SelectedIndex - numberOfItemLinesToMove;

            // Asegurarse de que el nuevo índice esté dentro de los límites de la lista
            newIndex = Math.Max(newIndex, 0);
            newIndex = Math.Min(newIndex, Items.Count - 1);

            SelectedIndex = newIndex;
        }
    }
}
