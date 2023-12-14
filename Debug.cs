using FishSoft.UserInterface;
internal static class Debug {
    public static void Main() {
        OptionCategory optionCategory1 = new OptionCategory("OptionCategory1", new string[] { "Option1", "Option2" });
        OptionCategory optionCategory2 = new OptionCategory("OptionCategory2", new string[] { "Option1", "Option2", "Option3" });
        OptionCategory optionCategory3 = new OptionCategory("OptionCategory3", new string[] { "Option1" });
        Menu menu1 = new Menu("Menu1", new OptionCategory[] { optionCategory1, optionCategory2, optionCategory3 });
        int[] inputMenu = menu1.Run();
        Console.Write(string.Join(", ", inputMenu));
        Console.Read();
    }
}


