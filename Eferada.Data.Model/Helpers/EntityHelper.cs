namespace Eferada.Data.Model.Helpers
{
    public static class EntityHelper
    {
        public static bool IsPersisted<T>(T id) => !id.Equals(default(T));
    }
}