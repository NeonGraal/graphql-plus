//HintName: Model_output-generic-enum.gen.cs
// Generated from output-generic-enum.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_output_generic_enum;

public interface IOutpGnrcEnum
{
  RefOutpGnrcEnum<EnumOutpGnrcEnum> AsRefOutpGnrcEnum { get; }
}
public class OutputOutpGnrcEnum
  : IOutpGnrcEnum
{
  public RefOutpGnrcEnum<EnumOutpGnrcEnum> AsRefOutpGnrcEnum { get; set; }
}

public interface IRefOutpGnrcEnum<Ttype>
{
  Ttype field { get; }
}
public class OutputRefOutpGnrcEnum<Ttype>
  : IRefOutpGnrcEnum<Ttype>
{
  public Ttype field { get; set; }
}

public enum EnumOutpGnrcEnum
{
  outpGnrcEnum,
}
