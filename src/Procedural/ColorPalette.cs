public class ColorPalette
{

    public Color[] colors;

    public ColorPalette()
    {

        colors = new Color[0];

    }

    public ColorPalette(PaletteGenerateOption option)
    {

        this(option, 5);

    }

    public ColorPalette(PaletteGenerateOption option, int n)
    {

        switch (option)
        {

            case PaletteGenerateOption.Values:
                colors = generateColorValues(5);
                return;

        }

    }

    public static Color[] generateColorValues(int n)
    {

        Color[] newColors = new Color[n];
        float hue = Random.Range(0.0f, 1.0f);

        for (int i = 0; i < n; i++)
        {

            newColors[i] = Color.HSVToRGB(hue, 1, i / (float)n);

        }

        return newColors;

    }

}

public enum PaletteGenerateOption
{
    Values
}