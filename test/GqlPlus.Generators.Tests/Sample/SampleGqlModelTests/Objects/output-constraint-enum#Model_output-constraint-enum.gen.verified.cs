//HintName: Model_output-constraint-enum.gen.cs
// Generated from output-constraint-enum.graphql+

/*
*/

namespace GqlTest.Model_output_constraint_enum;

public interface IOutpCnstEnum
{
  RefOutpCnstEnum<outpCnstEnum> AsRefOutpCnstEnum { get; }
}
public class OutputOutpCnstEnum
  : IOutpCnstEnum
{
  public RefOutpCnstEnum<outpCnstEnum> AsRefOutpCnstEnum { get; set; }
}

public interface IRefOutpCnstEnum<Ttype>
{
  Ttype field { get; }
}
public class OutputRefOutpCnstEnum<Ttype>
  : IRefOutpCnstEnum<Ttype>
{
  public Ttype field { get; set; }
}

public enum EnumOutpCnstEnum
{
  outpCnstEnum,
}
