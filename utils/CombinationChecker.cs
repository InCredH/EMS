namespace EMS.utils
{
    public class CombinationChecker
    {
        public bool IsCombinationUnique<T>(
            Func<T, bool> predicate,
            IQueryable<T> queryable)
        {
            return !queryable.Any(predicate);
        }

    }
}