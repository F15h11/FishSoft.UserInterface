namespace FishSoft.UserInterface {
    public static class GetUserInput {
        public static string StringInput(string instruction, bool inputInSameLine, bool newLine) {
            if(inputInSameLine) {
                if(newLine) {
                    Console.Out.Write($"\n{instruction}");
                }
                else {
                    Console.Out.Write(instruction);
                }
                string? output = Console.ReadLine();
                if(output != null) {
                    return output;
                }
                else {
                    return "";
                }
            }
            else {
                if(newLine) {
                    Console.Out.Write($"\n{instruction}\n");
                }
                else {
                    Console.Out.Write($"{instruction}\n");
                }
                string? output = Console.ReadLine();
                if(output != null) {
                    return output;
                }
                else {
                    return "";
                }
            }
        }
        public static bool KeyInput(string instruction, ConsoleKey keyTrue, ConsoleKey keyFalse) {
            Console.Out.Write("\n");
            Console.Out.Write(instruction);
            Console.Out.Write("\n");
            while(true) {
                ConsoleKey input = Console.ReadKey().Key;

                if(input == keyTrue) {
                    return true;
                }
                if(input == keyFalse) {
                    return false;
                }
                else {
                    continue;
                }
            }
        }
    }
}
