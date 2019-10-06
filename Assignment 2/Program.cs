using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter an integer value between 1 and 20: ");
            // This variable will gather data from user input
            string input = Console.ReadLine();
            // This variable will be used to perform the various iterative statements and is parsed as an integer
            int value_of_input = int.Parse(input);
            // min will be used to store the lowest random integer value that can be generated in the binary_search array
            int min = 0;
            // max will be used to store the maximum random integer value that can be generated in the binary_search array
            int max = 20;
            int[] binary_search = new int[value_of_input];
            // Generate a random number object instance called randNum
            Random randNum = new Random();

            // Populate the array with random numbers between 0 and 20
            for (int i = 0; i < value_of_input; i++)
            {
                // Populate an element within the array with a random number between 0 and 20
                binary_search[i] = randNum.Next(min, max);
                // Display the randomly generated element to the console
                // Console.Write("  " + binary_search[i]);
            }

            // Now sort the integer values in the array as required by binary search
            Array.Sort(binary_search);
            Console.WriteLine("");
            Console.WriteLine("Here is the array with the integer values in order as required by Binary Search: ");

            for (int i = 0; i < value_of_input; i++)
                Console.Write(" [" + i + "]");
            Console.WriteLine("");

            // Print the ordered array to the console
            for (int i = 0; i < value_of_input; i++)
            {
                Console.Write("   " + binary_search[i]);
            }
            Console.WriteLine("");
            // Here the user should enter an integer value from the list displayed by the array in the console
            Console.Write("Now enter one integer value from this array to conduct the Binary Search: ");

            // This variable will gather data from user input
            string get_search = Console.ReadLine();
            // This variable will be used to perform the various iterative statements and is parsed as an integer
            int value_of_get_search = int.Parse(get_search);

            

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Now let's search for your integer value ...");

            Console.WriteLine(SearchInsert(binary_search, value_of_get_search));


            int[] nums1 = { 1, 3, 2, 5, 5, 2 };

            int[] nums2 = { 0, 8, 2, 9, 3, 1 };

            int[] intersectionArray = Intersect(nums1, nums2);

            Console.WriteLine("Intersection Array:");
            foreach (int num in intersectionArray)
                Console.Write(num + " ");
            Console.WriteLine();

            int[] nums3 = { 9, 9, 8, 8 };
            Console.WriteLine("Largest Integer is " + LargestUniqueNumber(nums3));

            int[] nums4 = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            Console.WriteLine("Largest Integer is " + LargestUniqueNumber(nums4));

            string keyboard = "pqrstuvwxyzabcdefghijklmno";
            string word = "leetcode";

            Console.WriteLine("Time to type " + word + " using keyboard '" + keyboard + "' is " + CalculateTime(keyboard, word));

            int[,] image1 = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
            int[,] image2 = { { 1, 1, 0, 0 }, { 1, 0, 0, 1 }, { 0, 1, 1, 1 }, { 1, 0, 1, 0 } };

            Console.WriteLine("Original Image1:");
            for (int i = 0; i < image1.GetLength(0); i++)
            {
                for (int j = 0; j < image1.GetLength(1); j++)
                {
                    Console.Write(image1[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Flipped and Inverted Image1:");
            image1 = FlipAndInvertImage(image1);
            for (int i = 0; i < image1.GetLength(0); i++)
            {
                for (int j = 0; j < image1.GetLength(1); j++)
                {
                    Console.Write(image1[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Original Image2:");
            for (int i = 0; i < image2.GetLength(0); i++ )
            {
                for (int j = 0; j < image2.GetLength(1); j++ )
                {
                    Console.Write(image2[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Flipped and Inverted Image2:");
            image2 = FlipAndInvertImage(image2);
            for (int i = 0; i < image2.GetLength(0); i++)
            {
                for (int j = 0; j < image2.GetLength(1); j++)
                {
                    Console.Write(image2[i, j] + " ");
                }
                Console.WriteLine();
            }
            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
            int minMeetingRooms = MinMeetingRooms(intervals);
            Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);

            int[] arr = { -4, -1, 0, 3, 10 };
            int[] sortedSquares = SortedSquares(arr);
            Console.WriteLine("Squares of the array in sorted order is:");
            DisplayArray(sortedSquares);
            Console.Write("\n");

            string s = "abca";
            if (ValidPalindrome(s))
            {
                Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
            }
            else
            {
                Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
            }

            // Keep the console window open in debug mode.      
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                // do Binary Search with a twist ( if the target is not found, return the index of where it could be inserted to keep array sorted)

                // we need to keep track of upper and lower boundary/index as well as mid index
                int lower = 0;
                int upper = nums.Length - 1;
                int mid = 0;

                // while loop as long as upper boundary is greater or equal than lower
                while (upper >= lower)
                {
                    // calculate the current middle index using integer division
                    mid = (upper + lower) / 2;

                    Console.WriteLine("Lower Boundary: " + lower + ". Upper Boundary: " + upper + ". Middle Index: " + mid + ".");

                    // nums[mid] is the value in the middle
                    // Compare it to the target and update upper or lower boundary
                    if (nums[mid] > target)
                    {
                        // if value in the middle is greater than target than we need to search in the lower subarray
                        // reduce the upper boundary to current mid index minus 1
                        upper = mid - 1;
                    }
                    else if (nums[mid] < target)
                    {
                        // in case target is greater than the value in the middle, we need to search in the upper subarray
                        // update lower boundary to current mid plus 1
                        lower = mid + 1;
                    }
                    else
                    {
                        // otherwise, this is the target value and we're done! - return this index
                        return mid;
                    }
                }

                Console.WriteLine("Lower Boundary: " + lower + ". Upper Boundary: " + upper + ". Middle Index: " + mid + ".");

                // if binary search did not find the target value then return the index where the target could be inserted to keep array sorted
                // need to check the value at the last mid index and determine where the target could be inserted
                if ( nums[mid] < target )
                {
                    // if the value at the last mid index is less than target then we could insert after that index
                    return mid + 1;
                }
                else
                {
                    // in case last mid value is greater than the target then insert in its place
                    return mid;
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
                return -1;
            }
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
                // we're going to use Lists (One and Two) to produce intersection of these two arrays
                IList<int> listOne = new List<int>();
                IList<int> listTwo = new List<int>();
                // I'm also using list to store the intersection of the inputs and then will convert to int array and return
                List<int> listIntersection = new List<int>();

                // let's go ahead and populate listOne with integers from nums1, and listTwo from nums2
                for (int i = 0; i < nums1.Length; i++)
                    listOne.Add(nums1[i]);

                for (int i = 0; i < nums2.Length; i++)
                    listTwo.Add(nums2[i]);

                // now we can go through the values in listOne (aka nums1) and check if they appear in listTwo
                foreach (int num in listOne)
                {
                    // check if current value from listOne is in listTwo
                    if ( listTwo.Contains(num) )
                    {
                        // if it is then we got a value that needs to be added to the Intersection List
                        listIntersection.Add(num);
                        // also, need to remove this value from listTwo since it's been used already
                        // (to avoid extra countining in case same value is present in listOne multiple times but is in listTwo fewer times)
                        listTwo.Remove(num);
                    }
                }
                // convert list to array and return
                return listIntersection.ToArray();
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
                // some error occurred - return empty int array
                return new int[0];
            }
        }

        public static int LargestUniqueNumber(int[] A)
        {
            try
            {
                // first of all, convert input array into Dictionary 
                // where key is int value and value will be occurrence count
                // Initialize the Dictionary and then populate it looping through the input array
                Dictionary<int, int> intDictionary = new Dictionary<int, int>();
                foreach ( int num in A)
                {
                    // check if num is already a key
                    if ( intDictionary.ContainsKey(num) )
                    {
                        // if such key exists then just increment the occurrence counter
                        intDictionary[num]++;
                    }
                    else
                    {
                        // if current num is not a key yet, then add it with occurrence counter equal to one
                        intDictionary.Add(num, 1);
                    }
                }

                // now, once the dictionary is built go ahead and check for the largest key that occurs only once
                // initialize largestInt to return, set to -1
                // since this is the value that needs to be returned if no int matching our condition is found
                int largestInt = -1;
                foreach (KeyValuePair<int, int> item in intDictionary)
                {
                    // now if current key is greater than largestInt and its occurrence is one then update largestInt
                    if (item.Key > largestInt && item.Value == 1)
                        largestInt = item.Key;
                }
                // return (it will return -1 if no matches were found in the dictionary
                return largestInt;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
                // some error occurred, return -1
                return -1;
            }
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                // first, we convert the keyboard string to array of chars
                char[] keyboardChars = keyboard.ToCharArray();
                // let's convert keyboard string to the Dictionary where key is Char and Value is Integer
                // we need to initialize and populate this dictionary
                Dictionary<char, int> keyboardDictionary = new Dictionary<char, int>();
                for (int i = 0; i < keyboardChars.Length; i++ )
                    keyboardDictionary.Add(keyboardChars[i], i);
                // now, when we have keyboard as dictionary we can calculate time to type a given word string (initially = 0)
                // key will be used to find any Character and its value will indicate its position on the keyboard
                int typingTime = 0;
                // we also initialize the index where typing starts (start at 0 and then update as each char is typed)
                int index = 0;
                // we need to convert string word to array of chars first
                char[] wordChars = word.ToCharArray();
                // now loop through the characters in the provided word and calculate time
                for (int i = 0; i < wordChars.Length; i++ )
                {
                    // simply increment the typing time by absolute value of difference between previous char index and current char index
                    // note: wordChars[i] returns the character found at i while keyboardDictionary[wordChars[i]] returns its index on the keyboard
                    typingTime += Math.Abs(index - keyboardDictionary[wordChars[i]]);

                    // update the index, it will be used as a previous char index during next loop iteration
                    index = keyboardDictionary[wordChars[i]];
                }
                // return the typing time we calculated
                return typingTime;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
                // some error occurred - return negative one
                return -1;
            }
        }

        public static int[,] FlipAndInvertImage(int[,] A)
        {
            try
            {
                // here, we need to iterate through the 2D array. We will use GetLength() method to get the dimensions of 2D array
                // GetLength(0) returns the number of "rows" while GetLength(1) returns the number of "columns"

                // initialize new image 2D array which will be returned after original is flipped and inverted
                int[,] newImage = new int[A.GetLength(0), A.GetLength(1)];
                
                // first, we need to flip each row
                // outer loop iterates through rows, while inner loop iterates through columns
                for ( int i = 0; i < A.GetLength(0); i++ )
                {
                    // flip here (aka reverse each row)
                    // iterate the original row and populate newImage array (backwards)
                    for (int j = 0; j < A.GetLength(1); j++)
                        newImage[i,A.GetLength(1)-1-j] = A[i, j];
                }

                // now go ahead and reverse the image, 
                // iterate through the flipped image (aka new image)
                for ( int i = 0; i < newImage.GetLength(0); i++ )
                {
                    for ( int j = 0; j < newImage.GetLength(1); j++ )
                    {
                        // reverse simply change 1 to 0 or 0 to 1
                        if (newImage[i, j] == 0)
                            newImage[i, j] = 1;
                        else
                            newImage[i, j] = 0;
                    }
                }
                    
                // return new image 2D array
                return newImage;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
                // some error occured, return the input array
                return A;
            }
        }
        public static int MinMeetingRooms(int[,] interval)
        {

            // for calculating the min rooms required we need to split the start times and end times of every meeting
            // and then we need to sort them so that we can compare the overlapping start times and end times and calculate
            // rooms accordingly.
            List<int> start_time = new List<int>();
            List<int> end_time = new List<int>();
            for (int k = 0; k < interval.GetLength(0); k++)
            {
                start_time.Add(interval[k, 0]);
            }
            for (int k = 0; k < interval.GetLength(0); k++)
            {
                end_time.Add(interval[k, 1]);
            }
            start_time.Sort();
            end_time.Sort();
            int i = 0, j = 0, rooms = 0;

            while (i < interval.GetLength(0))
            {
                // logic here is if the start time of the next meeting is less than that of the end time of the new meeting, 
                // then we increment the count of new rooms by variable i. Through i we keep track of number of meetings occured in new room.
                if (start_time[i] < end_time[j])
                {
                    i++;
                }
                // also we check if the start_time of the current meeting is greater than the end time of the previous old meeting, 
                // then we can use the old meeting room its self for the current meeting. Through j we keep track of number of meetings occured in old rooms( reused meeting rooms)
                else if (start_time[i] > end_time[j])
                {
                    j++;
                }
                // if all the meetings have same start time and end time we need different rooms for every meeting. so only i is incremented 
                // showing that we need new meeting room for all meetings
                else
                {
                    i++;
                    j++;
                }
                // Now we can calculate the difference number of meeting occured in new room(i) and number of meetings occured in old(reused) rooms j.
                // This gives us number of rooms required.
                rooms = Math.Max(rooms, i - j);
            }
            // finally return the minimum number of rooms required.
            return rooms;
        }
        public static int[] SortedSquares(int[] a)
        {
            int p;
            //Getting the count of negative numbers in variable p
            for (p = 0; p < a.Length; p++)
            {
                if (a[p] >= 0)
                {
                    break;
                }
            }


            int i = p - 1; // reading the negative numbers in reverse order starting from p-1
            int j = p; // reading the positive numbers from p
            // initializing a llist to store temporary squares of numbers
            List<int> temp = new List<int>();
            // this while loop will iterate the negative numbers starting from p-1 to 0 and positive numbers starting from p to a.length 
            while (i >= 0 && j < a.Length)
            {
                // if square of first negative number at p-1 is < square of first positive number at p then square of first positive number
                // should be the first element of temporary list. Then we will go to next negative element by decreasing the i value to i--.
                // then in the next iteration the square of second negative value at p-2 is compared to square of first positive number.
                // if the square of second negative values is greater than square of first positive number then it will go to else condition and then 
                // adds the first positive number to the temporary list. Then it increments the positive value to p+1. i.e j++.
                // This cycle continues until i becomes less than zero or j becomes greater than or equal to the length of the list.
                // once either of the above condition meets the loop will break.
                if (a[i] * a[i] < a[j] * a[j])
                {
                    temp.Add(a[i] * a[i]);
                    i--;

                }
                else
                {
                    temp.Add(a[j] * a[j]);
                    j++;

                }


            }
            // after the above loop breaks this while loop will add the remaining squares of negative numbers to the list
            while (i >= 0)
            {
                temp.Add(a[i] * a[i]);
                i--;
            }
            // after the above loop breaks this while loop will add the remaining squares of positive numbers to the list
            while (j < a.Length)
            {
                temp.Add(a[j] * a[j]);
                j++;
            }
            // now we will replace every element of initial array with the element from temporary list which has squares of numbers
            for (int m = 0; m < temp.Count; m++)
            {
                a[m] = temp[m];
            }
            // finally we will return the array which has squares of numbers in sorted order.
            return a;
        }
        public static void DisplayArray(int[] i)
        {
            for(int j=0;j<i.Length; j++)
            {
                Console.WriteLine(i[j]);
            }
        }
        public static bool ValidPalindrome(string s)
        {

            int i = 0;
            // Loop through the entire string length
            while (i < s.Length)
            {
                // first convert the string to char list
                List<char> p = new List<char>(s);
                // then we will remove the every char at each elemnt of string by iterating through loop
                p.RemoveAt(i);
                // once the char is removed convert the previous char list to new char list
                List<char> temp_char = new List<char>(p);
                // now convert the char list with removed char to string
                string temp = string.Join("", temp_char.ToArray());
                // reverse the char list
                temp_char.Reverse();
                // then convert the reversed char list to string
                string temp_rev = string.Join("", temp_char.ToArray());
                // if reversed string is equal to unreversed string then palindrome is valid hence return true
                if (temp_rev == temp)
                {
                    return true;


                }
                // remove each character and check for paliindrome until its found by looping through the end of the string.
                i++;

            }
            return false;
        }
    }
}
