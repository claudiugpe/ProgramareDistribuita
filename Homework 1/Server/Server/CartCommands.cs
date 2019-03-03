namespace Server
{
    public static class CartCommands
    {
        public const string VIEW_COMMANDS = "VIEW_COMMANDS";

        public const string ADD_ITEM = "ADD";

        public const string VIEW_ITEMS = "VIEW_ITEMS";

        public const string REMOVE_ITEM = "REMOVE";

        public const string VIEW_CART = "VIEW_CART";

        public const string CASHOUT = "CASHOUT";

        public const string START = "START_SHOPPING";

        public static string GetCommands()
        {
            var result = string.Empty;

            result = result + VIEW_COMMANDS + ",";
            result = result + ADD_ITEM + ",";
            result = result + VIEW_ITEMS + ",";
            result = result + REMOVE_ITEM + ",";
            result = result + VIEW_CART + ",";
            result = result + CASHOUT + ",";
            result = result + START + ",";

            return result;
        }
    }
}
