using UnityEngine;
 
public class Singleton<T> where T : class, new()
{
    private static object m_Lock = new object();
    private static T m_Instance;

	private Singleton()
	{

	}
 
    /// <summary>
    /// Access singleton instance through this propriety.
    /// </summary>
    public static T Instance
    {
        get
        {
            lock (m_Lock)
            {
                if (m_Instance == null)
                {
                    m_Instance = new T();
                }
 
                return m_Instance;
            }
        }
    }
}