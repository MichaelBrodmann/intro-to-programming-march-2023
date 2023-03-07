

namespace CSharpSyntax
{
    internal class Customer
    {
        private decimal _availableCredit = 5000;
        /// <summary>
        /// Use this method to get credit limit
        /// </summary>
        /// <returns>Customer current credit limit</returns>
        public decimal GetCurrentAvailableCredit()
        {
            return _availableCredit;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="effectiveData"></param>
        public void IncreaseAvailableCredit(decimal amount, DateTimeOffset effectiveData)
        {
            _availableCredit += amount;
        }
    }
}
