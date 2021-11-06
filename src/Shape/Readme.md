# Shape Generation

## Rectangular Prism

The rectangular prism generator provides an API for many utility functions around rectangular prisms. The flagship feature of this class is by-far the ability to generate a rectangular prism mesh given a width, height, and depth. There is also a feature inside of the rectangular prism generator that allows for the calculation of volume inside the prism given the dimensions.

### Example

```c#

// Generates a 2x1x4 Rectangular Prism and Gets Volume
RectangularPrism.Generate(2, 1, 4);
RectangularPrism.Volume(2, 1, 4);

// Generates a 2x2x2 Cube and Gets Volume
RectangularPrism.Generate(2);
RectangularPrism.Volume(2);

```

## Square

The square generator provides an API for many utility functions around squares. The flagship feature of this class is by-far the ability to generate a square mesh given a width and height. There is also a feature inside of the square generator that allows for the calculation of area inside the prism given the dimensions.

```c#

// Generates a 2x1 Square and Gets Area
Square.Generate(2, 1);
Square.Area(2, 1);

// Generates a 4x4 Square and Gets Area
Square.Generate(4);
Square.Area(4);

```
