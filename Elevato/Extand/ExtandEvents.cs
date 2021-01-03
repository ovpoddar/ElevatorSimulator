﻿using System;
using System.ComponentModel;

namespace Elevator.Extand
{
    public static class ExtandEvents
    {
        public static object Raise(this MulticastDelegate multicastDelegate, object sender, object eventArgs)
        {
            object retval = null;
            if (multicastDelegate != null)
            {
                foreach (var d in multicastDelegate.GetInvocationList())
                {
                    var ISynchronizeInvoke = d.Target as ISynchronizeInvoke;
                    if (ISynchronizeInvoke != null && ISynchronizeInvoke.InvokeRequired)
                        retval = ISynchronizeInvoke.EndInvoke(ISynchronizeInvoke.BeginInvoke(d, new[] { sender, eventArgs }));
                    else
                        retval = d.DynamicInvoke(new[] { sender, eventArgs });
                }
            }
            return retval;
        }
    }
}
