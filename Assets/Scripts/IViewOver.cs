using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    /// <summary>
    /// Wird von ViewSystem aufgrufen wenn die Camera auf das Objekt sieht.
    /// </summary>
    interface IViewOver
    {
        void OnViewOver(float distance);
    }
}
