using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

class CFGObject
{

    /// <summary>
    /// Generic constructor for any CFGObject. Creates a new object from location on disk.
    /// </summary>
    /// <param name="path">The path to the stored CFGObject.</param>
    public CFGObject(string path)
    {

        foreach (string line in File.ReadLines(path))
        {

            string lineKey = "";
            string lineValue = "";
            int state = 0;

            for (int i = 0; i < line.Length; i++)
            {

                switch (state)
                {

                    case 0:

                        if (line[i] == '=')
                        {

                            state = 1;
                            break;

                        }

                        lineKey += line[i];

                        break;

                    case 1:

                        lineValue += line[i];

                        break;

                }

            }

            string cleanedKey = lineKey.Trim();
            string cleanedValue = lineValue.Trim();

            FieldInfo info = this.GetType().GetField(cleanedKey);

            if (info == null) break;

            switch (info.FieldType.Name)
            {

                case "String":

                    info.SetValue(this, cleanedValue);

                    break;

                case "Int32":

                    int numValue;
                    Int32.TryParse(cleanedValue, out numValue);
                    info.SetValue(this, numValue);

                    break;

                case "Boolean":

                    if (cleanedValue.ToUpper() == "YES") info.SetValue(this, true);
                    if (cleanedValue.ToUpper() == "NO") info.SetValue(this, false);

                    break;

                default:

                    break;

            }

        }

    }

    /// <summary>
    /// Gets a list of keys from the object. 
    /// </summary>
    /// <returns>The list of keys stored from the object.</returns>
    public List<string> GetKeys()
    {

        Dictionary<string, object> keyValues = GetParameters();
        List<string> keys = new List<string>();

        foreach (KeyValuePair<string, object> pair in keyValues)
        {

            keys.Add(pair.Key);

        }

        return keys;

    }

    /// <summary>
    /// A list of values from the object.
    /// </summary>
    /// <returns>The list of values stored from the object.</returns>
    public List<object> GetValues()
    {

        Dictionary<string, object> keyValues = GetParameters();
        List<object> values = new List<object>();

        foreach (KeyValuePair<string, object> pair in keyValues)
        {

            values.Add(pair.Value);

        }

        return values;

    }

    /// <summary>
    /// Saves the Object as a Config File at a given path.
    /// </summary>
    /// <param name="path">The location to save the object.</param>
    public void Save(string path)
    {

        File.WriteAllText(path, Print());

    }

    /// <summary>
    /// Print the object in the config format.
    /// </summary>
    /// <returns>The printed object in config format.</returns>
    public string Print()
    {

        Dictionary<string, object> keyValues = GetParameters();
        StringBuilder output = new StringBuilder();

        foreach (KeyValuePair<string, object> pair in keyValues)
        {

            output.Append(pair.Key);
            output.Append(" = ");
            // output.Append(pair.Value.GetType().Name);

            switch (pair.Value.GetType().Name)
            {

                case "String":

                    output.Append(pair.Value);

                    break;
                case "Int32":

                    output.Append(pair.Value);

                    break;
                case "Boolean":

                    output.Append(((bool)pair.Value) ? "Yes" : "No");

                    break;
                default:

                    output.Append(pair.Value.ToString());

                    break;

            }

            output.Append('\n');

        }

        return output.ToString();

    }

    /// <summary>
    /// Gets the parameters along with their values from the object.
    /// </summary>
    /// <returns>A key-value pair of the object's parameters.</returns>
    public Dictionary<string, object> GetParameters()
    {

        Dictionary<string, object> output = new Dictionary<string, object>();

        Type currentType = this.GetType();
        FieldInfo[] fields = currentType.GetFields();

        foreach (FieldInfo prop in fields)
        {

            object propValue = prop.GetValue(this);

            output.Add(prop.Name, propValue);

        }

        return output;

    }

    /// <summary>
    /// Similar to GetParameters, but instead of getting values, gets types instead. 
    /// </summary>
    /// <returns>A key-type pair of the object's parameters. </returns>
    public Dictionary<string, Type> GetParameterTypes()
    {

        Dictionary<string, Type> output = new Dictionary<string, Type>();

        Type currentType = this.GetType();
        FieldInfo[] fields = currentType.GetFields();

        foreach (FieldInfo prop in fields)
        {

            output.Add(prop.Name, prop.FieldType);

        }

        return output;

    }

}
