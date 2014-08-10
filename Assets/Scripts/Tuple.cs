using UnityEngine;
using System.Collections;

public class Tuple<T,U,V,X>
{
	public T Item1 { get; private set; }
	public U Item2 { get; private set; }
	public V Item3 { get; private set; }
	public X Item4 { get; private set; }

	
	public Tuple(T item1, U item2, V item3, X item4)
	{
		Item1 = item1;
		Item2 = item2;
		Item3 = item3;
		Item4 = item4;
	}
}

public static class Tuple
{
	public static Tuple<T,U,V,X> Create<T,U,V,X>(T item1, U item2, V item3, X item4)
	{
		return new Tuple<T,U,V,X>(item1, item2, item3, item4);
	}
}