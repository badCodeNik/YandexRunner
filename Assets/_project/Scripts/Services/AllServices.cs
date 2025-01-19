namespace _project.Scripts.Services
{
  public class AllServices
  {
    private static AllServices _instance;
    public static AllServices Container => _instance ?? (_instance = new AllServices());

    public void RegisterSingle<T>(T implementation)  =>
      Implementation<T>.ServiceInstance = implementation;

    public T Single<T>()  =>
      Implementation<T>.ServiceInstance;

    private class Implementation<T> 
    {
      public static T ServiceInstance;
    }
  }
}