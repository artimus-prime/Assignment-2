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

                Console.WriteLine("Intersection List:");
                foreach (int num in listIntersection)
                    Console.Write(num + " ");
                Console.WriteLine();

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

                return largestInt;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
                // some error occurred - return empty int array
                return -1;
            }
        }
    }
}
