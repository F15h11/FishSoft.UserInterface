/*
 How to use:
 Call the constructor like this to create a OptionCategory with a name:
    -> OptionCategory myOptionCategory = new OptionCategory("myOptionCategory", new string[] { "optionOne", "optionTwo" });
 Use the OptionCategory with name with other OptionCategoriy's (must also have a name) to have a menu with multiple option categories.
 Call the constructor like this to create a OptionCategory without a name:
    -> OptionCategory myOptionCategory = new OptionCategory(new string[] { "optionOne", "optionTwo", "optionThree" });
 Use this option if the menu has only one option categorie (the menu title should describe the option categorie then).
 */

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
