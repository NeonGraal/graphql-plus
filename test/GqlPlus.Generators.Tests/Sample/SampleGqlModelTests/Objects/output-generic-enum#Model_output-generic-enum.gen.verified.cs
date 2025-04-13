//HintName: Model_output-generic-enum.gen.cs
// Generated from output-generic-enum.graphql+

/*
*/

namespace GqlTest.Model_output_generic_enum;

public interface IOutpGnrcEnum
{
  RefOutpGnrcEnum < I@041/0001 EnumOutpGnrcEnum.outpGnrcEnum > AsRefOutpGnrcEnum { get; }
}
public class OutputOutpGnrcEnum
{
  public RefOutpGnrcEnum < I@041/0001 EnumOutpGnrcEnum.outpGnrcEnum > AsRefOutpGnrcEnum { get; set; }
}

public interface IRefOutpGnrcEnum
{
  $type field { get; }
}
public class OutputRefOutpGnrcEnum
{
  public $type field { get; set; }
}

public enum EnumOutpGnrcEnum
{
  outpGnrcEnum,
}
