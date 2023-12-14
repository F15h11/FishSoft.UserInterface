/*
 How to use:
	1. Call a new instance of this class with one of the constructors.
		-The first constructor has 2 parameters.
			1. title: This is the title of the menu.
			2. optionCategories: this is an array of ObjectCategory instances which will be used in the menu.
		-The second constructor has the same parameters as the first one + a bool called displayDebugInfo, when its value is "true"
		the menu will show debug info below itself.
		-The third and fourth costructor are working the same way as the first two but they
		have a single OptionCategory as parameter.
	2. Declare an int array and assign it with the return value of the Run() method
	3. Use the returned value to let your program decide the next step.
		-The first index of the returned value is the chosen OptionCategory.
		-The second index is the chosen option of the OptionCategory.
	4. Done :)
*/
namespace FishSoft.UserInterface {
    public class Menu {
        private const string pointer = " <-";
        private const string info = "Use the arrow keys to navigate through the menu.\nUse Enter to select and Space to deselect.\n";

        string _title;
        OptionCategory[] _optionCategories;
        int _optionCategoriesCount;
        int[] _optionsCount;        //Index = Index of Option category
        int _positionOptionCategorie;
        int _positionOption;
        bool _inOptionCategorie;
        bool _multipleOptionCategories;
        bool _displayDebugInfo;
        public Menu(string title, OptionCategory[] optionCategories) {
            _title = title;
            _optionCategories = optionCategories;
            _optionCategoriesCount = optionCategories.Length;
            _optionsCount = getOptionsCount(optionCategories);
            _positionOptionCategorie = 0;
            if(optionCategories.Length > 1) {
                checkIfValid(optionCategories);
                _inOptionCategorie = false;
                _multipleOptionCategories = true;
            }
            else {
                _inOptionCategorie = true;
                _multipleOptionCategories = false;
            }
            _displayDebugInfo = false;
        }
        public Menu(string title, OptionCategory[] optionCategories, bool displayDebugInfo) {
            _title = title;
            _optionCategories = optionCategories;
            _optionCategoriesCount = optionCategories.Length;
            _optionsCount = getOptionsCount(optionCategories);
            _positionOptionCategorie = 0;
            if(optionCategories.Length > 1) {
                checkIfValid(optionCategories);
                _inOptionCategorie = false;
                _multipleOptionCategories = true;
            }
            else {
                _inOptionCategorie = true;
                _multipleOptionCategories = false;
            }
            _displayDebugInfo = displayDebugInfo;
        }
        public Menu(string title, OptionCategory optionCategory) {
            _title = title;
            _optionCategories = new OptionCategory[] { optionCategory };
            _optionCategoriesCount = 1;
            _optionsCount = new int[] { optionCategory.Options.Length };
            _positionOptionCategorie = 0;
            _inOptionCategorie = true;
            _multipleOptionCategories = false;
        }
        public Menu(string title, OptionCategory optionCategory, bool displayDebugInfo) {
            _title = title;
            _optionCategories = new OptionCategory[] { optionCategory };
            _optionCategoriesCount = 1;
            _optionsCount = new int[] { optionCategory.Options.Length };
            _positionOptionCategorie = 0;
            _inOptionCategorie = true;
            _multipleOptionCategories = false;
            _displayDebugInfo = displayDebugInfo;
        }
        public int[] Run() {
            while(update()) ;
            return new int[2] { _positionOptionCategorie, _positionOption };
        }
        bool update() {
            Console.Out.Write(display());
            if(_displayDebugInfo) {
                Console.Out.Write(displayDebugInfo());
            }
            int input = 0;
            do {
                input = getKeyInput();
            } while(input == 0);
            if(input == 1) {
                movePosition(true);
            }
            if(input == 2) {
                movePosition(false);
            }
            if(input == 3) {
                _inOptionCategorie = false;
                _positionOption = 0;
            }
            if(input == 4) {
                if(!_inOptionCategorie & _multipleOptionCategories) {
                    _inOptionCategorie = true;
                }
                else {
                    Console.Clear();
                    return false;
                }
            }
            Console.Clear();
            return true;
        }

        string display() {
            string output = "";

            output += _title;
            output += "\n";

            for(int i = 0; i < _optionCategories.Length; i++) {
                if(_optionCategories[i].HasName) {
                    output += _optionCategories[i].Name;
                    if(_positionOptionCategorie == i & !_inOptionCategorie) {
                        output += pointer;
                    }
                    output += "\n";
                }
                for(int j = 0; j < _optionCategories[i].Options.Length; j++) {
                    output += $"  {_optionCategories[i].Options[j]}";
                    if(_positionOptionCategorie == i & _positionOption == j & _inOptionCategorie) {
                        output += pointer;
                    }
                    output += "\n";
                }
            }
            output += info;

            return output;
        }
        string displayDebugInfo() {
            string output = "\n";
            output += $"Debug info (Menu)\n";
            output += $"{nameof(_optionCategoriesCount)}: {_optionCategoriesCount} \n";
            output += $"{nameof(_optionsCount)}: {string.Join(", ", _optionsCount)}\n";
            output += $"{nameof(_positionOptionCategorie)}: {_positionOptionCategorie}\n";
            output += $"{nameof(_positionOption)}: {_positionOption}\n";
            output += $"{nameof(_inOptionCategorie)}: {_inOptionCategorie}\n";
            output += $"{nameof(_multipleOptionCategories)}: {_multipleOptionCategories}\n";

            return output;
        }
        void movePosition(bool up) {
            if(!_inOptionCategorie) {
                if(up) {
                    if(_positionOptionCategorie > 0) {
                        _positionOptionCategorie--;
                    }
                    else {
                        _positionOptionCategorie = _optionCategoriesCount - 1;
                    }
                }
                if(!up) {
                    if(_positionOptionCategorie < _optionCategoriesCount - 1) {
                        _positionOptionCategorie++;
                    }
                    else {
                        _positionOptionCategorie = 0;
                    }
                }
            }
            if(_inOptionCategorie) {
                if(up) {
                    if(_positionOption > 0) {
                        _positionOption--;
                    }
                    else {
                        _positionOption = _optionsCount[_positionOptionCategorie] - 1;
                    }
                }
                if(!up) {
                    if(_positionOption < _optionsCount[_positionOptionCategorie] - 1) {
                        _positionOption++;
                    }
                    else {
                        _positionOption = 0;
                    }
                }
            }
        }
        static void checkIfValid(OptionCategory[] optionCategories) {
            for(int i = 0; i < optionCategories.Length; i++) {
                if(!optionCategories[i].HasName) {
                    throw new Exception("Contructor got more than one option categories and one of them didnt have a name");
                }
            }
        }
        static int[] getOptionsCount(OptionCategory[] optionCategories) {
            int[] c = new int[optionCategories.Length];
            int counter = 0;
            for(int i = 0; i < optionCategories.Length; i++) {
                for(int j = 0; j < optionCategories[i].Options.Length; j++) {
                    counter++;
                }
                c[i] = counter;
                counter = 0;
            }
            return c;
        }
        static int getKeyInput() {
            ConsoleKey input = Console.ReadKey().Key;
            if(input == ConsoleKey.UpArrow | input == ConsoleKey.NumPad8) {
                return 1;
            }
            if(input == ConsoleKey.DownArrow | input == ConsoleKey.NumPad2) {
                return 2;
            }
            if(input == ConsoleKey.Spacebar) {
                return 3;
            }
            if(input == ConsoleKey.Enter) {
                return 4;
            }
            else {
                return 0;
            }
        }
    }
}
