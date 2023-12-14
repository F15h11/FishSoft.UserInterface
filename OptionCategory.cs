namespace FishSoft.UserInterface {
    public struct OptionCategory {
        public string? Name;
        public string[] Options;
        public bool HasName;
        public OptionCategory(string name, string[] options) {
            Name = name;
            Options = options;
            HasName = true;
        }
        public OptionCategory(string[] options) {       //Should only be used if its the only OptionCategoriy used in the Menu
            Options = options;
            HasName = false;
        }
    }
}
