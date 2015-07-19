using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// Wird von ViewSystem aufgrufen wenn die Camera auf das Objekt sieht.
/// </summary>
interface IViewOver
{
	void fireSelect(); // fired when object is viewed
	void fireAction(); // fired when object is clicked
}

