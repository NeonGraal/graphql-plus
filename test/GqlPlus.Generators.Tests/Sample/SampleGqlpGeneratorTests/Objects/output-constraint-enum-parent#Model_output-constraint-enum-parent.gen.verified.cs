//HintName: Model_output-constraint-enum-parent.gen.cs
// Generated from output-constraint-enum-parent.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_output_constraint_enum_parent;

public interface IOutpCnstEnumPrnt
{
  RefOutpCnstEnumPrnt<outpCnstEnumPrnt> AsRefOutpCnstEnumPrnt { get; }
}
public class OutputOutpCnstEnumPrnt
  : IOutpCnstEnumPrnt
{
  public RefOutpCnstEnumPrnt<outpCnstEnumPrnt> AsRefOutpCnstEnumPrnt { get; set; }
}

public interface IRefOutpCnstEnumPrnt<Ttype>
{
  Ttype field { get; }
}
public class OutputRefOutpCnstEnumPrnt<Ttype>
  : IRefOutpCnstEnumPrnt<Ttype>
{
  public Ttype field { get; set; }
}

public enum EnumOutpCnstEnumPrnt
{
  parentOutpCnstEnumPrnt = ParentOutpCnstEnumPrnt.parentOutpCnstEnumPrnt,
  outpCnstEnumPrnt,
}

public enum ParentOutpCnstEnumPrnt
{
  parentOutpCnstEnumPrnt,
}
