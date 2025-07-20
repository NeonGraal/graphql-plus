namespace GqlPlus;

[Flags]
public enum GqlpGeneratorType
{
  None = 0,

  Static = 1 << 0,
  Interface = 1 << 1,
  Enum = 1 << 2,
  Implementation = 1 << 3,
  Test = 1 << 4,

  All = Static | Implementation | Enum | Interface | Test
}
