using System;

public class Note
{

    public string value = "E4";

    /// <summary>
    /// Gets the name of the current note.
    /// </summary>
    /// <returns>A string-type containing the name of the note.</returns>
    public string GetNoteName()
    {

        return GetNoteName(value);

    }

    /// <summary>
    /// Gets the full note value.
    /// </summary>
    /// <returns>An integer-type containing the current note's value.</returns>
    public int GetFullNote()
    {

        return GetFullNote(value);

    }

    /// <summary>
    /// Gets the octave value of the note.
    /// </summary>
    /// <returns>An integer-type containing the current note's octave.</returns>
    public int GetOctave()
    {

        return GetOctave(value);

    }

    /// <summary>
    /// Gets the frequency of the note.
    /// </summary>
    /// <returns>A float-type containing the current note's frequency.</returns>
    public float GetFrequency()
    {

        return GetFrequency(value);

    }

    /// <summary>
    /// Gets the current note's value in the octave.
    /// </summary>
    /// <returns>An integer-type containing the current note's value in the octave.</returns>
    public float GetNote()
    {

        return GetNote(value);

    }

    /// <summary>
    /// Constructs a default note.
    /// </summary>
    public Note()
    {

        value = "C4";

    }

    /// <summary>
    /// Constructs a note with a input value.
    /// </summary>
    /// <param name="_value">The value notation of the note.</param>
    public Note(string _value)
    {

        value = _value;

    }

    /// <summary>
    /// Frequency of A4 used to tune all the other notes.
    /// </summary>
    public static float tuneFrequency = 440.00f;

    /// <summary>
    /// Gets the name of the inputted note.
    /// </summary>
    /// <param name="input">The value notation of the note.</param>
    /// <returns>A string-type containing the name of the note.</returns>
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

    /// <summary>
    /// Gets the value of the inputted note in the octave.
    /// </summary>
    /// <param name="input">The value notation of the note.</param>
    /// <returns>An integer-type containing the current note's value in the octave.</returns>
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

    /// <summary>
    /// Gets the octave of the inputted note.
    /// </summary>
    /// <param name="input">The value notation of the note.</param>
    /// <returns>An integer-type containing the current note's octave.</returns>
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

    /// <summary>
    /// Gets the full value of the inputted note.
    /// </summary>
    /// <param name="input">The value notation of the note.</param>
    /// <returns>An integer-type containing the current note's value.</returns>
    public static int GetFullNote(string input)
    {

        // Just Use Existing Functions
        return (GetOctave(input) * 12) + GetNote(input);

    }

    /// <summary>
    /// Gets the frequency of the inputted note.
    /// </summary>
    /// <param name="input">The value notation of the note.</param>
    /// <returns>A float-type containing the current note's frequency.</returns>
    public static float GetFrequency(string input)
    {

        // Get Value of A4 vs Current Note
        int inputValue = GetFullNote(input);
        int distance = inputValue - 57; // 57 = A4

        // Return the Frequency
        return tuneFrequency * (float)Math.Pow(2, distance / 12.0);

    }

}