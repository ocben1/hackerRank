using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


/*ESCAPE SEQUENCES*/
// Escape sequences represent non-printable and special characters in literal strings. 
// Originally used to send commands to hardware devices like printers and display terminal
// They are still useful for embedded tabs, line feed and similar into the string

// use the \ to indicate the start of the escape sequence.

// \', \", \\

// Console.WriteLine("The customer said, \"I want a refund\".");

// // \r carriage return, \n new line
// Console.WriteLine("The first line.\r\nThe second line");

// // \t horizontal tab, \v vertical tab
// Console.WriteLine("aaa\tbbb\tccc\vddd\teee\tfff");

// 			//	\\ Backslash used for file path
// Console.WriteLine("C:\\users\\walt\\documents");

// 			// \u to inject unicode into string
// Console.WriteLine("Add any Unicode code point:\v\u2600 \u2614 \u2615 \u273F \r\n\u2600 \u2614 \u2615 \u273F ");

//dollarString = String.Format("{0:C}", num1);
//percentageString = String.Format("{0:P}", num1);
//interpolatedString = $"{header}{num1:P}, {num2:C}";

/*SPLIT STRINGS

		private void ButtonA_Click(object sender, RoutedEventArgs e)
		{
			string foods = "apple banana cherry durian eggplant fig grape  honey";
			OutputTextBox.Text += $"{foods}\r\n";
			// Split is used to break a delimited string into individual strings. 
			// which are added to a string array 

			var foodArray = foods.Split();
			foreach (var food in foodArray)
			{
				OutputTextBox.Text += $"{food}\r\n";
			}
		}
        //SPLIT BY COMMA
		private void ButtonB_Click(object sender, RoutedEventArgs e)
		{
			string foods = "kiwi, lemon, mushroom, onion, potato, radish, spinach, tomato";
			OutputTextBox.Text += $"{foods}\r\n";

			string[] comma = { ", " };
			var foodArray = foods.Split(comma, StringSplitOptions.None);

			foreach (var food in foodArray)
			{
				OutputTextBox.Text += $"{food}\r\n";
			}

		}
        //SPLIT USING MULTIPLE DELIMITERS
		private void ButtonC_Click(object sender, RoutedEventArgs e)
		{
			string foods = "kiwi--banana--mushroom # eggplant # potato # grape.spinach.honey";
			OutputTextBox.Text += $"{foods}\r\n";
			string[] splitters = { ", ", "--", ".", " # " };

			var foodArray = foods.Split(splitters, StringSplitOptions.None);

			foreach (var food in foodArray)
			{
				OutputTextBox.Text += $"{food}\r\n";
			}
		}
        //SPLIT BY COMMA, REMOVE EMPTY ENTRIES
		private void ButtonD_Click(object sender, RoutedEventArgs e)
		{
			string foods = "kiwi, , mushroom, onion, potato, , spinach, tomato";
			OutputTextBox.Text += $"{foods}\r\n";
			string[] comma = { ", " };
			var foodArray = foods.Split(comma, StringSplitOptions.RemoveEmptyEntries);

			foreach (var food in foodArray)
			{
				OutputTextBox.Text += $"{food}\r\n";
			}
		}

        // USING LINQ TO QUERY STRING ARRAY
        private void ButtonA_Click(object sender, RoutedEventArgs e) {
			string foods = "kiwi, lemon, kiwi, onion, potato, lemon, spinach, tomato, lemon, onion";
			OutputTextBox.Text += foods + "\r\n";
			string[] comma = { ", " };


			var foodArray = foods.Split(comma, StringSplitOptions.RemoveEmptyEntries);
            //GROUP BY EACH WORD, THEN OUTPUT FOODS THAT OCCUR MORE THAN ONCE
			var countQuery = foodArray.GroupBy(x => x).Where(x => x.Count() > 1);
			foreach (var food in foodArray)
			{
				OutputTextBox.Text += $"{food}\r\n";
			}

		}
        //convert to string array, then search for substring
		private void ButtonB_Click(object sender, RoutedEventArgs e) {

			string statusCodes = "#kr032,#rt887,#kr932,#wt187,#aa321,#bb872,#dm554";
			OutputTextBox.Text += statusCodes + "\r\n";
			var statusArray = statusCodes.Split(',');



			foreach (var status in statusArray)
			{
				OutputTextBox.Text += $"{status} \r\n";
			}
			OutputTextBox.Text += "------------\r\n";

            var query = statusArray.Where(x=>x.Contains("87"))

            foreach(var status in query)
            {
                OutputTextBox.Text += $"{status} \r\n";
            }
		}
        //join a string array and parse a delimiter
        		private void ButtonA_Click(object sender, RoutedEventArgs e)
		{
			string[] foodArray = { "banana", "celery", "kiwi", "onion", "potato", "cherry" };

			string foodString = string.Join("--=--", foodArray);

			this.OutputTextBox.Text = foodString;

		}

		private void ButtonB_Click(object sender, RoutedEventArgs e)
		{
			List<string> foodList = new List<string> { "banana", "celery", "kiwi", "onion", "potato", "cherry" };

			string foodString = String.Join("#", foodList);

			this.OutputTextBox.Text = foodString;
		}

		private void ButtonC_Click(object sender, RoutedEventArgs e)
		{

			List<double> numbers = new List<double> { 1.5, 2.5, 3.5, 8.5, 7.5, 6.5 };

			string numbersString = String.Join(" + ", numbers);
			this.OutputTextBox.Text = numbersString;
		}

        //REMOVE WHITESPACE FROM START AND END OF A STRING USING TRIM METHOD
        		private void ButtonA_Click(object sender, RoutedEventArgs e) {
			string sample = "   At Roux, our mission is to teach and inspire the next generation’s artists to create work that changes the way people think, and hopefully, even the way they act. We believe art inspires compassion by providing audiences with an empathetic outlet.  ";


			string trimmedString  = string.Empty;
			trimmedString = sample.Trim();
			OutputTextBox.Text = trimmedString;
		}
        //FIRST TRIM, THEN TRIM THE UNWANTED CHARS (specified by charsToTrim) FROM START
		private void ButtonB_Click(object sender, RoutedEventArgs e) {
			string sample = " ,,../   At Roux, our mission is to teach and inspire the next generation’s artists to create work that changes the way people think, and hopefully, even the way they act. We believe art inspires compassion by providing audiences with an empathetic outlet.  ";
			char[] charsToTrim = { ',', '.', ' ','/' };
			var trimmedString = sample.Trim().TrimStart(charsToTrim);
			OutputTextBox.Text = trimmedString;
		}
        //SEARCH FOR A SUBSTRING
        		private void ButtonA_Click(object sender, RoutedEventArgs e) {
			string longString = "01-02-03-04-05-06-07-08-09-10-11-12-13-14-15-16-17-18-19-20";

			string sub1 = longString.Substring(18);
			string sub2 = longString.Substring(18, 8);


			OutputTextBox.Text += sub1 + "\r\n";
			OutputTextBox.Text += sub2 + "\r\n";
		}

		private void ButtonB_Click(object sender, RoutedEventArgs e) {
			string longString = "AA212-BB102-CC453-BT455-TR376-GH003-QR417-NV018-AG204-LJ122";
			string result = string.Empty;
			// use Contains to determine if a sub string exists
			// use IndexOf to get index of substring
			OutputTextBox.Text += longString + "\r\n";
			string searchString = InputTextBox.Text;
            //FINDS THE SEARCHSTRING - ARRIVES AT INDEXOF SKIPS 2 CHAR, THEN GET THE NEXT 3
			if (longString.Contains(searchString))
			{
				int index = longString.IndexOf(searchString);
				result = longString.Substring(index + 2, 3); 

				OutputTextBox.Text += $"Ticket Code: {searchString} is {result}\r\n";
			}
		}
        */

private void doesCharExist(object sender, RoutedEventArgs e)
{
    // determine if a char exists within string
    char c3 = 'm';
    char resultChar;

    string letters = "abc-def-ghi-jkl-mno-pqr-stu-vwx-yz";

    if (letters.Contains(c3))
    {
        var index = letters.IndexOf(c3);
        resultChar = letters[index];
    }
}
private void isItPunctuation(object sender, RoutedEventArgs e)
{
    Char c1 = '.';
    // use the Char methods to test for Unicode categories.

    if (Char.IsPunctuation(c1))
    {
        // determine if this char is considered a punctuation
        // by the Unicode Standards.
        return "Is punctuation";
    }
    else
    {
        return "Is not punctuation";
    }
}

private void isItADigit(object sender, TextCompositionEventArgs e)
{
    Char currentChar = e.Text[0];

    if (Char.IsDigit(currentChar))
    {
        return true;
    }
}