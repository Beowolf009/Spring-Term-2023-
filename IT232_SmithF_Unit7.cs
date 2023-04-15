using System;
using System.IO;
using System.Runtime.CompilerServices;

internal class Program
{
    static string logFileName = "logFile.txt";

    private static void Main(string[] args)
    {
        Console.WriteLine("Assignment 7 - Logging Exceptions to a file.");
        Console.WriteLine("Testing Try/Catch for Divide by Zero, File Does Not Exist, Array Out of Bounds, and Array is Null scenarios.");
        Console.WriteLine("All console error messages are printed from error log file\n");

        
        /* Create a logfile. Redirect the stdErr stream to write to your logfile.*/
        /* STreamWriter is a subclass of TextWriter and can be stored as a variable type, I needed to research this*/
        TextWriter textWriter = new StreamWriter(logFileName);
        Console.SetError(textWriter);

        try
        {
            DivideByZero(9, 0);
        }
        catch (Exception ex)
        {
            string err = ex.Message.ToString();
            Console.Error.WriteLine($"1: {err}");
        }
        
        try
        {
            FileDoesNotExist();
        }
        catch (Exception ex)
        {
            string err = ex.Message.ToString();
            Console.Error.WriteLine($"2: {err}");
        }
       
        try
        {
            ArrayOutOfBounds();
        }
        catch (Exception ex)
        {
            string err = ex.Message.ToString();
            Console.Error.WriteLine($"3: {err}");
        }
     
        try
        {
            ArrayIsNull();
        }
        catch(Exception ex)
        {
            string err = ex.Message.ToString();
            Console.Error.WriteLine($"4: {err}");
        }
        textWriter.Close();
        DisplayLogFile(logFileName);
    }
    
    /* Create a function named ArrayIsNull(), which will create an array and then set it equal to null before trying to access an item in the array.*/
    public static void ArrayIsNull()
    {
        int[] badlyNamedArray = null;
       Console.WriteLine($"The index of array is at {badlyNamedArray[3]}");
    }



    /*Create a function named, DivideByZero(), which will attempt to divide a number by 0. */
    public static int DivideByZero(int dividend, int divisor)
        {
                    return dividend / divisor;
        }

    /*Create a function named, FileDoesNotExist(), which will attempt to open a non-existent file named, “NoFileNamedThis.txt”. */
    public static void FileDoesNotExist()
    {
        string filePath = @"NoFileNamedThis.txt";
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The file {filePath} does not exist.");
        }
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }


    /*Create a function named, ArrayOutOfBounds(), which will create an array and then try to access a non-existent index in that an array */

    public static void ArrayOutOfBounds()
        {
            int[] genericArrayName = new int[1];                    //had to step away for a bit, because I keep doing int[] ArrayName = new Array[] nad inintializing it incorrectly
            Console.WriteLine($"Index of array is at {genericArrayName[3]}");


    }
    /* Create a function, DisplayLogfile(), that will read the logfile and display to the console.*/
/****************************
 *************************************
 I had to borrow your code, as I was having trouble getting my original idea to work, sorry.
 *********************************************/
    public static void DisplayLogFile(string logFileName)
        {
        Console.Error.Close();
        string path = (logFileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) 
            using (StreamReader streamReader = new StreamReader(fileStream))
      {
            Console.WriteLine($"Reading log file: {logFileName}");
            while (streamReader.EndOfStream == false)
            {
                Console.WriteLine(streamReader.ReadLine());
            }
      }
        Console.WriteLine("Log file reading complete.");
    }
  




}


