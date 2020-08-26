using System;

namespace ByDenisRafi
{
    class C1
    {
        static void Main()
        {
            Console.Title = "Track Your Calories";
            genderCheck();
            weightCheck();
            calorieCalc();
            getUserMacros();
        }

        public static int weight, multiplier, numCalories;

        private static void genderCheck(bool onlyLetters = false)
        {
            Console.Write("Are You a Male or Female?\n");
            string gender = Console.ReadLine();

            for (int i = 0; i < gender.Length; i++)
            {
                if (gender == "Male" || gender == "male" || gender == "Female" || gender == "female")
                {
                    onlyLetters = true;
                    Console.WriteLine("You are a " + gender.ToLower() + ".\n");
                    break;
                }
                else
                {
                    onlyLetters = false;
                }
            }

            if (onlyLetters == false)
            {
                Console.WriteLine("Enter a valid gender.\n");
                genderCheck();
            }
        }

        private static void weightCheck()
        {

            Console.Write("Please enter your goal weight in lbs.\n");
            string lbs = Console.ReadLine();

            int.TryParse(lbs, out weight);

            Console.Write("Your goal weight is " + weight + " lbs.\n");

        }

        private static void calorieCalc()
        {
            Console.Write("\nA multiplier determines calorie intake for cutting, maintenance or bulking diets.\n");
            Console.Write("\nPlease select a calorie multiplier between 10 and 20:\n");

            string multSelect = Console.ReadLine();

            int.TryParse(multSelect, out multiplier);

            Console.Write("Your multiplier is " + multiplier + ".\n");

            numCalories = weight * multiplier;

            Console.Write("\nYou should eat " + numCalories + " calories per day.\n");

            Console.Write("\nEnter the percentages of each macronutrient.\n");
        }

        private static void getUserMacros()
        {

            Console.Write("Protein: ");
            string proteinNumber = Console.ReadLine();

            float proteinPercent;
            float.TryParse(proteinNumber, out proteinPercent);

            Console.Write("\nCarbs: ");
            string carbNumber = Console.ReadLine();

            float carbPercent;
            float.TryParse(carbNumber, out carbPercent);

            Console.Write("\nFat: ");
            string fatNumber = Console.ReadLine();

            float fatPercent;
            float.TryParse(fatNumber, out fatPercent);

            if (proteinPercent + carbPercent + fatPercent != 100)
            {
                Console.Write("\nYour selected percentages must add up to 100%.\n");
                getUserMacros();
            }
            else
            {
                float proteinCalories = numCalories * (proteinPercent / 100);
                float proteinGrams = proteinCalories / 4;

                float carbCalories = numCalories * (carbPercent / 100);
                float carbGrams = carbCalories / 4;

                float fatCalories = numCalories * (fatPercent / 100);
                float fatGrams = fatCalories / 9;

                Console.Write("\nYour recommended macronutrient :\n\n");
                Console.Write("Protein: " + proteinCalories + " calories (" + proteinGrams.ToString("#.##") + "g)\n");
                Console.Write("Carbs: " + carbCalories + " calories (" + carbGrams.ToString("#.##") + "g)\n");
                Console.Write("Fat: " + fatCalories + " calories (" + fatGrams.ToString("#.##") + "g)\n");
            }
        }
    }
}