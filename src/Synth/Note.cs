using System;

public class Note
{

    #region Local

    public string value = "E4";

    public string GetNoteName()
    {

        return GetNoteName(value);

    }

    public int GetFullNote()
    {

        return GetFullNote(value);

    }

    public int GetOctave()
    {

        return GetOctave(value);

    }

    public float GetFrequency()
    {

        return GetFrequency(value);

    }

    public float GetNote()
    {

        return GetNote(value);

    }

    #endregion

    #region Constructors

    public Note()
    {

        value = "C4";

    }

    public Note(string _value)
    {

        value = _value;

    }

    #endregion

    #region Static 

    public static float tuneFrequency = 440.00f; // Frequency of A4

    public static string GetNoteName(string input)
    {

        // Make Sure Note Exists
        if (input.Length < 2) return "";
        if (input.Length > 3) return "";

        // Disect String
        char noteChar = input[0];
        string accent = "";

        // Check if Accent Exists
        if (input.Length == 3)
        {

            // Get the Accent
            char accentChar = input[1];

            // Add the Accent
            if (accentChar == '#') accent = "-Sharp";
            if (accentChar == '-') accent = "-Flat";

        }

        // Return the Note Value
        return noteChar + accent;

    }

    public static int GetNote(string input)
    {

        // Make Sure Note Exists
        if (input.Length < 2) return -1;
        if (input.Length > 3) return -1;

        // Disect the String
        char noteChar = input[0];

        // Find the Note Value. { A: 9, B: 11, C: 0, D: 2, E: 4, F: 5, G: 7}
        int[] finalNotes = new int[] { 9, 11, 0, 2, 4, 5, 7 };
        int finalNoteValue = finalNotes[noteChar - 65];

        // Check if note has Accent
        if (input.Length == 3)
        {

            // Disect the String
            char accentChar = input[1];

            // If it has an accent, apply accent
            if (accentChar == '#') finalNoteValue++;
            if (accentChar == '-') finalNoteValue--;

        }

        // Return the Final Value
        return finalNoteValue;

    }

    public static int GetOctave(string input)
    {

        // Make Sure Note Exists
        if (input.Length < 2) return -1;
        if (input.Length > 3) return -1;

        // Disect the String
        char lastValue = input[input.Length - 1];
        int octave = (int)(lastValue - 48);

        // Return the Octave
        return octave;

    }

    public static int GetFullNote(string input)
    {

        // Just Use Existing Functions
        return (GetOctave(input) * 12) + GetNote(input);

    }

    public static float GetFrequency(string input)
    {

        // Get Value of A4 vs Current Note
        int inputValue = GetFullNote(input);
        int distance = inputValue - 57; // 48 = A4

        // Return the Frequency
        return tuneFrequency * (float)Math.Pow(2, distance / 12.0);

    }

    private static int[] GetFactors(int num)
    {

        // TODO: OPTIMIZE
        if (num <= 0) return new int[0];
        if (num == 1) return new int[1] { 1 };
        if (num == 2) return new int[2] { 0, 1 };

        int[] output = new int[num];
        int remaining = num;
        int divisor = 2;

        while (remaining > 1)
        {
            if (remaining % divisor == 0)
            {

                remaining /= divisor;
                output[divisor]++;

            }
            else
            {

                divisor++;

            }
        }

        return output;

    }

    public static int GetConsonance(Note a, Note b)
    {

        // First Rule
        if (a.GetNote() == b.GetNote()) return Math.Abs(a.GetOctave() - b.GetOctave()) + 1;



        // General Rule
        int[] factors = GetFactors(a.GetFullNote());
        int outputSum = 0;

        for (int i = 2; i < factors.Length; i++)
        {

            outputSum += (i - 1) * factors[i];

        }

        return outputSum;

    }

    #endregion

}