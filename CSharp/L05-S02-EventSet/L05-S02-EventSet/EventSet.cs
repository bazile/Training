using System;
using System.Collections.Generic;
using System.Threading;

namespace BelhardTraining.EventSetDemo
{
	// This class exists to provide a bit more type safety and
	// code maintainability when using EventSet
	public sealed class EventKey : Object
	{
	}

	public sealed class EventSet
	{
		// The private dictionary used to maintain EventKey -> Delegate mappings
		private readonly Dictionary<EventKey, Delegate> _events = new Dictionary<EventKey, Delegate>();

		// Adds an EventKey -> Delegate mapping if it doesn't exist or
		// combines a delegate to an existing EventKey
		public void Add(EventKey eventKey, Delegate handler)
		{
			Monitor.Enter(_events);
			Delegate d;
			_events.TryGetValue(eventKey, out d);
			_events[eventKey] = Delegate.Combine(d, handler);
			Monitor.Exit(_events);
		}

		// Removes a delegate from an EventKey (if it exists) and
		// removes the EventKey -> Delegate mapping the last delegate is removed
		public void Remove(EventKey eventKey, Delegate handler)
		{
			Monitor.Enter(_events);
			// Call TryGetValue to ensure that an exception is not thrown if
			// attempting to remove a delegate from an EventKey not in the set
			Delegate d;
			if (_events.TryGetValue(eventKey, out d))
			{
				d = Delegate.Remove(d, handler);
				// If a delegate remains, set the new head else remove the EventKey
				if (d != null)
					_events[eventKey] = d;
				else
					_events.Remove(eventKey);
			}
			Monitor.Exit(_events);
		}

		// Raises the event for the indicated EventKey
		public void Raise(EventKey eventKey, Object sender, EventArgs e)
		{
			// Don't throw an exception if the EventKey is not in the set
			Delegate d;
			Monitor.Enter(_events);
			_events.TryGetValue(eventKey, out d);
			Monitor.Exit(_events);
			if (d != null)
			{
				// Because the dictionary can contain several different delegate types,
				// it is impossible to construct a type-safe call to the delegate at
				// compile time. So, I call the System.Delegate type's DynamicInvoke
				// method, passing it the callback method's parameters as an array of}
				// objects. Internally, DynamicInvoke will check the type safety of the
				// parameters with the callback method being called and call the method.
				// If there is a type mismatch, then DynamicInvoke will throw an exception.
				d.DynamicInvoke(new Object[] {sender, e});
			}
		}
	}
}
