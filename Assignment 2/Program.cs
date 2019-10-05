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
    }
}
