namespace NonProfitLibrary.Api.Models.Abstractions
{
    public class AbstractionService
    {
        public bool DoAction(Action action)
        {
            try
            {
                action.Invoke();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
